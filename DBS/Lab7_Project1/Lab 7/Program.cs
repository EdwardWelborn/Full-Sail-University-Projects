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
            string cs = @"server=172.31.99.63;userid=dbremoteuser;password=password;database=example0219;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            // Prompt user to enter an Current LastName
            Console.Write("Enter a last name: ");

            // Read input from user
            string inputLastname = Console.ReadLine();

            // Prompt user to enter an New LastName
            Console.Write("Please enter NEW last name: ");

            // Read input from user
            string inputNewLastName = Console.ReadLine();

            try
            {
                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
               
                string stm = "select lastnam from users where lastname = lastname";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Binding Variables
                cmd.Parameters.AddWithValue("@inputNewLastName", inputNewLastName);
                cmd.Parameters.AddWithValue("@lastname", inputLastname);

                // Execute SQL Statement and Convert Results to a String
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    int lastname = reader.varchar(50);

                    // Add new SqlParameter to the command.
                    //
                    command.Parameters.Add(new SqlParameter("New Lastname", inputNewLastName));
                    // Print out to Console.
                    Console.WriteLine("Lastname: {0}, New LastName {1}", lastname, inputNewLastName);
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
