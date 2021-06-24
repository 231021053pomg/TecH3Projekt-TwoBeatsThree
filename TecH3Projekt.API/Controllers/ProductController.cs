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
    public class ProductController : ControllerBase
    {
      
        private readonly IProductService _productService; //inject service into controller.
        //ctor gets IProductService, which allows for use of classes with IProductService implemented.
        public ProductController(IProductService productService) //
        {
            _productService = productService; //connect readonly
        }






        //EXAMPLE: https://localhost:5001/api/product
        [HttpGet]//getALL
        public async Task<IActionResult> GetAll()    //---------------------------
        {
            try
            {
                var products = await _productService.GetAllProducts(); //fra product service
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(products);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/product/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)    //---------------------------
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if(product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/product/typeID //Extra Id used to specify object for DELETE, PUT(update), or GetById/ GetByType.
        [HttpGet("Category/{id}")]//GetByType
        public async Task<IActionResult> GetByType([FromRoute] int id)    //---------------------------
        {
            try
            {
                var products = await _productService.GetProductByType(id);
                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/product
        [HttpPost] //Create
        public async Task<IActionResult> Create(Product product)     //---------------------------
        {
            try
            {
                var newProduct = await _productService.Create(product);
                if(newProduct == null) //hvis den ny product ikke findes returner den et messege med product error
                {
                    return BadRequest("Product ERROR..");
                }
                return Ok(newProduct);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/product/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpPut("{id}")] //Update
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product product)    //---------------------------
        {
            try
            {
                var updateProduct = await _productService.Update(id, product);
                if(updateProduct == null)
                {
                    return BadRequest("Update failed..");
                }
                return Ok(updateProduct);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/login/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpDelete("{id}")] //Delete
        public async Task<IActionResult> Delete([FromRoute] int id)    //---------------------------
        { 
            try
            {
                var deleteProduct = await _productService.Delete(id);
                if(deleteProduct == null)
                {
                    return BadRequest("Delete Failed..");
                }
                return Ok(deleteProduct);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
