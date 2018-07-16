using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.Biz
{
    public class OrderService
    {
        DAL.OrderService _orderService;
        public decimal GetOrderPrice(Order order)
        {
            _orderService = new DAL.OrderService();
            return _orderService.GetOrderPrice(order);
        }

        public bool SaveOrder(Order order)
        {
            _orderService = new DAL.OrderService();
            return _orderService.SaveOrder(order);
        }
    }
}
