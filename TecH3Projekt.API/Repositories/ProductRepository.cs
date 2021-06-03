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

        //GETALL
        public async Task<List<Product>> GetAll()//async tasks don't stop other tasks from running.
        {
            //await will return data when completed.
            return await _context.Product
               .Where(a => a.DeletedAt == null)//Sort out Deleted Products.
               .Include(a => a.Pictures)//1-to-M relations? what about 1-to-1 like type?
               .ToListAsync();
        }

        //GETBYID
        public async Task<Product> GetById(int id)
        {
            return await _context.Product
               .Where(a => a.DeletedAt == null)
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async Task<Product> Create(Product product)
        {
            product.CreatedAt = DateTime.Now;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        //UPDATE
        public async Task<Product> Update(int id, Product product)
        {
            var editProduct = await _context.Product.FirstOrDefaultAsync(a => a.Id == id);
            if (editProduct != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editProduct.UpdatedAt = DateTime.Now;


                _context.Product.Update(editProduct);
                await _context.SaveChangesAsync();
            }
            return editProduct;
        }

        //DELETE
        public async Task<Product> Delete(int id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(a => a.Id == id);
            if (product != null)
            {
                product.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return product;
        }

    }
}
