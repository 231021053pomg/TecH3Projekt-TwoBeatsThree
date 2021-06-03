using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Repositories;
using Xunit;

namespace TecH3Projekt.Tests
{
    public class LogInRepositoryTests
    {
        private DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;


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
    }
}
