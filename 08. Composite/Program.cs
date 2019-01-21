﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });

            drawing.Children.Add(group);

            WriteLine(drawing);
        }
    }
}
