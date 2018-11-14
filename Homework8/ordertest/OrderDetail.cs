using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    //[Serializable]
    public class OrderDetail
    {
        public OrderDetail()
        {

        }
        public OrderDetail(Goods goods,uint  quantity)
        {
            Goods = goods;
            Quantity = quantity;
        }
        public OrderDetail(string orderdetailID, Goods goods, uint quantity)
        {
            OrderDetailID = orderdetailID;
            Goods = goods;
            Quantity = quantity;
        }

        public string OrderDetailID { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }

        public override string ToString()
        {
            string result = "";
            result += $"明细序号:{OrderDetailID}    ";
            result += Goods + $",数量:{Quantity}";
            return result;
        }
    }
}
