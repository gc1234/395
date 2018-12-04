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
        public void testAdminsControllerIndexClooney()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var search = admin.Index("Clooney");
            //Assert
            Assert.NotNull(search);
        }

        [Fact]
        public void testAdminsControllerIndexDragon()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            AdminsController admin = new AdminsController(projectContext);

            //Act
            var search = admin.Index("Dragon");
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
