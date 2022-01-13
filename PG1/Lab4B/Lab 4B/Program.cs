using System;
using Tester;

namespace FSPG1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.Run(4);
            Console.ReadKey();
        }
    }

    public enum MathOperator
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
