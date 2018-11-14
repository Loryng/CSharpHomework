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
        public Customer(int id, string name)
        {
            CustomerId = id;
            CustomerName = name;
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set;}

        public override string ToString()
        {
            return CustomerName;
        }
    }
}
