using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAllOrderItems();
        Task<OrderItem> GetOrderItemById(int id);
        Task<OrderItem> Create(OrderItem orderItem);
        Task<OrderItem> Update(int id, OrderItem orderItem);
        Task<OrderItem> Delete(int id);
    }
}
