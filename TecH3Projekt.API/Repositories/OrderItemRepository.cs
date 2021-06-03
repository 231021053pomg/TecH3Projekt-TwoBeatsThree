using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Database;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TecH3ProjectDbContext _context;

        public OrderItemRepository(TecH3ProjectDbContext context)
        {
            _context = context;
        }



        //GETALL
        public async Task<List<OrderItem>> GetAll()
        {
            return await _context.OrderItem
                .Where(a => a.DeletedAt == null)
                .Include(a => a.ProductId) //??
                .ToListAsync();
        }

        //GETBYID
        public async Task<OrderItem> GetById(int id)
        {
            return await _context.OrderItem
                .Where(a => a.DeletedAt == null)
                .Include(a => a.ProductId)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        

        //CREATE
        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            orderItem.CreatedAt = DateTime.Now;
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        //UPDATE
        public async Task<OrderItem> Update(int id, OrderItem orderItem)
        {
            var editOrderItem = await _context.OrderItem.FirstOrDefaultAsync(a => a.Id == id);
            if (editOrderItem != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring

                editOrderItem.UpdatedAt = DateTime.Now;
                editOrderItem.Quantity = orderItem.Quantity;
                editOrderItem.SinglePrice = orderItem.SinglePrice;


                _context.OrderItem.Update(editOrderItem);
                await _context.SaveChangesAsync();
            }
            return editOrderItem;
        }

        //DELETE
        public async Task<OrderItem> Delete(int id)
        {
            var orderItem = await _context.OrderItem.FirstOrDefaultAsync(a => a.Id == id);
            if (orderItem != null)
            {
                orderItem.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return orderItem;
        }
    }
}
