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
    public class ContractorsControllerTests
    {
        [Fact]
        public void testContractorsController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act

            //Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void testCompaniesControllerIndex()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Index("");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerIndexFilter()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Index("Dragon");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerIndexTrue()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Index("", true);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerIndexFalse()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Index("", false);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerDetails()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Details(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerCreate()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerEdit()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Edit(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerIndexIdAndCompany()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Edit(1, null);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerDelete()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.Delete(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void testContractorsControllerDeleteConfirmed()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            ContractorsController controller = new ContractorsController(projectContext);

            //Act
            var result = controller.DeleteConfirmed(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
