using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    class Goods
    {
        private double goodsValue;
        public Goods(uint id,string name,double value)
        {
            GoodsID = id;
            GoodsName = name;
            GoodsValue = value;
        }

        public uint GoodsID { get; set; }
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
            return $"商品序号:{GoodsID},商品名称:{GoodsName},商品价格:{GoodsValue}";
        }
    }
}
