using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WelbornEdward_CE05
{
    class Program
    {
        const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        static void Main(string[] args)
        {
            int i = 0;
            string sUserChoice = String.Empty;
            bool bProgramRunning = true;
            Console.SetWindowSize(120, 30);
            int xpos = 600;
            int ypos = 275;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            List<Animal> Pets = new List<Animal>();

            Welcome(Pets);
            do
            {
                // Main Menu
                Console.Clear();
                Console.WriteLine("\r\n       CE05 Assignment");
                Console.WriteLine("-----------------------------\r\n");
                Console.WriteLine("[1]. Armadillo (arm)");
                Console.WriteLine("[2]. Chinchilla (ch)");
                Console.WriteLine("[3]. Rabbit (rab)");
                Console.WriteLine("[4]. Eagle (eag)");
                Console.WriteLine("[5]. Otter (ott)");
                Console.WriteLine("[6]. Fox (fox)");
                Console.WriteLine("[7]. Exit (e)");
                Console.WriteLine("\r\n-----------------------------");

                Console.WriteLine("Choose a number between 1 and 7, type the phrase, abbreviation in ()");
                Console.Write("\r\nPlease enter your choice: ");

                sUserChoice = Console.ReadLine().ToLower();
                switch (sUserChoice)
                {
                    case "1":
                    case "armadillo":
                    case "arm":
                        {
                            Console.Clear();
                            SubMenu((Animal));
                        }
                        break;
                    case "2":
                    case "chinchilla":
                    case "ch":
                        {
                            Console.Clear();
                            SubMenu((Animal)Chinchilla);
                        }
                        break;
                    case "3":
                    case "rabbit":
                    case "rab":
                    {
                        Console.Clear();
                        SubMenu((Animal)Rabbit);
                    }
                        break;
                    
                    case "4":
                    case "eagle":
                    case "eag":
                    {
                        Console.Clear();
                        SubMenu((Animal(Eagle);
                    }
                        break;
                    case "5":
                    case "otter":
                    case "ott":
                    {
                        Console.Clear();
                        SubMenu((Animal(Otter);
                    }
                        break;
                    case "6":
                    case "fox":
                    {
                        Console.Clear();
                        SubMenu(Fox);
                    }
                        break;
                    case "7":
                    case "exit":
                    case "e":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Choose a number between 1 and 7");
                            Utility.PressAnyKey("Press any key to Continue");
                        }
                        break;
                }
            } while (bProgramRunning);
            Utility.PressAnyKey("Press any key to exit:");
        }

        static void Welcome(List<Animal> Pets)
        {
            string sWelcome = string.Empty;

            sWelcome = Validation.GetString("Please Enter Your Name: ");
            Pets.Add(new Armadillo("Armadillo", 0, "Beetles", false));
            Pets.Add(new Chinchilla("Chinchilla", 0, "Hay", true));
            Pets.Add(new Eagle("Eagle", 0, "Fish", false));
            Pets.Add(new Rabbit("Rabbit", 0, "Grass", false));
            Pets.Add(new Fox("Fox", 0, "Mouse", true));
            Pets.Add(new Otter("Otter", 0 , "Oyster", true));
        }

        static void SubMenu(Animal animal)
        {
            string sUserChoice = string.Empty;
            bool bSubMenuRunning = true;
            do
            {
                // Main Menu
                Console.Clear();
                Console.WriteLine("\r\n   CE05 Animal Menu");
                Console.WriteLine("-----------------------------\r\n");
                Console.WriteLine("[1]. Train Pet (tp)");
                Console.WriteLine("[2]. Feed Pet (fp)");
                Console.WriteLine("[3]. Watch Pet Perform (p)");
                Console.WriteLine("[4]. Exit (e)");
                Console.WriteLine("\r\n-----------------------------");

                Console.WriteLine("Choose a number between 1 and 4, type the phrase, abbreviation in ()");
                Console.Write("\r\nPlease enter your choice: ");

                sUserChoice = Console.ReadLine().ToLower();
                switch (sUserChoice)
                {
                    case "1":
                    case "train pet":
                    case "tp":
                        {
                            Console.Clear();
                            Training(animal);
                        }
                        break;
                    case "2":
                    case "feed pet":
                    case "fp":
                        {
                            Console.Clear();
                            Feed(animal);
                        }
                        break;
                    case "3":
                    case "watch pet perform":
                    case "p":
                        {
                            Console.Clear();
                            Perform(animal);
                        }
                        break;
                    case "4":
                    case "exit":
                    case "e":
                        {
                            bSubMenuRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Choose a number between 1 and 4");
                            Utility.PressAnyKey("Press any key to continue");
                        }
                        break;
                }
            } while (bSubMenuRunning);
        }

        public static void Training(Animal animal)
        {

        }

        public static void Feed(Animal animal)
        {

        }

        public static void Perform(Animal animal)
        {

        }

        public void Poop(Animal animal)
        {

        }

    }
}
/* Animal Classes:
Some animals are trainable (dogs, dolphins, even cats) and some aren’t (snakes, fish etc) and your application should reflect that. 
At least half of the animals should implement the ITrainable interface. This will mean they will be required to implement the properties and methods as described above in the Interface section.

The Perform method should return a string similar to: "After you signaled clapping hands the otter will now perform the 'jump through the hoop' behavior."
The Train method should collect the signal and behavior strings and input them into the Behavior dictionary and return a string such as: "The dolphin learned to slap it’s tail when you point to the sky."
Contain a Behaviors property that will hold the signals and behaviors the given animal can perform based on what the user enters.

*/

/*
 * Zookeeper Application:

Your main program application class should have the following:

A List object which will contain all the animals you create. --
A method which welcomes the user and adds instances of each animal into the List object.
Your application should list the animals you’ve initialized, specify which are trainable, and give the user the option of selecting one.

Upon selecting an animal it will announce which animal was selected and then provide a menu for activities the user can do with the selected animal:


Training:

If the user selects Training, the program should ask the user what behavior they would like to teach the animal and what signal they will associate with the behavior. The program then stores this information and reprints the menu:


Feeding the Animal:

For feeding an animal a treat (this is for all animals, not just the trainable ones) it produces the following result, printing the string produced by the Eat() method in the Animal base class:


Get the animal to perform a behavior:

When signaling the animal, if the animal is trainable, then the program should ask the user for the relevant signal. If the animal is not trainable a message should show to the user: “The animal you selected is not a trainable animal. Please select a different activity or exit to select a different animal.”

If the signal is in the dictionary it should respond. (If it is not a message should be shown “The dolphin does not know this signal. Train it to recognize this signal and associate it with a behavior.” )


Make noise:

When this option is selected the animal should make a noise:

Or the user can select a different animal.

*/