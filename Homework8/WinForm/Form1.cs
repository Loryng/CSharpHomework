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
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;

namespace WinForm
{
    public partial class Form1 : Form
    {
        //判断输入的为数字
        public static bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]*$");
        }
        public List<Order> GetOrders = new List<Order>();
        public static OrderService os = new OrderService();
        public List<OrderDetail> details = new List<OrderDetail>();
        public Form1()
        {
            GetOrders = os.orderDict;
            InitializeComponent();
            this.dataGridView1.DataError += delegate (object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e) { };//加上否则报错
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        //查询
        private void button2_Click(object sender, EventArgs e)
        {
            GetOrders = os.orderDict;
            List<Order> B = new List<Order>();
            if (GetOrders.Count()==0)
            {
                MessageBox.Show("当前不存在订单！");
                return;
            }
           if(comboBox1.Text.Equals("客户名"))
            {
                var A = GetOrders.Where(a=>a.Customer.CustomerName.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("不存在此订单！");
                        return;
                }
                foreach (Order a in A)
                    B.Add(a);
                orderDetailBindingSource.DataSource = new BindingList<OrderDetail>(B[0].orderDetailsDict);
            }

           if(comboBox1.Text.Equals("订单号"))
            {
                var A = GetOrders.Where(a => a.Customer.CustomerId.Equals(textBox1.Text));
                if(A.Count()==0)
                {
                    MessageBox.Show("不存在此订单！");
                    return;
                }
                foreach (Order a in A)
                    B.Add(a);
                orderDetailBindingSource.DataSource = new BindingList<OrderDetail>(B[0].orderDetailsDict);
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
                orderBindingSource.DataSource = new BindingList<Order>(os.orderDict);
            }
            else
                MessageBox.Show("没有订单！");
        }
        //os.orderDict[A].orderDetailsDict.Values = “os.orderDict[A].orderDetailsDict.Values”引发了类型“System.Collections.Generic.KeyNotFoundException”的异常
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (os.orderDict.Count() == 0)
                return;
            int A = os.orderDict.FindIndex(a => a.OrderID.Equals(label1.Text));

            orderDetailBindingSource.DataSource = new BindingList<OrderDetail>(os.orderDict[A].orderDetailsDict);

        }

        private void orderDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //到处为html文件
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                os.Export();
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Order.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"./Order.xslt");

                FileStream outFileStream = File.OpenWrite(@"./Order.html");
                XmlTextWriter writer = new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, writer);
                MessageBox.Show("成功！");
            }
            catch(XmlException ea)
            {
                Console.WriteLine("XML Exception:" + ea.ToString());
            }
            catch(XsltException ea)
            {
                Console.WriteLine("XSLT Exception:"+ea.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
