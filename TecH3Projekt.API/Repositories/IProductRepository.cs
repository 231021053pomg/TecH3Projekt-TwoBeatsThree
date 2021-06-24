using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IProductRepository
    {
        //Hvis der bliver lavet et klasse som implementer den her interface
        //så skal den have de methoder som er defineret i interfacen

        //Hvad heder methoden
        //hvilket parameter vi sender med til methoden
        //Hvilket arguumenter kommer der tilbage fra dem



        // Get all Product objects
        Task<List<Product>> GetAll();  //Task - asynchronouse operation that can return a value    //---------------------

        //Get Product object by id.
        Task<Product> GetById(int id);    //---------------------

        //Create Product
        Task<Product> Create(Product product);

        //Update Product
        Task<Product> Update(int id, Product product);

        //Delete Product
        Task<Product> Delete(int id);


        
        //Get Products by type
        Task<List<Product>> GetByType(int id);
    }
}
