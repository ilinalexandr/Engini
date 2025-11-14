using Company.Application.Services;
using Company.Infrastructure.Repositories.Interfaces;
using Company.Model.Entities;
using Moq;
using System.Linq;

namespace CompanyTest
{
    public class Tests
    {
        [Test]
        public void GetEmployeeHierarchy_ReturnsCorrectHierarchy()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();

            mockRepo.Setup(r => r.GetEmployeeHierarchyFlat(1))
                                 .Returns(new List<EmployeeEntity>
                                 {
                                     new EmployeeEntity { Id = 1, Name = "Boss", ManagerId = null },
                                     new EmployeeEntity { Id = 2, Name = "Worker", ManagerId = 1 }
                                 });

            var service = new EmployeeService(mockRepo.Object);

            // Act
            var result = service.GetEmployeeHierarchy(1);

            // Assert
            Assert.NotNull(result);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(1));
                Assert.That(result.Subordinates, Has.Count.EqualTo(1));
            });
        }
    }
}