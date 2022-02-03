using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Channels;


namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;

            char[] delimiters = new char[] { ' ', ',', '.', '\t', '=', ';', '"', '+', '\n', '\r', '-', '_', ':' };

            // Show Menu
            while (!exitProgram)
            {
                String text = GetSpeech();
                List<string> splitSpeech = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                Dictionary<string, int> wordCount = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Regex.Replace(x.ToLower(), "[^a-zA-Z0-9-]", ""))
                    .GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count());

                MainMenu();
                int menuChoice = Validation.ValidateInt(Console.ReadLine());
                
                switch (menuChoice)
                {
                        case 1:
                        {
                            ShowSpeech(text);
                            break;
                        }
                        case 2:
                        {
                            listWords(splitSpeech);
                            break;
                        }
                        case 3:
                        {
                            showHistogram(wordCount);
                            break;
                        }
                        case 4:
                        {
                            // TODO: This entire section Needs done
                            wordSearch(wordCount);
                            break;
                        }
                        case 5:
                        {
                            // TODO: This entire section Needs done
                            removeWord(splitSpeech);
                            break;
                        }
                        case 6:
                        {
                            // Exit Prompt -- This works as intended and completed
                            Console.WriteLine("\n\nThank you for using Histogram!");
                            Utility.PressAnyKeyToContinue("Press Any Key to Exit");
                            System.Environment.Exit(-1);
                            exitProgram = true;
                            break;
                        }

                    default:
                    {
                        // This works as intended and is completed
                        Console.WriteLine("Please Input a number from 1..6!");
                        Utility.PressAnyKeyToContinue("Press Any Key to Exit");
                        break;
                    }
                            
                }
            }
            static void MainMenu()
            {
                Console.Clear();
                Console.WriteLine("1.. The Speech");
                Console.WriteLine("2.. List of Words");
                Console.WriteLine("3.. Show Histogram");
                Console.WriteLine("4.. Search for a Word");
                Console.WriteLine("5.. Remove a Word");
                Console.Write("\n6.. Exit the Program: \b_");
            }
        
        }

        public static String GetSpeech()
        {
            // This method grabs all the text from the filename and returns a string for processing
            StreamReader sr = new StreamReader(@"D:\GitHub\Full-Sail-University-Projects\PG2\Histogram\Histogram\speechString.txt");
           
            String inline = sr.ReadToEnd();

            return inline;
        }

        private static void removeWord(List<string> output)
        {
            Console.Clear();

            Utility.PressAnyKeyToContinue("Press Any Key to Return to Main Menu");
        }

        private static void wordSearch(Dictionary<string, int> input)
        {
            // This method searches for a word in the unique dictionary
            
            Console.Clear();
            Dictionary<String, int> resultList = new Dictionary<string, int>();
            Console.Write("Please Enter a Word to Search: ");
            String result = Validation.ValidateText(Console.ReadLine());

            if (input.ContainsKey(result))
            {

                // Utility.PrintBars();

            }
            else
            {
                Console.WriteLine($"\nKeyword {result} not found!");
            }

           //  Utility.PrintBars(resultList.ToList());

            Utility.PressAnyKeyToContinue("\nPress Any Key to Return to Main Menu");
        }

        private static void showHistogram(Dictionary<string, int> input)
        {
            // This method Counts each word, adds it to a dictionary and displays the result
            Console.Clear();

            Utility.PrintBars(input.ToList());

            Utility.PressAnyKeyToContinue("Press Any Key to Return to Main Menu");
        }

        private static void listWords(List<string> items)
        {
            // This method shows the list or words
            Console.Clear();
            foreach (object obj in items)
            {
                Console.WriteLine(obj);
            }
            Utility.PressAnyKeyToContinue("\nPress Any Key to Return to Main Menu");
        }

        private static void ShowSpeech(String text)
        {
            // This method shows the raw text that came in from the text file
            Console.Clear();
            Console.WriteLine(text);
            Utility.PressAnyKeyToContinue("\nPress Any Key to Return to Main Menu");
        }
    }
}
