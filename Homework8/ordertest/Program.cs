using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "张三");
                Customer customer2 = new Customer(2, "赵四");

                Goods milk = new Goods(1, "牛奶", 6.9);
                Goods eggs = new Goods(2, "鸡蛋", 4.99);
                Goods apple = new Goods(3, "苹果", 5.59);

                OrderDetail orderDetails1 = new OrderDetail("1", apple, 8);
                OrderDetail orderDetails2 = new OrderDetail("2", eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail("3", milk, 1);

                Order order1 = new Order("1", customer1);
                Order order2 = new Order("2", customer2);
                Order order3 = new Order("3", customer2);
                order1.AddOrderDetail(orderDetails1);
                order1.AddOrderDetail(orderDetails2);
                order1.AddOrderDetail(orderDetails3);
                order2.AddOrderDetail(orderDetails2);
                order2.AddOrderDetail(orderDetails3);
                order3.AddOrderDetail(orderDetails3);

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("得到所有订单");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("按照顾客姓名查询：赵四");
                orders = os.GetOrdersByCustomerName("赵四");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("按照商品查询:'苹果'");
                orders = os.QueryOrdersByGoodsName("苹果");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("移除订单（2号）并查询订单");
                os.RemoveOrder("2");
                orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                //os.Export();
                //os.Import();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
