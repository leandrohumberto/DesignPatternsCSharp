using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FluentBuilder
{
	class Person
	{
		public string Name { get; set; }
		public string Position { get; set; }
		
		public class Builder : PersonJobBuilder<Builder>
		{
			
		}
		
		public static Builder New => new Builder();

		public override string ToString()
		{
			return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
		}
	}
	
	abstract class PersonBuilder
	{
		protected Person Person { get; set; } = new Person();
		
		public Person Build()
		{
			return Person;
		}
	}

	class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
	{
		public SELF Called(string name)
		{
			Person.Name = name;
			return (SELF)this;
		}
	}

	class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
	{
		public SELF WorkAsA(string position)
		{
			Person.Position = position;
			return (SELF)this;
		}
	}
}
