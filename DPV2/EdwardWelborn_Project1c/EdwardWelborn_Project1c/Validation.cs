using System;
using System.Data;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace EdwardWelborn_Project1c
{ 
    class Validation
    {

        public static string ValidateText(string text)
        {
            Regex reg = new Regex("^[a-zA-Z ]*$");
//            while ((string.IsNullOrWhiteSpace(text)))
            while ((!reg.IsMatch(text)) || (string.IsNullOrWhiteSpace(text)))
            {
                Console.Write("The text entered is not correct. Please try again: ");
                text = Console.ReadLine();
            }
            return text;
        }
        public static double ValidateDouble(string _number)
        {
            double number;

            while (!(double.TryParse(_number, out number)) || (string.IsNullOrWhiteSpace(_number)))
            {
                Console.Write($"You did not enter a valid number. Please try again: ");
                _number = Console.ReadLine();
            }
            return number;
        }
        public static double ValidateDoubleRange(int min, int max, string _number)
        {
            double number = 0;
            bool bValidInput = false;

            while (!(bValidInput))
            {
                bValidInput = double.TryParse(_number, out number);
                if ((number >= min) && (number <= max))
                {
                    bValidInput = true;
                }
                else
                {
                    Console.Write($"You did not enter a valid number. Must be between {min} and {max}: ");
                    _number = Console.ReadLine();
                    bValidInput = false;
                }

            }
            // Console.WriteLine(number);
            // Utility.PressAnyKeyToContinue("pause");
            return number;
        }

        // ----
        public static decimal ValidateDecimal(string _number)
        {
            decimal number;

            while (!Decimal.TryParse(_number, out number) || (string.IsNullOrWhiteSpace(_number)))
            {
                Console.Write("You did not enter a valid number. Please try again: ");
                _number = Console.ReadLine();
            }
            return number;
        }
        public static int ValidateInt(string _number)
        {
            int number;

            while (!int.TryParse(_number, out number) || (string.IsNullOrWhiteSpace(_number)))
            {
                Console.Write("You did not enter a valid number. Please try again: ");
                _number = Console.ReadLine();
            }
            return number;
        }
        public static int ValidateIntRange(int min, int max, string _number)
        {
            bool bValidInput = false;
            int number = 0;

            while (!(bValidInput))
            {
                bValidInput = int.TryParse(_number, out number);
                if ((number >= min) && (number <= max))
                {
                    bValidInput = true;
                }
                else
                {
                    Console.Write($"You did not enter a valid number. Must be between {min} and {max}: ");
                    _number = Console.ReadLine();
                    bValidInput = false;
                }
            }
            // Console.WriteLine(number);
            // Utility.PressAnyKeyToContinue("pause");
            return number;
        }
        public static decimal ValidateDecimalRange(int min, int max, string _number)
        {
            decimal number = 0;
            bool bValidInput = false;

            while (!(bValidInput))
            {
                bValidInput = decimal.TryParse(_number, out number);
                if ((number >= min) && (number <= max))
                {
                    bValidInput = true;
                }
                else
                {
                    Console.Write($"You did not enter a valid number. Must be between {min} and {max}: ");
                    _number = Console.ReadLine();
                    bValidInput = false;
                }
            }
            // Console.WriteLine(number);
            // Utility.PressAnyKeyToContinue("pause");
            return number;
        }

        public static string ValidateEmail(string strEmail)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            Regex reg = new Regex(pattern);
            //            while ((string.IsNullOrWhiteSpace(text)))
            while ((!reg.IsMatch(strEmail)) || (string.IsNullOrWhiteSpace(strEmail)))
            {
                Console.Write("The email entered is not correct. Please try again: ");
                strEmail = Console.ReadLine();
            }
            return strEmail;
        }

        public static string ValidateDateTime(string strDateTime)
        {
            DateTime dateUserDateTime = new DateTime();
            bool boolValidDate = false;

            boolValidDate = DateTime.TryParse(strDateTime, out dateUserDateTime);

            while (!boolValidDate)
            {
                Console.WriteLine("Please Enter a Valid date (mm/dd/yyyy): ");
                boolValidDate = DateTime.TryParse(Console.ReadLine(), out dateUserDateTime);
            }

            string strUserDateTime = dateUserDateTime.ToShortDateString();
            return strUserDateTime;
        }
        public static bool ValidateUserExists(MySqlConnection conn, string username)
        {
            
            MySqlCommand cmd = new MySqlCommand("Select * From user_table Where username =@Name ");
            cmd.Parameters.AddWithValue("@Name", username);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            // conn.Open();

            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }
    }
}
