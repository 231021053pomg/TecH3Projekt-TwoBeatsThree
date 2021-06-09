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
    public class OrderController : ControllerBase
    {
        //inject service into controller.
        private readonly IOrderService _orderService;

        //ctor gets IOrderService, which allows for use of classes with IOrderService implemented.
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService; //connect functions.
        }

        //EXAMPLE: https://localhost:5001/api/order
        [HttpGet]//ALL
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                //throw new Exception("Planned fail...");//Used to fail Tests
                return Ok(orders);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/order/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpGet("{id}")]//GetById
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                if(order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/order
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            try
            {
                var newOrder = await _orderService.Create(order);
                if(newOrder == null)
                {
                    return BadRequest("Order ERROR...");
                }
                return Ok(newOrder);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/order/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Order order)
        {
            try
            {
                var updateOrder = await _orderService.Update(id, order);
                if(updateOrder == null)
                {
                    return BadRequest("Update Failed..");
                }
                return Ok(updateOrder);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //EXAMPLE: https://localhost:5001/api/order/id //Extra Id used to specify object for DELETE, PUT(update), or GetById.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteOrder = await _orderService.Delete(id);
                if(deleteOrder == null)
                {
                    return BadRequest("Delete Failed");
                }
                return Ok(deleteOrder);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
