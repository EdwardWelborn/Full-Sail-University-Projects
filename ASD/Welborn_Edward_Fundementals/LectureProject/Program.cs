using System;
using System.Collections.Generic;
using System.IO;

namespace LectureProject
{
    class Program
    {
        //this is the main character
        private static List<Character> characters;
        //Random used for character generation
        public static Random rand = new Random();

        static void Main(string[] args)
        {
            //initialize the characters list
            characters = new List<Character>();

            while (true)
            {
                //show the menu
                PrintMenu();

                //get user input
                String userSelection = Console.ReadLine();
                userSelection = userSelection.ToLower();

                //handle user input
                //switch statement
                switch (userSelection)
                {
                    //case to create character
                    case "create character":
                    case "1":
                        CreateCharacter();
                        break;
                    //case to display status
                    case "display status":
                    case "2":
                        if (characters.Count > 0)
                        {
                            foreach(Character c in characters)
                            {
                                Console.WriteLine(c);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No characters to display.");
                        }
                        break;
                    //case to exit
                    case "save":
                    case "3":
                        Save();
                        break;
                    //case to exit
                    case "load":
                    case "4":
                        Load();
                        break;
                    //case to exit
                    case "exit":
                    case "5":
                        return;
                    //default
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            }

        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            if (characters.Count == 0)
            {
                Console.WriteLine("No characters currently exist.");
            }
            Console.WriteLine();
            Console.WriteLine("Select an option.");
            Console.WriteLine("1. Create Characters");
            Console.WriteLine("2. Display Status");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
        }

        private static void Save()
        {
        }

        private static void Load()
        {
        }

        //creates a new mainCharacter
        private static void CreateCharacter()
        {
            Console.WriteLine("Please provide 3 character names. Press enter key after each entry.");
            for(int i = 0; i < 3; i++)
            {
                string characterName = Console.ReadLine();
                Character tempChar = new Character();
                tempChar.Name = characterName;
                characters.Add(tempChar);
            }
        }
    }
}
