using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace EdwardWelborn_CardGame
{
    class Program
    {
        /// This section of code deals with setting the window position other than default

        const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy,
            int wFlags);

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
            string cs =
                $"server={sConnection};userid=dbremoteuser;password=password;database=samplerestaurantdatabase;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);


            // Populate restaurant profile list
            restaurantProfileList = GetProfile(conn, "select * from RestaurantProfiles");

            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "                         Bar Graph Assignment\n" +
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
                            ShowCase(conn);
                        }
                        break;
                    case "3":
                    case "showcase our animated bar graph review system":
                    case "reviews":
                        {
                            ShowReviews(conn);
                        }
                        break;
                    case "4":
                    case "play a card game":
                    case "play":
                        {
                            PlayCardGame(conn);
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
                            Console.WriteLine("Please Input the phrase, or use 1 thru 5, or abbreviated phrase in {}: ");
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
            List<String> header = new List<String>
            {
                "Id", "RestaurantName", "Address", "Phone", "HoursOfOperation", "Price", "USACityLocation", "Cuisine",
                "FoodRating", "ServiceRating",
                "AmbienceRating", "OverallRating", "OverAllPossibleRating", "End of Record Indicator"
            };

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

        public static void ShowCase(MySqlConnection conn)
        {
            // Showcare menu from main, this showcases the restaurant ratings
            // This method also calls the ShowCaseSubMenu for more rating information

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
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "                              Bar Graph Assignment\n" +
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
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles order by RestaurantName ASC;");
                        }
                        break;
                    case "2":
                    case "list restaurants in reverse alphabetical":
                    case "reverse":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles order by RestaurantName DESC;");
                        }
                        break;
                    case "3":
                    case "sort restaurants from best to worst":
                    case "best":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles order by OverallRating ASC;");
                        }
                        break;
                    case "4":
                    case "sort restaurants from worst to best":
                    case "worst":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles order by OverallRating DESC;");
                        }
                        break;
                    case "5":
                    case "Show Only X and Up":
                    case "show":
                        {
                            ShowCaseSubMenu(conn);
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

        public static void ShowCaseSubMenu(MySqlConnection conn)
        {
            /* Submenu for Showcase Menu option.  
             * This method is called from the ShowCase Menu Method
             * This method is for showing a different rating system than the previous menu
             * 
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
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "                              Bar Graph Assignment\n" +
                    "                          Showcase Our 5 Star Ratings\n" +
                    "------------------------------------------------------------------------------------\n" +
                    "[1]..  Show the Best (5 Star) {5 star}\n" +
                    "[2]..  Show 4 Stars and Up {4 star}\n" +
                    "[3]..  Show 3 Stars and Up {3 star}\n" +
                    "[4]..  Show the Worst {1 Star}\n" +
                    "[5]..  Show Unrated {unrated}\n" +
                    "[6]..  Return to the ShowCase Menu {r}\n" +
                    "------------------------------------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "show the best":
                    case "5 star":
                        {
                            ListData(conn, "SELECT * FROM RestaurantProfiles WHERE OverallRating = 5");
                        }
                        break;
                    case "2":
                    case "show 4 stars and up":
                    case "4 star":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles where OverallRating >= 4 Order By OverallRating Desc;");
                        }
                        break;
                    case "3":
                    case "show 3 stars and up":
                    case "3 star":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles where OverallRating >= 3 Order By OverallRating Desc;");
                        }
                        break;
                    case "4":
                    case "show the worst":
                    case "1 star":
                        {
                            ListData(conn,
                                "SELECT * FROM SampleRestaurantDatabase.RestaurantProfiles where OverallRating <= 1 Order By OverallRating Desc;");
                        }
                        break;
                    case "5":
                    case "show unrated":
                    case "unrated":
                        {
                            ListData(conn,
                                "SELECT * FROM RestaurantProfiles WHERE OverallRating is null Order By RestaurantName;");
                        }
                        break;
                    case "6":
                    case "r":
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

        public static void ShowReviews(MySqlConnection conn)
        {
            bool boolShowReviewRunning = true;

            /* This method is called from the ShowCaseMenu to display reviews on the restaurants.  (This Feature is not implemented yet)
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "                Bar Graph Assignment\n" +
                    "      Showcase Our Animated Bar Graph Review System\n" +
                    "-----------------------------------------------------------\n" +
                    "[1]..  Show Average of Reviews for Restaurants {average}\n" +
                    "[2]..  Dinner Spinner (Selects Random Restaurant) {spinner}\n" +
                    "[3]..  Top 10 Restaurants {topten}\n" +
                    "[4]..  Return to the Main Menu {e}\n" +
                    "-----------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "list restaurants alphabetically":
                    case "average":
                        {
                            ListReview(conn);
                        }
                        break;
                    case "2":
                    case "list restaurants in reverse alphabetical":
                    case "spinner":
                        {
                            DinnerSpinner(conn);
                        }
                        break;
                    case "3":
                    case "sort restaurants from best to worst":
                    case "topten":
                        {
                            TopTenList(conn);
                        }
                        break;
                    case "4":
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

        public static void PlayCardGame(MySqlConnection conn)
        {
            /* This method plays a card game for the amusement of the user.  (This Feature is not implemented yet)
             * sub menu
             * shuffle
             * deal
             * quit
             */
            List<string> lstPlayers = new List<string>();
            bool boolPlayCardGameRunning = true;
            while (boolPlayCardGameRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "      Bar Graph Assignment\n" +
                    "        Play a Card Game\n" +
                    "-----------------------------------\n" +
                    "[1]..  Shuffle the Deck {shuffle}\n" +
                    "[2]..  Deal the Cards {deal}\n" +
                    "[3]..  Return to the Main Menu {e}\n" +
                    "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 3, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "shuffle the deck":
                    case "shuffle":
                    {
                        lstPlayers = Shuffle(conn);
                    }
                        break;
                    case "2":
                    case "deal the cards":
                    case "deal":
                        {
                            if (lstPlayers.Count > 0)
                            {
                                DealTheCards(lstPlayers);
                            }
                            else
                            {
                                Console.WriteLine("\nPlease Shuffle The Cards First:");
                                Utility.PressAnyKeyToContinue("Press any key to try again");
                            }
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

        public static List<string> GetProfile(MySqlConnection conn, string strSQLStatement)
        {
            /// This method populates a list to be manipulated for the JSON portion of the assignment
            /// It will grab the data from the database, then can be split or manipulated into the JSON file

            Console.WriteLine("Populating Restaurant Profile List\n");
            List<string> restaurantProfile = new List<string>();
            try
            {
                double FoodRating = 0;
                double ServiceRating = 0;
                double AmbienceRating = 0;
                double OverallRating = 0;
                double OverAllPossibleRating = 0;
                string newList = null;
                //                int ID = 0;
                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string RestaurantName = rdr["RestaurantName"].ToString();
                    string Address = rdr["Address"].ToString();
                    string Phone = rdr["Phone"].ToString();
                    string HoursOfOperation = rdr["HoursOfOperation"].ToString();
                    string Price = rdr["Price"].ToString();
                    string USACityLocation = rdr["USACityLocation"].ToString();
                    string Cuisine = rdr["Cuisine"].ToString();

                    double.TryParse(rdr["FoodRating"].ToString(), out FoodRating);
                    double.TryParse(rdr["ServiceRating"].ToString(), out ServiceRating);
                    double.TryParse(rdr["AmbienceRating"].ToString(), out AmbienceRating);
                    double.TryParse(rdr["OverallRating"].ToString(), out OverallRating);
                    double.TryParse(rdr["OverallPossibleRating"].ToString(), out OverAllPossibleRating);

                    newOverAllRating = ChangeOverAllRating(OverallRating);

                    newList = (RestaurantName + "~" + Address + "~" + Phone + "~" + HoursOfOperation + "~" + Price +
                               "~" + USACityLocation + "~" + Cuisine + "~" + FoodRating + "~" +
                               ServiceRating + "~" + AmbienceRating + "~" + newOverAllRating + "~" +
                               OverAllPossibleRating +
                               "~" + "!end");
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

            conn.Close();
            return restaurantProfile;

        }

        public static void ShowCaseOnlyX()
        {
            Utility.PressAnyKeyToContinue(
                "This Feature will be implemented in a future release, press any key to return to the menu:");
        }

        public static void ListData(MySqlConnection conn, string SQLstatement)
        {
            /// This method is called from the ShowCaseMenu method,  it passes in the mysql connection string, then a SQL string in order
            /// to grab the data from the database and display accordingly.
            /// 
            List<string> restaurantData = new List<string>();
            try
            {
                double OverallRating = 0;
                string newList = null;

                // Form SQL Statement

                string stm = SQLstatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string RestaurantName = rdr["RestaurantName"].ToString();
                    string Cuisine = rdr["Cuisine"].ToString();

                    double.TryParse(rdr["OverallRating"].ToString(), out OverallRating);

                    newOverAllRating = ChangeOverAllRating(OverallRating);

                    string newName = RestaurantName.PadRight(50);
                    string newCuisine = Cuisine.PadRight(35);
                    newList = (newName + newCuisine + newOverAllRating);
                    restaurantData.Add(newList);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            /*            finally
                        {
                            if (conn != null)
                            {

                                conn.Close();
                            }
                        }
            */
            Console.Clear();
            Console.SetWindowSize(125, 63);
            int xpos = 650;
            int ypos = 10;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            Console.Clear();
            Console.WriteLine(
                "Restaurant Name                                   Cuisine                            Rating");
            Console.WriteLine(
                "-------------------------------------------------------------------------------------------");
            foreach (string obj in restaurantData)
            {
                Console.WriteLine(obj.ToString());
            }

            conn.Close();
            Utility.PressAnyKeyToContinue("Press any key to continue");
        }

        public static string ChangeOverAllRating(double OverallRating)
        {
            /// This method is called from the ListData method to change the OverAllRating from a numeric value to a star rating system
            /// 
            string newOverAllRating = string.Empty;

            if (OverallRating < 0)
            {
                newOverAllRating = "No Rating";
            }

            if (OverallRating == 0)
            {
                newOverAllRating = "0";
            }
            else if (OverallRating == 0.25)
            {
                newOverAllRating = "  1/4";
            }
            else if (OverallRating == 0.50)
            {
                newOverAllRating = "  1/2";
            }
            else if (OverallRating == 0.75)
            {
                newOverAllRating = "  3/4";
            }

            if (OverallRating == 1)
            {
                newOverAllRating = "*";
            }
            else if (OverallRating == 1.25)
            {
                newOverAllRating = "* 1/4";
            }
            else if (OverallRating == 1.50)
            {
                newOverAllRating = "* 1/2";
            }
            else if (OverallRating == 1.75)
            {
                newOverAllRating = "* 3/4";
            }

            if (OverallRating == 2)
            {
                newOverAllRating = "**";
            }
            else if (OverallRating == 2.25)
            {
                newOverAllRating = "** 1/4";
            }
            else if (OverallRating == 2.50)
            {
                newOverAllRating = "** 1/2";
            }
            else if (OverallRating == 2.75)
            {
                newOverAllRating = "** 3/4";
            }

            if (OverallRating == 3)
            {
                newOverAllRating = "***";
            }
            else if (OverallRating == 3.25)
            {
                newOverAllRating = "*** 1/4";
            }
            else if (OverallRating == 3.50)
            {
                newOverAllRating = "*** 1/2";
            }
            else if (OverallRating == 3.75)
            {
                newOverAllRating = "*** 3/4";
            }

            if (OverallRating == 4)
            {
                newOverAllRating = "****";
            }
            else if (OverallRating == 4.25)
            {
                newOverAllRating = "**** 1/4";
            }
            else if (OverallRating == 4.50)
            {
                newOverAllRating = "**** 1/2";
            }
            else if (OverallRating == 4.75)
            {
                newOverAllRating = "**** 3/4";
            }

            if (OverallRating == 5)
            {
                newOverAllRating = "*****";
            }

            return newOverAllRating;
        }

        public static void ListReview(MySqlConnection conn)
        {
            /// This method is called from the ShowCaseMenu method,  it passes in the mysql connection string, then a SQL string in order
            /// to grab the data from the database and display accordingly.

            var lstRestuarantReview = new List<KeyValuePair<string, double>>();
            try
            {
                double dblReviewScore = 0;
                // string newList = null;

                // Form SQL Statement

                string stm =
                    "select restaurantprofiles.restaurantName, avg(restaurantreviews.reviewscore) from restaurantreviews " +
                    "join restaurantprofiles on restaurantprofiles.id = restaurantreviews.restaurantid " +
                    "group by restaurantid; ";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;
                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string RestaurantName = rdr["restaurantname"].ToString();

                    double.TryParse(rdr["avg(restaurantreviews.reviewscore)"].ToString(), out dblReviewScore);

                    string newName = RestaurantName.PadRight(50);

                    lstRestuarantReview.Add(new KeyValuePair<string, double>(newName, dblReviewScore));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            /*            finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
            */
            Console.Clear();

            // make color bar changes here might have to change list to dictionary
            Console.SetWindowSize(125, 60);
            int xpos = 650;
            int ypos = 10;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            Console.Clear();
            Console.WriteLine("Restaurant Name                                   Rating");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var element in lstRestuarantReview)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(element.Key);
                string strColorBar = ChangeOverAllReview(element.Value);
                Console.WriteLine(strColorBar);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            conn.Close();
            Utility.PressAnyKeyToContinue("Press any key to continue");
        }

        public static string ChangeOverAllReview(double OverallReview)
        {
            /// This method is called from the ListData method to change the OverAllRating from a numeric value to a star rating system

            string strReviewBar = string.Empty;
            string strTemp = string.Format("{0:0.00}", OverallReview);
            if (OverallReview <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                strReviewBar = "  No Review  ";
                strReviewBar.PadRight(20);
            }
            if (OverallReview > 0 && OverallReview < 30)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                strReviewBar = $" {strTemp}% / 100";
                strReviewBar.PadRight(20);
            }

            if (OverallReview > 30 && OverallReview < 70)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                strReviewBar = $" {strTemp}% / 100";
                strReviewBar.PadRight(20);
            }
            if (OverallReview > 69)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                strReviewBar = $" {strTemp}% ";
                strReviewBar.PadRight(20);
            }

            return strReviewBar;
        }

        public static void DinnerSpinner(MySqlConnection conn)
        {
            /// Choose a random restaurant to go eat
            ///
            Console.Clear();
            Console.Write("Getting Your Next Dinner Idea");
            Console.BackgroundColor = ConsoleColor.Cyan;
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" -- Done. Your Next Dinner Will be at the Following Restaurant\n");
            List<String> lstSpinner = new List<string>();
            string strSQLCommand = "select * from RestaurantProfiles order by Rand() limit 1;";
            lstSpinner = GetDinner(conn, strSQLCommand);
            ConvertDinnerSpinner(lstSpinner);
            Utility.PressAnyKeyToContinue("ENJOY!! Press any key to Continue");
        }

        public static void TopTenList(MySqlConnection conn)
        {
            ///  Top Ten showcase sorted by percentile
            /// 
            /// SELECT RestaurantProfiles.RestaurantName, avg(RestaurantReviews.ReviewScore) FROM RestaurantReviews 
            /// join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.RestaurantId
            /// group by RestaurantProfiles.RestaurantName
            /// order by avg(RestaurantReviews.ReviewScore) desc
            /// limit 10;
            List<string> lstTopTen = new List<string>();
            string strSqlStatement =
                " SELECT RestaurantProfiles.RestaurantName, avg(RestaurantReviews.ReviewScore) FROM RestaurantReviews " +
                "join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.RestaurantId " +
                "group by RestaurantProfiles.RestaurantName " +
                "order by avg(RestaurantReviews.ReviewScore) desc " +
                "limit 10;";
            // conn.Open();

            ListTopTen(conn);
        }
        public static void ListTopTen(MySqlConnection conn)
        {
            /// This method is called from the reviewmenu method,  it passes in the mysql connection string, then a SQL string in order
            /// to grab the data from the database and display accordingly.
            /// 
            var lstRestuarantReview = new List<KeyValuePair<string, double>>();
            try
            {
                double dblReviewScore = 0;
                string newList = null;

                // Form SQL Statement

                string strSqlStatement =
                    " SELECT RestaurantProfiles.RestaurantName, avg(RestaurantReviews.ReviewScore) FROM RestaurantReviews " +
                    "join RestaurantProfiles on RestaurantProfiles.id = RestaurantReviews.RestaurantId " +
                    "group by RestaurantProfiles.RestaurantName " +
                    "order by avg(RestaurantReviews.ReviewScore) desc " +
                    "limit 10;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(strSqlStatement, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;
                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string RestaurantName = rdr["restaurantname"].ToString();

                    double.TryParse(rdr["avg(restaurantreviews.reviewscore)"].ToString(), out dblReviewScore);

                    string newName = RestaurantName.PadRight(50);

                    lstRestuarantReview.Add(new KeyValuePair<string, double>(newName, dblReviewScore));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            /*            finally
                        {
                            if (conn != null)
                            {
                                conn.Close();
                            }
                        }
            */
            Console.Clear();

            // make color bar changes here might have to change list to dictionary
            Console.SetWindowSize(125, 60);
            int xpos = 650;
            int ypos = 10;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            Console.Clear();
            Console.WriteLine("Restaurant Name                                   Rating");
            Console.WriteLine("--------------------------------------------------------------");
            foreach (var element in lstRestuarantReview)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(element.Key);
                string strColorBar = ChangeOverAllReview(element.Value);
                Console.WriteLine(strColorBar);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            conn.Close();
            Utility.PressAnyKeyToContinue("Press any key to continue");
        }
        public static void ConvertDinnerSpinner(List<string> restaurantProfileList)
        {
            // This method iterates through the list converted from the database then
            // Reads the data from the header list, adds the data to a list, 
            // Then Splits the list into another list for the key:value pairs
            // when completed, it will write the output file.

            List<String> header = new List<String>
            {
                "RestaurantName", "Address", "Phone", "HoursOfOperation", "Price", "USACityLocation", "Cuisine",
                "FoodRating", "ServiceRating",
                "AmbienceRating", "OverallRating", "OverAllPossibleRating"
            };

            List<string> data = new List<string>();
            List<string> totalString = new List<string>();
            List<List<string>> splitter = new List<List<string>>();
            List<string> quotedString = new List<string>();

            List<string> tmpHeader = new List<string>();

            foreach (string newHeaderstr in header)
            {
                tmpHeader.Add($"{newHeaderstr} - ");
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
                    quotedString.Add($"{strItem}");
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

            // output total string to output file.
            for (int iOutPut = 0; iOutPut < totalString.Count; iOutPut++)
            {
                Console.WriteLine(totalString[iOutPut]);
            }
        }
        public static List<string> GetDinner(MySqlConnection conn, string strSQLStatement)
        {
            /// This method populates a list to be manipulated for the JSON portion of the assignment
            /// It will grab the data from the database, then can be split or manipulated into the JSON file

            List<string> restaurantProfile = new List<string>();
            try
            {
                double FoodRating = 0;
                double ServiceRating = 0;
                double AmbienceRating = 0;
                double OverallRating = 0;
                double OverAllPossibleRating = 0;
                string newList = null;
                //                int ID = 0;
                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string RestaurantName = rdr["RestaurantName"].ToString();
                    string Address = rdr["Address"].ToString();
                    string Phone = rdr["Phone"].ToString();
                    string HoursOfOperation = rdr["HoursOfOperation"].ToString();
                    string Price = rdr["Price"].ToString();
                    string USACityLocation = rdr["USACityLocation"].ToString();
                    string Cuisine = rdr["Cuisine"].ToString();

                    double.TryParse(rdr["FoodRating"].ToString(), out FoodRating);
                    double.TryParse(rdr["ServiceRating"].ToString(), out ServiceRating);
                    double.TryParse(rdr["AmbienceRating"].ToString(), out AmbienceRating);
                    double.TryParse(rdr["OverallRating"].ToString(), out OverallRating);
                    double.TryParse(rdr["OverallPossibleRating"].ToString(), out OverAllPossibleRating);

                    string newFoodRating = ChangeOverAllRating(FoodRating);
                    string newServiceRating = ChangeOverAllRating(ServiceRating);
                    string newAmbienceRating = ChangeOverAllRating(AmbienceRating);
                    string newOverAllRating = ChangeOverAllRating(OverallRating);
                    string newOverAllPossibleRating = ChangeOverAllRating(OverAllPossibleRating);
                    newList = (RestaurantName + "~" + Address + "~" + Phone + "~" + HoursOfOperation + "~" + Price +
                               "~" + USACityLocation + "~" + Cuisine + "~" + newFoodRating + "~" +
                               newServiceRating + "~" + newAmbienceRating + "~" + newOverAllRating + "~" +
                               newOverAllPossibleRating);
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

            conn.Close();
            return restaurantProfile;
        }

        public static List<String> Shuffle(MySqlConnection conn)
        {
            /// Choose a random restaurant to go eat
            ///
            Console.Clear();
            Console.Write("Getting Your Next group of players, please wait: ");
            Console.BackgroundColor = ConsoleColor.Cyan;
            List<string> lstPlayer = new List<string>();
            string strPlayer = string.Empty;
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" -- Done. The next four card players will be\n");
            for (int x = 1; x <= 4; x++)
            {
                string strSQLCommand = "select * from RestaurantReviewers order by Rand() limit 1;";
                strPlayer = GetPlayer(conn, strSQLCommand);
                lstPlayer.Add(strPlayer);
            }

            foreach (var username in lstPlayer)
            {
                Console.WriteLine(username);
            }
            Utility.PressAnyKeyToContinue("COME ON DOWN!! Let's play some cards!!!  Press any key to continue");
            return lstPlayer;
        }
        public static string GetPlayer(MySqlConnection conn, string strSQLStatement)
        {
            /// This method populates a list to be manipulated for the JSON portion of the assignment
            /// It will grab the data from the database, then can be split or manipulated into the JSON file

            ;
            string newList = null;
            try
            {

                //                int ID = 0;
                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                conn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>


                    string strPlayerName = rdr["username"].ToString();
                    string strPaddedPlayerName = strPlayerName.PadRight(15);
                    newList = (strPaddedPlayerName);
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

            conn.Close();
            return newList;
            
        }
        public static void DealTheCards(List<string> lstPlayers)
        {
            Console.Clear();

            List<string> lstAvailableClubs = new List<string>()
            {
                "Ace(C) ", "2(C)   ", "3(C)   ", "4(C)   ", "5(C)   ", "6(C)   ", "7(C)   ", "8(C)   ", "9(C)   ", "10(C)  ", "J(C)   ", "Q(C)   ",
                "K(C)  "
            };
            List<string> lstAvailableHearts = new List<string>()
            {
                "Ace(H) ", "2(H)   ", "3(H)   ", "4(H)   ", "5(H)   ", "6(H)   ", "7(H)   ", "8(H)   ", "9(H)   ", "10(H)  ", "J(H)   ", "Q(H)   ",
                "K(H)   "
            };
            List<string> lsAvailableDiamonds = new List<string>()
            {
                "Ace(D) ", "2(D)   ", "3(D)   ", "4(D)   ", "5(D)   ", "6(D)   ", "7(D)   ", "8(D)   ", "9(D)   ", "10(D)  ", "J(D)   ", "Q(D)   ",
                "K(D)   "
            };
            List<string> lstAvailableSpades = new List<string>()
            {
                "Ace(S) ", "2(S)   ", "3(S)   ", "4(S)   ", "5(S)   ", "6(S)   ", "7(S)   ", "8(S)   ", "9(S)   ", "10(S)  ", "J(S)   ", "Q(S)   ",
                "K(S)   "
            };

            List<string> lstPlayer1Hand = new List<string>();
            List<string> lstPlayer2Hand = new List<string>();
            List<string> lstPlayer3Hand = new List<string>();
            List<string> lstPlayer4Hand = new List<string>();
            int intPickCard = 0;

            Random ranSuit = new Random();
            Random ranCard = new Random();
            int intCardCount1 = 0;
            int intCardCount2 = 0;
            int intCardCount3 = 0;
            int intCardCount4 = 0;
            int intPlayer1Sum = 0;
            int intPlayer2Sum = 0;
            int intPlayer3Sum = 0;
            int intPlayer4Sum = 0;
            int intTemp1 = 0;
            int intTemp2 = 0;
            int intTemp3 = 0;
            int intTemp4 = 0;

            // first player dealt
            Console.WriteLine("Player   Name           Hand");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            do
            {

                int intPickDeck = ranSuit.Next(1, 5);
                //                Console.WriteLine(intPickDeck);
                //                Utility.PressAnyKeyToContinue("pause");
                if (intPickDeck == 1 && lstAvailableClubs.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableClubs.Count);
                    lstPlayer1Hand.Add(lstAvailableClubs[intPickCard]);
                    intTemp1 = AddToCardSum(lstAvailableClubs[intPickCard]);
                    intPlayer1Sum += intTemp1;
                    lstAvailableClubs.RemoveAt(intPickCard);
                    intCardCount1++;


                }
                else if (intPickDeck == 2 && lstAvailableHearts.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableHearts.Count);
                    lstPlayer1Hand.Add(lstAvailableHearts[intPickCard]);
                    intTemp1 = AddToCardSum(lstAvailableHearts[intPickCard]);
                    intPlayer1Sum += intTemp1;
                    lstAvailableHearts.RemoveAt(intPickCard);
                    intCardCount1++;
                }
                else if (intPickDeck == 3 && lsAvailableDiamonds.Count > 0)
                {
                    intPickCard = ranCard.Next(lsAvailableDiamonds.Count);
                    lstPlayer1Hand.Add(lsAvailableDiamonds[intPickCard]);
                    intTemp1 = AddToCardSum(lsAvailableDiamonds[intPickCard]);
                    intPlayer1Sum += intTemp1;
                    lsAvailableDiamonds.RemoveAt(intPickCard);
                    intCardCount1++;
                }
                else if (intPickDeck == 4 && lstAvailableSpades.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableSpades.Count);
                    lstPlayer1Hand.Add(lstAvailableSpades[intPickCard]);
                    intTemp1 = AddToCardSum(lstAvailableSpades[intPickCard]);
                    lstAvailableSpades.RemoveAt(intPickCard);
                    intPlayer1Sum += intTemp1;
                    intCardCount1++;
                }
            } while (intCardCount1 < 13);

            //            Console.WriteLine(lstAvailableClubs.Count + " " + lstAvailableHearts.Count + " " + lsAvailableDiamonds.Count + " " + lstAvailableSpades.Count);
            //            Utility.PressAnyKeyToContinue("pause");
            Console.Write($"\nPlayer1: {lstPlayers.ElementAt(0)}");
            foreach (var element in lstPlayer1Hand)
            {
                Console.Write(element);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nPlayer 1 Hand Total: {intPlayer1Sum}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                int intPickDeck = ranSuit.Next(1, 5);
                //                Console.WriteLine(intPickDeck);
                //                Utility.PressAnyKeyToContinue("pause");

                if (intPickDeck == 1 && lstAvailableClubs.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableClubs.Count);
                    lstPlayer2Hand.Add(lstAvailableClubs[intPickCard]);
                    intTemp2 = AddToCardSum(lstAvailableClubs[intPickCard]);
                    intPlayer2Sum += intTemp2;
                    lstAvailableClubs.RemoveAt(intPickCard);
                    intCardCount2++;
                }
                else if (intPickDeck == 2 && lstAvailableHearts.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableHearts.Count);
                    lstPlayer2Hand.Add(lstAvailableHearts[intPickCard]);
                    intTemp2 = AddToCardSum(lstAvailableHearts[intPickCard]);
                    intPlayer2Sum += intTemp2;
                    lstAvailableHearts.RemoveAt(intPickCard);
                    intCardCount2++;
                }
                else if (intPickDeck == 3 && lsAvailableDiamonds.Count > 0)
                {
                    intPickCard = ranCard.Next(lsAvailableDiamonds.Count);
                    lstPlayer2Hand.Add(lsAvailableDiamonds[intPickCard]);
                    intTemp2 = AddToCardSum(lsAvailableDiamonds[intPickCard]);
                    intPlayer2Sum += intTemp2;
                    lsAvailableDiamonds.RemoveAt(intPickCard);
                    intCardCount2++;
                }
                else if (intPickDeck == 4 && lstAvailableSpades.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableSpades.Count);
                    lstPlayer2Hand.Add(lstAvailableSpades[intPickCard]);
                    intTemp2 = AddToCardSum(lstAvailableSpades[intPickCard]);
                    intPlayer2Sum += intTemp2;
                    lstAvailableSpades.RemoveAt(intPickCard);
                    intCardCount2++;
                }

                //                Console.WriteLine("2 " + intCardCount2);

            } while (intCardCount2 < 13);
            //            Console.WriteLine(lstAvailableClubs.Count + " " + lstAvailableHearts.Count + " " + lsAvailableDiamonds.Count + " " + lstAvailableSpades.Count);
            //            Utility.PressAnyKeyToContinue("pause");
            Console.Write($"Player2: {lstPlayers.ElementAt(1)}");
            foreach (var element in lstPlayer2Hand)
            {
                Console.Write(element);
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nPlayer 2 Hand Total: {intPlayer2Sum}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                int intPickDeck = ranSuit.Next(1, 5);
                //                Console.WriteLine(intPickDeck);
                //                Utility.PressAnyKeyToContinue("pause");

                if (intPickDeck == 1 && lstAvailableClubs.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableClubs.Count);
                    lstPlayer3Hand.Add(lstAvailableClubs[intPickCard]);
                    intTemp3 = AddToCardSum(lstAvailableClubs[intPickCard]);
                    intPlayer3Sum += intTemp3;
                    lstAvailableClubs.RemoveAt(intPickCard);
                    intCardCount3++;
                }
                else if (intPickDeck == 2 && lstAvailableHearts.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableHearts.Count);
                    lstPlayer3Hand.Add(lstAvailableHearts[intPickCard]);
                    intTemp3 = AddToCardSum(lstAvailableHearts[intPickCard]);
                    intPlayer3Sum += intTemp3;
                    lstAvailableHearts.RemoveAt(intPickCard);
                    intCardCount3++;
                }
                else if (intPickDeck == 3 && lsAvailableDiamonds.Count > 0)
                {
                    intPickCard = ranCard.Next(lsAvailableDiamonds.Count);
                    lstPlayer3Hand.Add(lsAvailableDiamonds[intPickCard]);
                    intTemp3 = AddToCardSum(lsAvailableDiamonds[intPickCard]);
                    intPlayer3Sum += intTemp3;
                    lsAvailableDiamonds.RemoveAt(intPickCard);
                    intCardCount3++;
                }
                else if (intPickDeck == 4 && lstAvailableSpades.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableSpades.Count);
                    lstPlayer3Hand.Add(lstAvailableSpades[intPickCard]);
                    intTemp3 = AddToCardSum(lstAvailableSpades[intPickCard]);
                    intPlayer3Sum += intTemp3;
                    lstAvailableSpades.RemoveAt(intPickCard);
                    intCardCount3++;
                }

                //                Console.WriteLine("3 " + intCardCount3);
            } while (intCardCount3 < 13);
            //            Console.WriteLine(lstAvailableClubs.Count + " " + lstAvailableHearts.Count + " " + lsAvailableDiamonds.Count + " " + lstAvailableSpades.Count);
            //            Utility.PressAnyKeyToContinue("pause");

            Console.Write($"Player3: {lstPlayers.ElementAt(2)}");
            foreach (var element in lstPlayer3Hand)
            {
                Console.Write(element);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nPlayer 3 Hand Total: {intPlayer3Sum}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                int intPickDeck = ranSuit.Next(1, 5);
                //                Console.WriteLine(intPickDeck);
                //                Utility.PressAnyKeyToContinue("pause");

                if (intPickDeck == 1 && lstAvailableClubs.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableClubs.Count);
                    lstPlayer4Hand.Add(lstAvailableClubs[intPickCard]);
                    intTemp4 = AddToCardSum(lstAvailableClubs[intPickCard]);
                    intPlayer4Sum += intTemp4;
                    lstAvailableClubs.RemoveAt(intPickCard);
                    intCardCount4++;
                }
                else if (intPickDeck == 2 && lstAvailableHearts.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableHearts.Count);
                    lstPlayer4Hand.Add(lstAvailableHearts[intPickCard]);
                    intTemp4 = AddToCardSum(lstAvailableHearts[intPickCard]);
                    intPlayer4Sum += intTemp4;
                    lstAvailableHearts.RemoveAt(intPickCard);
                    intCardCount4++;
                }
                else if (intPickDeck == 3 && lsAvailableDiamonds.Count > 0)
                {
                    intPickCard = ranCard.Next(lsAvailableDiamonds.Count);
                    lstPlayer4Hand.Add(lsAvailableDiamonds[intPickCard]);
                    intTemp4 = AddToCardSum(lsAvailableDiamonds[intPickCard]);
                    intPlayer4Sum += intTemp4;
                    lsAvailableDiamonds.RemoveAt(intPickCard);
                    intCardCount4++;
                }
                else if (intPickDeck == 4 && lstAvailableSpades.Count > 0)
                {
                    intPickCard = ranCard.Next(lstAvailableSpades.Count);
                    lstPlayer4Hand.Add(lstAvailableSpades[intPickCard]);
                    intTemp4 = AddToCardSum(lstAvailableSpades[intPickCard]);
                    intPlayer4Sum += intTemp4;
                    lstAvailableSpades.RemoveAt(intPickCard);
                    intCardCount4++;
                }
            } while (intCardCount4 < 13);
            //            Console.WriteLine(lstAvailableClubs.Count + " " + lstAvailableHearts.Count + " " + lsAvailableDiamonds.Count + " " + lstAvailableSpades.Count);
            //            Utility.PressAnyKeyToContinue("pause");
            Console.Write($"Player4: {lstPlayers.ElementAt(3)}");
            foreach (var element in lstPlayer4Hand)
            {
                Console.Write(element);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nPlayer 4 Hand Total: {intPlayer4Sum}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            int intWinner = Winner(intPlayer1Sum, intPlayer2Sum, intPlayer3Sum, intPlayer4Sum);
            Console.WriteLine($"\nAnd the Winner is!  Player {intWinner}!!");
            int intTotal = intPlayer1Sum + intPlayer2Sum + intPlayer3Sum + intPlayer4Sum;
            Console.WriteLine($"\nTotal of each hands is: {intTotal}");
            Utility.PressAnyKeyToContinue("Press Any Key to Continue");
        }

        public static int AddToCardSum(string strCard)
        {
            int intTotal = 0;

            if (strCard.Contains("2("))
            {
                intTotal += 2;
            }
            else if (strCard.Contains("3("))
            {
                intTotal += 3;
            }
            else if (strCard.Contains("4("))
            {
                intTotal += 4;
            }
            else if (strCard.Contains("5("))
            {
                intTotal += 5;
            }
            else if (strCard.Contains("6("))
            {
                intTotal += 6;
            }
            else if (strCard.Contains("7("))
            {
                intTotal += 7;
            }
            else if (strCard.Contains("8("))
            {
                intTotal += 8;
            }
            else if (strCard.Contains("9("))
            {
                intTotal += 9;
            }
            else if (strCard.Contains("10("))
            {
                intTotal += 10;
            }
            else if (strCard.Contains("J("))
            {
                intTotal += 12;
            }
            else if (strCard.Contains("Q("))
            {
                intTotal += 12;
            }
            else if (strCard.Contains("K("))
            {
                intTotal += 12;
            }
            else if (strCard.Contains("Ace("))
            {
                intTotal += 15;
            }

            return intTotal;
        }

        public static int Winner(int P1, int P2, int P3, int P4)
        {
            int max = P1;
            int intWinner = 1;

            if (max < P2)
            {
                max = P2;
                intWinner = 2;
            }

            if (max < P3)
            {
                max = P3;
                intWinner = 3;
            }

            if (max < P4)
            {
                max = P4;
                intWinner = 4;
            }

            return intWinner;
        }
    }
}
/// card game psuedo code
/// shuffle deck
/// four suits diamond, hearts, spades, clubs
/// Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, jack, queen, king
/// 52 total cards
/// dealing 13 to each of four players
/// total cards for each player
/// 


