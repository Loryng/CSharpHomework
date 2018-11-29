using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderDemo
{
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public string Goods { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public OrderDetail()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderDetail(string id, string goods, double price, int quantity)
        {
            Id = id;
            Goods = goods;
            Price = price;
            Quantity = quantity;
        }
    }
}
