using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void MyMethod(out ushort A, out ushort B)
        {
            A = B = 0;

            try
            {
                A = unchecked((ushort)(A - 10));
            }
            catch (OverflowException)
            {
                WriteLine("Can't calculate A");
            }

            try
            {
                B = checked((ushort)(B - 10));
            }
            catch (OverflowException)
            {
                WriteLine("Can't calculate B");
            }
        }
        static void Main()
        {
            ushort a = 0, b = 0;
            MyMethod(out a, out b);

            WriteLine($"A = {a}, B = {b}");
            ReadLine();
        }
    }



}

