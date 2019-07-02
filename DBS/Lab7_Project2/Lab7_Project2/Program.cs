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
            decimal dSum = 0;

            Console.WriteLine("Starting\n");

            // MySQL Database Connection String
            string cs = @"server=192.168.1.13;userid=dbremoteuser;password=password;database=example0219;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            // Prompt user to enter an orderID
            Console.Write("Enter a order ID: ");

            // Read input from user
            string inputOrderID = Console.ReadLine();

            try
            {
                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement

                string stm = "select orderItem.orderID, orderItem.quantity, item.retailPrice from orderItem join item on item.itemId = orderItem.itemID where orderItem.orderId = @inputOrderID order by orderItem.orderId;";
                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Binding Variables
                cmd.Parameters.AddWithValue("@InputOrderID", inputOrderID);

                // Execute SQL Statement and Convert Results to a String
                MySqlDataReader rdr = cmd.ExecuteReader();

                // Read Info
                while (rdr.Read())
                {
                    // Strings
                    string orderId = rdr["orderID"].ToString();
                    string quantity = rdr["quantity"].ToString();
                    string Price = rdr["retailPrice"].ToString();
                  
                    decimal dPrice = Decimal.Parse(Price);
                    int iQuantity = int.Parse(quantity);
                    Order O = new Order();
                    decimal dTotal = O.AddtoTotal(iQuantity, dPrice);
                    dSum += dTotal;
                    // Print out to Console.
                    Console.WriteLine("OrderId: {0}, Total: {1}", orderId, dTotal);
                }
                Console.WriteLine("Sum of Order: {0}", dSum);
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

    class  Order
    {
        public void Orders(int OrderID, decimal total)
        {
            // do something
            
        }
        public decimal AddtoTotal(int quantity, decimal price)
        {
            decimal Total = 0;
            Total = quantity * price;
            return Total;
        }
    }

}

