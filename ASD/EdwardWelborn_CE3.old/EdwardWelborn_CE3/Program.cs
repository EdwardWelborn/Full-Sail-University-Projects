using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE3
{
    class Program
    {
        private static Logger Logs = null;

        static void Main(string[] args)
        {
            string input = null;
            bool bRunning = true;
            string sCarMake = null;
            string sCarModel = null;
            string sCarColor = null;
            float fCarMileage = 0;
            float fOldCarMileage = 0;
            int iCarYear = 0;
            bool bLogging = true;
            string sLogging = null;
            float fNewCarMileage = 0;
            string[] currentCar = new String[5];
            


            while (bRunning)
            {
                // Main Menu
                Console.Clear();
                Console.WriteLine("\r\n       CE01 Assignment");
                Console.WriteLine("-----------------------------\r\n");
                Console.WriteLine("[1] or Disable Logging");
                Console.WriteLine("[2] or Enable Logging");
                Console.WriteLine("[3] or Create a Car");
                Console.WriteLine("[4] or Drive the Car");
                Console.WriteLine("[5] or Destroy the car");
                Console.WriteLine("[6] or Exit");
                Console.WriteLine("\r\n-----------------------------");
                
                if (bLogging)
                {
                    sLogging = "Enabled";

                }
                else
                    sLogging = "Disabled";
                Console.Write("\r\nLogging is ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sLogging);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\r\nUse either the number or phrase to choose: ");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "disable logging":
                        {
                            Console.WriteLine("\r\nLogging is now disabled");
                            bLogging = false;
                            Utility.PressAnyKey();
                        }
                        break;
                    case "2":
                    case "enable logging":
                        {
                            Console.WriteLine("\r\nYou Chose to Enable Logging");
                            bLogging = true;
                            Utility.PressAnyKey();
                        }
                        break;
                    case "3":
                    case "create a car":
                        {
                            sCarMake = Validation.GetCarMake();
                            sCarModel = Validation.GetCarModel();
                            sCarColor = Validation.GetCarColor();
                            fCarMileage = Validation.GetCarMileage();
                            iCarYear = Validation.GetCarYear();
                            Car car = new Car(sCarMake, sCarModel, sCarColor, fCarMileage, iCarYear);
                            string sCarMileage = fCarMileage.ToString();
                            string sCarYear = iCarYear.ToString();
                            currentCar[0] = sCarMake;
                            currentCar[1] = sCarModel;
                            currentCar[2] = sCarColor;
                            currentCar[3] = sCarMileage;
                            currentCar[4] = sCarYear;
                            if (bLogging)
                            {
                                LogToConsole Logging = new LogToConsole();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Logging.Log($"New Car Created! a {currentCar[0]} {currentCar[1]}");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        Utility.PressAnyKey();
                        break;
                    case "4":
                    case "drive the car":
                        {
                            if (fCarMileage <= 0)
                            {
                                Console.WriteLine("Enter Car Information First");
                            }
                            else
                            {
                                fOldCarMileage = fCarMileage;
                                fCarMileage = Validation.GetNewCarMileage();
                                fNewCarMileage = fCarMileage + fOldCarMileage;
                                Console.WriteLine($"\r\nMileage is now:  {fNewCarMileage}");
                                currentCar[3] = fNewCarMileage.ToString();
                                fCarMileage = fNewCarMileage;
                            }
                            if (bLogging)
                            {
                                LogToConsole Logging = new LogToConsole();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Logging.LogD($"Mileage has Change from {fOldCarMileage} to {fNewCarMileage}");
                                Console.ForegroundColor = ConsoleColor.Gray;

                            }
                            Utility.PressAnyKey();
                        }
                        break;
                    case "5":
                    case "destroy the car":
                        {
                            if (fCarMileage <= 0)
                            {
                                Console.WriteLine("Enter Car Information First");
                            }
                            else
                            {
                                Console.WriteLine("\r\nYou Chose to Destroy the Current Car");

                                int count = 0;
                                foreach (string value in currentCar)
                                {
                                    currentCar[count] = null;
                                }
                                Console.WriteLine("Current Car Destroyed");
                            }
                            if (bLogging)
                            {
                                LogToConsole Logging = new LogToConsole();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Logging.LogW($"Car being destroyed is a {currentCar[0]} {currentCar[1]}");
                                Console.ForegroundColor = ConsoleColor.Gray;

                            }
                        
                        }
                        Utility.PressAnyKey();
                        break;
                    case "6":
                    case "exit":
                    case "e":
                        {
                            bRunning = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            
            Utility.PressAnyKey();
        }
        public static Logger GetLogger()
        {
            return Logs;
        }

    }
}

