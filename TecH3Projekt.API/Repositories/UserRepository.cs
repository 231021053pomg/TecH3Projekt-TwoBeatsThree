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



        //GETALL
        public async Task<List<User>> GetAll()
        {
            return await _context.User
                .Where(a => a.DeletedAt == null)
                .Include(a => a.LogIn)
                .ToListAsync();
        }

        //GETBYID
        public async Task<User> GetById(int id)
        {
            return await _context.User
                .Where(a => a.DeletedAt == null)
                .Include(a => a.LogIn)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async Task<User> Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        //UPDATE
        public async Task<User> Update(int id, User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(a => a.Id == id);
            if (editUser != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editUser.UpdatedAt = DateTime.Now;
                editUser.FirstName = user.FirstName;
                editUser.LastName = user.LastName;
                editUser.Address = user.Address;
                editUser.PostNr = user.PostNr;
                editUser.City = user.City;


                _context.User.Update(editUser);
                await _context.SaveChangesAsync();
            }
            return editUser;
        }

        //DELETE
        public async Task<User> Delete(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(a => a.Id == id);
            if (user != null)
            {
                user.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return user;
        }

    }
}
