using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class ProjectAdvertisementConfiguration : IEntityTypeConfiguration<ProjectAdvertisement>
    {
        public void Configure(EntityTypeBuilder<ProjectAdvertisement> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.ExpiredAt)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("money");

            builder.Property(x => x.Description)
              .HasMaxLength(5000)
              .IsRequired();

            builder.Property(x => x.WorkplaceCount)
               .HasDefaultValue(1);

            builder.HasOne(x => x.Employer);

            builder.HasMany(x => x.RequiredSkills);

            builder.Property(x => x.FreelancerId)
              .IsRequired(false);

            builder.HasOne(x => x.Freelancer);
        }
    }
}
