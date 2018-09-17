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
            int[] array = { 1, 4, 2, 5, 3, 5, 3, 6 };
            Console.WriteLine("这个整数数组的最大值是：");
            Console.WriteLine(GetMax(array));
            Console.WriteLine("这个整数数组的最小值是：");
            Console.WriteLine(GetMin(array));
            Console.WriteLine("这个整数数组的平均值是：");
            Console.WriteLine(GetAverage(array));
            Console.WriteLine("这个整数数组所有数组元素的和为：");
            Console.WriteLine(GetSum(array));
        }

        private static int GetMax(int[] array)
        {
            int max = 0;
            for(int i=0;i<array.Length;i++)
            {
                while (max < array[i])
                    max = array[i];
            }
            return max;
        }

        private static int GetMin(int[] array)
        {
            int min = array[0];
            for(int i=0;i<array.Length;i++)
            {
                while (min > array[i])
                    min = array[i];
            }
            return min;
        }
        private static double GetAverage(int[] array)
        {
            double sum = 0;
            for(int i=0;i<array.Length;i++)
            {
                sum += array[i];
            }
            double average = sum / array.Length;
            return average;
        }
        private static int GetSum(int[] array)
        {
            int sum = 0;
            for(int i=0;i<array.Length;i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }

}
