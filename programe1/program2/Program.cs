using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order a = new Order();
            int Id, price, Number;
            string Name, Client;

            bool T = true;

            while (T)
            {
                try
                {

                    Console.WriteLine("\n请选择您要功能：\n1.添加订单   2.删除订单   3.查询    \n    其他键退出");
                    int select = Convert.ToInt32(Console.ReadLine());
                    if (select == 1)
                    {
                        Console.WriteLine("1.添加订单：");
                        Console.WriteLine("编号：");
                        Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("名称：");
                        Name = Console.ReadLine();
                        Console.WriteLine("数量：");
                        price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("价格：");
                        Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("客户：");
                        Client = Console.ReadLine();
                        orderService.Add(a.MyOreder, Id, Name, Number, price, Client);
                    }
                    else if (select == 2)
                    {
                        Console.WriteLine("2.删除订单：");
                        Console.WriteLine("编号：");
                        Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("名称：");
                        Name = Console.ReadLine();
                        Console.WriteLine("数量：");
                        price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("价格：");
                        Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("客户：");
                        Client = Console.ReadLine();
                        orderService.Delete(a.MyOreder, Id, Name, Number, price, Client);
                    }
                    else if (select == 3)
                    {
                        Console.WriteLine("3.查询：");
                        Console.WriteLine("编号：");
                        Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("名称：");
                        Name = Console.ReadLine();
                        Console.WriteLine("数量：");
                        price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("价格：");
                        Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("客户：");
                        Client = Console.ReadLine();
                        orderService.Search(a.MyOreder, Id, Name, Number, price, Client);
                    }
                    else
                    {
                        Console.WriteLine("谢谢使用！");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("输入错误");
                }
            }
        }
    }
}
