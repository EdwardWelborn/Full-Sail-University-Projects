using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Polymorphism
{
    class Validation
    {
        public static int GetInt()
        {
            int validationInt = 0; ;
            string input = null;

            do
            {
                Console.Write("Please enter an integer: ");
                input = Console.ReadLine();

            } while (Int32.TryParse(input, out validationInt) == false);
            return validationInt;
        }
        public static int GetInt(int min, int max, string message = "Please enter an integer (between 1 and 50): ")
        {
            int validationInt = 0; ;
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

            } while (!(Int32.TryParse(input, out validationInt) && (validationInt >= min) && (validationInt <= max)));
            return validationInt;

        }

        public static bool GetBool(string message = "Please Enter Yes or No:")
        {
            bool answer = false;
            string input = null;
            bool needValidRespone = true;

            while (needValidRespone)
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "true":
                        {
                            answer = true;
                            needValidRespone = false;
                        }
                        break;
                    case "false":
                        {
                            needValidRespone = false;
                        }
                        break;
                    case "t":
                        {
                            answer = true;
                            needValidRespone = false;
                        }
                        break;
                    case "f":
                        {
                            needValidRespone = false;
                        }
                        break;
                    case "y":
                        {
                            answer = true;
                            needValidRespone = false;
                        }
                        break;
                    case "yes":
                        {
                            answer = true;
                            needValidRespone = false;
                        }
                        break;
                    case "n":
                        {
                            needValidRespone = false;
                        }
                        break;
                    case "no":
                        {
                            needValidRespone = false;
                        }
                        break;
                }

            }
            return answer;
        }
        public static double GetDouble()
        {
            double validationDouble = 0; ;
            string input = null;

            do
            {
                Console.Write("Please enter an number ");
                input = Console.ReadLine();

            } while (Double.TryParse(input, out validationDouble) == false);
            return validationDouble;
        }
        public static double GetDouble(int min, int max, string message = "Please enter an number:(between 1 and 10) ")
        {
            double validationDouble = 0; ;
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();

            } while (!(double.TryParse(input, out validationDouble) && (validationDouble >= min) && (validationDouble <= max)));
            return validationDouble;
        }
    }
}
