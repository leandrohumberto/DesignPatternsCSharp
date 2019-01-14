using static System.Console;

namespace Factory.AbstractFactory
{
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }
}
