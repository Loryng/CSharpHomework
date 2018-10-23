using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "赵四");

            Goods milk = new Goods(1, "牛奶", 6.9);
            Goods eggs = new Goods(2, "鸡蛋", 4.99);
            Goods apple = new Goods(3, "苹果", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddOrderDetail(orderDetails1);
            order1.AddOrderDetail(orderDetails2);
            order1.AddOrderDetail(orderDetails3);
            order2.AddOrderDetail(orderDetails2);
            order2.AddOrderDetail(orderDetails3);
            order3.AddOrderDetail(orderDetails3);

            OrderService os = new OrderService();
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "张三");
            Customer customer2 = new Customer(2, "赵四");

            Goods milk = new Goods(1, "牛奶", 6.9);
            Goods eggs = new Goods(2, "鸡蛋", 4.99);
            Goods apple = new Goods(3, "苹果", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddOrderDetail(orderDetails1);
            order1.AddOrderDetail(orderDetails2);
            order1.AddOrderDetail(orderDetails3);
            order2.AddOrderDetail(orderDetails2);
            order2.AddOrderDetail(orderDetails3);
            order3.AddOrderDetail(orderDetails3);

            OrderService os = new OrderService();
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void QueryOrderByIDTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void QueryOrdersByGoodsNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void QueryOrderByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOrdersByCustomerNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateOrderCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}