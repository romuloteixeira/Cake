using MyLibrary;
using System;

namespace Cake.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var calc = new Calculator();
            var result = calc.Add(1, 2);
        }
    }
}
