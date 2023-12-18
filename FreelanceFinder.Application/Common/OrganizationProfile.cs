using AutoMapper;
using FreelanceFinder.Application.Common.Models;
using FreelanceFinder.Core.Entities;

namespace FreelanceFinder.Application.Common
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Employer, EmployerDTO>().ReverseMap();
            CreateMap<Freelancer, FreelancerDTO>().ReverseMap();
            CreateMap<ProjectAdvertisement, ProjectAdvertisementDTO>().ReverseMap();
            CreateMap<ProjectAdvertisementCreateDTO, ProjectAdvertisement>();
            CreateMap<ProjectAdvertisement, ProjectAdvertisementEditDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<RequiredSkill, RequiredSkillDTO>().ReverseMap();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
