using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01_SingleResponsibility
{
    /// <summary>
    /// A journal that just keeps track of its entries.
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    /// <summary>
    /// Manages the persistence of the journal.
    /// </summary>
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }

    /// <summary>
    /// Journal and Persistence classes demonstration.
    /// </summary>
    class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"Journal.txt";
            p.SaveToFile(j, filename, true);
        }
    }
}
