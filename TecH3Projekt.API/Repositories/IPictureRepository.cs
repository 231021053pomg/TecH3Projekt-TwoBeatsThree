using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;//

namespace TecH3Projekt.API.Repositories
{
    public interface IPictureRepository
    {
        // Get all Picture objects
        Task<List<Picture>> GetAll();

        //Get Picture object by id.
        Task<Picture> GetById(int id);

        //Create Picture
        Task<Picture> Create(Picture picture);

        //Update Picture
        Task<Picture> Update(int id, Picture picture);

        //Delete Picture
        Task<Picture> Delete(int id);
    }
}
