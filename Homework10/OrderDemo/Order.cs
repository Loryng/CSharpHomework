using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderDemo
{
    public class Order
    {
        [Key]
        public String Id { get; set; }
        public String Customer { get; set; }
        public List<OrderDetail> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }

        public Order(string id, string customer,  List<OrderDetail> details)
        {
            Id = id;
            Customer = customer;
            Details = details;
        }
    }
}
