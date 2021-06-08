using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Repositories
{
    public interface ITypeRepository
    {
        // Get all Type objects
        Task<List<Domain.Type>> GetAll();

        //Get Type object by id.
        Task<Domain.Type> GetById(int id);

        //Create Type
        Task<Domain.Type> Create(Domain.Type type);

        //Update Type
        Task<Domain.Type> Update(int id, Domain.Type type);

        //Delete Type
        Task<Domain.Type> Delete(int id);
    }
}
