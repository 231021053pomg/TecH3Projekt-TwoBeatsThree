using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;//
using TecH3Projekt.API.Database;//
using Microsoft.EntityFrameworkCore;//

namespace TecH3Projekt.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public ProductRepository(TecH3ProjectDbContext context)
        {
            _context = context;//connect readonly and instance context.
        }

        
        public async Task<List<Product>> GetAll()//async tasks don't stop other tasks from running.
        {
            //await will return data when completed.
            return await _context.Product
               .Where(a => a.DeletedAt == null)//Sort out Deleted Products.
               .Include(a => a.Pictures)//1-to-M relations? what about 1-to-1 like type?
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
