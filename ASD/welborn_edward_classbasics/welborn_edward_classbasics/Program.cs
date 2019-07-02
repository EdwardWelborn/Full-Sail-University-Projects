using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace welborn_edward_classbasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // int anyInteger = GetInt();
            //  int rangedInteger = GetInt(1, 50, "Please enter an integer (between 1 and 50): ");

            // Console.WriteLine($"\r\nYou picked a number the number: {anyInteger}");
            // Console.WriteLine($"Your Value between 1 and 50 was: {rangedInteger}");

            Console.Write("Please Enter an Name: ");
            string sName = Console.ReadLine();
            Console.Write("Please Type your Address: ");
            string sAddress = Console.ReadLine();
            int iAge = Validation.GetInt(18, 120, $"{sName}, Please Enter Your Age: (18 to 120) ");

            User users = null;
            users = new User(sName, sAddress, iAge);

            //           users.SetName(sName);
            //           users.SetAddress(sAddress);
            //           users.SetAge(iAge);

            bool shouldVideoAutoPlay = Validation.GetBool("Should Videos Auto Play? ");
            double volumeLevel = Validation.GetDouble(0, 10, "What Volume Level do you want to user: (1 to 10)");

            Preferences prefs = new Preferences(shouldVideoAutoPlay, volumeLevel);
            users.SetPreference(prefs);
            Console.WriteLine($"{users.GetName()}'s address is {users.GetAddress()} and they are {users.GetAge()} years old\n");
            Console.WriteLine($"Autoplay:  {prefs.GetAutoPlay()}\n" + 
                $"Volume Level: {prefs.GetVolumeLevel()}");
            Console.WriteLine($"Autoplay:  {users.GetPreferences().GetAutoPlay()}\n" +
                              $"Volume Level: {users.GetPreferences().GetVolumeLevel()}");


            // press any key to continue
            Console.WriteLine("\r\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
