using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Services;

namespace TecH3Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;
        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService; 
        }

        // https://localhost:5001/api/picture
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pictures = await _pictureService.GetAllPictures();
                //throw new Exception("Should fail");
                return Ok(pictures);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }



        // https://localhost:5001/api/picture
        [HttpPost]
        public async Task<IActionResult> Create (Picture picture)
        {
            try
            {
                throw new Exception("Vi tester lige");
                var newPicture = await _pictureService.Create(picture);
                return Ok(newPicture);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        // GET https://localhost:5001/api/picture/1
        [HttpGet("{id}")]   //   "{id}/{something}/evenmore"  )
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] Picture picture)
        {
            try
            {
                var updatePicture = await _pictureService.Update(id, picture);
                return Ok(updatePicture);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
