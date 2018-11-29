using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using OrderDemo;

namespace OrderGUI
{
    public partial class AddForm : Form
    {
        //判断电话号码
        public bool IsPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"[1]+\d{10}");
        }
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
        private static int m = 0;

        private void Finish_Button_Click(object sender, EventArgs e)
        {
            int orderid = 0;

            Order order = new Order();
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            if (!textBox3.Text.Equals(""))
            {
                m++;
                order.Id = Convert.ToString(m);
                order.Customer = textBox3.Text;
            }
            else
            {
                MessageBox.Show("请输入客户名！");
                return;
            }
            if (checkBox1.Checked && textBox1.Text != "")
            {
                OrderDetail orderDetail = new OrderDetail("1","苹果" ,6.99,Convert.ToInt32(textBox1.Text));
                orderid++;
                orderDetail.Id = Convert.ToString(orderid);
            }
            if (checkBox2.Checked && textBox2.Text != "")
            {
                OrderDetail orderDetail = new OrderDetail("2","鸡蛋",3.00, Convert.ToInt32(textBox2.Text));
                orderid++;
                orderDetail.Id = Convert.ToString(orderid);
            }

            //if (!IsPhoneNumber(textBox5.Text))
            //{
            //    MessageBox.Show("抱歉！请正确输入电话号码！");
            //    return;
            //}
            //else
            //{
            //    order.Phone = textBox5.Text;
            //}
            if (orderid == 0)
            {
                MessageBox.Show("不存在任何订单！");
                return;
            }
            else
                MessageBox.Show("订单添加成功！");

            order.Id = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + m.ToString().PadLeft(3, '0');
            MainForm.orderService.Add(order);
            this.Close();
        }
    }
}
