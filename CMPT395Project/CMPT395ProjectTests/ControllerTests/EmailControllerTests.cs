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
    public class EmailControllerTests
    {
        [Fact]
        public void testEmailController()
        {
            //Arrange
            DbContextOptions<ProjectContext> context = new DbContextOptions<ProjectContext>();
            ProjectContext projectContext = new ProjectContext(context);
            EmailController controller = new EmailController(projectContext);

            //Act

            //Assert
            Assert.NotNull(controller);
        }
    }
}
