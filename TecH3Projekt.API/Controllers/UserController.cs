using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;//
using TecH3Projekt.API.Services;//

namespace TecH3Projekt.API.Controllers
{
    [Route("api/[controller]")]//[controller = current controller(user)]
    [ApiController]
    public class UserController : ControllerBase
    {
        //inject service into controller.
        private readonly IUserService _userService;
        //ctor gets IUserService, which allows for use of classes with IUserService implemented.
        public UserController(IUserService userService)
        {
            _userService = userService;// connect functions.
        }

        //EXAMPLE: https://localhost:5001/api/user
        [HttpGet]//endpoint

        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        //EXAMPLE: https://localhost:5001/api/user
        [HttpPost]
        public async Task<IActionResult>Create(User user)
        {
            var newUser = await _userService.Create(user);
            return Ok(newUser);
        }

    }
}
