using Microsoft.EntityFrameworkCore;
using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class SkillAreaConfiguration : IEntityTypeConfiguration<SkillArea>
    {
        public void Configure(EntityTypeBuilder<SkillArea> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
               .HasMaxLength(100)
               .IsRequired();

            builder.HasMany(x => x.Skills);
        }
    }
}
