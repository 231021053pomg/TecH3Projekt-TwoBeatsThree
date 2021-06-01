using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TecH3ProjectDbContext _context;

        public UserRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }




        public async Task<List<User>> GetAll()
        {
            return await _context.User
                .Where(a => a.DeletedAt == null)
                .Include(a => a.LogInId)
                .ToListAsync();
        }


        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }


        public async Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
