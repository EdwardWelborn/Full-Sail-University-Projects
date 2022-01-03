using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strName = "";
            string strAge = "";

            // Clear the Console on every Run
            Console.Clear();

            // Welcome Label
            Console.WriteLine("Hello Fullsail, Welcome to Lab 1\n");

            // Get user name
            Console.Write("Please Enter Your Name: ");
            strName = Console.ReadLine();

            // Get user age
            Console.Write("Please enter your age in years: ");
            strAge = Console.ReadLine();

            // OutPut answers to the Screen
            Console.WriteLine($"\nGlad to meet you {strName}, \nGood to have you around for these {strAge} year(s)\n\n");

            // Prompt to exit the program
            Console.Write("Press Any Key to end the program");
            Console.ReadKey();
        }
    }
}
