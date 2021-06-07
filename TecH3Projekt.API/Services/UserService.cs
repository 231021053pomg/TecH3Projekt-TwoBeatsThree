using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }





        // GET ALL USERS
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users;
        }


        // GET USER BY ID
        public async Task<User> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            return user;
        }


        // CREATE USER
        public async Task<User> Create(User user)
        {
            user = await _userRepository.Create(user);
            return user;
        }


        // UPDATE USER
        public async Task<User> Update(int id, User user)
        {
            await _userRepository.Update(id, user);
            return user;
        }


        // DELETE USER
        public async Task<User> Delete(int id)
        {
            var user = await _userRepository.Delete(id);
            return user;
        }
    }
}
