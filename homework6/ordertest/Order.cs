using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    [Serializable]
    public class Order
    {
        public Order()
        {

        }
        private Dictionary<uint, OrderDetail> orderDetailsDict;

        public Order(uint orderId,Customer customer)
        {
            OrderID = orderId;
            Customer = customer;
            orderDetailsDict = new Dictionary<uint, OrderDetail>();
        }
        public uint OrderID { get; set; }
        public Customer Customer { get; set; }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetailsDict.ContainsKey(orderDetail.OrderDetailID))
                throw new Exception($"订单明细{orderDetail.OrderDetailID}已经存在！");
            else
                orderDetailsDict[orderDetail.OrderDetailID] = orderDetail;
        }
        public void RemoveOrderDrtail(uint orderDetailID)
        {
            if (orderDetailsDict.ContainsKey(orderDetailID))
                orderDetailsDict.Remove(orderDetailID);
            else
                throw new Exception($"订单明细{orderDetailID}不存在！");
        }
         public List<OrderDetail> QueryAllOrderDetails()
        {
            return orderDetailsDict.Values.ToList();
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"订单序号:{OrderID}, 客户:({Customer})";
            orderDetailsDict.Values.ToList().ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
