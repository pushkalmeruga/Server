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
    public class CustomerController : ApiController
    {
        DeliveryServices.Biz.CustomerService customerService;

        [HttpPost]
        public int ValidateCustomer([FromBody] Customer customer)
        {
            customerService = new DeliveryServices.Biz.CustomerService();
            return customerService.ValidateCustomer(customer);
        }

        [HttpPost]
        public int SaveCustomer([FromBody] Customer customer)
        {
            customerService = new DeliveryServices.Biz.CustomerService();
            return customerService.SaveCustomer(customer);
        }
    }
}
