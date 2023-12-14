namespace FreelanceFinder.Core.Entities
{
    public class ProjectAdvertisement : BaseEntity
    {
        public ProjectAdvertisement()
        {
            RequiredSkills = new HashSet<RequiredSkill>();
        }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public string Description { get; set; }
        public ICollection<RequiredSkill> RequiredSkills { get; set; }
        public int WorkplaceCount { get; set; }
        public int? FreelancerId { get; set; }
        public Freelancer? Freelancer { get; set; }

    }
}
