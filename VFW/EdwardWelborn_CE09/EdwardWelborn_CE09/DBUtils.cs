using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;


namespace CEdwardWelborn_CE09
{
    public static class DBUtils
    {
        // method to create the connection string to the database
        public static string BuildConnectionString()
        {
            // strings to hold the IP and port
            string connectionString = string.Empty;
            string portString = string.Empty;
            string cs = string.Empty;
            try
            {
                // open the text file using stream reader
                StreamReader Config = new StreamReader(@"c:/vfw/connection.txt");
                connectionString = Config.ReadLine();
                portString = Config.ReadLine();
                // MySQL Database Connection String
                 cs = $"server={connectionString};userid=dbsAdmin;password=password;database=exampledatabase;Sslmode=none;port={portString}";
                Config.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }

            return cs;
        }
        // method to create the connection to the mysql database
        public static MySqlConnection Connect(string myConnectionString)
        {
            // need to have a connection object which will be sent back to the main program
            MySqlConnection conn = new MySqlConnection();
            try
            {
                // Declare a MySQL Connection
                conn.ConnectionString = myConnectionString;
                conn.Open();
                // DEBUG: to see if it connected or not
                 MessageBox.Show("Connected");
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042:
                        MessageBox.Show("Can't resolve Host address. \n\n" + myConnectionString);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid user name or password.");
                        break;
                    case 1046:
                        MessageBox.Show("Cannot Find Database. \n\n" + myConnectionString);
                        break;
                    default:
                        MessageBox.Show(e.ToString() + myConnectionString);
                        break;
                }
            }

            return conn;
        }
    }
}
