namespace FreelanceFinder.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Freelancers = new HashSet<Freelancer>();
        }
        public int ProjectAdvertiseId { get; set; }
        public ProjectAdvertisement ProjectAdvertise { get; set; }
        public ICollection<Freelancer> Freelancers { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
