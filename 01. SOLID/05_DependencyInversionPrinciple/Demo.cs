using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _05_DependencyInversionPrinciple
{
    enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    class Person
    {
        public string Name { get; set; }
    }

    interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildren(string name);
    }

    class Relationships : IRelationshipBrowser
    {
        private readonly List<(Person, Relationship, Person)> relations =
            new List<(Person, Relationship, Person)>();

        // public List<(Person, Relationship, Person)> Relations => relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildren(string name)
        {
            foreach (var p in relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent))
            {
                yield return p.Item1;
            }
        }
    }

    class Demo
    {
        //public Demo(Relationships relationships)
        //{
        //    var relations = relationships.Relations;

        //    foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Demo(IRelationshipBrowser browser)
        {
            foreach (var c in browser.FindAllChildren("John"))
            {
                WriteLine($"John has a child called {c.Name}");
            }
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relatioships = new Relationships();
            relatioships.AddParentAndChild(parent, child1);
            relatioships.AddParentAndChild(parent, child2);

            new Demo(relatioships);
        }
    }
}
