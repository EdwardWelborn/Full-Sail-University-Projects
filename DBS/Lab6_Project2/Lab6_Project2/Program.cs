// DEV-231
// Objective: Test your connection from C# on a Windows VMWare instance to MySQL on a Macbook
// This code will connect to MySQL and display the version.
// Be sure both VMWare/Windows and MAMP is running

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace db_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start\n");

            // MySQL Database Connection String
            string cs = @"server=192.168.1.13;userid=dbremoteuser;password=password;database=example0219;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            // Prompt user to enter an vehicle model
            Console.Write("Enter your Username: ");

            // Read input from user
            string inputUserName = Console.ReadLine();
        
           // Prompt user to enter an vehicle year
            Console.Write("Enter Password: ");

            // Read input from user
            string inputPassword = Console.ReadLine();

            try
            {

                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT userId, firstname, lastname, dob, gender, occupationId, passwordEncrypted from users where username = @sUserName and password = @sPassword";
                
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Binding Variables
                cmd.Parameters.AddWithValue("@sUserName", inputUserName);
                cmd.Parameters.AddWithValue("@sPassword", inputPassword);

                // Execute SQL Statement and Convert Results to a String
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    string userId = rdr["userId"].ToString();
                    string firstname = rdr["firstname"].ToString();
                    string lastname = rdr["lastname"].ToString();
                    string dob = rdr["dob"].ToString();
                    string gender = rdr["gender"].ToString();
                    string occupationId = rdr["occupationId"].ToString();

                    DateTime myDate;
                    string sDate;
                    DateTime.TryParse(dob, out myDate);
                    sDate = string.Format("{0:MMMM dd, yyyy}", myDate);

                    // Print out to Console.
                    Console.Write("UserId: {0}, Firstname: {1}, lastname: {2}, dob: {3}, gender: {4}, occupationId {5}, ", userId, firstname, lastname, sDate, gender, occupationId);

                    string passwordEncrypted = rdr["passwordEncrypted"].ToString();

                    Console.WriteLine("Password Encrypted: {0}", passwordEncrypted);

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
            Console.Write("\r\nPress any key to Continue");
            Console.ReadKey();
        }
        
    }
   
}

