using MoreLinq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Singleton
{
    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private OrdinaryDatabase()
        {
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
