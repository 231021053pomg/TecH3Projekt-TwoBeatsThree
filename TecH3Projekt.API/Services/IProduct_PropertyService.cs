using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface IProduct_PropertyService
    {
        Task<List<Product_Property>> GetAllProduct_Properties();
        Task<Product_Property> GetProduct_PropertyById(int id);
        Task<Product_Property> Create(Product_Property product_Property);
        Task<Product_Property> Update(int id, Product_Property product_Property);
        Task<Product_Property> Delete(int id);
    }
}
