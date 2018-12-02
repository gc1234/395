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
//using Microsoft.AspNetCore.App;
using CMPT395Project.Models;
/*
namespace CMPT395ProjectTests.ControllerTests
{
    public class AdminsControllerTests
    {
        [Fact]
        public async Task TestAdminsIndex()
        {
            //public DbSet<Admin> Admin { get; set; }
            //Arrange
            var mockRepo = new Mock<ProjectContext>();
            //mockRepo.Setup(repo => repo.Admin())
                //.ReturnsAsync(GetTestSessions());

            var controller = new AdminsController(mockRepo.Object);

            //Act
            var result = await controller.Index(null);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Admin>>(
                viewResult.ViewData.Model);
            //Assert.Equal(0, model.Count());
            Assert.Empty(model);
        }

        private List<Admin> GetTestSessions()
        {
            var sessions = new List<Admin>();
            sessions.Add(new Admin()
            {
                AdminId = 1,
                FirstName = "test",
                LastName = "one",
                Password = "test"
            });
            sessions.Add(new Admin()
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
*/