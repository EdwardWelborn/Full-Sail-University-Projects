using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize((int)(Console.LargestWindowWidth * .8), (int)(Console.LargestWindowHeight * .8));
            Tester.Run();
            Console.ReadKey();
        }

    }
}
