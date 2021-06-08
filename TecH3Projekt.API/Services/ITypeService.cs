using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Services
{
    public interface ITypeService
    {
        Task<List<Domain.Type>> GetAllTypes();
        Task<Domain.Type> GetTypeById(int id);
        Task<Domain.Type> Create(Domain.Type type);
        Task<Domain.Type> Update(int id, Domain.Type type);
        Task<Domain.Type> Delete(int id);
    }
}
