namespace FreelanceFinder.Application.Common.Models
{
    public class EmployerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public int ProjectOffersCount { get; set; }
        public int FinishedProjectsCount { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
