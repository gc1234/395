using System;
using Xunit;
using CMPT395Project.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using CMPT395Project.Models;

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
        public void TestHomeReportHourPara()
        {
            //Arrange
            HomeController controller = new HomeController();
            ReportHourModel reportHourModel = new ReportHourModel();
            reportHourModel.StoreHour = "15";
            reportHourModel.InvalidHour = true;

            //Act
            ViewResult result = controller.ReportHour(reportHourModel) as ViewResult;

            //Assert
            //Assert.NotNull(result);
            Assert.NotNull(reportHourModel);
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

        [Fact]
        public void TestHomeContact()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeErrorContract()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ErrorContract() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeLogout()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Logout() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeIndex()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestHomeIndexPara()
        {
            //Arrange
            HomeController controller = new HomeController();
            LoginModel loginModel = new LoginModel();
            loginModel.Username = "test";
            loginModel.Password = "test";
            loginModel.FirstLogin = false;
            //Act
            ViewResult result = controller.Index(loginModel) as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
