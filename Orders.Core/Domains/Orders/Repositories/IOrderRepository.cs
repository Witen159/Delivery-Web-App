using System.Collections.Generic;

namespace Orders.Core.Domains.Orders.Repositories
{
    public interface IOrderRepository
    {
        Order Get(string id);
        IEnumerable<Order> GetAll();
        void Creat(Order order);
        void Update(Order order);
        void Delete(string id);
    }
}