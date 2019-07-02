// Connection.TXT Location
// c:/VFW/Connection.txt (this file contains ONLY the ip address of the mysql server
//Database Location
//  string cs = $"server={sConnection};userid=dbremoteuser;password=password;database=notetrackerplus;port=8889";
//Output Location
//  string outPutPath = $@"../../../FirstLast_ConvertedData.json";

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace EdwardWelborn_Project1c
{
    class Program
    {
        const int SWP_NOSIZE = 0x0001;

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr MyConsole = GetConsoleWindow();

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy,
            int wFlags);
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 20);
            int xpos = 650;
            int ypos = 275;
            SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
            MainMenu();
        }

        public static void MainMenu()
        {
            // This Method is the main menu for the program, it is called from the main method of the program

            //  int intUser_ID = 0;
            string sConnection = string.Empty;
            StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
            sConnection = Config.ReadLine();
            // MySQL Database Connection String
            string cs =
                $"server={sConnection};userid=dbremoteuser;password=password;database=notetrackerplus;port=8889";
            Config.Close();
            // Declare a MySQL Connection
            MySqlConnection conn = new MySqlConnection(cs);

            Console.WriteLine("Welcome to Note Tracker Plus");
            Console.WriteLine("Please Login to Continue\n");
            // Prompt user to enter a username
            Console.Write("Enter your Username: ");
            string strName = Console.ReadLine();
            string strUserName = Validation.ValidateText(strName);

            // Prompt user to enter a password
            Console.Write("Enter your Password: ");

            string strPassword = Orb.App.Console.ReadPassword();

            MySqlCommand cmd = new MySqlCommand("select * from user_table where username like @username and password = @password;");
            cmd.Parameters.AddWithValue("@username", strName);
            cmd.Parameters.AddWithValue("@password", strPassword);
            cmd.Connection = conn;
            conn.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            /// need a way to log in if they are a new user....
            /// 
            if (!loginSuccessful)
            {
                Console.WriteLine("Invalid username or password");
                Console.Write("Are you a new user? (y or n): ");
                string strNewUser = Console.ReadLine().ToLower();
                switch (strNewUser)  
                {
                    case "y":
                    {
                            CreateUser(conn);
                            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                            System.Diagnostics.Process.Start(myApp);
                            Environment.Exit(0);
                    }
                        break;
                    case "n":
                    {
                            Utility.PressAnyKeyToContinue("Have a Nice Day, Press any key to Exit");
                            Environment.Exit(0);
                    }
                        break;
                    default:
                    {
                        Utility.PressAnyKeyToContinue("Thank you for Stopping by, Press any key to Exit");
                        Environment.Exit(0);
                    }
                        break;
                }
            }

            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine($"       Welcome {strName}\n" +
                    "       Note Tracker Plus\n" +
                    "-------------------------------\n" +
                    "[1]..  User Menu {user}\n" +
                    "[2]..  Create New Note {create}\n" +
                    "[3]..  Edit Notes {edit}\n" +
                    "[4]..  View Notes {view}\n" +
                    "[5]..  Delete Notes {delete}\n" +
                    "[6]..  Exit Program {e}\n" +
                    "------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "user menu":
                    case "user":
                    {
                        UserMenu(conn);
                    }
                        break;
                    case "2":
                    case "create new note":
                    case "create":
                    {
                        CreateNote(conn, strName);
                    }
                        break;
                    case "3":
                    case "edit notes":
                    case "edit":
                    {
                        EditNote(conn, strName);
                    }
                        break;
                    case "4":
                    case "view notes":
                    case "view":
                    {
                        ViewNote(conn, strName);
                    }
                    break;
                    case "5":
                    case "delete notes":
                    case "delete":
                    {
                        DeleteNote(conn, strName);
                    }
                        break;
                    case "6":
                    case "e":
                    case "exit program":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 6, or abbreviated phrase in {}: ");
                        }
                        break;
                }

                if (!bProgramRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Exit the Program");
                }
            }
        }

        public static void UserMenu(MySqlConnection conn)
        {
            bool bUserMenuRunning = true;

            while (bUserMenuRunning)
            {
                Console.Clear();
                Console.SetWindowSize(100, 20);
                int xpos = 650;
                int ypos = 275;
                SetWindowPos(MyConsole, 0, xpos, ypos, 0, 0, SWP_NOSIZE);
                Console.WriteLine(
                    "                      Note Tracker Plus\n" +
                    "                          User Menu\n" +
                    "-------------------------------------------------------------------------\n" +
                    "[1]..  Create New User {create}\n" +
                    "[2]..  Edit User {edit}\n" +
                    "[3]..  View User Information {view}\n" +
                    "[4]..  Delete User {delete}\n" +
                    "[5]..  Return to Main Menu {r}\n" +
                    "-------------------------------------------------------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1 thru 5, or abbreviated phrase in {}: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "create new user":
                    case "create":
                        {
                            CreateUser(conn);
                        }
                        break;
                    case "2":
                    case "edit user":
                    case "edit":
                        {
                            EditUser(conn);

                        }
                        break;
                    case "3":
                    case "view user information":
                    case "view":
                        {
                            ViewUser(conn);
                        }
                        break;
                    case "4":
                    case "delete user":
                    case "delete":
                        {
                            DeleteUser(conn);
                        }
                        break;
                    case "5":
                    case "r":
                    case " return to main menu":
                        {
                            bUserMenuRunning = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please Input the phrase, or use 1 thru 5, or abbreviated phrase in {}: ");
                        }
                        break;
                }

                if (!bUserMenuRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To return to the main menu");
                }
            }
        }

        public static void CreateUser(MySqlConnection conn)
        {
            /// This method creates a new user and writes that information to the database

//            MySqlCommand cmd;
//            MySqlDataReader rdr;

            Console.Clear();
            Console.WriteLine("Greetings and welcome new user");
            Console.WriteLine("Please complete all the information below\n");

            Console.Write("Enter your Username: ");
            string strName = Console.ReadLine();
            string strUserName = Validation.ValidateText(strName);

            Console.Write("Enter your Password: ");
            string strPassword = Console.ReadLine();
            string strUserPassword = Validation.ValidateText(strPassword);

            Console.Write("Enter your email address: ");
            string strEmail = Console.ReadLine();
            string strUserEmail = Validation.ValidateEmail(strEmail);

            MySqlCommand cmd = new MySqlCommand("select * from user_table where username like @username and password = @password;");
            cmd.Parameters.AddWithValue("@username", strName);
            cmd.Parameters.AddWithValue("@password", strPassword);
            cmd.Connection = conn;
            // conn.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            bool boolAccountExist = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));
            string strCreationDate = DateTime.Now.ToShortDateString();
            DateTime dateCreationDate = Convert.ToDateTime(strCreationDate);
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string strSQLStatement = $"insert into user_table (username, email, password, creation_date) values(@username, @email, @password, @creation_date);";
            MySqlCommand myCmd = new MySqlCommand(strSQLStatement, conn);
            if (!boolAccountExist)
            {
                using (conn)
                {
                    // conn.Open();
                    using (myCmd)
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.Parameters.AddWithValue("@username", strUserName);
                        myCmd.Parameters.AddWithValue("@password", strUserPassword);
                        myCmd.Parameters.AddWithValue("@email", strUserEmail);
                        myCmd.Parameters.AddWithValue("@creation_date", dateCreationDate);
                        myCmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                Console.WriteLine("\nAccount Already Exist!");
                Utility.PressAnyKeyToContinue("Press any key to Return");
            }
            cmd.Connection.Close();
            myCmd.Connection.Close();
            conn.Close();
        }

        public static void EditUser(MySqlConnection conn)
        {
            // list users for the user to select and edit
            //            MySqlCommand cmd;
            //            MySqlDataReader rdr;
            string strUser_Name = string.Empty;
            string strUser_Email = string.Empty;
            string strUser_Password = string.Empty;
            List<string> lstUsers = new List<string>();
            Console.Clear();

            lstUsers = PopulateUsers(conn, "SELECT * FROM user_table; ; ");
            Console.WriteLine("UserName               Email Address                              Member Since");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            for (int i = 0; i < lstUsers.Count; i++)
            {
                Console.WriteLine($"{lstUsers[i].ToString()}");
            }

            Console.Write("\nSelect a user to edit: ");
            string strName = Console.ReadLine();
            string strUserName = Validation.ValidateText(strName);
            string strSQL = @"SELECT * FROM user_table where username = @username;";

            using (conn)
            {
                conn.Open();
                using (MySqlCommand myCmd = new MySqlCommand(strSQL, conn))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.Parameters.AddWithValue("@username", strUserName);
                    MySqlDataReader rdr = myCmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        /// Database data, read into a List<string>

                        strUser_Name = rdr["username"].ToString();
                        strUser_Email = rdr["email"].ToString();
                       strUser_Password = rdr["password"].ToString();
                    }
                }
                Console.Write($"Enter your Username: (old = {strUser_Name}): ");
                string strEditName = Console.ReadLine();
                string strEditUserName = Validation.ValidateText(strEditName);

                Console.Write($"Enter your Password: (old = {strUser_Password}): ");
                string strEditPassword = Console.ReadLine();
                string strEditUserPassword = Validation.ValidateText(strEditPassword);

                Console.Write($"Enter your email address: (old = {strUser_Email}): ");
                string strEditEmail = Console.ReadLine();
                string strEditUserEmail = Validation.ValidateEmail(strEditEmail);

                string strInsertSql = "update user_table set username = @username, email = @email, password = @password where username='" + strEditName + "' ;";

                using (conn)
                {
                    using (MySqlCommand myCmd = new MySqlCommand(strInsertSql, conn))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.Parameters.AddWithValue("@username", strEditUserName);
                        myCmd.Parameters.AddWithValue("@password", strEditUserPassword);
                        myCmd.Parameters.AddWithValue("@email", strEditUserEmail);
                        myCmd.ExecuteNonQuery();
                    }
                }
            }


            Utility.PressAnyKeyToContinue("Press Any Key to Continue");
            conn.Close();
        }

        public static void ViewUser(MySqlConnection conn)
        {
            List<string> lstUsers = new List<string>();
            Console.Clear();

            lstUsers = PopulateUsers(conn, "SELECT * FROM user_table; ; ");
            Console.WriteLine("UserName               Email Address                              Member Since");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            foreach (string element in lstUsers)
            {
                Console.WriteLine(element.ToString());
            }
            Utility.PressAnyKeyToContinue("Press Any Key to Continue");
        }

        public static void DeleteUser(MySqlConnection conn)
        {
            // list users for the user to select and edit
            //            MySqlCommand cmd;
            //            MySqlDataReader rdr;
            string strUser_Name = string.Empty;
            List<string> lstUsers = new List<string>();
            Console.Clear();

            lstUsers = PopulateUsers(conn, "SELECT * FROM user_table; ; ");
            Console.WriteLine("UserName               Email Address                              Member Since");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            for (int i = 0; i < lstUsers.Count; i++)
            {
                Console.WriteLine($"{lstUsers[i].ToString()}");
            }

            Console.Write("\nSelect a user to delete: ");
            string strDeleteUSer = Console.ReadLine();
            string strdeleteUserName = Validation.ValidateText(strDeleteUSer);
            string strdeletetSql = "delete from user_table where username='" + strdeleteUserName + "' ;";

            using (conn)
            {
                conn.Open();
                using (MySqlCommand myCmd = new MySqlCommand(strdeletetSql, conn))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.Parameters.AddWithValue("@username", strdeleteUserName);
                    MySqlDataReader rdr = myCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        /// Database data, read into a List<string>

                        strUser_Name = rdr["username"].ToString();
                    }
                }
            }
        }
        public static void CreateNote(MySqlConnection conn, string strName)
        {
            ///  This method will create the new note and write that information to the database.
            /// This method creates a new user and writes that information to the database

            //            MySqlCommand cmd;
            //            MySqlDataReader rdr;
            string strAlertDate = string.Empty;
            string strCompletionDate = string.Empty;
            DateTime dateAlertDate = new DateTime();
            DateTime dateCompletionDate = new DateTime();
            Console.Clear();
            Console.WriteLine("Please complete all the information below\n");

            Console.Write("Do you want to add an alert to the note: (y or n): ");
            string strAlertChoice = Console.ReadLine().ToLower();
            string strValidAlert = Validation.ValidateText(strAlertChoice);
            switch (strValidAlert)
            {
                case "y":
                case "yes":
                {
                    Console.Write("Choose the date of the Alert (mm/dd/yyyy): ");
                    string strAlarmChoise = Console.ReadLine();
                    strAlertDate = Validation.ValidateDateTime(strAlarmChoise);
                    dateAlertDate = Convert.ToDateTime(strAlertDate);
                    }
                    break;
                case "n":
                case "no":
                {
                    // continue to the next question
                }
                    break;
                default:
                {
                    // continue to the next question
                }
                    break;
            }
            Console.Write("Do you want to add an completeion date to the note: (y or n)");
            string strCompletionChoice = Console.ReadLine().ToLower();
            string strValidCompletion = Validation.ValidateText(strCompletionChoice);
            switch (strValidCompletion)
            {
                case "y":
                case "yes":
                {
                    Console.Write("Choose the date of the completion: (mm/dd/yyyy): ");
                    string strCompletedChoise = Console.ReadLine();
                    strCompletionDate = Validation.ValidateDateTime(strCompletedChoise);
                }
                    break;
                case "n":
                case "no":
                {
                    // continue to the next question
                }
                    break;
                default:
                {
                    // continue to the next question
                }
                    break;
            }
            Console.Write("Enter the note Title: ");
            string strNoteTitleChoice = Console.ReadLine();
            string strNoteTitle = Validation.ValidateText(strNoteTitleChoice);

            Console.Write("Enter the Note: ");
            string strNote = Console.ReadLine();
            string strNoteText = Validation.ValidateText(strNote);

            // convert intAlramChoice to a calendar date
            string strCreationDate = DateTime.Now.ToShortDateString();
            DateTime dateCreationDate = Convert.ToDateTime(strCreationDate);

            string strSQLStatement = $"insert into notes_table (username, creation_date, alert_date, completion_date, title, description) values(@username, @creation_date, @alert_date, completion_date, @title, @description);";
 
            using (conn)
            {
                 if (conn != null && conn.State == ConnectionState.Closed)
                 {
                     conn.Open();   
                 }
                 using (MySqlCommand myCmd = new MySqlCommand(strSQLStatement, conn))
                 {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.Parameters.AddWithValue("@username", strName);
                    myCmd.Parameters.AddWithValue("@creation_date", dateCreationDate);
                    myCmd.Parameters.AddWithValue("@alert_date", dateAlertDate);
                    myCmd.Parameters.AddWithValue("@completion_date", strCompletionDate);
                    myCmd.Parameters.AddWithValue("@title", strNoteTitle);
                    myCmd.Parameters.AddWithValue("@description", strNoteText);
                    myCmd.ExecuteNonQuery();
                 }
            }

            conn.Close();

        }

        public static void EditNote(MySqlConnection conn, string strName)
        {
            // list users for the user to select and edit
            //            MySqlCommand cmd;
            //            MySqlDataReader rdr;
 
            List<string> lstNotes = new List<string>();
            string strTitle = string.Empty;
            string strDescription = string.Empty;
            string strCompletionDate = string.Empty;
            string strAlertDate = string.Empty;
            DateTime dateCompletionDate = new DateTime();
            DateTime dateAlertDate = new DateTime();

            Console.Clear();

            lstNotes = PopulateViewChoice(conn, "SELECT note_id, username, creation_date, title FROM notes_table;", strName);
            if (lstNotes.Count > 0)
            {
                Console.WriteLine("Note ID     UserName             Note Created   Note Title");
                Console.WriteLine(
                    "----------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < lstNotes.Count; i++)
                {
                    Console.WriteLine($"{lstNotes[i].ToString()}");
                }

                Console.Write("\nSelect a note to edit: ");
                string strNoteChoice = Console.ReadLine();
                int intEditNote = Validation.ValidateIntRange(1, lstNotes.Count, strNoteChoice);
                string strSQL = @"SELECT * FROM notes_table where note_id = @note_id;";

                using (conn)
                {
                    conn.Open();
                    using (MySqlCommand myCmd = new MySqlCommand(strSQL, conn))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.Parameters.AddWithValue("@note_id", intEditNote);
                        MySqlDataReader rdr = myCmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            /// Database data, read into a List<string>

                            strTitle = rdr["title"].ToString();
                            strDescription = rdr["description"].ToString();
                            strAlertDate = rdr["alert_date"].ToString();
                            strCompletionDate = rdr["completion_date"].ToString();
                        }
                    }

                    Console.Write($"Enter the New Note Title: (old = {strTitle}): ");
                    string strEditTitle = Console.ReadLine();
                    string strEditNoteTitle = Validation.ValidateText(strEditTitle);

                    Console.Write($"Enter the New Note: (old = {strDescription}): ");
                    string strEditDescription = Console.ReadLine();
                    string strEditNoteDescription = Validation.ValidateText(strEditDescription);

                    Console.Write("Do you want to add an alert to the note: (y or n): ");
                    string strAlertChoice = Console.ReadLine().ToLower();
                    string strValidAlert = Validation.ValidateText(strAlertChoice);
                    switch (strValidAlert)
                    {
                        case "y":
                        case "yes":
                        {
                            Console.Write($"Choose the date of the Alert (mm/dd/yyyy) (old: {strAlertDate}: ");
                            string strAlarmChoice = Console.ReadLine();
                            strAlertDate = Validation.ValidateDateTime(strAlarmChoice);
                            dateAlertDate = Convert.ToDateTime(strAlertDate);

                        }
                            break;
                        case "n":
                        case "no":
                        {
                            // continue to the next question
                        }
                            break;
                        default:
                        {
                            // continue to the next question
                        }
                            break;
                    }

                    Console.Write("Do you want to add an completion date to the note: (y or n)");
                    string strCompletionChoice = Console.ReadLine().ToLower();
                    string strValidCompletion = Validation.ValidateText(strCompletionChoice);
                    switch (strValidCompletion)
                    {
                        case "y":
                        case "yes":
                        {
                            Console.Write(
                                $"Choose the date of the completion: (mm/dd/yyyy) (old: {strCompletionDate}: ");
                            string strCompletedChoise = Console.ReadLine();
                            strCompletionDate = Validation.ValidateDateTime(strCompletedChoise);
                            dateCompletionDate = Convert.ToDateTime(strCompletionDate);
                            String.Format("{0:MM/dd/yyyy}", dateCompletionDate);
                        }
                            break;
                        case "n":
                        case "no":
                        {
                            // continue to the next question
                        }
                            break;
                        default:
                        {
                            // continue to the next question
                        }
                            break;
                    }

                    string strInsertSql =
                        "update notes_table set title = @title, description = @description, alert_date = @alert_date, completion_date = @completion_date;";

                    using (conn)
                    {
                        using (MySqlCommand myCmd = new MySqlCommand(strInsertSql, conn))
                        {
                            myCmd.CommandType = CommandType.Text;
                            myCmd.Parameters.AddWithValue("@title", strEditNoteTitle);
                            myCmd.Parameters.AddWithValue("@description", strEditNoteDescription);
                            myCmd.Parameters.AddWithValue("@alert_date", dateAlertDate);
                            myCmd.Parameters.AddWithValue("@completion_date", dateCompletionDate);
                            myCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no notes to edit");
            }

            Utility.PressAnyKeyToContinue("Press Any Key to Continue");
            conn.Close();
        }

        public static void ViewNote(MySqlConnection conn, string strName)
        {
            List<string> lstNotes = new List<string>();

            Console.Clear();
            lstNotes = PopulateViewChoice(conn, "SELECT * FROM notes_table where username='" + strName + "' ;", strName);
            if (lstNotes.Count > 0)
            {
                Console.WriteLine("NoteID   UserName                   Note Created            Note Title ");
                Console.WriteLine(
                    "----------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < lstNotes.Count; i++)
                {
                    Console.WriteLine($"{lstNotes[i].ToString()}");
                }

                Console.Write("\nSelect a NoteID to view the note: ");
                string strNoteChoice = Console.ReadLine();
                int intEditNote = Validation.ValidateIntRange(1, lstNotes.Count, strNoteChoice);
                string strSQL =
                    @"SELECT note_id, username, creation_date, alert_date, completion_date, title, description FROM notes_table where note_id ='" +
                    intEditNote + "';";

                lstNotes = PopulateNotes(conn, strSQL);
                ConvertNote(lstNotes);
            }
            else
            {
                Console.WriteLine("There are no notes to view");
            }

            Utility.PressAnyKeyToContinue("Press Any Key to continue");
 
        }

        public static void DeleteNote(MySqlConnection conn, string strName)
        {
            // list users for the user to select and edit
            //            MySqlCommand cmd;
            //            MySqlDataReader rdr;

            List<string> lstNotes = new List<string>();
            Console.Clear();
            
            lstNotes = PopulateViewChoice(conn, "SELECT * FROM notes_table; ; ", strName);
            if (lstNotes.Count > 0)
            {

            Console.WriteLine("Note ID    UserName     Date Created        Note Title");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            for (int i = 1; i < lstNotes.Count; i++)
            {
                Console.WriteLine($"{lstNotes[i].ToString()}");
            }

            Console.Write("\nSelect a note to edit: ");
            string strNoteChoice = Console.ReadLine();
            int intEditNote = Validation.ValidateIntRange(1, lstNotes.Count, strNoteChoice);
            string strSQL = @"delete FROM notes_table where note_id = @note_id;";

            using (conn)
            {
                conn.Open();
                using (MySqlCommand myCmd = new MySqlCommand(strSQL, conn))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.Parameters.AddWithValue("@note_id", intEditNote);
                    MySqlDataReader rdr = myCmd.ExecuteReader();
                }
            }
            }
            else
            {
                Console.WriteLine("There are not notes to deleteS");
            }
            Utility.PressAnyKeyToContinue("Press Any Key to Continue");
            conn.Close();
        }
        public static List<string> PopulateUsers(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Descriptions from the database for viewing

            Console.WriteLine("Populating Users List\n");
            List<string> lstUsers = new List<string>();

            string strUserName = string.Empty;
            try
            { 
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>
                    
                    string strUser_Name = rdr["username"].ToString();
                    string strUser_Email = rdr["email"].ToString();
                    string strAccountCreated = rdr["creation_date"].ToString();
                    string strNewUserName = strUser_Name.PadRight(20);
                    string strNewUser_Email = strUser_Email.PadRight(40);
                    string strNewAccountCreation = strAccountCreated.PadRight(15);
                    newList = strNewUserName + "   " + strNewUser_Email + "   " + strNewAccountCreation;
                    lstUsers.Add(newList);
                }
                rdr.Close();
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

            return lstUsers;
        }

        public static List<string> PopulateNotes(MySqlConnection conn, string strSQLStatement)
        {
            // This method will populate the Activity Descriptions from the database for viewing

            Console.WriteLine("Populating Notes List\n");
            List<string> lstNote = new List<string>();

            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                // conn.Open();
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    /// Database data, read into a List<string>

                    string strNoteID = rdr["note_id"].ToString();
                    string strUserName = rdr["username"].ToString();
                    string strAlertDate = rdr["alert_date"].ToString();
                    string strAccountCreated = rdr["creation_date"].ToString();
                    string strCompletionDate = rdr["completion_date"].ToString();
                    string strNoteTitle = rdr["title"].ToString();
                    string strNoteDescription = rdr["description"].ToString();
                    DateTime dateCreationDate = Convert.ToDateTime(strAccountCreated);
                    String.Format("{0:MM/dd/yyyy}", dateCreationDate);
                    newList = strNoteID + "~" + strUserName + "~" + dateCreationDate + "~" + strAlertDate + "~" +
                                  strCompletionDate + "~" + strNoteTitle + "~" + strNoteDescription;
                    lstNote.Add(newList);
                }

                rdr.Close();
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

            return lstNote;
        }

        public static List<string> PopulateViewChoice(MySqlConnection conn, string strSQLStatement, string strName)
        {
            // This method will populate the Activity Descriptions from the database for viewing

            Console.WriteLine("Populating Notes List\n");
            List<string> lstNote = new List<string>();

            try
            {
                string newList = null;

                // Form SQL Statement

                string stm = strSQLStatement;
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                // conn.Open();
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();
                using (conn)
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    using (MySqlCommand myCmd = new MySqlCommand(strSQLStatement, conn))
                    {
                        myCmd.CommandType = CommandType.Text;
                        myCmd.Parameters.AddWithValue("@username", strName);
                        // Read Info
                        while (rdr.Read())
                        {
                            /// Database data, read into a List<string>
                            string strNoteID = rdr["note_id"].ToString();
                            string strUserName = rdr["username"].ToString();
                            string strAccountCreated = rdr["creation_date"].ToString();
                            string strNoteTitle = rdr["title"].ToString();
                            string strNewUserName = strUserName.PadRight(25);
                            DateTime dateCreationDate = Convert.ToDateTime(strAccountCreated);
                            String.Format("{0:MM/dd/yyyy}", dateCreationDate);

                            newList = strNoteID + "        " + strNewUserName + "   " + dateCreationDate + "   " +
                                      strNoteTitle;
                            lstNote.Add(newList);
                        }
                    }
                }
                rdr.Close();
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

            return lstNote;
        }
        public static void ConvertNote(List<string> NoteList)
        {
            // This method iterates through the list converted from the database then
            // Reads the data from the header list, adds the data to a list, 
            // Then Splits the list into another list for the key:value pairs
            // when completed, it will write the output file.

            Console.Clear();
            List<String> header = new List<String>
            {
                "Note_ID", "User Name", "Creation_date", "Alert Date", "Completion Date", "Title", "Description",
            };
            Console.WriteLine(" ");
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
            foreach (string strItem in NoteList)
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
