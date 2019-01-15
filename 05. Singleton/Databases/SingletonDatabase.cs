using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Singleton
{
    class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private static int _instanceCount;

        public static int Count => _instanceCount;

        private static Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => _instance.Value;

        private SingletonDatabase()
        {
            _instanceCount++;
            WriteLine("Initializing database");

            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0)?.Trim(),
                    list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals.Keys.Contains(name) ? capitals[name] : 0;
        }
    }
}
