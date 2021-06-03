using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public OrderRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }


        //GETALL
        public async Task<List<Order>> GetAll()
        {
            return await _context.Order
                .Where(a => a.DeletedAt == null)
                //.Include(a => a.LogInId)
                .ToListAsync();
        }

        //GETBYID
        public async Task<Order> GetById(int id)
        {
            return await _context.Order
                .Where(a => a.DeletedAt == null)
                .Include(a => a.LogInId)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        //Create
        public async Task<Order> Create(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }


        //Update
        public async Task<Order> Update(int id, Order order)
        {
            var editOrder = await _context.Order.FirstOrDefaultAsync(a => a.Id == id);
            if (editOrder != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editOrder.UpdatedAt = DateTime.Now;
                editOrder.LogInId = order.LogInId; //??


                _context.Order.Update(editOrder);
                await _context.SaveChangesAsync();
            }
            return editOrder;
        }

        //Delete
        public async Task<Order> Delete(int id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(a => a.Id == id);
            if (order != null)
            {
                order.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return order;
        }
    }
}
