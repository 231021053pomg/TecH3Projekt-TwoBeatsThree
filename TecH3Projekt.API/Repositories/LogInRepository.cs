using Microsoft.EntityFrameworkCore;//
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


        //GETALL
        public async Task<List<LogIn>> GetAll()
        {
            return await _context.LogIn
                .Where(a => a.DeletedAt == null)
                .Include(a => a.UserProfile)
                .ToListAsync();
        }

        //GETBYID
        public async Task<LogIn> GetById(int id)
        {
            return await _context.LogIn
                .Where(a => a.DeletedAt == null)
                .Include(a => a.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //CREATE
        public async Task<LogIn> Create(LogIn logIn)
        {
            logIn.CreatedAt = DateTime.Now;
            _context.LogIn.Add(logIn);
            await _context.SaveChangesAsync();
            return logIn;
        }

        //UPDATE
        public async Task<LogIn> Update(int id, LogIn logIn)
        {
            var editLogIn = await _context.LogIn.FirstOrDefaultAsync(a => a.Id == id);
            if (editLogIn != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editLogIn.UpdatedAt = DateTime.Now;
                editLogIn.Email = logIn.Email;
                editLogIn.Password = logIn.Password;
                editLogIn.IsAdmin = logIn.IsAdmin;


                _context.LogIn.Update(editLogIn);
                await _context.SaveChangesAsync();
            }
            return editLogIn;
        }

        //DELETE
        public async Task<LogIn> Delete(int id)
        {
            var logIn = await _context.LogIn.FirstOrDefaultAsync(a => a.Id == id);
            if (logIn != null)
            {
                logIn.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return logIn;
        }

    }
}
