using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceFinder.Core.Entities
{
    public class FreelancerSkill : BaseEntity
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public DateTime ExperienceInitDate { get; set; }
        public int FinishedProjectCount { get; set; }
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        //[NotMapped]
        //public int ExpirienceInMonths
        //{
        //    get
        //    {
        //        // TO DO
        //        return 0;
        //    }
        //    set
        //    {
        //        ExpirienceInMonths = value;
        //    }

        //}
    }
}
