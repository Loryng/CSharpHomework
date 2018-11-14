using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ordertest
{
    // 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    public class OrderService
    {
        public List<Order> orderDict = new List<Order>();
        public OrderService()
        {
            orderDict = new List<Order>();
        }
        //添加订单
        public void AddOrder(Order order)
        {
            if (orderDict.Contains(order))
                throw new Exception($"订单{order.OrderID}已经存在！");
            else
                this.orderDict.Add(order);
        }
        //删除订单
        public void RemoveOrder(string orderID)
        {
            
            var A = orderDict.Where(a => a.OrderID == orderID).Select(a => a);
           if(A!=null)
            {
                orderDict.RemoveAll(a => a.OrderID == orderID);
            }
        }
        //查询订单
        public List<Order>QueryAllOrders()
        {
            return orderDict;
        }

        public List<Order>QueryOrderByID(string orderID)
        {
            List<Order> result = new List<Order>();
            var A = orderDict.Where(a => a.OrderID == orderID).Select(a => a);
            foreach(var B in A )
            {
                result.Add(B);
            }
            //if(orderDict.ContainsKey(orderID))
            //{
            //    result.Add(orderDict[orderID]);
            //}
            return result;
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict)
            {
                List<OrderDetail> orderDetailsList = order.QueryAllOrderDetails();
                foreach (OrderDetail od in orderDetailsList)
                {
                    if (od.Goods.GoodsName == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Order> QueryOrderByName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach(Order order in orderDict)
            {
                List<OrderDetail> orderDetailsList = order.QueryAllOrderDetails();
                foreach(OrderDetail od in orderDetailsList)
                {
                    if(od.Goods.GoodsName==goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }
        public List<Order>GetOrdersByCustomerName(string customerName)
        {
            List<Order> result = new List<Order>();
            orderDict.ForEach(order =>
            {
                if (order.Customer.CustomerName == customerName)
                    result.Add(order);
            });
            return result;
        }

        public void UpdateOrderCustomer(string orderId, Customer newCustomer)
        {
            if (orderDict.Equals(orderId))
            {
                orderDict[Convert.ToInt32(orderId)].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"订单{orderId}不存在！");
            }
        }

        //public void Export()
        //{
        //    List<Order> orders = new List<Order>();
        //    foreach(Order order in orderDict)
        //    {
        //        orders.Add(order);
        //    }
        //    XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
        //    using (FileStream fs = new FileStream("fs.xlm", FileMode.Create))
        //    {
        //        xml.Serialize(fs, orders);
        //    }
        //}

        //XML序列化
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "Order_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".xml";
            Export("Order.xml");
            return fileName;
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orderDict);
            }
        }

        public void Import()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("fs.xml", FileMode.Open))
            {
                List<Order> or = (List<Order>)xml.Deserialize(fs);
            }
        }
    }
}
