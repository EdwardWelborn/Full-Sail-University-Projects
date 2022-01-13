using System;
using Tester;

namespace Lab_6A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 10);
            Test.Run(6);
            Console.ReadKey();
        }
    }
}
