using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServices.DAL.Data
{

    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Distance { get; set; }
        public string Address { get; set; }
        public int FloorNum { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsGoldRatedCustomer { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
