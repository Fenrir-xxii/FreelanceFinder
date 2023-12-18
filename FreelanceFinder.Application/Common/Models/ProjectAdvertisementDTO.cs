using FreelanceFinder.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace FreelanceFinder.Application.Common.Models
{
    public class ProjectAdvertisementDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpiredAt { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<RequiredSkill> RequiredSkills { get; set; }
        [Required]
        public int WorkplaceCount { get; set; }
        public Freelancer? Freelancer { get; set; } = null;
        public int? FreelancerId { get; set; }
    }
}
