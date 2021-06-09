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
    public class PropertyController : ControllerBase
    {
        //inject service into controller.
        private readonly IPropertyService _propertyService;

        //ctor gets IPropertyService, which allows for use of classes with IPropertyService implemented.
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        //EXAMPLE: https://localhost:5001/api/property
        [HttpGet]//ALL
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var properties = await _propertyService.GetAllProperties();
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(properties);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/property/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var property = await _propertyService.GetPropertyById(id);
                if(property == null)
                {
                    return NotFound();
                }
                return Ok(property);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/property
        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            try
            {
                var newProperty = await _propertyService.Create(property);
                if(newProperty == null)
                {
                    return BadRequest("Property ERROR....");
                }
                return Ok(property);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        //[HttpPut("{id}")]
    }
}
