using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EdwardWelborn_CE3
{
    class Validation
    {
        public static string GetCarMake()
        {
            string sInput = null;
            string validCarMake = null;
            do
            {
                Console.Write("\r\nPlease Enter the Car Make: ");
                sInput = Console.ReadLine();
            } while (!(Regex.IsMatch(sInput, @"^[a-zA-Z]+$")));
            validCarMake = sInput;
            
            return validCarMake;
        }
        public static string GetCarModel()
        {
            string sInput = null;
            string validCarModel = null;
            do
            {
                Console.Write("Please Enter the Car Model: ");
                sInput = Console.ReadLine();
            } while (!(Regex.IsMatch(sInput, @"^[a-zA-Z]+$")));
            validCarModel = sInput;
            return validCarModel;
        }
        public static string GetCarColor()
        {
            string sInput = null;
            string validCarColor = null;
            do
            {
                Console.Write("Please Enter the Car Color: ");
                sInput = Console.ReadLine();
            } while (!(Regex.IsMatch(sInput, @"^[a-zA-Z]+$")));
            validCarColor = sInput;
            return validCarColor;
        }
        public static float GetCarMileage()
        {
            string sInput = null;
            float validCarMileage = 0;
            do
            {
                Console.Write("Please Enter the car mileage (Numbers only please.) ");
                sInput = Console.ReadLine();
            } while (!(float.TryParse(sInput, out validCarMileage)));
            return validCarMileage;
        }
        public static int GetCarYear()
        {
            string sInput = null;
            int validCarYear = 0;
            do
            {
                Console.Write("Please Enter the car year: (Numbers only please.) ");
                sInput = Console.ReadLine();
            } while (!(int.TryParse(sInput, out validCarYear)));
            return validCarYear;
        }
        public static float GetNewCarMileage()
        {
            string sInput = null;
            float validNewCarMileage = 0;
            do
            {
                Console.Write("\r\nPlease Enter how far to drive (Numbers only please.) ");
                sInput = Console.ReadLine();
            } while (!(float.TryParse(sInput, out validNewCarMileage)));
            return validNewCarMileage;
        }

    }
}

