namespace FreelanceFinder.Core.Entities
{
    public class RequiredSkill : BaseEntity
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int? MonthsOfExperience { get; set; }
        public int? FinishedProjectCount { get; set; }
        public int ProjectAdvertisementId { get; set; }
        public ProjectAdvertisement ProjectAdvertisement { get; set; }
    }
}
