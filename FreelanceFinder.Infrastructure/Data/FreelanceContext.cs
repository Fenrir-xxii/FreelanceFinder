using FreelanceFinder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FreelanceFinder.Infrastructure.Data
{
    public class FreelanceContext : DbContext
    {
        public FreelanceContext() : base() { }
        public FreelanceContext(DbContextOptions<FreelanceContext> options) : base(options) { }

        public DbSet<SkillArea> SkillAreas { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<FreelancerSkill> FreelancerSkills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAdvertisement> ProjectAdvertisements { get; set; }
        public DbSet<RequiredSkill> RequiredSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Currency> Currencies { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        const string connectionString = "Data Source=FENRIR-PC\\SQLEXPRESS;Initial Catalog=FreelanceFinder;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
