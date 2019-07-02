using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programIsRunning = true;
            User currentUser = null;
            Program instance = new Program();

           while(programIsRunning)
            {
                // Display a list of options
                // choose an option
                // execute based on choice
                Console.Clear();
                Console.Write(
                    "1.. Create a User\n" + 
                    "2.. Set Preferences\n" + 
                    "3.. Display Current User\n" + 
                    "4.. Exit\n" + 
                    "Select and Option: ");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "1":
                    case "create a cser":
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
                    case "exit":
                        {
                            programIsRunning = false;
                        }
                        break;
                }
                // Do whatever the user chooses

                Utility.PressAnyKey();
            }

        }
        private User CreateUser()
        {
            User newUser = null;
            Console.Write("What is the user's name: ");
            string name = Console.ReadLine();
            Console.Write("What is the user's address: ");
            string address = Console.ReadLine();
            int age = Validation.GetInt(18, 150, "Enter the user's age, between 18 and 150:");
            bool selectingUserType = true;
            while(selectingUserType)
            {
                Console.Write(
                    "1.. User\n" + 
                    "2.. Super\n" + 
                    "What type of user is being created: ");
                string type = Console.ReadLine().ToLower();
                switch (type)
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
        private void SetPreferences(User currentUser)
        {
            Console.Clear();
            if (currentUser == null)
            {
                Console.WriteLine("Please create a user first:");
            } else
            {
                bool shouldAutoPlay = Validation.GetBool("Should Videos Auto Play?");
                double volumeLevel = Validation.GetDouble(0, 10, "Set the new Volume Level:");

                if (currentUser.Prefs == null)
                {
                    currentUser.Prefs = new Preferences(shouldAutoPlay, volumeLevel);
                }
                else
                {
                    currentUser.Prefs.ShouldVideoAutoPlay = shouldAutoPlay;
                    currentUser.Prefs.VolumeLevel = volumeLevel;
                }
            }
        }
        private void DisplayUser(User currentUser)
        {
            Console.Clear();
            if (currentUser == null)
            {
                Console.WriteLine("Please create a user first:");
            }
            else
            {
                if (currentUser is Super)
                {
                    Super temp = currentUser as Super;
                    temp.DisplayStatus();
                }
                Console.WriteLine($"Security Level: {currentUser.SecurityLevel}");

                if (currentUser.Prefs == null)
                {
                    Console.WriteLine("User setting: ");
                    Console.WriteLine($"\tAutplay Enabled: {currentUser.Prefs.ShouldVideoAutoPlay}");
                    Console.WriteLine($"\tVolume LeveL: {currentUser.Prefs.VolumeLevel}");
                }
            }
        }
    }
}
