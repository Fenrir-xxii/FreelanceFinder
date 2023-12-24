using AutoFixture.Xunit2;
using AutoFixture;
using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceFinder.Application.Tests
{
    public class ProjectAdvertisementServiceTest
    {
        [Theory]
        [AutoMoqData]
        public void GetByIdAsync_ShouldReturnProjectAdvertisement(ProjectAdvertisement projectAdvertisement, int id)
        {
            // Arrange
            var service = new Mock<IEntityService<ProjectAdvertisement>>();
            service.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(projectAdvertisement);

            // Act
            var result = service.Object.GetByIdAsync(id).Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projectAdvertisement, result);
        }
        [Theory]
        [AutoMoqData]
        public void CreateAsync_ShouldCreateProjectAdvertisement(ProjectAdvertisement projectAdvertisement)
        {
            // Arrange
            var service = new Mock<IEntityService<ProjectAdvertisement>>();

            // Act
            service.Object.CreateAsync(projectAdvertisement);

            // Assert
            service.Verify(s => s.CreateAsync(projectAdvertisement), Times.Once());
        }
        [Theory]
        [AutoMoqData]
        public void DeleteAsync_ShouldDeleteProjectAdvertisement(int id)
        {
            // Arrange
            var service = new Mock<IEntityService<ProjectAdvertisement>>();

            // Act
            service.Object.DeleteAsync(id);

            // Assert
            service.Verify(s => s.DeleteAsync(id), Times.Once());
        }
        [Theory]
        [AutoMoqData]
        public void GetAllAsync_ShouldReturnListOfAllProjectAdvertisement(Fixture fixture)
        {
            // Arrange
            var service = new Mock<IEntityService<ProjectAdvertisement>>();
            var projectAdvertisementsFixture = fixture.CreateMany<ProjectAdvertisement>(3).ToList();
            service.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture);

            // Act
            var projectAdvertisements = service.Object.GetAllAsync().Result;

            // Assert
            Assert.NotEmpty(projectAdvertisements);
            Assert.Equal(3, projectAdvertisements.Count);
        }
        [Theory]
        [AutoMoqData]
        public void UpdateAsync_ShouldUpdateProjectAdvertisement_IfExist(Fixture fixture)
        {

            // Arrange
            var service = new Mock<IEntityService<ProjectAdvertisement>>();
            var projectAdvertisementsFixture = fixture.CreateMany<ProjectAdvertisement>(3).ToList();
            service.Setup(x => x.GetAllAsync()).ReturnsAsync(projectAdvertisementsFixture);

            var updatedProjectAdvertisement = projectAdvertisementsFixture[0];
            service.Setup(c => c.GetByIdAsync(updatedProjectAdvertisement.Id)).ReturnsAsync(updatedProjectAdvertisement);

            updatedProjectAdvertisement.Title = "Some UPDATED Title";    

            // Act
            service.Object.UpdateAsync(updatedProjectAdvertisement);
            var projectAdvertisements = service.Object.GetAllAsync().Result;
            var projectAdvertisement = service.Object.GetByIdAsync(updatedProjectAdvertisement.Id).Result;

            // Assert
            Assert.Equal(projectAdvertisement, updatedProjectAdvertisement);
            Assert.Equal("Some UPDATED Title", projectAdvertisement.Title);
            Assert.NotEmpty(projectAdvertisements);
            Assert.Equal(3, projectAdvertisements.Count);
        }
    }
}
