using System.Collections.Generic;

namespace Orders.Core.Domains.Orders.Services
{
    public interface IOrderService
    {
        Order Get(int id);
        IEnumerable<Order> GetAll();
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}