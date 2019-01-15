namespace Prototype
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy() => new Line
        {
            Start = new Point { X = Start.X, Y = Start.Y },
            End = new Point { X = End.X, Y = End.Y }
        };
    }
}
