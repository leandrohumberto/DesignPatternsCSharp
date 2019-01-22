using System;

namespace Decorator.DynamicDecorator
{
    interface IShape
    {
        string AsString();
    }

    class Circle : IShape
    {
        float radius;

        public Circle(float radius) => this.radius = radius;

        public void Resize(float factor) => radius *= factor;

        public string AsString() => $"A circle with radius {radius}";
    }

    class Square : IShape
    {
        private readonly float side;

        public Square(float side) => this.side = side;

        public string AsString() => $"A square with side {side}";
    }

    class ColoredShape : IShape
    {
        private IShape shape;
        private string color;

        public ColoredShape(IShape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public string AsString() => $"{shape.AsString()} has the color {color}";
    }

    class TransparentShape : IShape
    {
        private IShape shape;
        private float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }

        public string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
}
