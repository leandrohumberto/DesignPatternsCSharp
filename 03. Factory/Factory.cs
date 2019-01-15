using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{

    class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)} = {x}, {nameof(y)} = {y}";
        }

        public static Point Origin = new Point(0, 0);

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

            public static Point NewPolarPoint(double x, double y) => new Point(x * Math.Cos(y), x * Math.Sin(y));
        }
    }
}
