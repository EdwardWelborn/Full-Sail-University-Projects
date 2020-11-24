using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
namespace CasimirJustin_Assignment2
{
    public static class DBUtils
    {

        //method ot create the connection string
        public static string BuildConnectionString()
        {
            string serverIP = "";
            string port = "";

            //use a try catch to verify that the data can be retrieved
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\VFW\connect.txt"))
                {
                    // read the data for the IP and the port
                    serverIP = sr.ReadLine();
                    port = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return "server=" + serverIP + $";uid=dbsAdmin;pwd=password;database=ContactList;port={port};Sslmode=none";

        }

        public static MySqlConnection Connect(string myConnectionString)
        {
            MySqlConnection conn = new MySqlConnection();

            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1042:
                        MessageBox.Show("Can't resolve the host address. \n" + myConnectionString);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password");
                        break;
                    default:
                        MessageBox.Show(e.ToString() + "\n" + myConnectionString);
                        break;
                }
                ;
            }

            return conn;
        }


    }
}
