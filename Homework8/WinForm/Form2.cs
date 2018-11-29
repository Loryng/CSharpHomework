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
using System.Text.RegularExpressions;

namespace WinForm
{
    public partial class Form2 : Form
    {
        //判断电话号码
        public bool IsPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"[1]+\d{10}");
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private static int m = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Goods goods1, goods2, goods3;
            int orderid=0;
          
            Order order = new Order();
            if (!textBox4.Text.Equals(""))
            {
                m++;
                Customer customer = new Customer();
                customer.CustomerName= textBox4.Text;
                customer.CustomerId = m;
                order.OrderID = Convert.ToString(m);
                order.Customer = customer;
            }        
            else
            {
                MessageBox.Show("请输入客户名！");
                return;
            }
            if (checkBox1.Checked&&textBox1.Text!="")
            {
                goods1 = new Goods(1,"苹果",6.99);
                OrderDetail orderDetail = new OrderDetail(goods1, Convert.ToUInt32(textBox1.Text));
                orderid++;
                orderDetail.OrderDetailID = Convert.ToString(orderid);
                order.orderDetailsDict.Add(orderDetail);
            }
            if(checkBox2.Checked&&textBox2.Text!="")
            {
                goods2 = new Goods(2,"鸡蛋",3.00);
                OrderDetail orderDetail = new OrderDetail(goods2, Convert.ToUInt32(textBox2.Text));
                orderid++;
                orderDetail.OrderDetailID =Convert.ToString(orderid);
                order.orderDetailsDict.Add(orderDetail);
            }
            if(checkBox3.Checked&&textBox3.Text!="")
            {
                goods3 = new Goods(3,"牛奶",6.2);
                OrderDetail orderDetail = new OrderDetail(goods3, Convert.ToUInt32(textBox3.Text));
                orderid++;
                orderDetail.OrderDetailID = Convert.ToString(orderid);
                order.orderDetailsDict.Add(orderDetail);
            }

            if (!IsPhoneNumber(textBox5.Text))
            {
                MessageBox.Show("抱歉！请正确输入电话号码！");
                return;
            }
            else
            {
                order.Phone = textBox5.Text;
            }
            if (orderid == 0)
            {
                MessageBox.Show("不存在任何订单！");
                return;
            }
            else
                MessageBox.Show("订单添加成功！");

            order.OrderID = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + m.ToString().PadLeft(3, '0');
            Form1.os.AddOrder(order);
            this.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
