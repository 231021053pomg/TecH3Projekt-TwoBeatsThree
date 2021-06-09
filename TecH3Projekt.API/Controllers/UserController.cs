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
        [HttpGet]//ALL
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(users);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        //EXAMPLE: https://localhost:5001/api/user/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/user
        [HttpPost]
        public async Task<IActionResult>Create(User user)
        {
            try
            {
                var newUser = await _userService.Create(user);
                if (newUser == null)
                {
                    return BadRequest("User ERROR....");
                }
                return Ok(newUser);
            }
           
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                var updateUser = await _userService.Update(id, user);
                if(updateUser == null)
                {
                    return BadRequest("Update Failed.");
                }
                return Ok(updateUser);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteUser = await _userService.Delete(id);
                if(deleteUser == null)
                {
                    return BadRequest("Delete Failed..");
                }
                return Ok(deleteUser);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
