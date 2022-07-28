using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Orders.Core.Domains.Orders;
using Orders.Core.Domains.Orders.Services;
using Orders.Web.Models;

namespace Orders.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet]
        public IEnumerable<OrderModel> GetAll()
        {
            return _orderService.GetAll().Select(x => new OrderModel()
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
        
        [HttpPost]
        public void Create(OrderCreateModel model)
        {
            _orderService.Create(new Order()
            {
                SendersAddress = model.SendersAddress,
                SendersCity = model.SendersCity,
                RecipientsAddress = model.RecipientsAddress,
                RecipientsCity = model.RecipientsCity,
                OrderWeightKg = model.OrderWeightKg,
                PickupDate = model.PickupDate
            });
        }
    }
}