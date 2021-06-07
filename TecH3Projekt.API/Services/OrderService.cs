using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        // GET ALL ORDERS
        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }


        // GET ORDER BY ID
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return order;
        }


        // CREATE ORDER
        public async Task<Order> Create(Order order)
        {
            order = await _orderRepository.Create(order);
            return order;
        }


        // UPDATE ORDER
        public async Task<Order> Update(int id, Order order)
        {
            await _orderRepository.Update(id, order);
            return order;
        }


        // DELETE ORDER
        public async Task<Order> Delete(int id)
        {
            var order = await _orderRepository.Delete(id);
            return order;
        }
    }
}
