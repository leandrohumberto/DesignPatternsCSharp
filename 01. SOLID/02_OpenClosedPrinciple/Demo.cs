using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OpenClosedPrinciple
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Yuge
    }

    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }


    #region Violating Open-Closed Principle

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color && p.Size == size)
                {
                    yield return p;
                }
            }
        }
    }

    #endregion

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        readonly Color color;

        public ColorSpecification(Color color) => this.color = color;

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        readonly Size size;

        public SizeSpecification(Size size) => this.size = size;

        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification : ISpecification<Product>
    {
        readonly ISpecification<Product> sizeSpecification;
        readonly ISpecification<Product> colorSpecification;

        public AndSpecification(ISpecification<Product> sizeSpecification, ISpecification<Product> colorSpecification)
        {
            this.sizeSpecification = sizeSpecification;
            this.colorSpecification = colorSpecification;
        }

        public bool IsSatisfied(Product t)
        {
            return sizeSpecification.IsSatisfied(t) && colorSpecification.IsSatisfied(t);
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Green, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            WriteLine("Green products (old)");

            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                WriteLine($" - {p.Name} is green.");
            }

            var bf = new BetterFilter();
            WriteLine("Green products (new)");

            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green.");
            }

            WriteLine("Green products (new)");
            var andSpec = new AndSpecification(new SizeSpecification(Size.Large),
                new ColorSpecification(Color.Blue));

            foreach (var p in bf.Filter(products, andSpec))
            {
                WriteLine($" - {p.Name} is large and blue.");
            }
        }
    }
}
