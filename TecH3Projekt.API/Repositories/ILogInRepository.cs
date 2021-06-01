using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface ILogInRepository
    {
        Task<List<LogIn>> GetAll();
        Task<LogIn> GetById(int id);
        Task<LogIn> Create(LogIn logIn);
        Task<LogIn> Update(int id, LogIn logIn);
        Task<LogIn> Delete(int id);
    }
}
