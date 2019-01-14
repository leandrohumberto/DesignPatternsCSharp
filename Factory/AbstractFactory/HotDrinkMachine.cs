using System;
using System.Collections.Generic;
using static System.Console;

namespace Factory.AbstractFactory
{
    class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty), 
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");

            for (var i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = ReadLine()) != null
                    && int.TryParse(s.Trim(), out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Write("Amount: ");
                    if ((s = ReadLine()) != null
                        && int.TryParse(s.Trim(), out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }
            }
        }
    }
}
