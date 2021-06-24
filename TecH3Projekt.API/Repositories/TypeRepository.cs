using Microsoft.EntityFrameworkCore;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;//
//using TecH3Projekt.API.Domain;//

namespace TecH3Projekt.API.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly TecH3ProjectDbContext _context;  //------------------

        public TypeRepository(TecH3ProjectDbContext context)    //------------------
        {
            _context = context;  //------------------
        }





        //GET ALL TYPES
        public async Task<List<Domain.Type>> GetAll()   //------------------
        {
            return await _context.Type
               .Where(a => a.DeletedAt == null)
               .ToListAsync();
        }



        //GET TYPE BY ID
        public async Task<Domain.Type> GetById(int id)   //------------------
        {
            return await _context.Type
               .Where(a => a.DeletedAt == null)
               .FirstOrDefaultAsync(a => a.Id == id);
        }



        //CREATE 
        public async Task<Domain.Type> Create(Domain.Type type)  //------------------
        {
            type.CreatedAt = DateTime.Now;
            _context.Type.Add(type);
            await _context.SaveChangesAsync();
            return type;
        }



        //UPDATE
        public async Task<Domain.Type> Update(int id, Domain.Type type)  //------------------
        {
            var editType = await _context.Type.FirstOrDefaultAsync(a => a.Id == id);
            if (editType != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editType.UpdatedAt = DateTime.Now;
                editType.TypeName = type.TypeName;


                _context.Type.Update(editType);
                await _context.SaveChangesAsync();
            }
            return editType;
        }


        //DELETE 
        public async Task<Domain.Type> Delete(int id)   //------------------
        {
            var type = await _context.Type.FirstOrDefaultAsync(a => a.Id == id);
            if (type != null)
            {
                type.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return type;
        }
    }
}
