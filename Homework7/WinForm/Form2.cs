using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;

namespace WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private static uint m = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Goods goods1, goods2, goods3;
            uint orderid=0;
          
            Order order = new Order();
            if (!textBox4.Text.Equals(""))
            {
                m++;
                Customer customer = new Customer();
                customer.CustomerName= textBox4.Text;
                customer.CustomerId = m;
                order.OrderID = m;
                order.Customer = customer;
            }        
            else
            {
                MessageBox.Show("请输入客户名！");
                return;
            }
            if (checkBox1.Checked&&textBox1.Text!="")
            {
                goods1 = new Goods("苹果");
                OrderDetail orderDetail = new OrderDetail(goods1, Convert.ToUInt32(textBox1.Text));
                orderid++;
                orderDetail.OrderDetailID = orderid;
                order.orderDetailsDict.Add(orderid,orderDetail);
            }
            if(checkBox2.Checked&&textBox2.Text!="")
            {
                goods2 = new Goods("鸡蛋");
                OrderDetail orderDetail = new OrderDetail(goods2, Convert.ToUInt32(textBox2.Text));
                orderid++;
                orderDetail.OrderDetailID = orderid;
                order.orderDetailsDict.Add(orderid, orderDetail);
            }
            if(checkBox3.Checked&&textBox3.Text!="")
            {
                goods3 = new Goods("牛奶");
                OrderDetail orderDetail = new OrderDetail(goods3, Convert.ToUInt32(textBox3.Text));
                orderid++;
                orderDetail.OrderDetailID = orderid;
                order.orderDetailsDict.Add(orderid, orderDetail);
            }
            

            if (orderid == 0)
            {
                MessageBox.Show("不存在任何订单！");
                return;
            }
            else
                MessageBox.Show("订单添加成功！");

           
            Form1.os.AddOrder(order);
            this.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
