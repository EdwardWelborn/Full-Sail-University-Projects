using System;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace DiceRoller
{
    class Program
    {
        public static Random rng = new Random();
        private static int[] diceRolls = new int[0];
        private static int totalRolled = 0;
        static void Main(string[] args)
        {
        
            Console.Write("How Many Dice do you wish to roll: ");
            int diceCount = int.Parse(Console.ReadLine());
            Console.Write("What dice type: (20 = d20): ");
            int diceType  = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            for (int i = 0; i < diceCount; i++)
            {
                int rolled = rng.Next(1, diceType + 1);
                diceRolls.Append(rolled);
                Console.WriteLine($"Dice Roll {i + 1} is: {rolled}");
                totalRolled += rolled;
            }
            
            Console.WriteLine($"\nTotal Rolled is: {totalRolled}");

            Console.Write("\nPress Any Key To Continue");
            Console.ReadKey();
        }
    }
}
