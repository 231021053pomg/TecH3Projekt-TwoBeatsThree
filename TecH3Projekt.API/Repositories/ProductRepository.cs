using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TecH3ProjectDBContext _context;
        public async Task<List<Product>> GetAll()//async tasks don't stop other tasks from running.
        {
            //await will return data when completed.
            return await _context.Product
               .Where(a => a.DeletedAt == null)
               .Include(a => a.Type)
               .ToListAsync();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }
        public Task<Product> Update(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
