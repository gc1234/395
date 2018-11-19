using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMPT395Project;

namespace CMPT395ProjectTests
{
    [TestClass]
    public class ControllerTests
    {
        [Fact]
        public async Task AdminsControllerTest()
        {
            // Arrange
            var mockRepo = new Mock<ProjectContext>();
            mockRepo.Setup(mockRepo => mockRepo.ListAsync())
                .ReturnAsync(GetTestSessions());
            var controller = new AdminsController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<viewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, Count());
        }

        private List<BrainstormSession> GetTestSession()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                AdminId = 1,
                FirstName = "test",
                LastName = "one",
                Password = "test"
            });
            sessions.Add(new BrainstormSession()
            {
                AdminId = 2,
                FirstName = "test",
                LastName = "two",
                Password = "test"
            });
            return sessions;
        }
    }
}
