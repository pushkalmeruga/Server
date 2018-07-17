using AutoMapper;
using DeliveryServices.DAL.Data;
using DeliveryServices.DAL.DBContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.DAL
{
    public class OrderService
    {
        IMapper mapper;
        public OrderService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, Common.Order>();
                cfg.CreateMap<Common.Order, Order>();

            });

            mapper = config.CreateMapper();
        }

        public bool SaveOrder(Common.Order order)
        {
            Order o = mapper.Map<Order>(order);

            using (var ctx = new OrderContext())
            {
                Order od = ctx.Orders.Add(o);
                ctx.SaveChanges();
            }

            return true;
        }

        public decimal GetOrderPrice(Common.Order order)
        {
            SqlParameter orderPrice = new SqlParameter { Value = 0 };

            Order o = mapper.Map<Order>(order);

            using (var ctx = new OrderContext())
            {
                orderPrice = new SqlParameter();

                orderPrice.ParameterName = "@totalcost";

                orderPrice.Direction = ParameterDirection.Output;

                orderPrice.SqlDbType = SqlDbType.Money;

                var res = ctx.Database.ExecuteSqlCommand("usp_GetOrderPrice @distance, @floor, @totalcost OUT",
                                                                new SqlParameter("@distance", o.Distance),
                                                                new SqlParameter("@floor", o.FloorNum),
                                                                orderPrice);
            }

            return Convert.ToDecimal(orderPrice.Value);
        }

        public bool IsNewCustomer(int customerId)
        {
            bool result = false;

            using (var ctx = new OrderContext())
            {
                result = ctx.Orders.Any(c => c.CustomerId == customerId);
            }

            return !result;
        }
    }
}
