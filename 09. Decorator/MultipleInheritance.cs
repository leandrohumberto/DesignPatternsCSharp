using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Decorator
{
    interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }

    interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }

    class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int weight;

        public int Weight
        {
            get => weight;
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}
