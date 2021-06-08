using Microsoft.EntityFrameworkCore;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;//
using TecH3Projekt.API.Domain;//
using TecH3Projekt.API.Repositories;//
using Xunit;//

namespace TecH3Projekt.Tests.TestRepos
{
    public class PictureRepositoryTests
    {
        //ctor for inmemory. sim database
        private readonly DbContextOptions<TecH3ProjectDbContext> _options;
        private readonly TecH3ProjectDbContext _context;

        public PictureRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "PicturesDatabase")
                .Options;

            _context = new TecH3ProjectDbContext(_options);
            _context.Database.EnsureDeleted();//delete any former database contexts, ensure a clean slate.

            //Product examples.
            _context.Product.Add(new Product
            {
                Id = 1,
                ProductName = "TestName",
                Price = 12.00,
                Description = "Test product for Pictures."


            });
            _context.SaveChanges();//Save Product examples

            //Picture examples.
            _context.Picture.Add(new Picture
            {
                Id = 1,
                Src = "TestSrc1",
                ProductId = 1

            });
            _context.SaveChanges();//Save Picture examples
        }


        //<<<<<<<<<<<<<<<<<<<<<<< GET ALL PICTURES
        [Fact]
        public async Task GetAllPictures_ReturnAllPictures()
        {
            //Arrange
            PictureRepository pictureRepository = new PictureRepository(_context);

            //Act. What am i doing?
            var pictures = await pictureRepository.GetAll();

            //Assert. What am i looking for?
            Assert.NotNull(pictures);
            //Assert.Null(pictures);
            //Assert.Equal(1, pictures.Count);
        }


        //<<<<<<<<<<<<<<<<<<<<<<< GET PICTURES BY ID
        [Fact]
        public async Task GetPictureByID_ReturnSinglePicture()
        {
            // Arrange
            PictureRepository pictureRepository = new PictureRepository(_context);


            // Act
            var pictures = await pictureRepository.GetById(1);


            // Assert
            Assert.Equal(1, pictures.Id);
            Assert.Equal("TestSrc1", pictures.Src);
            Assert.Equal(1, pictures.ProductId);
            //Assert.Null(pictures);
        }


        //<<<<<<<<<<<<<<<<<<<<<<< CREATE PICTURE
        [Fact]
        public async Task CreatePicture_ReturnPictureWithNewDateTime()
        {
            //Arrange
            PictureRepository pictureRepository = new PictureRepository(_context);

            Picture newPicture = new Picture
            {
                Src = "NewTestPicture",

            };

            List<Picture> picturess = await pictureRepository.GetAll();

            //Act
            var pictures = await pictureRepository.Create(newPicture);

            //Assert
            Assert.NotNull(pictures);
            Assert.NotEqual(DateTime.MinValue, pictures.CreatedAt);
            Assert.Equal(picturess.Count + 1, pictures.Id);
            //Assert.Null(pictures);
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //<<<<<<<<<<<<<<<<<<<<<<< UPDATE PICTURE
        [Fact]
        public async Task UpdatePicture_ReturnPictureWithUpdateDateTime()
        {
            //Arrange
            PictureRepository pictureRepository = new PictureRepository(_context);
            int pictureId = 1;

            Picture updatePicture = new Picture
            {
                
            };

        }


        //<<<<<<<<<<<<<<<<<<<<<<< DELETE PICTURE
    }
}
