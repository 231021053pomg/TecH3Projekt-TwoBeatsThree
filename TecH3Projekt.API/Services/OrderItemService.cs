using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Projekt.API.Domain;
using TecH3Projekt.API.Repositories;

namespace TecH3Projekt.API.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository; //??
        }



        // GET ALL ORDER ITEMS
        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            var orderItem = await _orderItemRepository.GetAll();
            return orderItem;
        }


        // GET ORDER ITEM BY ID
        public async Task<OrderItem> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemRepository.GetById(id);
            return orderItem;
        }


        // CREATE ORDER ITEM
        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            orderItem = await _orderItemRepository.Create(orderItem);
            return orderItem;
        }


        // UPDATE ORDER ITEM
        public async Task<OrderItem> Update(int id, OrderItem orderItem)
        {
            await _orderItemRepository.Update(id, orderItem);
            return orderItem;
        }


        // DELETE ORDER ITEM
        public async Task<OrderItem> Delete(int id)
        {
            var orderItem = await _orderItemRepository.Delete(id);
            return orderItem;
        }
    }
}
