using Microsoft.AspNetCore.Mvc.Infrastructure;//for IStatusCodeActionResult
using Moq;//for Mock
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Projekt.API.Controllers;//
using TecH3Projekt.API.Domain;//
using TecH3Projekt.API.Services;//
using Xunit;//Fact

namespace TecH3Projekt.Tests.TestControllers
{
    public class LogInControllerTests
    {
        private readonly LogInController _sut;
        private readonly Mock<ILogInService> _loginServiceMock = new();


        public LogInControllerTests()
        {
            _sut = new LogInController(_loginServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturn200_WhenDataExists()
        {
            //Arrange
            List<LogIn> logins = new List<LogIn>();

            for (int i = 0; i < 5; i++)
            {
                logins.Add(new LogIn());
            }

            _loginServiceMock
                .Setup(x => x.GetAllLogIns())
                .ReturnsAsync(logins);

            //Act
            var result = await _sut.GetAll();

            //Assert
            var StatusCodeResult = (IStatusCodeActionResult) result;
            Assert.Equal(200, StatusCodeResult.StatusCode);//200 = Success.
        }
    }
}
