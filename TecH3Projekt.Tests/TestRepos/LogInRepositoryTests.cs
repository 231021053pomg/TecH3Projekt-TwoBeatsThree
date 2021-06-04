using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;
using Xunit;

namespace TecH3Projekt.Tests
{
    public class LogInRepositoryTests
    {
        private DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;



        //<<<<<<<<<<<<<<<<<<<<<<< ADD 3 LOGINS
        public LogInRepositoryTests()
        {

            _options = new DbContextOptionsBuilder<TecH3ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "TecH3ProjectDatabase")
                .Options;

            _context = new TecH3ProjectDbContext(_options);


            _context.Database.EnsureDeleted();

            _context.LogIn.Add(new API.Domain.LogIn
            {
                Id = 1,
                Email = "Albert@gmail.com",
                Password = "Andersen",
                IsAdmin = false
            });

            _context.LogIn.Add(new API.Domain.LogIn
            {
                Id = 2,
                Email = "Anderson@gmail.com",
                Password = "Andersen123",
                IsAdmin = false
            });

            _context.LogIn.Add(new API.Domain.LogIn
            {
                Id = 3,
                Email = "Morten@gmail.com",
                Password = "Mortensen123",
                IsAdmin = false
            });

            _context.SaveChanges();
        }
        


        //<<<<<<<<<<<<<<<<<<<<<<< GET ALL LOGINS
        [Fact]
        public async Task GetAllLogIns_ShouldReturnAllLogIns_WhenLogIndsExists()
        {
            // Arrange
            LogInRepository logInRepository = new LogInRepository(_context);

            // Act
            var logIn = await logInRepository.GetAll();

            // Assert
            Assert.Equal(3, logIn.Count);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< GET LOG INS BY ID
        [Fact]
        public async Task GetLogInById_ShouldReturnLogInById_WhenLogInExists()
        {
            // Arrange
            LogInRepository logInRepository = new LogInRepository(_context);


            // Act
            var logIn = await logInRepository.GetById(1);


            // Assert
            Assert.Equal(1, logIn.Id);
            Assert.Equal("Albert@gmail.com", logIn.Email);
            Assert.Equal("Andersen", logIn.Password);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< CREATE LOG IN
        [Fact]
        public async Task CreateLogIn_ShouldReturnLogInWithNewDateTime_WhenCreated()
        {
            //Arrange
            LogInRepository logInRepository = new LogInRepository(_context);

            LogIn newLogIn = new LogIn
            {
                Email = "Dennis@gmail.com",
                Password = "Denlighter123*",
                IsAdmin = false
            };

            List<LogIn> logInss = await logInRepository.GetAll();


            //Act
            var logIns = await logInRepository.Create(newLogIn);


            //Assert
            Assert.NotNull(logIns);
            Assert.NotEqual(DateTime.MinValue, logIns.CreatedAt);
            Assert.Equal(logInss.Count + 1, logIns.Id);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< UPDATE LOG IN
        [Fact]
        public async Task UpdateLogIn_ShouldReturnLogInWithUpdatedDateTime_WhenUpdated()
        {
            //Arrange
            LogInRepository logInRepository = new LogInRepository(_context);
            int logInId = 1;

            LogIn updateLogIn = new LogIn
            {
                Email = "Finn@gmail.com",
                Password = "Filur123*",
                IsAdmin = true
            };
            List<LogIn> logInss = await logInRepository.GetAll();


            //Act
            var logIns = await logInRepository.Update(logInId, updateLogIn);


            //Assert
            Assert.NotNull(logIns);
            Assert.Equal(logInId, logIns.Id);
            Assert.Equal(updateLogIn.Email, logIns.Email);
            Assert.Equal(updateLogIn.Password, logIns.Password);
            Assert.Equal(updateLogIn.IsAdmin, logIns.IsAdmin);
            Assert.NotNull(logIns.UpdatedAt);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< DELETE LOG IN
        [Fact]
        public async Task DeleteLogIn_ShouldDeleteAllLogInsWithSameId_WhenLogInExists()
        {
            //Arrange
            LogInRepository logInRepository = new LogInRepository(_context);
            int logInId = 1;


            //Act
            var logIns = await logInRepository.Delete(logInId);


            //Assert
            Assert.NotNull(logIns.DeletedAt);
        }
    }
}
