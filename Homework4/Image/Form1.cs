using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (graphics == null)
                graphics = this.CreateGraphics();

            this.graphics.Clear(Color.White);

            drawCayleyTree(7, 200, 310, Convert.ToDouble(textBox4.Text), -Math.PI / 2);
        }
        private Graphics graphics;

        readonly double per1 = 0.6;
        readonly double per2 = 0.7;

        private void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            //找到下一个点——（x1,x2）;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            //找到第二个点——（x2,y2）
            double x2 = x0 + (leng * Math.Cos(th)) / 2;
            double y2 = y0 + (leng * Math.Sin(th)) / 2;

            //调用函数连线
            drawLine(x0, y0, x1, y1);

            double th1 = Convert.ToSingle(textBox1.Text) * Math.PI / 180;//30°
            double th2 = Convert.ToSingle(textBox2.Text) * Math.PI / 180;//20°

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        private void drawLine(double x0, double y0, double x1, double y1)
        {
            Random rnd = new Random();
            // 随机色
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(
                     rnd.Next(0, 255), /*红色*/
                     rnd.Next(0, 255), /*绿色*/
                     rnd.Next(0, 255)  /*蓝色*/ );
            Pen pen = new Pen(myColor, Convert.ToSingle(textBox3.Text));

            graphics.DrawLine(pen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
