using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private static int idCount = 0;

        public Person CreatePerson(string name)
        {
            return new Person { Id = idCount++, Name = name };
        }
    }
}
