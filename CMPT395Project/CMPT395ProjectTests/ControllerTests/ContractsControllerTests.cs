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
    public class ContractssControllerTests
    {
        [Fact]
        public void testContractsController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act

            //Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void testContractsControllerIndex()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Index("");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerIndexFilter()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Index("Dragon");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerIndexTrue()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Index("", true);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerIndexFalse()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Index("", false);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerDetails()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Details(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerCreate()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerEdit()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerIndexIdAndCompany()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Edit(1, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerDelete()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractsControllerDeleteConfirmed()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractsController controller = new ContractsController(projectContext);

            //Act
            var result = controller.DeleteConfirmed(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
