using System.Collections.Generic;
using Orders.Core.Domains.Orders.Repositories;

namespace Orders.Core.Domains.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Create(Order order)
        {
            _orderRepository.Create(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}