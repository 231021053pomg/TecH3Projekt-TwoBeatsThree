using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class Product_PropertyRepository : IProduct_PropertyRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public Product_PropertyRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }


        //GETALL
        public async Task<List<Product_Property>> GetAll()
        {
            return await _context.Product_Property
                .Where(a => a.DeletedAt == null)
                .ToListAsync();
        }

        //GETBYID
        public async Task<Product_Property> GetById(int id)
        {
            return await _context.Product_Property
                .Where(a => a.DeletedAt == null)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async  Task<Product_Property> Create(Product_Property product_Property)
        {
            product_Property.CreatedAt = DateTime.Now;
            _context.Product_Property.Add(product_Property);
            await _context.SaveChangesAsync();
            return product_Property;
        }

        //UPDATE
        public async Task<Product_Property> Update(int id, Product_Property product_Property)
        {
            var editProduct_Property = await _context.Product_Property.FirstOrDefaultAsync(a => a.Id == id);
            if (editProduct_Property != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editProduct_Property.UpdatedAt = DateTime.Now;


                _context.Product_Property.Update(editProduct_Property);
                await _context.SaveChangesAsync();
            }
            return editProduct_Property;
        }

        //DELETE
        public async Task<Product_Property> Delete(int id)
        {
            var product_Property = await _context.Product_Property.FirstOrDefaultAsync(a => a.Id == id);
            if (product_Property != null)
            {
                product_Property.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return product_Property;
        }
    }
}
