namespace FreelanceFinder.Core.Entities
{
    public class SkillArea : BaseEntity
    {
        public SkillArea()
        {
            Skills = new HashSet<Skill>();
        }
        public string Title { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
