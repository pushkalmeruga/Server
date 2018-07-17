using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DeliveryServices_Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        DeliveryServices.Biz.OrderService orderService;

        [HttpPost]
        public bool SaveOrder([FromBody] Order order)
        {
            orderService = new DeliveryServices.Biz.OrderService();
            return orderService.SaveOrder(order);
        }

        [HttpPost]
        public decimal GetOrderPrice([FromBody] Order order)
        {
            orderService = new DeliveryServices.Biz.OrderService();
            return orderService.GetOrderPrice(order);
        }
    }
}
