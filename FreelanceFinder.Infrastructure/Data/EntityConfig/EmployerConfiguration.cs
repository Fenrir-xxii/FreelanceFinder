using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelanceFinder.Infrastructure.Data.EntityConfig
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Rating)
               .HasMaxLength(100);

            builder.Property(x => x.ProjectOffersCount)
               .HasDefaultValue(0);

            builder.Property(x => x.FinishedProjectsCount)
               .HasDefaultValue(0);

            builder.Property(t => t.RegistrationDate)
               .HasColumnType("date")
               .IsRequired();
        }
    }
}
