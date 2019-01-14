using Factory.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
        }
    }
}
