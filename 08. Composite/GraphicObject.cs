using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{

    class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color { get; set; }

        private Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => _children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(!string.IsNullOrWhiteSpace(Color) ? $"{Color} " : string.Empty)
              .AppendLine(Name);

            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 1);
            return sb.ToString();
        }
    }

    class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    class Square : GraphicObject
    {
        public override string Name => "Square";
    }
}
