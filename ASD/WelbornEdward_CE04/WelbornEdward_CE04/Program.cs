using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WelbornEdward_CE04
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
            bool bRunning = true;
            string input = null;
            Console.SetWindowSize(120, 30);
            int xpos = 550;
            int ypos = 275;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            CollectionManager currentManager = null;
            List<Card> AvailableCards = new List<Card>();
            Card currentCard = new Card();
            while (bRunning)
            {
                // Main Menu
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\r\n       CE04 Assignment");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("-----------------------------\r\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[1] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Create collection manager ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(ccm)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[2] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Create empty collection ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(cec)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[3] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Create a Card ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(cac)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[4] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Add a card to a collection ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(add)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[5] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Remove a card from a collection ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(remove)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[6] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Display a collection ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(display)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[7] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Display all collections ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(dac)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[8] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Exit ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(e)(x)(exit)");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\r\n-----------------------------");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\r\nPlease enter your choice");
                Console.Write("Use either the number, phrase or abbreviation in parenthesis to choose: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "ccm":
                    case "create collection manager":
                        {
                            // Creating the Collection manager
                            /* Create collection manager- this option creates a new CollectionManager object and assigns it to the currentManager variable.  
                             * This is the one situation where created items can be lost.
                             */
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nCreating a New Collection: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Do you want to create a collection, warning present data will be lost!");
                            Console.Write("Continue: Y(es) or N(o): ");
                            string sInput = Console.ReadLine().ToLower();
                            switch (sInput)
                            {
                                case "y":
                                case "yes":
                                    {
                                        currentManager = new CollectionManager();
                                        Console.WriteLine("\nCurrent Collection has been Cleared: ");
                                        Utility.PressAnyKey("Press any key to continue");
                                    }
                                    break;
                                case "n":
                                case "no":
                                    {
                                        Console.WriteLine("\nCurrent Collection has NOT been Cleared: ");
                                        Utility.PressAnyKey("Press any key to continue");
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("\nNo Valid Choice Made");
                                        Console.WriteLine("Current Collection has NOT been Cleared: ");
                                        Utility.PressAnyKey("Press any key to continue");
                                    }
                                    break;
                            }
                        }
                        break;
                    case "2":
                    case "cec":
                    case "create empty collection":
                        {
                            /* Create empty collection - At least one empty collection list needs to be created before a card can be added to it. */
                            string name = Validation.GetString("Enter name for collection: ");
                            // Need key error checking here
                            currentManager.Collections.Add(name, new List<Card>());
                        }
                        break;
                    case "3":
                    case "cac":
                    case "create a card":
                        {
                            /* Create a card - this option prompts the user for the input necessary to create a new 
                             * Card and adds it to the available cards list in the currentManager.
                             */
                            string cardName = Validation.GetString("Enter name for card: ");
                            string desc = Validation.GetString("Enter description for card: ");
                            decimal value = Validation.GetDecimal("Enter card value: ");
                            Card card = new Card() {CardName = cardName, CardDescription = desc, CardValue = value };
                            currentManager.Cards.Add(card);
                            Utility.PressAnyKey("Press Any Key To Continue");
                        }
                        break;
                    case "4":
                    case "add":
                    case "add a card to a collection":
                        {
                            /* Add a card to a collection - this option prompts the user for a collection to add the card to, 
                             * presents the user with a list of the available cards, the user selects a card, the selected card is 
                             * removed from the available cards list, and is added to the specified collection.  
                             * If the collection does not exist it should be created and the card added to it.
                             */
                            int j = 0;
                            int i = 0;
                            Console.Clear();
                            Console.WriteLine("\n");
                            if (!currentManager.Cards.Any())
                            {
                                Console.WriteLine("No cards available. Please create card(s).");
                            }
                            else
                            {
                                foreach (var coll in currentManager.Collections)
                                {
                                    i++;
                                    Console.WriteLine($"Collection [{i}]: {coll.Key}");
                                }

                                //                                if (!currentManager.Collections.ContainsKey(collectionName))

                                int iInput = Validation.GetInt("\nPlease Choose a Collection: ");
                                Console.WriteLine($"Collection: {currentManager.Collections.ElementAt(iInput - 1).Key}");
                                string collectionName = currentManager.Collections.ElementAt(iInput - 1).Key;
                                // currentManager.Collections.Add(collectionName, new List<Card>());

                                for (i = 0; i < currentManager.Cards.Count; i++)
                                {
                                    Console.WriteLine($"Card [{i + 1}]:  {currentManager.Cards[i]}");
                                }

                                int cardNumber = Validation.GetInt("Please select a card: ");
                                currentManager.Collections[collectionName].Add(currentManager.Cards[cardNumber - 1]);
                                currentManager.Cards.RemoveAt(cardNumber - 1);

                            }

                            // Console.WriteLine("\r\nYou Chose to add a card to a collection");
                            // AddCard(currentManager, Available);
                            Utility.PressAnyKey("Press Any Key To Continue");
                        }
                        break;
                    case "5":
                    case "remove":
                    case "remove a card from a collection":
                    {
                        // need to convert to select by number instead of by name without using elementAT
                        int i = 0;
                            foreach (var coll in currentManager.Collections)
                            {
                                i++;
                                Console.Write($"Collection: [{i}]");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"{coll.Key}");
                                Console.ForegroundColor = ConsoleColor.Gray;

                            }
                            Console.WriteLine("WARNING: Collection name is case sensitive:");
                            string collectionName = Validation.GetString("Enter collection Name: ");
                            

                            if (!currentManager.Collections.ContainsKey(collectionName))
                            {
                                Console.WriteLine("Collection with the given name doesn't exist. Name is case sensitive!");
                            }
                            else
                            {
                                for (i = 0; i < currentManager.Collections[collectionName].Count; i++)
                                {
                                    Console.WriteLine($"{(i + 1)} {currentManager.Collections[collectionName][i]}");
                                }

                                Console.WriteLine();
                                int cardNumber = Validation.GetInt("Please select a card: ");
                                currentManager.Cards.Add(currentManager.Collections[collectionName][cardNumber - 1]);
                                currentManager.Collections[collectionName].RemoveAt(cardNumber - 1);

                            }
                            /* Remove a card from a collection - this option prompts the user for a collection to remove the card from, 
                             * presents the user with a list of cards in that collection, the user selects a card, the selected card is 
                             * removed from the collection and is added to the list of available cards.
                             */
                            /*
                            Console.Clear();
                            int i = 0;
                            int j = 0;
                            foreach (var coll in currentManager.Collections)
                            {
                                i++;
                                Console.WriteLine($"Collection [{i}]: {coll.Key}");
                                Console.WriteLine("\nCard in collection ");
                                if (coll.Value.Count > 0)
                                {
                                    Console.WriteLine(
                                        "Name                           Description                                   Value");
                                    Console.WriteLine(
                                        "-----------------------------------------------------------------------------------");
                                    foreach (Card c in coll.Value)
                                    {
                                        Console.WriteLine(c);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No Cards in Collection");
                                }
                            }

                            int iInput = Validation.GetInt("\nPlease Choose a Collection to View: ");
                            Console.WriteLine($"Collection: {currentManager.Collections.ElementAt(iInput -1).Key}");
                            if (currentManager.Collections.Count > 0)
                            {
                                Console.WriteLine();
                                if (currentManager.Cards.Count > 0)
                                {
                                    foreach (Card aCard in currentManager.Collections.ElementAt(iInput -1).Value)
                                    {
                                        j++;
                                        Console.WriteLine($"Card[{j}]: {aCard}");
                                    }
                                    int iInput2 = Validation.GetInt($"\nPlease Choose a Card to remove from {currentManager.Collections.ElementAt(iInput -1).Key}'s Collection: ");
                                    currentManager.Cards.Add(currentManager.Collections.Values.ElementAt(iInput2 -1))
                                    currentManager.Collections.ElementAt(iInput - 1).Value.RemoveAt(iInput2 - 1);
                                }
                                else
                                {
                                    Console.WriteLine("The List of Available Cards in Empty");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No Collection with the Collector's Name {currentManager.Collections.ElementAt(iInput).Key}");
                            }
                            */
                            Utility.PressAnyKey("Press Any Key To Continue");
                        }
                        break;
                    case "6":
                    case "display":
                    case "display a collection":
                    {
                       
                            /* Display a collection - this option prompts the user for a collection to display and then either displays 
                             * all of the cards in the collection or displays a message if the collection does not exist.
                            */
                            int i = 0;
                            CollectionManager tempCollection = new CollectionManager();
                            Console.Clear();
                            Console.WriteLine("\n");
                            foreach (var coll in currentManager.Collections)
                            {
                                i++;
                                Console.WriteLine($"Collection [{i}]: {coll.Key}");
                            }

                            int iInput = Validation.GetInt("\nPlease Choose a Collection to View: ");
                            Console.WriteLine($"\nCollection: {currentManager.Collections.ElementAt(iInput - 1).Key}");
                            Console.WriteLine("Cards:");
                            Console.WriteLine("Name                           Description                                   Value");
                            Console.WriteLine("-----------------------------------------------------------------------------------");
                            foreach (Card c in currentManager.Collections.ElementAt(iInput - 1).Value)
                                {
                                    Console.WriteLine(c);
                                }
                            Utility.PressAnyKey("Press Any Key To Continue");
                        }
                        break;
                    case "7":
                    case "dac":
                    case "display all collections":
                        {
                            /* Display all collections - this option loops through all of the collections in the dictionary 
                             * and displays all of the cards in each collection.
                             */
                            Console.Clear();
                            if (currentManager.Collections.Any())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\r\nCollections");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("------------------------------");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                foreach (var coll in currentManager.Collections)
                                {
                                    Console.WriteLine("\nCards in collection " + coll.Key);
                                    if (coll.Value.Count > 0)
                                    {
                                        Console.WriteLine("Name                           Description                                   Value");
                                        Console.WriteLine("-----------------------------------------------------------------------------------");
                                        foreach (Card c in coll.Value)
                                        {
                                            Console.WriteLine(c);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No Cards in Collection");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Collection Found");
                            }
                            if (currentManager.Cards.Count > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\nAvailable");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Name                           Description                                   Value");
                                Console.WriteLine("-----------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                foreach (var cards in currentManager.Cards)
                                {
                                    Console.WriteLine(cards);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Available Cards Found");
                            }
                            Utility.PressAnyKey("Press Any Key To Continue");
                        }
                        break;

                    case "8":
                    case "e":
                    case "exit":
                    case "x":
                        {
                            // Exit - stop the program.

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\r\nExitting Program");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            bRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Enter a Value 1 - 8, the phrase, or the abbreviated phrase in ():");
                            Utility.PressAnyKey("Press Any Key to Continue");
                        }
                        break;
                }
            }

            Utility.PressAnyKey("Press Any Key To exit");
        }

        public static void AddCard(Dictionary<string, List<Card>> Collector, List<Card> Available)
        {
            string sCollectorName = string.Empty;

            // Add a card to a collection -
            // this option prompts the user for a collection to add the card to, 
            // presents the user with a list of the available cards, the user selects a card, 
            // the selected card is removed from the available cards list, and is added to the specified collection.
            // If the collection does not exist it should be created and the card added to it.

        }
        public static void RemoveCard(Dictionary<string, List<Card>> Collector, List<Card> Available)
        {
            //Remove a card from a collection - 
            // this option prompts the user for a collection to remove the card from, 
            // presents the user with a list of cards in that collection, the user selects a card, 
            // the selected card is removed from the collection and is added to the list of available cards.
        }
        public static void MoveCards(Dictionary<string, List<Card>> Collector, List<Card> Available)
        {
            // Add a menu option that allows the user to move a card directly from one collection to another without having to move it to the available cards list first.
            Console.WriteLine("Feature In Process");
            Utility.PressAnyKey("Press Any Key To Continue");
        }


        public static void DisplayCollection(Dictionary<string, List<Card>> Collector)
        {
            // Dictionary<string, List<Card>> CardCollector = new Dictionary<string, List<Card>>();
            bool bContains = false;
            string sCollection = string.Empty;
            sCollection = Validation.GetString("Choose a Collection: ");

            // bool Contains = Collector.ContainsKey(Collection);
            // Display a collection - 
            // this option prompts the user for a collection to display and then either displays all of the cards in the collection or 
            // displays a message if the collection does not exist.
            bContains = Collector.ContainsKey(sCollection);
            if (bContains)
            {
                Console.WriteLine($"Cards owned by {sCollection}");

                for (int count = 0; count < Collector.Count; count++)
                {
                    var element = Collector.ElementAt(count);
                    var Key = element.Key;
                    var Value = element.Value;
                    Console.WriteLine(Key + "  " + Value);
                }
                // then choose a collector to display their cards
            }
            else
            {
                Console.WriteLine($"There is no Collector with the name: {sCollection}");
            }
        }
    }
}
/*
Chris MaxwellMon Apr 15 @ 03:03 pm CDT

Classes: Good 15/20,
A default constructor (the constructor method with an empty parameter list) is not needed for the Card class, especially since that constructor performs nothing. 
We never want an empty (members not populated with values) Card class object instantiated for this program. *** Fixed

The "Card" class contained helper method for working with collections. The goal for the "Card" class was to act as a model for a reword object, in this case -
a playing card. A playing card does not know anything about a dealer or what stack of cards it resides. It simply is a card with a name, description, and value.
How, where, when it is used is not the concern of the Card class, it it is the concern of the collection manager. You can think of the collection manager class as a the "dealer" 
who is in control of adding cards to a deck (available list) and dealing them to different players (named lists in the dictionary).
The "CollectionManager" manager class used the identifier (name) "currentManager" for its dictionary. An instance of a dictionary is not the same as an instance of a collection manager.

Dictionary and List Usage: Excellent 25/25

Menu: Poor 0/25,
The "create collection manager" menu option does not use the "new" keyword to create a new instance of the "CollectionManager" class.
The "create empty collection" menu option has no functionality described from the instructions.
The "create a card" menu option does not access the available list of cards through the collection manager. The collection manager class could have had a method which 
performs the functionality described in the instructions.
The "add a card to a collection" menu option does not add cards to the dictionary owned by the collection manager class. Either allow public acces to the dictionary 
through a property or method, or implement a method in the collection manager class which accomplishes the required functionality.
The "Move Card out of Collection" menu option was not required. Accomplish all other tasks for an assignment before attempting to implement additional features.

Main: Fair 4.5/15, 
The "Available" variable in the program's "Main" method was not needed as that list is already represented in the collection manager class. 
The same statement could be made for the "Collector" variable. 
The "currentCard" variable is also not needed. If it is only used in one menu case then it can be declared local to that menu case.
The "currentManager" variable was assigned a new instance of the collection manager class. The goal was to implement null-protection in the menu handling of that variable, 
and only have an instance created when the user selects the first menu option.

Input Validation: Fair 4.5/15, **** +=+=+=+=+ **** Fixed my validation mess.
Don't forget to always inform the user that their input is invalid and why it was rejected. The user may become confused as to why the program is not responding 
when they enter something. The user is more likely to blame the program as being broken than to realize they are making a mistake.
Unfortunately, blank (all spaces) input was accepted. The user should always be required to enter something and something other than solely spaces. Research the 
IsNullOrWhiteSpace methods.* */


