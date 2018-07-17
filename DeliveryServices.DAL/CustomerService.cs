using DeliveryServices.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using AutoMapper;
using DeliveryServices.DAL.DBContexts;

namespace DeliveryServices.DAL
{
    public class CustomerService
    {
        IMapper mapper;
        public CustomerService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, Common.Customer>();
                cfg.CreateMap<Common.Customer, Customer>();

            });

            mapper = config.CreateMapper();
        }
        public int ValidateCustomer(Common.Customer customer)
        {
            int customerId = 0;

            Customer cust = mapper.Map<Customer>(customer);

            using (var ctx = new CustomerContext())
            {
                Customer cus = ctx.Customers.Where(x => x.Username == cust.Username && x.Password == cust.Password).FirstOrDefault();
                if (cus != null)
                    customerId = cus.CustomerId;
            }

            return customerId;
        }

        public int SaveCustomer(Common.Customer customer)
        {
            int customerId = 0;

            Customer cust = mapper.Map<Customer>(customer);

            using (var ctx = new CustomerContext())
            {
                if(!ctx.Customers.Any(x => x.Username == cust.Username))
                {
                    ctx.Customers.Add(cust);
                    int result = ctx.SaveChanges();

                    customerId = ctx.Customers.Where(x => x.Username == cust.Username).FirstOrDefault().CustomerId;
                }                
            }

            return customerId;
        }

        public Common.Customer GetCustomer(int customerId)
        {
            Common.Customer customer;
            using (var ctx = new CustomerContext())
            {
                customer = mapper.Map<Common.Customer>(ctx.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault());
            }

            return customer;
        }

    }
}
