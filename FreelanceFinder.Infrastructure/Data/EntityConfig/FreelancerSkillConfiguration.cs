using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class FreelancerSkillConfiguration : IEntityTypeConfiguration<FreelancerSkill>
    {
        public void Configure(EntityTypeBuilder<FreelancerSkill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.ExperienceInitDate)
               .HasColumnType("date")
               .IsRequired();

            builder.HasOne(x => x.Skill);
            builder.HasOne(x => x.Freelancer);
        }
    }
}
