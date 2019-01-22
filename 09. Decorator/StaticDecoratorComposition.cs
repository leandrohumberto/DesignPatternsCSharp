using System;

namespace Decorator.StaticDecorator
{
    abstract class Shape
    {
        public abstract string AsString();
    }

    class Circle : Shape
    {
        float radius;

        public Circle() : this(0.0f)
        {

        }

        public Circle(float radius) => this.radius = radius;

        public void Resize(float factor) => radius *= factor;

        public override string AsString() => $"A circle with radius {radius}";
    }

    class Square : Shape
    {
        private readonly float side;

        public Square() : this(0.0f)
        {

        }

        public Square(float side) => this.side = side;

        public override string AsString() => $"A square with side {side}";
    }

    class ColoredShape : Shape
    {
        private Shape shape;
        private string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    class TransparentShape : Shape
    {
        private Shape shape;
        private float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }

    class ColoredShape<T> : Shape where T : Shape, new()
    {
        private string color;
        private T shape = new T();

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color)
        {
            this.color = color;
        }

        public override string AsString()
        {
            throw new NotImplementedException();
        }
    }

    class TransparentShape<T> : Shape where T : Shape, new()
    {
        private T shape = new T();
        private readonly float transparency;

        public TransparentShape() : this(0.0f)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
}
