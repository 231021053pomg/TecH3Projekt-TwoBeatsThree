using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//
using Xunit;//
using TecH3Projekt.API.Database;//
using TecH3Projekt.API.Repositories;//
using TecH3Projekt.API.Domain;//
using Microsoft.EntityFrameworkCore;//

namespace TecH3Projekt.Tests.TestRepos
{
    public class OrderRepositoryTests
    {
        //ctor for inmemory. sim database
        private readonly DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;

        public OrderRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "OrdersDatabase")
                .Options;

            _context = new TecH3ProjectDbContext(_options);
            _context.Database.EnsureDeleted();//delete any former database contexts, ensure a clean slate.

            _context.Order.Add(new Order { 
                //Add examples to database.
                //FK LogInID = int,
                //DateMade datetime.

            });
            _context.SaveChanges();//Save examples (if any)
        }

        [Fact]//places in test explorer?
        public async Task GetAllOrders_ReturnAllOrders()
        {
            //Arrange
            OrderRepository orderRepository = new OrderRepository(_context);

            //Act. What am i doing?
            var orders = await orderRepository.GetAll();

            //Assert. What am i looking for?
            Assert.NotNull(orders);
            //Assert.Equal(2, orders.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnSingleOrder()
        {
            //Arrange
            OrderRepository orderRepository = new OrderRepository(_context);

            //Act
            var order = await orderRepository.GetById(1);

            //Assert
            Assert.NotNull(order);
            Assert.Equal(1, order.Id);
            //Assert.Null(order);
        }

    }
}
