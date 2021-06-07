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

namespace TecH3Projekt.Tests.TestRepos
{
    public class ProductRepositoryTests
    {
        private DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;



        //<<<<<<<<<<<<<<<<<<<<<<< ADD 3 Products
        public ProductRepositoryTests()
        {

            _options = new DbContextOptionsBuilder<TecH3ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "TecH3ProjectDatabase")
                .Options;

            _context = new TecH3ProjectDbContext(_options);


            _context.Database.EnsureDeleted();

            //PRODUCTS
            _context.Product.Add(new Product
            {
                Id = 1,
                TypeId = 1,
                ProductName = "Orange T-shirt",
                Price = 125,
                Description = "Orange tshirt"
            });

            _context.Product.Add(new Product
            {
                Id = 2,
                TypeId = 1,
                ProductName = "Black T-shirt",
                Price = 140,
                Description = "Black tshirt"
            });

            _context.Product.Add(new Product
            {
                Id = 3,
                TypeId = 1,
                ProductName = "White T-shirt",
                Price = 150,
                Description = "White tshirt"
            });

            _context.SaveChanges();



            //TYPES
            _context.Type.Add(new API.Domain.Type
            {
                Id = 1,
                TypeName = "Tshirt"
            }) ;

            _context.SaveChanges();
        }



        //<<<<<<<<<<<<<<<<<<<<<<< GET ALL PRODUCTS
        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProduct_WhenProductsExists()
        {
            // Arrange
            ProductRepository productRepository = new ProductRepository(_context);

            // Act
            var product = await productRepository.GetAll();

            // Assert
            Assert.Equal(3, product.Count);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< GET PRODUCTS BY ID
        [Fact]
        public async Task GetProductsById_ShouldReturProductsById_WhenProductsExists()
        {
            // Arrange
            ProductRepository productRepository = new ProductRepository(_context);


            // Act
            var product = await productRepository.GetById(1);


            // Assert
            Assert.Equal(1, product.Id);
            Assert.Equal(1, product.TypeId);
            Assert.Equal("Orange T-shirt", product.ProductName);
            Assert.Equal(125, product.Price);
            Assert.Equal("Orange tshirt", product.Description);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< CREATE PRODUCT
        [Fact]
        public async Task CreateProduct_ShouldReturnProductWithNewDateTime_WhenCreated()
        {
            //Arrange
            ProductRepository productRepository = new ProductRepository(_context);

            Product newProduct = new Product
            {
                Id = 4,
                TypeId = 1,
                ProductName = "Yellow T-shirt",
                Price = 200,
                Description = "Ywllow tshirt"
            };

            List<Product> productss = await productRepository.GetAll();


            //Act
            var products = await productRepository.Create(newProduct);


            //Assert
            Assert.NotNull(products);
            Assert.NotEqual(DateTime.MinValue, products.CreatedAt);
            Assert.Equal(productss.Count + 1, products.Id);
        }


        //<<<<<<<<<<<<<<<<<<<<<<< UPDATE PRODUCT
        [Fact]
        public async Task UpdateProduct_ShouldReturnProductWithUpdatedDateTime_WhenUpdated()
        {
            //Arrange
            ProductRepository productRepository = new ProductRepository(_context);
            int productId = 1;

            Product updateProduct = new Product
            {
                Id = 1,
                TypeId = 1,
                ProductName = "Violet T-shirt",
                Price = 200,
                Description = "Violet tshirt"
            };
            List<Product> productss = await productRepository.GetAll();


            //Act
            var products = await productRepository.Update(productId, updateProduct);


            //Assert
            //Assert.NotNull(logIns);
            Assert.Equal(productId, products.Id);
            Assert.Equal(updateProduct.TypeId, products.TypeId);
            Assert.Equal(updateProduct.ProductName, products.ProductName);
            Assert.Equal(updateProduct.Price, products.Price);
            Assert.Equal(updateProduct.Description, products.Description);
            Assert.NotNull(products.UpdatedAt);
        }



        //<<<<<<<<<<<<<<<<<<<<<<< DELETE PRODUCT
        [Fact]
        public async Task DeleteProduct_ShouldDeleteAllProductWithSameId_WhenProductExists()
        {
            //Arrange
            ProductRepository productRepository = new ProductRepository(_context);
            int productId = 1;


            //Act
            var products = await productRepository.Delete(productId);


            //Assert
            Assert.NotNull(products.DeletedAt);
        }
    }
}
