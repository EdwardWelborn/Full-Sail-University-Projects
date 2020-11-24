using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace OteroJoshua_CE02
{
    public static class DBUtilities
    {
        /*
         * Joshua Otero
         * VFW 1906
         * Database Connectivity
         * 
         * */

        // method to buid the connection string
        public static string BuildConnectionString()
        {
            // variables to hold the IP address and the port number
            string serverIP = "";
            string port = "";

            try
            {
                // open the text file using a stream reader
                using (StreamReader sr = new StreamReader(@"C:\VFW\connect.txt"))
                {
                    // read the data from the text file
                    serverIP = sr.ReadLine();
                    port = sr.ReadLine();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }

            return $"server={serverIP};uid=dbsAdmin;pwd=password;database=series;SslMode=none;port={port}";
        }
        // Method to connect to the MySql Database
        public static MySqlConnection Connect(string myConnString)
        {
            MySqlConnection conn = new MySqlConnection();

            try
            {
                conn.ConnectionString = myConnString;
                conn.Open();
                
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042:
                        MessageBox.Show("Can't resolve host affress.\n\n" + myConnString);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password.");
                        break;
                    default:
                        MessageBox.Show(e.ToString() + "\n\n" + myConnString);
                        break;
                }
            }
            return conn;
        }

    }
}
