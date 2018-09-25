using System;

namespace program1
{
    abstract class Chart
    {
        public Chart()
        {
        }
        public abstract double Area();

    }
    //圆
    class Circle : Chart
    {
        private float Radius;
        public Circle(float r)
        {
            this.Radius = r;
        }
        public override double Area()
        {
           return (float)(Radius * Radius * Math.PI);
        }
    }
    //三角形
    class Trilateral : Chart
    {
        private float Height;
        private float Base;
        public Trilateral(float a, float h)
        {
            this.Height = h;
            this.Base = a;
        }
        public override double Area()
        {
           return Height * Base / 2;
        }
    }
    //正方形
    class Square : Chart
    {
        private float Side;
        public Square(float a)
        {
            Side = a;
        }
        public override double Area()
        {
            return Side * Side;
        }
    }
    //长方形
    class Rectangle : Chart
    {
        private float Height;
        private float Width;
        public Rectangle(float a, float b)
        {
            Height = a;
            Width = b;
        }
        public override double Area()
        {
            return Height * Width;
        }
    }
    class Factory
    {
        public static Chart GetChart(string cha, float s, float w)
        {
            Chart chart = null;
            if (cha.Equals("Trilateral"))
            {
                chart = new Trilateral(s, w);
            }
            else if (cha.Equals("Rectangle"))
            {
                chart = new Rectangle(s, w);
            }
            else if (cha.Equals("Circle"))
            {
                chart = new Circle(s);
            }
            else if (cha.Equals("Square"))
            {
                chart = new Square(s);
            }
            return chart;
        }
    }
    public class Test
    {
        public static void Main(string[] args)
        {
            Chart[] charts =
            {
             Factory.GetChart("Trilateral",3,6),
             Factory.GetChart("Rectangle",3,8),
             Factory.GetChart("Circle",3,7),
             Factory.GetChart("Square",4,7)
             };

            Console.WriteLine("Shapes Collection");
            foreach (Chart s in charts)
            {
                Console.WriteLine(s+" Area="+s.Area());
            }

        }
    }
}
