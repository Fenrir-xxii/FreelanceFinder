using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<FreelancerSkill> Skills { get; set; }
        [NotMapped]
        public double PercentageOfCompletedProjects
        {
            get
            {
                // TO DO
                return 0.00;
            }
        }
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }
}
