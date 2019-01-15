using static System.Console;

namespace Factory.AbstractFactory
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is sensational!");
        }
    }
}
