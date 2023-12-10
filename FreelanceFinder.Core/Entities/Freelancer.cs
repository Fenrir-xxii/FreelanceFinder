using System.Collections;

namespace FreelanceFinder.Core.Entities
{
    public class Freelancer : BaseEntity
    {
        public Freelancer()
        {
            Skills = new HashSet<FreelancerSkill>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ApprovedProjectsCount { get; set; }
        public int FinishedProjectsCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<FreelancerSkill> Skills { get; set; }

        public double getPercentageOfCompletedProjects()
        {
            // To Do
            return 0.00;
        }
    }
}
