using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface IProductService
    {
        //Næsten det sammen som Repository interface

        Task<List<Product>> GetAllProducts();    //--------------------
        Task<Product> GetProductById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(int id, Product product);
        Task<Product> Delete(int id);
        Task<List<Product>> GetProductByType(int id);
    }
}
