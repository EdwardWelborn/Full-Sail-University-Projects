// Connection.TXT Location
// c:/VFW/Connection.txt (this file contains ONLY the ip address of the mysql server
//Database Location
//  string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=SampleRestaurantDatabase;port=8889";
//Output Location
//  string outPutPath = $@"../../../FirstLast_ConvertedData.json";

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;


namespace EdwardWelborn_ConvertedData
{
    class Program
    {
        /// This section of code deals with setting the window position other than default
         
        const int SWP_NOSIZE = 0x0001;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        /// 

        static void Main(string[] args)
        {
            MainMenu(); // Main Menu for the program
        }
        public static void MainMenu()
        {
            // This Method is the main menu for the program, it is called from the main method of the program

            List<string> restaurantProfileList = new List<string>();
            string sConnection = string.Empty;
            StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
            sConnection = Config.ReadLine();
            // MySQL Database Connection String
            string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=SampleRestaurantDatabase;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);
            conn.Open();

            // Populate restaurant profile list
            restaurantProfileList = GetProfile(conn);

            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "                      Data Conversion Assignment\n" +
                        "-------------------------------------------------------------------------\n" +
                        "[1]..  Convert The Restaurant Reviews Database From SQL To JSON {convert}\n" +
                        "[2]..  Showcase Our 5 Star Rating System {showcase}\n" +
                        "[3]..  Showcase Our Animated Bar Graph Review System {reviews}\n" +
                        "[4]..  Play A Card Game {play}\n" +
                        "[5]..  Exit Program {e}\n" +
                        "-------------------------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 5, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "convert the restaurant reviews database from sql To json":
                    case "convert":
                        {
                            ConvertDataToFile(restaurantProfileList);
                        }
                        break;
                    case "2":
                    case "showcase sur 5 star rating system":
                    case "showcase":
                        {
                            ShowCase();
                        }
                        break;
                    case "3":
                    case "showcase our animated bar graph review system":
                    case "reviews":
                        {
                            ShowReviews();
                        }
                        break;
                    case "4":
                    case "play a card game":
                    case "play":
                        {
                            PlayCardGame();
                        }
                        break;
                    case "5":
                    case "e":
                    case "exit program":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 5, or abbreviated phrase in {}:");
                        }
                        break;
                }
                if (!bProgramRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Exit the Program");
                }
            }
        }

        public static void ConvertDataToFile(List<string> restaurantProfileList)
        {
            // This method iterates through the list converted from the database then
            // Reads the data from the header list, adds the data to a list, 
            // Then Splits the list into another list for the key:value pairs
            // when completed, it will write the output file.

            string outPutPath = $@"../../../FirstLast_ConvertedData.json";
            List<String> header = new List<String> {"Id", "RestaurantName", "Address", "Phone", "HoursOfOperation", "Price", "USACityLocation", "Cuisine", "FoodRating", "ServiceRating",
                "AmbienceRating", "OverallRating", "OverAllPossibleRating", "End of Record Indicator"};

            Console.WriteLine($"\r\nCreating Output File: ");
            
            List<string> data = new List<string>();
            List<string> totalString = new List<string>();
            List<List<string>> splitter = new List<List<string>>();
            List<string> quotedString = new List<string>();
            
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(outPutPath))
                {
                    // If file found, delete it    
                    File.Delete(outPutPath);
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            // JSON output file
            StreamWriter OutFile = new StreamWriter(outPutPath);
            // Add JSON formatting to header list 
            List<string> tmpHeader = new List<string>();
            
            foreach (string newHeaderstr in header)
            {
                tmpHeader.Add($"       \"{newHeaderstr}\"" + ": ");
            }
            // header processes fine with new string -- fix below
            // Splits each record into a list to add to the header
            List<string> tempList = new List<string>();
            foreach (string strItem in restaurantProfileList)
            {
                char[] splitChar = { '~' };
                tempList = strItem.Split(splitChar).ToList();
                splitter.Add(tempList);
            }

            // read through the splitter list, and add the new value string pattern
            foreach (List<string> lstItem in splitter)
            {
                foreach (string strItem in lstItem)
                {
                    if (!strItem.Contains("!end"))
                    {
                        quotedString.Add($"\"{strItem}\",");
                    }
                    else
                    {
                        quotedString.Add($"\"{strItem}\"");
                    }
                }
            }
            // Add header list, and quoted string list to the total string
            int iTemp = 0;
            foreach (string strQuoted in quotedString)
            {
                if (iTemp >= tmpHeader.Count)
                {
                    iTemp = 0;
                }
                totalString.Add(tmpHeader[iTemp] + strQuoted);
                iTemp++;
            }
            // Write file header
            OutFile.WriteLine("[");
            OutFile.WriteLine("    {");
            // output total string to output file.
            for (int iOutPut = 0; iOutPut < totalString.Count; iOutPut++)
            {
                OutFile.WriteLine((totalString[iOutPut]));
                if ((totalString[iOutPut].Contains("!end") && (iOutPut != totalString.Count - 1)))
                {
                    OutFile.WriteLine("    },");
                    OutFile.WriteLine("    {");
                }

                if (iOutPut == totalString.Count - 1)
                {
                    OutFile.WriteLine("    }");
                }
            }

            // Write file footer
            OutFile.WriteLine("]");
            // close all files
            OutFile.Close();
            // Inform user the file has been created
            Console.WriteLine($"The Output File has been created.");
            // Wait for user to continue back to menu.  
            Utility.PressAnyKeyToContinue("Press The Space Bar to return to the Main Menu...");
        }
        public static void ShowCase()
        {
            // Showcare menu from main, this showcases their ratings (Not implemented in this release)
            bool boolShowCaseRunning = true;

            /*
            1. List Restaurants Alphabetically (Show Rating Next To Name)
            2. List Restaurants in Reverse Alphabetical (Show Rating Next To Name)
            3. Sort Restaurants From Best to Worst (Show Rating Next To Name)
            4. Sort Restaurants From Worst to Best (Show Rating Next To Name)
            5. Show Only X and Up
            Sub-Menu
            1. Show the Best (5 Stars)
            2. Show 4 Stars and Up
            3. Show 3 Stars and Up
            4. Show the Worst (1 Stars)
            5. Show Unrated
            6. Back
            6. Exit

            */
            while (boolShowCaseRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "                            Data Conversion Assignment\n" +
                        "                           Showcase Our 5 Star Ratings\n" +
                        "------------------------------------------------------------------------------------\n" +
                        "[1]..  List Restaurants Alphabetically (Show Rating Next To Name) {alphabetically}\n" +
                        "[2]..  List Restaurants in Reverse Alphabetical (Show Rating Next To Name) {reverse}\n" +
                        "[3]..  Sort Restaurants From Best to Worst (Show Rating Next To Name) {best}\n" +
                        "[4]..  Sort Restaurants From Worst to Best (Show Rating Next To Name) {worst}\n" +
                        "[5]..  Show Only X and Up {show}\n" +
                        "[6]..  Return to the Main Menu {e}\n" +
                        "-----------------------------------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "list restaurants alphabetically":
                    case "alphabetically":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "2":
                    case "list restaurants in reverse alphabetical":
                    case "reverse":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "3":
                    case "sort restaurants from best to worst":
                    case "best":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "4":
                    case "sort restaurants from worst to best":
                    case "worst":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "5":
                    case "Show Only X and Up":
                    case "show":
                        {
                            ShowCaseSubMenu();
                        }
                        break;
                    case "6":
                    case "e":
                    case "return to the main menu":
                        {
                            boolShowCaseRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                        }
                        break;
                }
                if (!boolShowCaseRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key to Return to the Main Menu");
                }

            }
        }
        public static void ShowCaseSubMenu()
        {
            /* Submenu for Showcase Menu option.  (This feature is not implemented yet, see future release)
            1.Show the Best(5 Stars)
            2.Show 4 Stars and Up
            3.Show 3 Stars and Up
            4.Show the Worst(1 Stars)
            5.Show Unrated
            6.Back
            */
            bool boolSubMenuRunning = true;
            while (boolSubMenuRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "                           Data Conversion Assignment\n" +
                        "                          Showcase Our 5 Star Ratings\n" +
                        "------------------------------------------------------------------------------------\n" +
                        "[1]..  List Restaurants Alphabetically (Show Rating Next To Name) {alphabetically}\n" +
                        "[2]..  List Restaurants in Reverse Alphabetical (Show Rating Next To Name) {reverse}\n" +
                        "[3]..  Sort Restaurants From Best to Worst (Show Rating Next To Name) {best}\n" +
                        "[4]..  Sort Restaurants From Worst to Best (Show Rating Next To Name) {worst}\n" +
                        "[5]..  Show Only X and Up {show}\n" +
                        "[6]..  Return to the ShowCase Menu {e}\n" +
                        "------------------------------------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}:");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "list restaurants alphabetically":
                    case "alphabetically":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "2":
                    case "list restaurants in reverse alphabetical":
                    case "reverse":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "3":
                    case "sort restaurants from best to worst":
                    case "best":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "4":
                    case "sort restaurants from worst to best":
                    case "worst":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "5":
                    case "Show Only X and Up":
                    case "show":
                        {
                            ShowCaseOnlyX();
                        }
                        break;
                    case "6":
                    case "e":
                    case "return to the showcase menu":
                        {
                            boolSubMenuRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                        }
                        break;
                }
                if (!boolSubMenuRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Showcase Menu.");
                }

            }
        }
        public static void ShowReviews()
        {
            bool boolShowReviewRunning = true;

            /* Hello <user>, How would you like to sort the data:
             1. Show Average of Reviews for Restaurants 
             Show Average of Reviews for Restaurants 
            This will be 100 bar graphs. Be sure to limit it to something like 10 for testing, and set it to 100 when done.
            Not Animated - Show the restaurant name, bar graph, and average positive/total reviews
            The bar graphs must change color based on Good, Bad, or Average reviews
            2. Dinner Spinner (Selects Random Restaurant)
            Show average of reviews
            Animated - Show the restaurant name, animated bar graph, and average positive/total reviews 
            The bar graphs must change color based on Good, Bad, or Average reviews
            3. Top 10 Restaurants
            Averages all reviews per restaurant, sorts them and selects the top 10 to show
            Animated - Show the restaurant name, animated bar graph, and average positive/total reviews, from best (most positive reviews) to worst (least positive reviews)
            The bar graphs must change color based on Good, Bad, or Average reviews
            4. Back To Main Menu
            */
            while (boolShowReviewRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "              Data Conversion Assignment\n" +
                        "      Showcase Our Animated Bar Graph Review System\n" +
                        "-----------------------------------------------------------\n" +
                        "[1]..  Show Average of Reviews for Restaurants {average}\n" +
                        "[2]..  Dinner Spinner (Selects Random Restaurant) {spinner}\n" +
                        "[3]..  Top 10 Restaurants {topten}\n" +
                        "[5]..  Return to the Main Menu {e}\n" +
                        "-----------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}:");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "list restaurants alphabetically":
                    case "average":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "2":
                    case "list restaurants in reverse alphabetical":
                    case "spinner":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "3":
                    case "sort restaurants from best to worst":
                    case "topten":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "5":
                    case "e":
                    case "return to the main menu":
                        {
                            boolShowReviewRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}: ");
                        }
                        break;
                }
                if (!boolShowReviewRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Menu.");
                }

            }

        }
        public static void PlayCardGame()
        {
            /*
             * sub menu
             * shuffle
             * deal
             * quit
             */
            bool boolPlayCardGameRunning = true;
            while (boolPlayCardGameRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "    Data Conversion Assignment\n" +
                        "        Play a Card Game\n" +
                        "-----------------------------------\n" +
                        "[1]..  Shuffle the Deck {shuffle}\n" +
                        "[2]..  Deal the Cards {deal}\n" +
                        "[3]..  Return to the Main Menu {e}\n" +
                        "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 3, or abbreviated phrase in {}:");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "shuffle the deck":
                    case "shuffle":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "2":
                    case "deal the cards":
                    case "deal":
                        {
                            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
                        }
                        break;
                    case "3":
                    case "e":
                    case "return to the main menu":
                        {
                            boolPlayCardGameRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 3, or abbreviated phrase in {}: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to play again.");
                        }
                        break;
                }
                if (!boolPlayCardGameRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu.");
                }
            }
        }
        public static List<string> GetProfile(MySqlConnection conn)
        {
            // Method to get 20 records starting at record 1100. Adding that to the inventory list.

            Console.WriteLine("Populating Restaurant Profile List\n");
            List<string> restaurantProfile = new List<string>();
            try
            {
                decimal FoodRating = 9;
                decimal ServiceRating = 0;
                decimal AmbienceRating = 0;
                decimal OverallRating = 0;
                decimal OverAllPossibleRating = 0;
                string newList = string.Empty;
                int ID = 0;
                // Form SQL Statement

                string stm = "select * from RestaurantProfiles";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>
                    
                    int.TryParse(rdr["Id"].ToString(), out ID);

                    string RestaurantName = rdr["RestaurantName"].ToString();
                    string Address = rdr["Address"].ToString();
                    string Phone = rdr["Phone"].ToString();
                    string HoursOfOperation = rdr["HoursOfOperation"].ToString();
                    string Price = rdr["Price"].ToString();
                    string USACityLocation = rdr["USACityLocation"].ToString();
                    string Cuisine = rdr["Cuisine"].ToString();

                    decimal.TryParse(rdr["FoodRating"].ToString(), out FoodRating);
                    decimal.TryParse(rdr["ServiceRating"].ToString(), out ServiceRating);
                    decimal.TryParse(rdr["AmbienceRating"].ToString(), out AmbienceRating);
                    decimal.TryParse(rdr["OverallRating"].ToString(), out OverallRating);
                    decimal.TryParse(rdr["OverallPossibleRating"].ToString(), out OverAllPossibleRating);
                    newList = ID + "~" + RestaurantName + "~" + Address + "~" + Phone + "~" + HoursOfOperation + "~" + Price +
                              "~" + USACityLocation + "~" + Cuisine + "~" + FoodRating + "~" +
                              ServiceRating + "~" + AmbienceRating + "~" + OverallRating + "~" + OverAllPossibleRating +
                              "~" + "!end";
                    restaurantProfile.Add(newList);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {

                    conn.Close();
                }
            }
//            foreach (RestaurantProfile itm in restaurantProfile)
//            {
//                Console.WriteLine(itm.ToString());
//            }
//            Utility.PressAnyKeyToContinue("pause");
            return restaurantProfile;
        }

        public static void ShowCaseOnlyX()
        {
            Utility.PressAnyKeyToContinue("This Feature will be implemented in a future release, press any key to return to the menu:");
        }
    }
}

