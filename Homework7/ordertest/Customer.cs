using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    //[Serializable]
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(uint id, string name)
        {
            CustomerId = id;
            CustomerName = name;
        }

        public uint CustomerId { get; set; }
        public string CustomerName { get; set;}

        public override string ToString()
        {
            return $"客户序号:{CustomerId},客户名称:{CustomerName}";
        }
    }
}
