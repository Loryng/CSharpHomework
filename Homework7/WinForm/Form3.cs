using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("请输入想删除的东西！");
                return;
            }
           if(Form1.os.orderDict.Values.ToList().Exists(a=>a.OrderID==(Convert.ToUInt32(textBox1.Text))))
           {
                Form1.os.RemoveOrder(Convert.ToUInt32(textBox1.Text));
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("没有此订单");
                    return;
            }
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
