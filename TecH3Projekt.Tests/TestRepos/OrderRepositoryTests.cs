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

            //LogIn examples.
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

            _context.SaveChanges();//Save LogIn examples

            //Order examples
            _context.Order.Add(new Order {
                //Add examples to database.
                //Id is not mandatory.
                Id = 1,
                //OrderMade = ,
                //OrderItems = ,//HOW to call List of Products??
                LogInId = 1


            });

            _context.SaveChanges();//Save examples (if any)
        }


        //<<<<<<<<<<<<<<<<<<<<<<< GET ALL ORDERS
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


        //<<<<<<<<<<<<<<<<<<<<<<< GET ORDER BY ID
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

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //<<<<<<<<<<<<<<<<<<<<<<< CREATE ORDER
        [Fact]
        public async Task Create_ReturnOrderWithNewDateTime_WhenCreated()
        {
            //Arrange
            OrderRepository orderRepository = new OrderRepository(_context);
            Order NewOrder = new Order
            {
                //Add examples to database.
                //Id is not mandatory.
                
            };

            //Act
            var order = await orderRepository.GetAll();

            //Assert
            Assert.NotNull(order);
        }


        //<<<<<<<<<<<<<<<<<<<<<<< UPDATE ORDER
        [Fact]
        public async Task UpdateOrder_ShouldReturnOrderWithUpdatedDateTime_WhenUpdated()
        {
            //Arrange
            OrderRepository orderRepository = new OrderRepository(_context);


            //Act
            

            //Assert
            
        }


        //<<<<<<<<<<<<<<<<<<<<<<< DELETE ORDER
        [Fact]
        public async Task DeleteOrder_ShouldDeleteAllOrdersWithSameId_WhenOrderExists()
        {
            //Arrange
            OrderRepository orderRepository = new OrderRepository(_context);


            //Act


            //Assert

        }

    }
}
