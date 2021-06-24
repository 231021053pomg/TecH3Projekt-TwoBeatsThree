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
        private readonly TecH3ProjectDbContext _context;     //---------------------

        public ProductRepository(TecH3ProjectDbContext context) //constructor som returner vores DbContext     //---------------------
        {
            _context = context;//connect readonly and instance context.    //---------------------
        }




        //GETALL
        public async Task<List<Product>> GetAll()   //async tasks don't stop other tasks from running.
        {
            //await will return data when completed.
            return await _context.Product    //---------------------
               .Where(a => a.DeletedAt == null) //Sort out Deleted Products.  //---------------------
               .Include(a => a.Type) //Includes type   //---------------------
               .ToListAsync();   //---------------------
        }



        //GET ÅRPDUCT BY ID
        public async Task<Product> GetById(int id)  //---------------------
        {
            return await _context.Product  //---------------------
               .Where(a => a.DeletedAt == null)  //---------------------
               .Include(a => a.Pictures)   //---------------------
               .FirstOrDefaultAsync(a => a.Id == id);  //---------------------
        }





        //GET PRODUCT BY TYPE
        public async Task<List<Product>> GetByType(int id)  //---------------------
        {
            return await _context.Product
                .Where(a => a.DeletedAt == null)
                .Where(a => a.TypeId == id)
                //.Include(a => a.Type)
                .ToListAsync();
        }




        //CREATE
        public async Task<Product> Create(Product product)  //---------------------
        {
            product.CreatedAt = DateTime.Now; //setter created at dato
            _context.Product.Add(product);   //tilføjer product
            await _context.SaveChangesAsync();  //afventer save changes
            return product;
        }



        //UPDATE
        public async Task<Product> Update(int id, Product product)   //---------------------
        {
            var editProduct = await _context.Product.FirstOrDefaultAsync(a => a.Id == id); //findes der product med indskrevet id?
            if (editProduct != null) //checker hvis product findes opdateres der UpdatedAt dato for specific id
                                     //og så bliver opdateret og gemt.
            {
                editProduct.UpdatedAt = DateTime.Now;
                //Hvilket ting der skal opdateres eksempel:
                //editProduct.ProductName = product.ProductName;
                _context.Product.Update(editProduct);
                await _context.SaveChangesAsync();
            }
            return editProduct;
        }





        //DELETE
        public async Task<Product> Delete(int id)  //---------------------
        {
            var product = await _context.Product.FirstOrDefaultAsync(a => a.Id == id);  //findes der product med indskrevet id?
            if (product != null)  //hvis der productet findes oprettes der DeletedAt dato og gemmes.
            {
                product.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
