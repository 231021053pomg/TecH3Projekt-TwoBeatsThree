using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;
using TecH3Projekt.API.Services;
using Xunit;

namespace TecH3Projekt.Tests.TestService
{


    //Der skal laves test til Service for Type og Product














    public class LogInServiceTests
    {
        private readonly LogInService _sut;   // sut - system under test
        private readonly Mock<ILogInRepository> _logInRepositoryMock = new();

        public LogInServiceTests()
        {
            _sut = new LogInService(_logInRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ShouldFailIfNullIsPassed()
        {
            // Arrange
            _logInRepositoryMock
                .Setup(x => x.Create(It.IsAny<LogIn>()))
                .ReturnsAsync(() => null);

            // Act
            var logIn = await _sut.Create(null);

            // Assert
            Assert.Null(logIn);
        }



        [Fact]
        public async Task GetByIdAsync_ShouldReturnNothing_WhenLogInDoesNotExist()
        {
            // Arrange
            // make the MockRepo return null when any LogIn is requested
            _logInRepositoryMock
                .Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            // try to get a single logIn with the id == 1
            var logIn = await _sut.GetLogInById(1);

            // Assert
            Assert.Null(logIn);
        }



        [Fact]
        public async Task GetByIdAsync_ShouldReturnLogIn_WhenLogInExists()
        {
            // Arrange
            // setup the Mock logIn data
            var logInId = 1;
            var logInEmail = "Albert@gmail.com";
            var logInPassword = "Andersen";
            var LogInIsAdmin = false;
            var mockLogIn = new LogIn
            {
                Id = logInId,
                Email = logInEmail,
                Password = logInPassword,
                IsAdmin = LogInIsAdmin
        };
            _logInRepositoryMock
                .Setup(x => x.GetById(logInId))
                .ReturnsAsync(mockLogIn);

            // Act
            var logIn = await _sut.GetLogInById(logInId);

            // Assert
            Assert.Equal(mockLogIn, logIn);

        }
    }
}
