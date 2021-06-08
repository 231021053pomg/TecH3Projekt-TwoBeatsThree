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

        //ctor gets IUserService, which allows for use of classes with IUserService implemented.
        public LogInController(ILogInService loginService)
        {
            _loginService = loginService;// connect functions.
        }

        //EXAMPLE: https://localhost:5001/api/login
        [HttpGet]//endpoint
        public async Task<IActionResult> GetAll()
        {
            var logins = await _loginService.GetAllLogIns();
            return Ok(logins);
        }
        //EXAMPLE: https://localhost:5001/api/login
        [HttpPost]
        public async Task<IActionResult> Create(LogIn login)
        {
            var newLogIn = await _loginService.Create(login);
            return Ok(newLogIn);
        }
    }
}
