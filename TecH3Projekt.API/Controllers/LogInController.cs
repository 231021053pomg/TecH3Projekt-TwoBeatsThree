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
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        //inject service into controller.
        private readonly ILogInService _loginService;

        //ctor gets ILogInService, which allows for use of classes with ILogInService implemented.
        public LogInController(ILogInService loginService)
        {
            _loginService = loginService;// connect functions.
        }

        //EXAMPLE: https://localhost:5001/api/login
        [HttpGet]//ALL
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var logins = await _loginService.GetAllLogIns();
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(logins);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
           
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var login = await _loginService.GetLogInById(id);
                if(login == null)
                {
                    return NotFound();
                }
                return Ok(login);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/login
        [HttpPost]
        public async Task<IActionResult> Create(LogIn login)
        {
            try
            {
                var newLogIn = await _loginService.Create(login);
                if (newLogIn == null)
                {
                    return BadRequest("Login ERROR.... ");
                }
                return Ok(newLogIn);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LogIn login)
        {
            try
            {
                var updateLogIn = await _loginService.Update(id, login);
                if(updateLogIn == null)
                {
                    return BadRequest("Update Failed.");
                }
                return Ok(updateLogIn);
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
                var deleteLogin = await _loginService.Delete(id);
                if(deleteLogin == null)
                {
                    return BadRequest("Delete Failed");
                }
                return Ok(deleteLogin);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
