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
    public class EmployeesControllerTests
    {
        [Fact]
        public void testEmployeesController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act

            //Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void testEmployeesControllerIndex()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Index("");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerIndexFilter()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Index("Dragon");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerIndexTrue()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Index("", true);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerIndexFalse()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Index("", false);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerDetails()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Details(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerCreate()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerEdit()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerIndexIdAndCompany()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Edit(1, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerDelete()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeesControllerDeleteConfirmed()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeesController controller = new EmployeesController(projectContext);

            //Act
            var result = controller.DeleteConfirmed(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
