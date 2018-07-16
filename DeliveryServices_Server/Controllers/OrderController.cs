using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryServices_Server.Controllers
{
    public class OrderController : ApiController
    {
        DeliveryServices.Biz.OrderService orderService;

        [HttpGet]
        public bool SaveOrder(Order order)
        {
            orderService = new DeliveryServices.Biz.OrderService();
            return orderService.SaveOrder(order);
        }

        [HttpGet]
        public decimal SaveCustomer(Order order)
        {
            order = new Order()
            {
                FloorNum = 6,
                Distance = 50  
            };
            orderService = new DeliveryServices.Biz.OrderService();
            return orderService.GetOrderPrice(order);
        }
    }
}
