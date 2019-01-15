using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FacetedBuilder
{
    class Person
    {
        // Address
        public string StreetAdress { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        // Employment
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public int AnnualIncome { get; set; }

        public override string ToString()
        {
            return $"{nameof(StreetAdress)}: {StreetAdress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    class PersonBuilder
    {
        // Reference!
        protected Person Person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(Person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);

        public override string ToString()
        {
            return Person.ToString();
        }

        public static implicit operator Person(PersonBuilder pb) => pb.Person;
    }

    class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            Person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            Person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            Person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            Person.AnnualIncome = amount;
            return this;
        }
    }

    class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            Person = person;
        }

        public PersonAddressBuilder At(string address)
        {
            Person.StreetAdress = address;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            Person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            Person.City = city;
            return this;
        }
    }
}
