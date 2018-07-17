using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.Biz
{
    public class OrderService
    {
        DAL.OrderService _orderService;

        DAL.CustomerService _customerService;

        private decimal basePrice = Convert.ToDecimal(ConfigurationManager.AppSettings["BasePrice"]);

        public decimal GetOrderPrice(Order order)
        {
            _orderService = new DAL.OrderService();

            _customerService = new DAL.CustomerService();

            bool isNewCustomer = _orderService.IsNewCustomer(order.CustomerId);

            Customer customer = _customerService.GetCustomer(order.CustomerId);

            var orderDate = order.OrderDate.DayOfWeek;

            if (!string.IsNullOrWhiteSpace(order.Coupon))
            {
                return order.Quantity * Convert.ToDecimal(ConfigurationManager.AppSettings["CouponCost"]);
            }
            else if (isNewCustomer)
            {
                return order.Quantity * Convert.ToDecimal(ConfigurationManager.AppSettings["NewCustomer"]);
            }
            else if (customer.IsGoldRatedCustomer && !isNewCustomer)
            {
                return order.Quantity * Convert.ToDecimal(ConfigurationManager.AppSettings["GoldRatedCustomerCost"]);
            }
            else if (orderDate == DayOfWeek.Saturday || orderDate == DayOfWeek.Sunday)
            {
                return order.Quantity * Convert.ToDecimal(ConfigurationManager.AppSettings["WeekendCost"]);
            }
            else
            {
                return _orderService.GetOrderPrice(order) + (basePrice * order.Quantity);
            }
        }

        public bool SaveOrder(Order order)
        {
            _orderService = new DAL.OrderService();
            return _orderService.SaveOrder(order);
        }
    }
}
