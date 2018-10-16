using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    // 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    class OrderService
    {
        private Dictionary<uint, Order> orderDict;
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }
        //添加订单
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderID))
                throw new Exception($"订单{order.OrderID}已经存在！");
            else
                orderDict[order.OrderID] = order;
        }
        //删除订单
        public void RemoveOrder(uint orderID)
        {
            
            var A = orderDict.Values.Where(a => a.OrderID == orderID).Select(a => a);
           if(A!=null)
            {
                orderDict.Remove(orderID);
            }
        }

        public List<Order>QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        //查询订单
        public List<Order>QueryOrderByID(uint orderID)
        {
            List<Order> result = new List<Order>();
            var A = orderDict.Values.Where(a => a.OrderID == orderID).Select(a => a);
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
            foreach (Order order in orderDict.Values.ToList())
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
            foreach(Order order in orderDict.Values.ToList())
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
            orderDict.Values.ToList().ForEach(order =>
            {
                if (order.Customer.CustomerName == customerName)
                    result.Add(order);
            });
            return result;
        }

        public void UpdateOrderCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"订单{orderId}不存在！");
            }
        }
    }
}
