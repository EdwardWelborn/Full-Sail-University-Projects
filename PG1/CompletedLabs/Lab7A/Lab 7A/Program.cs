using System;
using Tester;

namespace Lab_7A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize((int)(Console.LargestWindowWidth * .8), (int)(Console.WindowHeight));

            Test.Run(7);  
            Console.ReadKey();
        }
    }
}
