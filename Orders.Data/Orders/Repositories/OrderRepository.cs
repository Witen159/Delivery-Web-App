using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Orders.Core.Domains.Orders;
using Orders.Core.Domains.Orders.Repositories;

namespace Orders.Data.Orders.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            var entity = _context.Orders.AsNoTracking().FirstOrDefault(x => x.OrderNumber == id);

            if (entity == null)
            {
                return null;
            }

            return new Order()
            {
                OrderNumber = entity.OrderNumber,
                SendersAddress = entity.SendersAddress,
                SendersCity = entity.SendersCity,
                RecipientsAddress = entity.RecipientsAddress,
                RecipientsCity = entity.RecipientsCity,
                OrderWeightKg = entity.OrderWeightKg,
                PickupDate = entity.PickupDate
            };
        }

        public IEnumerable<Order> GetAll()
        {
            var users = _context.Orders.AsNoTracking().ToList();
            
            return users.Select(x => new Order()
            {
                OrderNumber = x.OrderNumber,
                SendersAddress = x.SendersAddress,
                SendersCity = x.SendersCity,
                RecipientsAddress = x.RecipientsAddress,
                RecipientsCity = x.RecipientsCity,
                OrderWeightKg = x.OrderWeightKg,
                PickupDate = x.PickupDate
            });
        }

        public void Create(Order order)
        {
            var entity = new OrderEntity()
            {
                SendersAddress = order.SendersAddress,
                SendersCity = order.SendersCity,
                RecipientsAddress = order.RecipientsAddress,
                RecipientsCity = order.RecipientsCity,
                OrderWeightKg = order.OrderWeightKg,
                PickupDate = order.PickupDate
            };

            _context.Orders.Add(entity);
        }

        public void Update(Order order)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.OrderNumber == order.OrderNumber);

            if (entity != null)
            {
                entity.SendersAddress = order.SendersAddress;
                entity.SendersCity = order.SendersCity;
                entity.RecipientsAddress = order.RecipientsAddress;
                entity.RecipientsCity = order.RecipientsCity;
                entity.OrderWeightKg = order.OrderWeightKg;
                entity.PickupDate = order.PickupDate;
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.OrderNumber == id);

            if (entity != null)
            {
                _context.Orders.Remove(entity);
            }
        }
    }
}