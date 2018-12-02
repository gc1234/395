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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMPT395ProjectTests.ControllerTests
{
    public class AdminsControllerTests
    {
        /*
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
        }*/

        [Fact]
        public void testAdminsController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act

            //Assert
            Assert.NotNull(admin);
        }

        [Fact]
        public void testAdminsControllerIndex()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var search = admin.Index("");
            //Assert
            Assert.NotNull(search);
        }

        [Fact]
        public void testAdminsControllerIndexParaTrue()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var search = admin.Index("", true);
            //Assert
            Assert.NotNull(search);
        }

        [Fact]
        public void testAdminsControllerIndexParaFalse()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var search = admin.Index("", false);
            //Assert
            Assert.NotNull(search);
        }

        [Fact]
        public void testAdminsControllerCreate()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var create = admin.Create();
            //Assert
            Assert.NotNull(create);
        }

        [Fact]
        public void testAdminsControllerEdit()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var edit = admin.Edit(2);
            //Assert
            Assert.NotNull(edit);
        }

        [Fact]
        public void testAdminsControllerDelete()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var delete = admin.Delete(1);
            //Assert
            Assert.NotNull(delete);
        }

        [Fact]
        public void testAdminsControllerDeleteConfirmed()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var delete = admin.DeleteConfirmed(1);
            //Assert
            Assert.NotNull(delete);
        }
    }
}
