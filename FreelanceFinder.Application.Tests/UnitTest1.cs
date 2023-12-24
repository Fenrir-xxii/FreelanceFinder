using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FreelanceFinder.Application.Common;
using FreelanceFinder.Application.Services;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Infrastructure.Data;
using Moq;
using System.Data;

namespace FreelanceFinder.Application.Tests
{
    public class UnitTest1
    {
        //private readonly Mock<IEntityService<ProjectAdvertisement>> _projectAdvertiseService;
        //[Fact]
        //public void Test1()
        //{
        //    // Arrange

        //    var projectAdvertisements = new List<ProjectAdvertisement> {
        //        new ProjectAdvertisement
        //    {
        //        Id = 1,
        //        Price = 100,
        //        Title = "Test",
        //        Description = "Test D",
        //    },
        //        new ProjectAdvertisement
        //    {
        //        Id = 2,
        //        Price = 560,
        //        Title = "Nope",
        //        Description = "Test EED",
        //    },
        //        new ProjectAdvertisement
        //    {
        //        Id = 3,
        //        Price = 22,
        //        Title = "Yuppi",
        //        Description = "Test GHGD",
        //    }

        //};
        //    var service = new Mock<IEntityService<ProjectAdvertisement>>();
        //    service.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisements);
        //    service.Setup(service => service.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => projectAdvertisements.Where(x => x.Id == id).Single());
        //    // Act

        //    // Assert
        //    Assert.Equal(3, service.Object.GetAllAsync().Result.Count);
        //    Assert.Equal("Test", service.Object.GetByIdAsync(1).Result.Title);

        //}
        //[Theory]
        //[AutoData]
        //public async void CreateProjectAdvertisement() //[Frozen] ProjectAdvertisement projectAdvertisement, [Frozen] Mock<IEntityService<ProjectAdvertisement>> projectAdvertiseService)
        //{
        //    // Arrange
        //    var fixture = new Fixture();

        //    fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
        //    fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        //    fixture.Customize(new AutoMoqCustomization());

        //    fixture.Customize<ProjectAdvertisement>(transform => transform
        //    .With(s => s.RequiredSkills, new List<RequiredSkill> { new RequiredSkill {
        //    Skill = new Skill()} })
        //    .With(s => s.Freelancer, new Freelancer()));

        //    var projectAdvertisementsFixture = fixture.CreateMany<ProjectAdvertisement>(3).ToList();

        //    //fixture.Customize<Mock<IEntityService<ProjectAdvertisement>>>(transform => transform
        //    //.With(s => s.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture)));

        //    var p = fixture.Create<ProjectAdvertisement>();
        //    projectAdvertisementsFixture.Add(p);

        //    var serv = fixture.Freeze<Mock<IEntityService<ProjectAdvertisement>>>();
        //    serv.Setup(s => s.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture);
        //    //var serv = fixture.Freeze<Mock<ProjectAdvertisementService>>();

        //    serv.Object.CreateAsync(p).Wait();
        //    var list = await serv.Object.GetAllAsync();
            
        //    Assert.NotEmpty(list);
        //    Assert.Equal(4, list.Count);

        //    //projectAdvertiseService.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<ProjectAdvertisement>());

        //    //var projectAdvertisementsFixture = fixture.CreateMany<ProjectAdvertisement>(3).ToList();

        //    //fixture.Customize<Mock<IEntityService<ProjectAdvertisement>>>(transform => transform
        //    //.With(s => s.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture)));

        //    //var dataReaderMock = fixture.Freeze<Mock<IEntityService<ProjectAdvertisement>>>();
        //    //dataReaderMock.Setup(dr => dr.GetAllAsync())
        //    //              .Returns(dataReaderMock.Object.GetAllAsync());

        //    // Act
        //    //projectAdvertiseService.Object.CreateAsync(projectAdvertisement).Wait();
        //    //var pa = projectAdvertiseService.Object.GetAllAsync().Result;

        //    //Assert
        //    //Assert.NotNull(pa);
        //    //Assert.Equal(1, pa.Count);
        //}
        //[Theory]
        //[AutoMoqData]
        //public void Test2(ProjectAdvertisement p)
        //{
        //    Assert.NotNull(p);
        //}
        //[Fact]
        //public async Task GetByIdAsync_ShouldReturnProjectAdvertisement()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var id = fixture.Create<int>();
     
        //    var projectAdvertisement = fixture.Create<ProjectAdvertisement>();

        //    var dbContextMock = new Mock<FreelanceContext>();
        //    dbContextMock.Setup(c => c.FindAsync<ProjectAdvertisement>(id)).ReturnsAsync(projectAdvertisement);

        //    var service = new ProjectAdvertisementService(dbContextMock.Object);

        //    // Act
        //    var result = await service.GetByIdAsync(id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(projectAdvertisement, result);
        //}
        //[Theory]
        //[AutoData]
        //public async void GetByIdAsync_Test()
        //{
        //    // Arrange
        //    var fixture = new Fixture();
        //    var id = fixture.Create<int>();
        //    fixture.Customize<ProjectAdvertisement>(transform => transform
        //  .With(s => s.RequiredSkills, new List<RequiredSkill> { new RequiredSkill {
        //    Skill = new Skill()} })
        //  .With(s => s.Freelancer, new Freelancer()));
        //    var projectAdvertisement = fixture.Create<ProjectAdvertisement>();

        //    var service = new Mock<IEntityService<ProjectAdvertisement>>();
        //    service.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(projectAdvertisement);

        //    // Act
        //    var result = service.Object.GetByIdAsync(id).Result;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(projectAdvertisement, result);
        //}
    }
}