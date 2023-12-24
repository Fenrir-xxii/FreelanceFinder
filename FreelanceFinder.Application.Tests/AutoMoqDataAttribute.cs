
using AutoFixture.AutoMoq;
using AutoFixture;
using AutoFixture.Xunit2;
using FreelanceFinder.Core.Entities;
using Moq;
using FreelanceFinder.Application.Common;
using System.Reflection.Metadata.Ecma335;

namespace FreelanceFinder.Application.Tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
        : base(() => new Fixture().Customize(new OmitOnRecursionCustomization())) { }
    }
    public class OmitOnRecursionCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize(new AutoMoqCustomization());

            fixture.Customize<ProjectAdvertisement>(transform => transform
            .With(s => s.RequiredSkills, new List<RequiredSkill> { new RequiredSkill {
            Skill = new Skill()} })
            .With(s => s.Freelancer, new Freelancer()));

            //fixture.Customize<Mock<IEntityService<ProjectAdvertisement>>>(transform => transform
            //.With(s => s.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(projectAdvertisement)));
            //service.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(projectAdvertisement);

            //var projectAdvertisementsFixture = fixture.CreateMany<ProjectAdvertisement>(3).ToList();

            //fixture.Customize<Mock<IEntityService<ProjectAdvertisement>>>(transform => transform
            //.With(s => s.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture)));

        }
    }
}