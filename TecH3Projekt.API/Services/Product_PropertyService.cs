using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class Product_PropertyService : IProduct_PropertyService
    {
        private readonly IProduct_PropertyRepository _product_PropertyRepository;

        public Product_PropertyService(IProduct_PropertyRepository product_PropertyRepository) 
        {
            _product_PropertyRepository = product_PropertyRepository;
        }



        // GET ALL PRODUCT_PROPERTIES
        public async Task<List<Product_Property>> GetAllProduct_Properties()
        {
            var product_Property = await _product_PropertyRepository.GetAll();
            return product_Property;
        }


        // GET PRODUCT_PROPERTY BY ID
        public async Task<Product_Property> GetProduct_PropertyById(int id)
        {
            var product_Property = await _product_PropertyRepository.GetById(id);
            return product_Property;
        }


        // CREATE PRODUCT_PROPERTY
        public async Task<Product_Property> Create(Product_Property product_Property)
        {
            product_Property = await _product_PropertyRepository.Create(product_Property);
            return product_Property;
        }


        // UPDATE PRODUCT_PROPERTY
        public async Task<Product_Property> Update(int id, Product_Property product_Property)
        {
            await _product_PropertyRepository.Update(id, product_Property);
            return product_Property;
        }


        // DELETE PRODUCT_PROPERTY
        public async Task<Product_Property> Delete(int id)
        {
            var product_Property = await _product_PropertyRepository.Delete(id);
            return product_Property;
        }
    }
}
