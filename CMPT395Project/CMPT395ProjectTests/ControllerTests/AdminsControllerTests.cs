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
using Microsoft.AspNetCore.App;

namespace CMPT395ProjectTests.ControllerTests
{
    public class AdminsControllerTests
    {
        [Fact]
        public async Task TestAdminsIndex()
        {
            var mockRepo = new Mock<IBrainstormSessionRepository>();
        }
    }
}
