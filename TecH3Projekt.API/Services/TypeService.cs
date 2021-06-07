using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository) //??
        {
            _typeRepository = typeRepository;
        }




        // GET ALL TYPES
        public async Task<List<Type>> GetAllTypes()
        {
            var types = await _typeRepository.GetAll();
            return types;
        }


        // GET TYPE BY ID
        public async Task<Type> GetTypeById(int id)
        {
            var type = await _typeRepository.GetById(id);
            return type;
        }


        // CREATE TYPE
        public async Task<Type> Create(Type type)
        {
            type = await _typeRepository.Create(type);
            return type;
        }


        // UPDATE TYPE
        public async Task<Type> Update(int id, Type type)
        {
            await _typeRepository.Update(id, type);
            return type;
        }


        // DELETE TYPE
        public async Task<Type> Delete(int id)
        {
            var type = await _typeRepository.Delete(id);
            return type;
        }
    }
}
