namespace FreelanceFinder.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Title { get; set; }
        //Foreign key for SkillArea
        public int SkillAreaId { get; set; }
        public SkillArea SkillArea { get; set; }
    }
}
