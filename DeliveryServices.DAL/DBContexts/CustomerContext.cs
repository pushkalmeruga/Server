using DeliveryServices.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.DAL.DBContexts
{
    public class CustomerContext: DbContext
    {
        public CustomerContext():base("ZeoConnectionString")
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
