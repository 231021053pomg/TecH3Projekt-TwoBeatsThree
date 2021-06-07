using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository) //??
        {
            _pictureRepository = pictureRepository;
        }



        // GET ALL PICTURES
        public async Task<List<Picture>> GetAllPictures()
        {
            var pictures = await _pictureRepository.GetAll();
            return pictures;
        }


        // GET PICTURE BY ID
        public async Task<Picture> GetPictureById(int id)
        {
            var pictures = await _pictureRepository.GetById(id);
            return pictures;
        }


        // CREATE PICTURE
        public async Task<Picture> Create(Picture picture)
        {
            picture = await _pictureRepository.Create(picture);
            return picture;
        }


        // UPDATE PICTURE
        public async Task<Picture> Update(int id, Picture picture)
        {
            await _pictureRepository.Update(id, picture);
            return picture;
        }


        // DELETE PICTURE
        public async Task<Picture> Delete(int id)
        {
            var picture = await _pictureRepository.Delete(id);
            return picture;
        }
    }
}
