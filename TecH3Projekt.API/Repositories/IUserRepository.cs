using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IUserRepository
    {

        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task<User> Update(int id, User user);
        Task<User> Delete(int id);
    }
}
