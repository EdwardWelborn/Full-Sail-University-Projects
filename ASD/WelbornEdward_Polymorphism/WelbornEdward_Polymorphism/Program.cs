using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bProgramRunning = true;
            User currentUser = null;
            Program instance = new Program();


            while(bProgramRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "[1]..  Create a User\n" +
                        "[2]..  Set Preferences\n" +
                        "[3]..  Display Current User\n" +
                        "[4]..  Exit Program\n");
                Console.Write("Select an Option: ");
                string input = Console.ReadLine().ToLower();

                switch(input)
                {
                    case "1":
                    case "create a user":
                        {
                            currentUser = instance.CreateUser();
                        }
                        break;
                    case "2":
                    case "set preferences":
                        {
                            instance.SetPreferences(currentUser);
                        }
                        break;
                    case "3":
                    case "display current user":
                        {
                            instance.DisplayUser(currentUser);
                        }
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        {
                            bProgramRunning = false;
                        }
                        break;
                }
                if (bProgramRunning)
                {
                   Utility.PressAnyKeyToContinue();
                }
            }
            Utility.PauseBeforeExit();
        }
        private User CreateUser()
        {
            User newUser = null;
            Console.Write("Please enter the User Name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter the User Address: ");
            string address = Console.ReadLine();

            int age = Validation.GetInt(18, 120, "Please Enter the User's Age: ");

            bool selectingUserType = true;

            while (selectingUserType)
            {
                Console.Write(
                    "[1].  User\n" +
                    "[2].  Super\n" +
                    "What Type of User is being created: ");
                string type = Console.ReadLine().ToLower();
                switch(type)
                {
                    case "1":
                    case "user":
                        {
                            newUser = new User(name, address, age);
                            selectingUserType = false;
                        }
                        break;
                    case "2":
                    case "super":
                        {
                            newUser = new Super(name, address, age);
                            selectingUserType = false;
                        }
                        break;
                }
            }
                
            return newUser;
        }

        private void SetPreferences(User CurrentUser)
        {

        }

        private void DisplayUser(User currentUser)
        {
            Console.Clear();
            if (currentUser == null)
            {
                Console.WriteLine("Please Create a User First!!");
            }
            else
            {
                Console.WriteLine($"User Name:      {currentUser.Name}");
                Console.WriteLine($"User Address:   {currentUser.Address}");

                if (currentUser is Super)
                {
                    Super temp = currentUser as Super;
                    temp.DisplayStatus();

                }
                Console.WriteLine($"Security Level: {currentUser.SecurityLevel}");

                if (currentUser.Prefs == null)
                {
                    Console.WriteLine("User Settings:");
                    Console.WriteLine($"\tAutoplay enabled: {currentUser.Prefs.AutoPlay}");
                    Console.WriteLine($"\tVolume Level: {currentUser.Prefs.VolumeLevel}");
                }
            }
        }

    }
}
