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
    public class EmployeeHoursControllerTests
    {
        [Fact]
        public void testEmployeeHoursController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act

            //Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void testEmployeeHoursControllerIndex()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Index();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerDetails()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Details(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerCreate()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerEdit()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerIndexIdAndCompany()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Edit(1, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerDelete()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testEmployeeHoursControllerDeleteConfirmed()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmployeeHoursController controller = new EmployeeHoursController(projectContext);

            //Act
            var result = controller.DeleteConfirmed(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
