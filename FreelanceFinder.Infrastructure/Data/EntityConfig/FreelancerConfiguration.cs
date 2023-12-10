using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.ApprovedProjectsCount)
                .HasDefaultValue(0);

            builder.Property(x => x.FinishedProjectsCount)
                .HasDefaultValue(0);

            builder.Property(x => x.Rating)
                .HasMaxLength(100);

            builder.Property(t => t.RegistrationDate)
               .HasColumnType("date")
               .IsRequired();

            builder.HasMany(x => x.Skills);
        }
    }
}
