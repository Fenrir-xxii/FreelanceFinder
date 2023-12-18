using System.ComponentModel.DataAnnotations;

namespace FreelanceFinder.Application.Common.Models
{
    public class ProjectAdvertisementEditDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EmployerId { get; set; }
        [Required]
        public DateTime ExpiredAt { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int WorkplaceCount { get; set; }
        public int? FreelancerId { get; set; }
    }
}
