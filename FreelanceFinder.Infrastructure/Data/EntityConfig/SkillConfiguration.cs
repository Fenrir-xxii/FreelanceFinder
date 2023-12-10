using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title)
               .HasMaxLength(100)
               .IsRequired();

            builder.HasOne(x => x.SkillArea);
            
        }
    }
}
