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
    public partial class Form1 : Form
    {
        public Dictionary<uint, Order> GetOrders;
        public static OrderService os = new OrderService();
        public List<OrderDetail> details = new List<OrderDetail>();
        public Form1()
        {
            GetOrders = os.orderDict;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders = os.orderDict;
            Dictionary<uint, Order> B = new Dictionary<uint, Order>();
            //List<Order> B = new List<Order>();
            if (GetOrders.Count()==0)
            {
                MessageBox.Show("当前不存在订单！");
                return;
            }
           if(comboBox1.Text.Equals("客户名"))
            {
                var A = GetOrders.Values.Where(a=>a.Customer.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("不存在此订单！");
                        return;
                }
                foreach (Order a in A)
                    B.Add(a.OrderID,a);
                bindingSource1.DataSource = new BindingList<OrderDetail>(B[0].orderDetailsDict.Values.ToList());
            }
           if(comboBox1.Text.Equals("订单号"))
            {
                var A = GetOrders.Values.Where(a => a.Customer.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("不存在此订单！");
                    return;
                }
                foreach (Order a in A)
                    B.Add(a.OrderID, a);
                bindingSource1.DataSource = new BindingList<OrderDetail>(B[0].orderDetailsDict.Values.ToList());
            }
           else
            {
                MessageBox.Show("没有相关订单号！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (os.orderDict.Count() != 0)
            {
                orderBindingSource.DataSource = new BindingList<Order>(os.orderDict.Values.ToList());
            }
            else
                MessageBox.Show("没有订单！");
        }
        //os.orderDict[A].orderDetailsDict.Values = “os.orderDict[A].orderDetailsDict.Values”引发了类型“System.Collections.Generic.KeyNotFoundException”的异常
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (os.orderDict.Count() == 0)
                return;
         List<Order> o = os.orderDict.Values.ToList();
            var A =(uint) o.FindIndex(a => a.OrderID == Convert.ToUInt32(label1.Text));
            List<OrderDetail> orderDetails = os.orderDict[A].orderDetailsDict.Values.ToList();
            orderDetailBindingSource.DataSource = new BindingList<OrderDetail>(orderDetails);
            
        }
    }
}
