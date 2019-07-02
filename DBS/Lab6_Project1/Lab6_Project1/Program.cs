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
            Console.Write("Enter a vehicle model: ");

            // Read input from user
            string inputVehicleModel = Console.ReadLine();

            // Prompt user to enter an vehicle year
            Console.Write("Enter vehicle Year: ");

            // Read input from user
            string inputVehicleYear = Console.ReadLine();

            try
            {

                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = "SELECT make, model, year, mpgHighway, mpgCity from vehicle where model = @vehiclemodel and year = @vehicleyear";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Binding Variables
                cmd.Parameters.AddWithValue("@vehicleyear", inputVehicleYear);
                cmd.Parameters.AddWithValue("@vehiclemodel", inputVehicleModel);

                // Execute SQL Statement and Convert Results to a String
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    string make = rdr["make"].ToString();
                    string model = rdr["model"].ToString();
                    string year = rdr["year"].ToString();
                    string mpgHighway = rdr["mpgHighway"].ToString();
                    string mpgCity = rdr["mpgCity"].ToString();

                    // Print out to Console.
                    Console.WriteLine("Make: {0}, Model: {1}, Year: {2}, mpgHighway: {3}, mpgCity: {4}", make, model, year, mpgHighway, mpgCity);

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

