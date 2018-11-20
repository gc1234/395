using System;
using Xunit;
using CMPT395Project.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

namespace CMPT395ProjectTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void TestHomeView()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeMain()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Main() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeReportHour()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ReportHour() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeAbout()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.About() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomePrivacy()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Privacy() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
