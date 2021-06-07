using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface IPictureService
    {
        Task<List<Picture>> GetAllPictures();
        Task<Picture> GetPictureById(int id);
        Task<Picture> Create(Picture picture);
        Task<Picture> Update(int id, Picture picture);
        Task<Picture> Delete(int id);
    }
}
