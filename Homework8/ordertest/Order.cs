using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    //[Serializable]
    public class Order
    {
        public Order()
        {

        }
        public List<OrderDetail> orderDetailsDict = new List<OrderDetail>();

        public Order(string orderId,Customer customer)
        {
            OrderID = orderId;
            Customer = customer;
            orderDetailsDict = new List<OrderDetail>();
        }
        public string OrderID { get; set; }
        public Customer Customer { get; set; }
        public string Phone { set; get; }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetailsDict.Contains(orderDetail))
                throw new Exception($"订单明细{orderDetail.OrderDetailID}已经存在！");
            else
                orderDetailsDict[Convert.ToInt32(orderDetail.OrderDetailID)] = orderDetail;
        }

        //public void RemoveOrderDetail(string orderDetailID)
        //{
        //    if (orderDetailsDict.Contains(orderDetail))
        //        orderDetailsDict.Remove(orderDetailID);
        //    else
        //        throw new Exception($"订单明细{orderDetailID}不存在！");
        //}
        public List<OrderDetail> QueryAllOrderDetails()
        {
            return orderDetailsDict;
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"订单序号:{OrderID}, 客户:({Customer})";
            orderDetailsDict.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
