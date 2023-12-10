namespace FreelanceFinder.Core.Entities
{
    public class Employer : BaseEntity
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int ProjectOffersCount { get; set; }
        public int FinishedProjectsCount { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
