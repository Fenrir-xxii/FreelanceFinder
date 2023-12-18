using FreelanceFinder.Core.Entities;

namespace FreelanceFinder.Application.Common.Models
{
    public class FreelancerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ApprovedProjectsCount { get; set; }
        public int FinishedProjectsCount { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public int Rating { get; set; }
        public ICollection<FreelancerSkill> Skills { get; set; }
    }
}
