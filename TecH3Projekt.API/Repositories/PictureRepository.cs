using Microsoft.EntityFrameworkCore;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;//
using TecH3Projekt.API.Domain;//

namespace TecH3Projekt.API.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public PictureRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }

        //GETALL
        public async Task<List<Picture>> GetAll()
        {
            return await _context.Picture
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }

        //GETBYID
        public async Task<Picture> GetById(int id)
        {
            return await _context.Picture
               .Where(a => a.DeletedAt == null)
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async Task<Picture> Create(Picture picture)
        {
            picture.CreatedAt = DateTime.Now;
            _context.Picture.Add(picture);
            await _context.SaveChangesAsync();
            return picture;
        }

        //UPDATE
        public async Task<Picture> Update(int id, Picture picture)
        {
            var editPicture = await _context.Picture.FirstOrDefaultAsync(a => a.Id == id);
            if (editPicture != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editPicture.UpdatedAt = DateTime.Now;
                editPicture.Src = picture.Src;
                //FK ProductId also needed???


                _context.Picture.Update(editPicture);
                await _context.SaveChangesAsync();
            }
            return editPicture;
        }

        //DELETE
        public async Task<Picture> Delete(int id)
        {
            var picture = await _context.Picture.FirstOrDefaultAsync(a => a.Id == id);
            if (picture != null)
            {
                picture.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return picture;
        }
    }
}
