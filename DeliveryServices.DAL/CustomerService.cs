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
        public Common.Customer ValidateCustomer(Common.Customer customer)
        {
            Customer cust = mapper.Map<Customer>(customer);

            using (var ctx = new CustomerContext())
            {
                Customer cus = ctx.Customers.Where(x => x.Username == cust.Username && x.Password == cust.Password).FirstOrDefault();
            }

            return mapper.Map<Common.Customer>(cust);
        }

        public Common.Customer SaveCustomer(Common.Customer customer)
        {
            Customer cust = mapper.Map<Customer>(customer);

            using (var ctx = new CustomerContext())
            {
                Customer cus = ctx.Customers.Add(cust);
                int k = ctx.SaveChanges();
            }

            return mapper.Map<Common.Customer>(cust);
        }

    }
}
