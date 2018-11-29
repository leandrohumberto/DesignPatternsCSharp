using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_InterfaceSegregationPrinciple
{
    class Document
    {

    }

    interface IPrinter
    {
        void Print(Document document);
    }

    interface IScanner
    {
        void Scan(Document document);
    }

    interface IFax
    {
        void Fax(Document document);
    }

    interface IMultiFunctionalMachine : IPrinter, IScanner
    {

    }

    class MultifunctionalMachine : IMultiFunctionalMachine
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultifunctionalMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException();
            this.scanner = scanner ?? throw new ArgumentNullException();
        }

        public void Print(Document document)
        {
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            scanner.Scan(document);
        }
    }

    class Demo
    {
        static void Main(string[] args)
        {
        }
    }
}
