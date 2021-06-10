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
    public class TypeController : ControllerBase
    {
        //inject service into controller.
        private readonly ITypeService _typeService;

        //ctor gets ILogInService, which allows for use of classes with ILogInService implemented.
        public TypeController( ITypeService typeService)
        {
            _typeService = typeService;
        }
        //EXAMPLE: https://localhost:5001/api/type
        [HttpGet]//ALL
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var proTypes = await _typeService.GetAllTypes();
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(proTypes);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/type/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var proType = await _typeService.GetTypeById(id);
                if(proType == null)
                {
                    return NotFound();
                }
                return Ok(proType);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/type
        [HttpPost]
        public async Task<IActionResult> Create(Domain.Type proType)
        {
            try
            {
                var newProType = await _typeService.Create(proType);
                if(newProType == null)
                {
                    return BadRequest("Type ERROR..");
                }
                return Ok(newProType);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/type/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Domain.Type proType)
        {
            try
            {
                var updateProType = await _typeService.Update(id, proType);
                if(updateProType == null)
                {
                    return BadRequest("Update Failed..");
                }
                return Ok(updateProType);
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
                var deleteProType = await _typeService.Delete(id);
                if(deleteProType == null)
                {
                    return BadRequest("Delete Failed..");
                }
                return Ok(deleteProType);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
