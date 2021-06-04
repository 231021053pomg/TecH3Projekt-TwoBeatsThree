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
    public class UserRepositoryTests
    {
        private DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;



        //<<<<<<<<<<<<<<<<<<<<<<< ADD 3 USERS
        public UserRepositoryTests()
        {

            _options = new DbContextOptionsBuilder<TecH3ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "TecH3ProjectDatabase")
                .Options;

            _context = new TecH3ProjectDbContext(_options);


            _context.Database.EnsureDeleted();

            //LOG INS
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

            //USERS
            _context.User.Add(new User
            {
                LogInId = 1,
                Id = 1,
                FirstName = "Matas",
                LastName = "Motuzas",
                Address = "Rubinvej 39",
                PostNr = 3650,
                City = "Ølstykke"
            });

            _context.User.Add(new User
            {
                LogInId = 2,
                Id = 2,
                FirstName = "Tomas",
                LastName = "Brunosis",
                Address = "Liepai 80",
                PostNr = 4280,
                City = "Kaunas"
            });

            _context.User.Add(new User
            {
                LogInId = 3,
                Id = 3,
                FirstName = "Skaidra",
                LastName = "Linkoniene",
                Address = "Geroviu 80",
                PostNr = 5080,
                City = "Vilnius"
            });

            _context.SaveChanges();
        }



        //<<<<<<<<<<<<<<<<<<<<<<< GET ALL USERS
        [Fact]
        public async Task GetAllUsers_ShouldReturnAllUsers_WhenUsersExists()
        {
            // Arrange
            UserRepository userRepository = new UserRepository(_context);

            // Act
            var user = await userRepository.GetAll();

            // Assert
            Assert.Equal(3, user.Count);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< GET USERS BY ID
        [Fact]
        public async Task GetUserById_ShouldReturnUserById_WhenUserExists()
        {
            // Arrange
            UserRepository userRepository = new UserRepository(_context);


            // Act
            var user = await userRepository.GetById(1);


            // Assert
            Assert.Equal(1, user.Id);
            Assert.Equal(1, user.LogInId);
            Assert.Equal("Matas", user.FirstName);
            Assert.Equal("Motuzas", user.LastName);
            Assert.Equal("Rubinvej 39", user.Address);
            Assert.Equal(3650, user.PostNr);
            Assert.Equal("Ølstykke", user.City);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< CREATE LOG IN
        [Fact]
        public async Task CreateUser_ShouldReturnUserWithNewDateTime_WhenCreated()
        {
            //Arrange
            UserRepository userRepository = new UserRepository(_context);

            User newUser = new User
            {
                LogInId = 4,
                Id = 4,
                FirstName = "John",
                LastName = "Johnson",
                Address = "Thestreet 123B",
                PostNr = 4000,
                City = "NewYork"
            };

            List<User> userss = await userRepository.GetAll();


            //Act
            var users = await userRepository.Create(newUser);


            //Assert
            Assert.NotNull(users);
            Assert.NotEqual(DateTime.MinValue, users.CreatedAt);
            Assert.Equal(userss.Count + 1, users.Id);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< UPDATE USER
        [Fact]
        public async Task UpdateUser_ShouldReturnUserWithUpdatedDateTime_WhenUpdated()
        {
            //Arrange
            UserRepository userRepository = new UserRepository(_context);
            int userId = 1;

            User updateUser = new User
            {
                Id = 1,
                LogInId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Address = "Martin Street 12",
                PostNr = 5400,
                City = "London"
            };
            List<User> userss = await userRepository.GetAll();


            //Act
            var users = await userRepository.Update(userId, updateUser);


            //Assert
            Assert.NotNull(users);
            Assert.Equal(userId, users.Id);
            Assert.Equal(updateUser.FirstName, users.FirstName);
            Assert.Equal(updateUser.LastName, users.LastName);
            Assert.Equal(updateUser.Address, users.Address);
            Assert.Equal(updateUser.PostNr, users.PostNr);
            Assert.Equal(updateUser.City, users.City);
            Assert.NotNull(users.UpdatedAt);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< DELETE LOG IN
        [Fact]
        public async Task DeleteUser_ShouldDeleteAllUsersWithSameId_WhenLogInExists()
        {
            //Arrange
            UserRepository userRepository = new UserRepository(_context);
            int userId = 1;


            //Act
            var users = await userRepository.Delete(userId);


            //Assert
            Assert.NotNull(users.DeletedAt);
        }
    }
}
