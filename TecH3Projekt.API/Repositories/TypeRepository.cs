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
        private readonly TecH3ProjectDbContext _context;

        public TypeRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Type>> GetAll()
        {
            return await _context.Type
               .Where(a => a.DeletedAt == null)
               .ToListAsync();
        }

        public async Task<Domain.Type> GetById(int id)
        {
            return await _context.Type
               .Where(a => a.DeletedAt == null)
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Domain.Type> Create(Domain.Type type)
        {
            type.CreatedAt = DateTime.Now;
            _context.Type.Add(type);
            await _context.SaveChangesAsync();
            return type;
        }

        public Task<Domain.Type> Update(int id, Domain.Type type)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Type> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
