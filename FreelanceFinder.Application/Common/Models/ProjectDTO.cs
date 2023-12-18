using FreelanceFinder.Core.Entities;

namespace FreelanceFinder.Application.Common.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public int ProjectAdvertiseId { get; set; }
        public ProjectAdvertisement ProjectAdvertise { get; set; }
        public ICollection<Freelancer> Freelancers { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
