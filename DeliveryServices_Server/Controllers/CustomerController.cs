using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryServices_Server.Controllers
{
    public class CustomerController : ApiController
    {
        DeliveryServices.Biz.CustomerService customerService;
        [HttpGet]
        public Customer ValidateCustomer(Customer customer)
        {
            customerService = new DeliveryServices.Biz.CustomerService();
            return customerService.ValidateCustomer(customer);
        }

        [HttpGet]
        public Customer SaveCustomer(Customer customer)
        {
            customerService = new DeliveryServices.Biz.CustomerService();
            return customerService.SaveCustomer(customer);
        }
    }
}
