using FreelanceFinder.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace FreelanceFinder.Application.Common.Models
{
    public class RequiredSkillDTO
    {
        [Required]
        public int SkillId { get; set; }
        public int? MonthsOfExperience { get; set; }
        public int? FinishedProjectCount { get; set; }
        [Required]
        public int ProjectAdvertisementId { get; set; }
    }
}
