namespace FreelanceFinder.Core.Entities
{
    public class RequiredSkill : BaseEntity
    {
        //Foreign key for Skill
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int? MonthsOfExperience { get; set; }
        public int? FinishedProjectCount { get; set; }
    }
}
