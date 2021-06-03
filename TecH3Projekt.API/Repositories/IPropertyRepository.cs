using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
     public interface IPropertyRepository
    {
        Task<List<Property>> GetAll();
        Task<Property> GetById(int id);
        Task<Property> Create(Property property);
        Task<Property> Update(int id, Property property);
        Task<Property> Delete(int id);
    }
}
