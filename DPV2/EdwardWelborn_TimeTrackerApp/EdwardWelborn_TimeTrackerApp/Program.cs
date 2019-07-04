using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;

namespace EdwardWelborn_TimeTrackerApp
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
            // Main part of the TimeTrackerApp, this method is where it starts, and calls the main menu
            MainMenu();
        }
        public static void MainMenu()
        {
            // This Method is the main menu for the program, it is called from the main method of the program
            // all the list I am populating from the database for viewing and manipulation
            Dictionary<int, string> dictUsers = new Dictionary<int, string>();
            List<string> lstCategory = new List<string>();
            List<string> lstDescription = new List<string>();
            List<string> lstActivityTimes = new List<string>();
            List<string> lstDaysOfTheWeek = new List<string>();
            List<string> lstCalendarDays = new List<string>();
            List<string> lstCalendarDates = new List<string>();

            string sConnection = string.Empty;
            int intUser_ID = 0;
            StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
            sConnection = Config.ReadLine();
            // MySQL Database Connection String
            string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=timetracking;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);
            Console.Clear();
            Console.SetWindowSize(100, 20);
            int xpos = 650;
            int ypos = 275;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            Console.WriteLine("Welcome to TimeTracker Plus\n");
            // Prompt user to enter a username
            Console.Write("Enter your Username: ");
            string strName = Console.ReadLine();
            string strUserName = Validation.ValidateText(strName);

            // Prompt user to enter a password
            Console.Write("Enter your Password: ");

            string strPassword = Orb.App.Console.ReadPassword();

            MySqlCommand cmd = new MySqlCommand("select * from time_tracker_users where user_name like @username and user_password = @password;");
            cmd.Parameters.AddWithValue("@username", strName);
            cmd.Parameters.AddWithValue("@password", strPassword);
            cmd.Parameters.AddWithValue("@user_id", intUser_ID);
            cmd.Connection = conn;
            conn.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            if (!loginSuccessful)
            {
                Console.WriteLine("Invalid username or password");
                Utility.PressAnyKeyToContinue("Press any key To Exit");
                Environment.Exit(0);
            }

            
            // populate the various list for use in viewing and choosing
            lstCategory = PopulateCategory(conn, "SELECT category_description FROM activity_categories;");
            conn.Open();
            lstDescription = PopulateDescription(conn, "SELECT activity_description FROM activity_descriptions;");
            conn.Open();
            lstActivityTimes = PopulateTimes(conn, "SELECT time_spent_on_activity FROM activity_times;");
            conn.Open();
            lstDaysOfTheWeek = PopulateDays(conn, "SELECT day_name FROM days_of_week;");
            conn.Open();
            lstCalendarDays = PopulateCalendarDays(conn, "SELECT calendar_numerical_day FROM tracked_calendar_days;");
            conn.Open();
            lstCalendarDates = PopulateCalendarDates(conn, "SELECT calendar_date FROM tracked_calendar_dates;");
            conn.Open();
            dictUsers = PopulateUsers(conn, "SELECT * FROM time_tracker_users;");
            conn.Open();
            foreach (KeyValuePair<int, string> obj in dictUsers)
            {
                if (obj.Value == strName)
                {
                    int.TryParse(obj.Key.ToString(), out intUser_ID);
                }
            }

            string strLogin = $"Welcome {strName}";

            
           
            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                Console.WriteLine(String.Format("{0," + ((32S / 2) + (strLogin.Length / 2)) + "}", strLogin));
                Console.WriteLine( 
                        "       Time Tracker Plus\n" +
                        "-------------------------------\n" +
                        "[1]..  Enter Activity {enter}\n" +
                        "[2]..  View Tracked Data {view}\n" +
                        "[3]..  Run Calculations {run}\n" +
                        "[4]..  Exit Program {e}\n" +
                        "------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "enter activity":
                    case "enter":
                    {
                            // Change window size to see all of the list
                            Console.SetWindowSize(100, 35);
                            EnterActivity(conn, intUser_ID, lstCategory, lstDescription, lstDaysOfTheWeek, lstCalendarDates, lstActivityTimes);
                        }
                        break;
                   case "2":
                    case "view tracked data":
                    case "view":
                        {
                            ViewTrackedDataSubMenu(conn, intUser_ID, lstCalendarDates, lstCategory, lstDescription);
                        }
                        break;
                    case "3":
                    case "run calculations":
                    case "run":
                        {
                            RunCalculationsSubMenu();
                        }
                        break;
                    case "4":
                    case "e":
                    case "exit program":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            
                            Utility.PressAnyKeyToContinue("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}:\n" +
                                "Press Any Key To Continue");
                        }
                        break;
                }
                if (!bProgramRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Exit the Program");
                }
            }
        }

        public static int CategoryMenu(List<string> lstCategory)
        {
            bool boolCategoryRunning = true;
            int intCategory = 0;
            // select category Menu
            while (boolCategoryRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "        Time Tracker Plus\n" +
                        "       Select Category Menu\n" +
                        "-----------------------------------\n" +
                        "[1]..  Select Category {select}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select category":
                    case "select":
                        {
                            intCategory = SelectCategory(lstCategory);
                        }
                        break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolCategoryRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again.");
                        }
                        break;
                }
                if (!boolCategoryRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu.");
                }
            }

            return intCategory;
        }
        public static int DescriptionMenu(List<string> lstDescription)
        {
            bool boolDescriptionRunning = true;
            int intDescription = 0;
            // select description Menu
            while (boolDescriptionRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "        Time Tracker Plus\n" +
                        "     Select Description Menu\n" +
                        "-----------------------------------\n" +
                        "[1]..  Select Description {select}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select description":
                    case "select":
                        {
                            intDescription = SelectDescription(lstDescription);
                        }
                        break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolDescriptionRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again");
                        }
                        break;
                }
                if (!boolDescriptionRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu");
                }
            }

            return intDescription;
        }
        public static int ActivityDateMenu(List<string> lstCalendarDates)
        {
            // choose date they performed the action
            bool boolDateRunning = true;
            int intDate = 0;
            // select description Menu
            while (boolDateRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "         Time Tracker Plus\n" +
                        "     Select Calendar Date Menu\n" +
                        "------------------------------------\n" +
                        "[1]..  Select Calendar Date {select}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "-----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select calendar date":
                    case "select":
                        {
                            intDate = SelectActivityDate(lstCalendarDates);
                        }
                        break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolDateRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again.");
                        }
                        break;
                }
                if (!boolDateRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu");
                }
            }
            return intDate;
        }

        public static int ActivityDayMenu(List<string> lstDayOfTheWeek)
        {
            // choose date they performed the action
            bool boolDaysRunning = true;
            int intDay = 0;
            // select description Menu
            while (boolDaysRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "        Time Tracker Plus\n" +
                        "    Select Day of the Week Menu\n" +
                        "-----------------------------------\n" +
                        "[1]..  Select Calendar Day {select}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select calendar day":
                    case "select":
                        {
                            intDay = SelectActivityDate(lstDayOfTheWeek);
                        }
                        break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolDaysRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again");
                        }
                        break;
                }
                if (!boolDaysRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu");
                }
            }
            return intDay;
        }

        public static int SelectDurationMenu(List<string> lstActivityTimes)
        {
            bool boolDurationRunning = true;
            int intDuration = 0;
            // select description Menu
            while (boolDurationRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "            Time Tracker Plus\n" +
                        "        Select Activity Time Menu\n" +
                        "----------------------------------------\n" +
                        "[1]..  Select Activity Duration {select}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "----------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select activity duration":
                    case "select":
                        {
                            intDuration = SelectDuration(lstActivityTimes);
                        }
                        break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolDurationRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again");
                        }
                        break;
                }
                if (!boolDurationRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu");
                }
            }

            return intDuration;
        }

        public static int SelectDuration(List<string> lstActivityTimes)
        {
            // Choose Lenght of the activity
            Console.Clear();
            Console.WriteLine("No.    Duration of Activity Performed");
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < lstActivityTimes.Count; i++)
            {
                String s = String.Format("{0,3}", i + 1);
                Console.WriteLine($"[{s}]   {lstActivityTimes[i].ToString()}");
            }
            Console.Write("\n Please Choose the Duration of the Activity: ");
            string strDuractionChoice = Console.ReadLine();
            int intDurationChoice = Validation.ValidateIntRange(1, lstActivityTimes.Count, strDuractionChoice);
            string strDuration = lstActivityTimes[intDurationChoice - 1].ToString();

            return intDurationChoice;
        }

        public static void EnterActivity(MySqlConnection conn, int intUser_ID, List<string> lstCategory, List<string> lstDescription, List<string> lstDaysOfTheWeek, List<string> lstCalendarDates, List<string> lstActivityTimes)
        {
            /// Pick a category for activity (list categories they can choose frome)
            /// Enter a date for this activity (list dates from database they can choose from
            /// How long did you perform this activity (list times from database they can choose from)
            /// In a submenu report to the user that the activity was added
            ///    submenu (EnterActivitySubMenu)
            ///    enter another activity
            ///    return to main menu

            // choose date they performed the action
            bool boolDaysRunning = true;
            int intDate = 0;
            int intCategory = 0;
            int intDescription = 0;
            int intDuration = 0;
            int intDayOfWeek = 0;
            int intDateChoice = 0;

            Console.WriteLine(intUser_ID);
            Utility.PressAnyKeyToContinue("pause");
            // select description Menu
            while (boolDaysRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                        "        Time Tracker Plus\n" +
                        "       Enter Activity Menu\n" +
                        "-----------------------------------\n" +
                        "[1]..  Enter Activity {enter}\n" +
                        "[2]..  Return to the Main Menu {e}\n" +
                        "----------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 2: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "enter activity":
                    case "enter":
                    {
                        intCategory = CategoryMenu(lstCategory);
                        intDescription = DescriptionMenu(lstDescription);
                        intDateChoice = ActivityDateMenu(lstCalendarDates);
                            
                        intDayOfWeek = ActivityDayMenu(lstDaysOfTheWeek);
                        intDuration = SelectDurationMenu(lstActivityTimes);
                        // Write to Database
                        string strInsertSQL = $"SET FOREIGN_KEY_CHECKS=0;insert into activity_log (user_id, calendar_day, calendar_date, day_name, category_description, activity_description, time_spent_on_activity) values({intUser_ID}, {intDateChoice}, {intDate}, {intDayOfWeek}, {intCategory}, {intDescription}, {intDuration});";
                        // conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(strInsertSQL, conn))
                        {  
                            cmd.Parameters.AddWithValue("@user_id", intUser_ID); 
                            cmd.Parameters.AddWithValue("@calendar_day", intDateChoice);
                            cmd.Parameters.AddWithValue("@calendar_date", intDate); 
                            cmd.Parameters.AddWithValue("@day_name", intDayOfWeek); 
                            cmd.Parameters.AddWithValue("@category_description", intCategory); 
                            cmd.Parameters.AddWithValue("@activity_description", intDescription); 
                            cmd.Parameters.AddWithValue("@time_spent_on_activity", intDuration); 
                            int affectedRows = cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Activity Entered");
                    }
                    break;
                    case "2":
                    case "e":
                    case "return to the main menu":
                        {
                            boolDaysRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 2: ");
                            Utility.PressAnyKeyToContinue("Press the space bar to try again.");
                        }
                        break;
                }
                if (!boolDaysRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Return to the Main Menu");
                }
            }
        }
        public static int SelectActivityDate(List<string> lstCalendarDates)
        {
            Console.Clear();
            Console.SetWindowSize(100, 35);
            Console.WriteLine("No.    Date Activity Performed");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < lstCalendarDates.Count; i++)
            {
                String s = String.Format("{0,2}", i + 1);
                Console.WriteLine($"[{s}]   {lstCalendarDates[i].ToString()}");
            }
            Console.Write("\n Please Choose the Date of Activity: ");
            string strDateChoice = Console.ReadLine();
            int intDateChoice = Validation.ValidateIntRange(1, lstCalendarDates.Count, strDateChoice);
            string strDate = lstCalendarDates[intDateChoice - 1].ToString();

            return intDateChoice;
        }

        public static int SelectActivityDay(List<string> lstDaysOfTheWeek)
        {

            // Choose day of the activity
            Console.Clear();
            Console.SetWindowSize(100, 35);
            Console.WriteLine("No.    Day Activity Performed");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < lstDaysOfTheWeek.Count; i++)
            {
                String s = String.Format("{0,2}", i + 1);
                Console.WriteLine($"[{s}]   {lstDaysOfTheWeek[i].ToString()}");
            }
            Console.Write("\n Please Choose the Day of the Activity: ");
            string strDayChoice = Console.ReadLine();
            int intDayChoice = Validation.ValidateIntRange(1, lstDaysOfTheWeek.Count, strDayChoice);
            string strDay = lstDaysOfTheWeek[intDayChoice - 1].ToString();

            return intDayChoice;
        }

        public static void ViewTrackedDataSubMenu(MySqlConnection conn, int intUser_ID, List<string> lstCalendarDates, List<string> lstCategory, List<string> lstDescription)
        {
            /// select by date (SelectByDateSubMenu)
            /// 2. Select By Category
            /// select by description (ShowByDescriptionSubMen)
            /// back
            int intCategory = 0;
            int intDescription = 0;
            int intDateChoice = 0;
            bool bViewTrackedRunning = true;
            List<string> lstTemp = new List<string>();

            while (bViewTrackedRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);

                Console.WriteLine("           Time Tracker Plus\n" +
                        "           View Tracked Data\n" +
                        "------------------------------------------\n" +
                        "[1]..  Select By Date {date}\n" +
                        "[2]..  Select By Category {category}\n" +
                        "[3]..  Select By Description {description}\n" +
                        "[4]..  Return to Main Menu {r}\n" +
                        "------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "select by date":
                    case "date":
                        {
                            // Change window size to see all of the list
                            Console.SetWindowSize(100, 35);
                            intDateChoice = ActivityDateMenu(lstCalendarDates);
                        }
                        break;
                    case "2":
                    case "select By category":
                    case "category":
                        {
                            intCategory = SelectCategory(lstCategory);
                            PopulateLog(conn, $"SELECT * FROM activity_log where category_description = {intCategory};");
                            for (int j = 0; j < lstTemp.Count; j++)
                            {
                                Console.WriteLine(lstTemp[j]);
                            }
                            Utility.PressAnyKeyToContinue(("Press any key to continue"));
                        }
                        break;
                    case "3":
                    case "run calculations":
                    case "run":
                        {
                            intDescription = DescriptionMenu(lstDescription);
                        }
                        break;
                    case "4":
                    case "r":
                    case "return to main menu":
                        {
                            bViewTrackedRunning = false;
                        }
                        break;
                    default:
                        {

                            Utility.PressAnyKeyToContinue("Please Input the phrase, or use 1 thru 4, or abbreviated phrase in {}:\n" +
                                "Press Any Key To Continue");
                        }
                        break;
                }
                if (!bViewTrackedRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To return to the main menu");
                }
            }
        }
        public static void RunCalculationsSubMenu()
        {
            /*
             * Look At All Of The Cool Data Collected Over 26 Days:
             * Total Time Spent Working on School Work: (Pulled from database)
             ■ Total Time Spent on Personal Time: (Pulled from database)
             ■ Total Time on Outside Job: (Pulled from database)     
             ■ Total Time Driving To School: (Pulled from database)
             ■ Percentage of Time on School Work vs Total Month: (Pulled from
                database)
             ■ Percentage of Time with Family vs Total Month: (Pulled from
                database)
             ■ ETC. ETC. ETC.
             ■ ...There needs to be at least 10 calculations run and shown to the
                user...all of them must run a calculation from the data in the
                database...you get to choose what those 10+ calculations are...
             ■ 1. Back
            */
        }

        public static List<String> PopulateCategory(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Categories from the database for viewing

            Console.WriteLine("Populating Category Description List\n");
            List<string> categoriesList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strCategoryDescription = rdr["category_description"].ToString();

                    newList = (strCategoryDescription);
                    categoriesList.Add(newList);
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

            return categoriesList;
        }
        public static void PopulateLog(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity log from the database for viewing

            Console.WriteLine("Populating Activity Log List\n");
            int intUserID = 0;
            int intCalendarDay = 0;
            int intCalendarDate = 0;
            int intDayName = 0;
            int intCategoryDescription = 0;
            int intActivityDescription = 0;
            int intDuration = 0;

            try
            {
 //               string newList = null; 

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    int.TryParse(rdr["user_id"].ToString(), out intUserID);
                    int.TryParse(rdr["calendar_day"].ToString(), out intCalendarDay);
                    int.TryParse(rdr["calendar_date"].ToString(), out intCalendarDate);
                    int.TryParse(rdr["day_name"].ToString(), out intDayName);
                    int.TryParse(rdr["category_description"].ToString(), out intCategoryDescription);
                    int.TryParse(rdr["activity_description"].ToString(), out intActivityDescription);
                    int.TryParse(rdr["time_spent_on_Activity"].ToString(), out intDuration);

                    Console.WriteLine("UserID   Day   Date        Day     Category Descriiption                  Activity Description          Time Spent");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{intUserID}  {intCalendarDay}  {intCalendarDate}    {intDayName}     {intCategoryDescription}          {intActivityDescription}        {intDuration}"  );
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

        }

        public static List<string> PopulateDescription(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Descriptions from the database for viewing

            Console.WriteLine("Populating Activity Description List\n");
            List<string> descriptionsList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement
                
                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strActivityDescription = rdr["activity_description"].ToString();

                    newList = (strActivityDescription);
                    descriptionsList.Add(newList);
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

            return descriptionsList;
        }

        public static Dictionary<int, string> PopulateUsers(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Descriptions from the database for viewing

            Console.WriteLine("Populating Users List\n");
            Dictionary<int, string> dictUsers = new Dictionary<int, string>();
            int intUser_ID = 0;
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    int.TryParse(rdr["user_id"].ToString(), out intUser_ID);
                    string strUser_Name = rdr["user_name"].ToString();

                    
                    dictUsers.Add(intUser_ID, strUser_Name);
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

            return dictUsers;
        }
        public static List<string> PopulateTimes(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Times from the database for viewing

            Console.WriteLine("Populating Activity Times List\n");
            List<string> activityTimeslList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strCategoryDescription = rdr["time_spent_on_activity"].ToString();

                    newList = (strCategoryDescription);
                    activityTimeslList.Add(newList);
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

            return activityTimeslList;
        }
        public static List<string> PopulateDays(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Days of the Week from the database for viewing

            Console.WriteLine($"Populating Days of the Week List\n");
            List<string> daysOfTheWeekList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                string newOverAllRating = string.Empty;

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strDayName = rdr["day_name"].ToString();

                    newList = (strDayName);
                    daysOfTheWeekList.Add(newList);
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

            return daysOfTheWeekList;
        }
        public static List<string> PopulateCalendarDays(MySqlConnection conn, string strSQLStatement)
        {

            // This method will populate the Calendar Days from the database for viewing

            Console.WriteLine("Populating CalendarDays List\n");
            List<string> calendarDaysList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strCategoryDescription = rdr["calendar_numerical_day"].ToString();

                    newList = (strCategoryDescription);
                    calendarDaysList.Add(newList);
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

            return calendarDaysList;
        }
        public static List<string> PopulateCalendarDates(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Calendar Dates from the database for viewing

            Console.WriteLine($"Populating Calendar Dates List\n");
            List<string> calendarDatesList = new List<string>();
            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = "SELECT calendar_date FROM tracked_calendar_dates;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strDayName = rdr["calendar_date"].ToString();

                    newList = (strDayName);
                    calendarDatesList.Add(newList);
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

            return calendarDatesList;
        }

        public static int SelectCategory(List<string> Category)
        {
            // choose category
            Console.Clear();
            Console.SetWindowSize(100, 35);
            Console.WriteLine("No.    Category");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < Category.Count; i++)
            {
                String s = String.Format("{0,2}", i + 1);
                Console.WriteLine($"[{s}]   {Category[i].ToString()}");
            }
            Console.Write("\n Please Choose a Category: ");
            string strCategoryChoice = Console.ReadLine();
            int intCategoryChoice = Validation.ValidateIntRange(1, Category.Count, strCategoryChoice);
            string strCategory = Category[intCategoryChoice - 1].ToString();

            return intCategoryChoice;
        }

        public static int SelectDescription(List<string> lstDescription)
        {
            // choose description
            Console.Clear();
            Console.SetWindowSize(100, 35);
            Console.WriteLine("No.    Description");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < lstDescription.Count; i++)
            {
                String s = String.Format("{0,2}", i + 1);
                Console.WriteLine($"[{s}]   {lstDescription[i].ToString()}");
            }

            Console.Write("\n Please Choose a Description: ");
            string strDescriptionChoice = Console.ReadLine();
            int intDescriptionChoice = Validation.ValidateIntRange(1, lstDescription.Count, strDescriptionChoice);
            string strDescription = lstDescription[intDescriptionChoice - 1].ToString();

            return intDescriptionChoice;
        }
    }
    namespace Orb.App
    {
        /// <summary>
        /// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
        /// </summary>
        static public class Console
        {
            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword(char mask)
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

                var pass = new Stack<char>();
                char chr = (char)0;

                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (chr == CTRLBACKSP)
                    {
                        while (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }

                System.Console.WriteLine();

                return new string(pass.Reverse().ToArray());
            }

            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword()
            {
                return Orb.App.Console.ReadPassword('*');
            }
        }
    }
}
