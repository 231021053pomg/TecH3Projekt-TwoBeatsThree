using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class LogInService : ILogInService
    {
        private readonly ILogInRepository _logInRepository;

        public LogInService(ILogInRepository logInRepository)
        {
            _logInRepository = logInRepository;
        }



        // GET ALL LOGINS
        public async Task<List<LogIn>> GetAllLogIns()
        {
            var logIns = await _logInRepository.GetAll();
            return logIns;
        }


        // GET LOGIN BY ID
        public async Task<LogIn> GetLogInById(int id)
        {
            var logIn = await _logInRepository.GetById(id);
            return logIn;
        }


        // CREATE LOGIN
        public async Task<LogIn> Create(LogIn logIn)
        {
            logIn = await _logInRepository.Create(logIn);
            return logIn;
        }


        // UPDATE LOGIN
        public async Task<LogIn> Update(int id, LogIn logIn)
        {
            await _logInRepository.Update(id, logIn);
            return logIn;
        }


        // DELETE LOGIN
        public async Task<LogIn> Delete(int id)
        {
            var logIn = await _logInRepository.Delete(id);
            return logIn;
        }
    }
}
