using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    //[Serializable]
    public class Goods
    {
        public Goods()
        {

        }
        public Goods(string name)
        {
            GoodsName = name;
        }
        public double goodsValue;

        public Goods(int id,string name,double value)
        {
            GoodsID = id;
            GoodsName = name;
            GoodsValue = value;
        }

        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
      
        public double GoodsValue
        {
            get{ return goodsValue; }
            set {
                if (value >= 0)
                    goodsValue = value;
                else
                    throw new ArgumentOutOfRangeException("价格必须为正数！");
            }
        }

        public override string ToString()
        {
            return $"{GoodsName}，{GoodsValue}￥";
        }
    }
}
