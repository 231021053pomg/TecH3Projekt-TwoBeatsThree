using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;

namespace TecH3Projekt.API.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Create(Order order);
        Task<Order> Update(int id, Order order);
        Task<Order> Delete(int id);
    }
}
