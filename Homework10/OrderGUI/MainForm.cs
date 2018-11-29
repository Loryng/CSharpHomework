using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderDemo;

namespace OrderGUI
{
    public partial class MainForm : Form
    {
        public static OrderService orderService = new OrderService();
        public MainForm()
        {
            InitializeComponent();
            orderBindingSource.DataSource = orderService.GetAllOrders();
            this.dataGridView2.DataError += delegate (object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e) { };//加上否则报错
            this.dataGridView1.DataError += delegate (object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e) { };//加上否则报错
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            queryOrder();
        }

        private void queryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 1:
                    orderBindingSource.DataSource =
                      orderService.GetOrder(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      orderService.QueryByCustormer(textBox1.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                      orderService.QueryByGoods(textBox1.Text);
                    break;
            }
            orderBindingSource.ResetBindings(false);
            detailsBindingSource.ResetBindings(false);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                EditForm editForm = new EditForm((Order)orderBindingSource.Current);
                editForm.ShowDialog();
                queryOrder();
            }
            else
            {
                MessageBox.Show("没有选择订单!");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Order order = (Order)orderBindingSource.Current;
                orderService.Delete(order.Id);
                queryOrder();
            }
            else
            {
                MessageBox.Show("没有选择订单！");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
