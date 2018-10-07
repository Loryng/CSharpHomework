using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programe1
{
    public delegate void AlarmClock(object sender);//委托声明
    public class SetClock
    {
        public string hour;
        public string minute;
        public string secord;
    }
    public class MyClock
    {
        public event AlarmClock Clock;//事件声明
        public string hour;
        public string minute;
        public string secord;
        public bool OnTime = false;//时间到

        public void RingOrShow(string a, string b, string c)//响铃或显示
        {
            SetClock args = new SetClock();
            args.hour = a;
            args.minute = b;
            args.secord = c;
            while (true)
            {
                string dateNowHour = DateTime.Now.Hour.ToString();
                string dateNowMinute = DateTime.Now.Minute.ToString();
                string dateNowSecord = DateTime.Now.Second.ToString();

                if (dateNowHour.Equals(a) && dateNowMinute.Equals(b))
                {
                    break;
                }
            }
            Clock(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClock mC = new MyClock();
            Console.WriteLine("请输入你的闹钟时间：");
            try
            {
                Console.WriteLine("几点：");
                mC.hour = Console.ReadLine();
                Console.WriteLine("几分：");
                mC.minute = Console.ReadLine(); ;
                Console.WriteLine("几秒：");
                mC.secord = Console.ReadLine(); ;

            }
            catch
            {
            }
            mC.Clock += new AlarmClock(ClockShow);
            mC.RingOrShow(mC.hour, mC.minute, mC.secord);
        }

        static void ClockShow(object sender)
        {
            Console.WriteLine("\n时间到！\n");
        }

    }
}

