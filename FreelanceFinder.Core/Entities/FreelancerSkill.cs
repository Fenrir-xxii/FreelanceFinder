namespace FreelanceFinder.Core.Entities
{
    public class FreelancerSkill : BaseEntity
    {
        //Foreign key for Skill
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public DateTime ExperienceInitDate { get; set; }
        public int FinishedProjectCount { get; set; }
        //Foreign key for Freelancer
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int getExpirienceInMonths()
        {
            // TO DO
            return 0;
        }
    }
}
