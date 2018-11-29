using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _03_LiskovSubstitutionPrinciple
{
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { Width = value; }
        }
    }

    class Demo
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(width: 99, height:88);
            WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square() { Width = 4 };
            WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
