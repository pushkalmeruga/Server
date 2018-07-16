using AutoMapper;
using DeliveryServices.DAL.Data;
using DeliveryServices.DAL.DBContexts;
using System;
using System.Collections.Generic;
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
            decimal orderPrice = 0M;
            Order o = mapper.Map<Order>(order);

            using (var ctx = new OrderContext())
            {
                Order od = ctx.Orders.Add(o);
                ctx.SaveChanges();
            }

            using (var ctx = new OrderContext())
            {
                var distance = new SqlParameter
                {
                    ParameterName = "distance",
                    Value = o.Distance
                };

                var floor = new SqlParameter
                {
                    ParameterName = "floor",
                    Value = o.FloorNum
                };
                
                orderPrice = Convert.ToDecimal(ctx.Database.SqlQuery<Decimal>("exec usp_GetOrderPrice @distance, @floor", new SqlParameter[] { distance, floor }).ToString());
            }

            return orderPrice;
        }
    }
}
