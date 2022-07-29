using System.Collections.Generic;
using Orders.Core.Domains.Orders.Repositories;

namespace Orders.Core.Domains.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
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
            _unitOfWork.SaveChanges();
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}