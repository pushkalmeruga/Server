using DeliveryServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.Biz
{
    public class CustomerService
    {
        DAL.CustomerService _customerService;
        public int ValidateCustomer(Customer customer)
        {
            _customerService = new DAL.CustomerService();
            return _customerService.ValidateCustomer(customer);
        }

        public int SaveCustomer(Customer customer)
        {
            _customerService = new DAL.CustomerService();
            return _customerService.SaveCustomer(customer);
        }
    }
}
