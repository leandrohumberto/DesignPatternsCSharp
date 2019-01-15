using System.Collections.Generic;
using System.Text;

namespace Builder
{

    class CodeBuilder
    {
        private class ClassField
        {
            public string Name { get; set; }
            public string Type { get; set; }

            public ClassField(string name, string type)
            {
                Name = name;
                Type = type;
            }

            public override string ToString()
            {
                return $"public {Type} {Name};";
            }
        }

        private readonly int indentSize = 4;
        private readonly string className;
        private readonly List<ClassField> fields = new List<ClassField>();

        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            fields.Add(new ClassField(name, type));
            return this;
        }

        public void Clear() => fields.Clear();

        public override string ToString()
        {
            return ToStringImpl(1);
        }

        private string ToStringImpl(int indent = 0)
        {
            StringBuilder sb = new StringBuilder()
                .AppendLine($"public class {className}")
                .AppendLine("{");

            foreach (var field in fields)
            {
                sb.Append($"{new string(' ', indent * indentSize)}")
                    .AppendLine(field.ToString());
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
