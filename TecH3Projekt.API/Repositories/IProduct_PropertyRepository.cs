using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IProduct_PropertyRepository
    {
        Task<List<Product_Property>> GetAll();
        Task<Product_Property> GetById(int id);
        Task<Product_Property> Create(Product_Property product_Property);
        Task<Product_Property> Update(int id, Product_Property product_Property);
        Task<Product_Property> Delete(int id);
    }
}
