/*
    Edward Welborn
    MDV2330-O
    C20181002
    09/28/2018
    Arrays Assignment
    Third assignment for SDI class
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Assignment_Starting_File
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable Declaration and Initialization

            int[] firstArray = new int[4];
            firstArray[0] = 34;
            firstArray[1] = 20;
            firstArray[2] = 91;
            firstArray[3] = 49;

            double[] secondArray = new double[4] { 42, 120.30, 210.20, 32.50 };
            double[] dMyArray = new double[4];
            double dSumofArray1;
            double dSumofArray2;
            double dAverageofArray1;
            double dAverageofArray2;
            String sNewSentence;

            string[] MixedUp = new string[] { "universe is winning.", "erse trying to produce bigger an", "between software engineers striving to build bigger ", "d better idiots. So far, the ", "Programming today is a race ", "and better idiot-proof programs, and the univ" };

            // Find the total sum of each of the 2 individual arrays  
            dSumofArray1 = firstArray[0] + firstArray[1] + firstArray[2] + firstArray[3];
            dSumofArray2 = secondArray[0] + secondArray[1] + secondArray[2] + secondArray[3];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Sum of the First Array is: " + dSumofArray1);
            Console.WriteLine("The Sum of the Second Array is: " + dSumofArray2);
            Console.WriteLine("");

            // Find the average value of each of the 2 individual arrays
            dAverageofArray1 = dSumofArray1 / 4;
            dAverageofArray2 = dSumofArray2 / 4;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Average of the first array is: {0:n2}", dAverageofArray1);
            Console.WriteLine("The Average of the second array is: {0:n2}", dAverageofArray2);
            Console.WriteLine("");

            /* Create a 3rd number array.  
               Add Each element of the first two arrays into the third
            */

            dMyArray[0] = firstArray[0] + secondArray[0];
            dMyArray[1] = firstArray[1] + secondArray[1];
            dMyArray[2] = firstArray[2] + secondArray[2];
            dMyArray[3] = firstArray[3] + secondArray[3];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Sum for the first elemant of each array is: " + dMyArray[0]);
            Console.WriteLine("The Sum for the second elemant of each array is: " + dMyArray[1]);
            Console.WriteLine("The Sum for the third elemant of each array is: " + dMyArray[2]);
            Console.WriteLine("The Sum for the fourth elemant of each array is: " + dMyArray[3]);
            Console.WriteLine("");

            // Unmixup the mixedup array and make a coherant sentence
            sNewSentence = MixedUp[4] + MixedUp[2] + MixedUp[5] + MixedUp[1] + MixedUp[3] + MixedUp[0];
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(sNewSentence);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            // Pause the program before exit
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
    }
}/* Test Output

The Sum of the First Array is: 194
The Sum of the Second Array is: 405

The Average of the first array is: 48.50
The Average of the second array is: 101.25

The Sum for the first elemant of each array is: 76
The Sum for the second elemant of each array is: 140.3
The Sum for the third elemant of each array is: 301.2
The Sum for the fourth elemant of each array is: 81.5

Programming today is a race between software engineers striving to build bigger and better idiot-proof programs, and the universe trying to produce bigger and better idiots. So far, the universe is winning.

Press any key to continue:
*/
