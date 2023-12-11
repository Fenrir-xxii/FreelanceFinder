namespace FreelanceFinder.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Title { get; set; }
        public int SkillAreaId { get; set; }
        public SkillArea SkillArea { get; set; }
    }
}
