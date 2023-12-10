using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class RequiredSkillConfiguration : IEntityTypeConfiguration<RequiredSkill>
    {
        public void Configure(EntityTypeBuilder<RequiredSkill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.MonthsOfExperience)
                .IsRequired(false);

            builder.Property(t => t.FinishedProjectCount)
                .IsRequired(false);

            builder.HasOne(x => x.Skill);
        }
    }
}
