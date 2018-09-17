using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[99];
            for(int i=0;i<99;i++)
            {
                array[i] = i + 2;
            }

            for (int n = 2; n <= 100; n++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (array[j] != 0)
                    {
                        if (array[j] % n == 0 && array[j] / n != 1)
                            array[j] = 0;
                    }
                }
            }
            Console.WriteLine("2-100内的素数有：");
            for(int k=0;k<array.Length;k++)
            {
                if(array[k]!=0)
                    Console.Write(" "+array[k]);
            }
        }
    }
}
