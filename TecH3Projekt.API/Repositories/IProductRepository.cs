using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IProductRepository
    {
        // Get all Product objects
        Task<List<Product>> GetAll();

        //Get Product object by id.
        Task<Product> GetById(int id);

        //Create Product
        Task<Product> Create(Product product);

        //Update Product
        Task<Product> Update(int id, Product product);

        //Delete Product
        Task<Product> Delete(int id);
        Task<List<Product>> GetByType(int id);
    }
}
