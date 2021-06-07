using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface ILogInService
    {
        Task<List<LogIn>> GetAllLogIns();
        Task<LogIn> GetLogInById(int id);
        Task<LogIn> Create(LogIn logIn);
        Task<LogIn> Update(int id, LogIn logIn);
        Task<LogIn> Delete(int id);
    }
}
