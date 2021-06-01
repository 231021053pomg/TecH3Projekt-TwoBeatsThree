using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class LogInRepository : ILogInRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public LogInRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }




        public async Task<LogIn> Create(LogIn logIn)
        {
            LogIn.CreatedAt = DateTime.Now;
            _context.LogIn.Add(logIn);
            await _context.SaveChangesAsync();
            return logIn;
        }

        public Task<LogIn> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LogIn>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LogIn> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LogIn> Update(int id, LogIn logIn)
        {
            throw new NotImplementedException();
        }
    }
}
