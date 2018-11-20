using System;
using Xunit;
using CMPT395Project.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.App;

namespace CMPT395ProjectTests.ControllerTests
{
    public class AdminsControllerTests
    {
        [Fact]
        public async Task TestAdminsIndex()
        {
            //Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnAsync(GetTestSessions());
            var controller = new AdminsController(mockRepo.Object);

            //Act
            var result = await controller.Index(null);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSessions>();
            sessions.Add(new BrainstormSessions()
            {
                AdminId = 1,
                FirstName = "test",
                LastName = "one",
                Password = "test"
            });
            sessions.Add(new BrainstormSessions()
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
