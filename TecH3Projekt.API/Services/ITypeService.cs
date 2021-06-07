using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Services
{
    public interface ITypeService
    {
        Task<List<Type>> GetAllTypes();
        Task<Type> GetTypeById(int id);
        Task<Type> Create(Type type);
        Task<Type> Update(int id, Type type);
        Task<Type> Delete(int id);
    }
}
