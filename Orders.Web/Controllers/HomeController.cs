using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.Core.Domains.Orders;
using Orders.Core.Domains.Orders.Services;
using Orders.Web.Models;

namespace Orders.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            var viewModel = _orderService.GetAll().Select(x => new OrderModel()
            {
                OrderNumber = x.OrderNumber,
                SendersAddress = x.SendersAddress,
                SendersCity = x.SendersCity,
                RecipientsAddress = x.RecipientsAddress,
                RecipientsCity = x.RecipientsCity,
                OrderWeightKg = x.OrderWeightKg,
                PickupDate = x.PickupDate
            });
            
            return View(viewModel);
        }

        public IActionResult MakeOrder()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult MakeOrder(OrderCreateModel order)
        {
            _orderService.Create(new Order()
            {
                SendersAddress = order.SendersAddress,
                SendersCity = order.SendersCity,
                RecipientsAddress = order.RecipientsAddress,
                RecipientsCity = order.RecipientsCity,
                OrderWeightKg = order.OrderWeightKg,
                PickupDate = order.PickupDate
            });
            
            return RedirectToAction("Orders");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}