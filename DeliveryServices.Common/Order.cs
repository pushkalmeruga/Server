using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.Common
{
    public class Order
    {
        public int Quantity { get; set; }
        public float Distance { get; set; }
        public string Address { get; set; }
        public int FloorNum { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsGoldRatedCustomer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
