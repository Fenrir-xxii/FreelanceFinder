using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ProjectAdvertise);

            builder.HasMany(x => x.Freelancers);

            builder.HasOne(x => x.Status);
        }
    }
}
