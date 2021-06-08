using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface IPropertyService
    {
        Task<List<Property>> GetAllProperties();
        Task<Property> GetPropertyById(int id);
        Task<Property> Create(Property property);
        Task<Property> Update(int id, Property property);
        //Task<Property> Delete(int id);
    }
}
