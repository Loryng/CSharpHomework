using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数字：");
            Int32 num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("这个数字的所有素数因子为：");
            for (int i = 2; i <= Math.Sqrt(num1); i++)
            {
                while (num1 % i == 0)
                {
                    num1 /= i;
                    Console.Write(" " + i);
                }
            }
            if (num1 != 1)
                Console.Write(" " + num1);
        }
    }
    }
}
