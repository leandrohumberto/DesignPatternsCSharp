using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable]
    public class Address //: IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address() { }

        public Address(Address other)
        {
            this.StreetName = other.StreetName;
            this.HouseNumber = other.HouseNumber;
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(paramName: nameof(streetName));
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        //public Address DeepCopy()
        //{
        //    return new Address(StreetName, HouseNumber);
        //}
    }
}
