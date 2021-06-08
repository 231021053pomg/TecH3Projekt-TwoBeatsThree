using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }




        // GET ALL PROPERTIES
        public async Task<List<Property>> GetAllProperties()
        {
            var property = await _propertyRepository.GetAll();
            return property;
        }


        // GET PROPERTY BY ID
        public async Task<Property> GetPropertyById(int id)
        {
            var property = await _propertyRepository.GetById(id);
            return property;
        }


        // CREATE PROPERTY
        public async Task<Property> Create(Property property)
        {
            property = await _propertyRepository.Create(property);
            return property;
        }


        // UPDATE PROPERTY
        public async Task<Property> Update(int id, Property property)
        {
            await _propertyRepository.Update(id, property);
            return property;
        }


        //// DELETE PROPERTY
        //public async Task<Property> Delete(int id)
        //{
        //    var property = await _propertyRepository.Delete();
        //    return property;
        //}
    }
}
