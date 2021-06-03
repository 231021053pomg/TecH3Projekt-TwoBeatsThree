using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> GetById(int id);
        Task<OrderItem> Create(OrderItem orderItem);
        Task<OrderItem> Update(int id, OrderItem orderItem);
        Task<OrderItem> Delete(int id);
    }
}
