using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppFileIO
{
    class Program
    {
        static void Main(string[] args)
        {

            //Declare strings to store temparory data
            string tempStr = "";

            //A string array to hold field layout names of the data, data from the data files
            string[] field;

            //A boolean to control while loop
            bool running = true;

            //Declare a string to catch user input
            string inputString;

            //Declare Lists to store splitted data
            //To write all data into a single file
            List<string> data1Split = new List<string>();
            List<string> data2Split = new List<string>();
            List<string> data3Split = new List<string>();

            //Store field layout in the field string
            using (StreamReader stmLayout = new StreamReader(@"DataFieldsLayout.txt"))
            {
                tempStr = stmLayout.ReadToEnd();
                field = tempStr.Split('\n');
            }

            //while loop
            while (running)
            {
                Menu();
                //Catch input
                inputString = Console.ReadLine().ToLower();


                //Use switch to proceed according to user input
                switch (inputString)
                {
                    case "1":
                    case "datafile1":
                        {
                            //Prompt user it is processing
                            Console.WriteLine("Processing...please wait...");

                            //To write all data into a single file
                            data1Split = SplitToDetail(@"DataFile1.txt", @"Data1.txt");
                            //Convert to JSON
                            JSONConvert(field, data1Split, @"JSONData1.json");

                            //Clear screen and prompt user
                            Console.Clear();
                            Console.WriteLine("DataFile1.txt is processed successfully!");

                            break;
                        }

                    case "2":
                    case "datafile2":
                        {
                            //Prompt user it is processing
                            Console.WriteLine("Processing...please wait...");

                            //To write all data into a single file
                            data2Split = SplitToDetail(@"DataFile2.txt", @"Data2.txt");
                            //Convert to JSON
                            JSONConvert(field, data2Split, @"JSONData2.json");

                            //Clear screen and prompt user
                            Console.Clear();
                            Console.WriteLine("DataFile2.txt is processed successfully!");

                            break;
                        }

                    case "3":
                    case "datafile3":
                        {
                            //Prompt user it is processing
                            Console.WriteLine("Processing...please wait...");

                            //To write all data into a single file
                            data3Split = SplitToDetail(@"DataFile3.txt", @"Data3.txt");
                            //Convert to JSON
                            JSONConvert(field, data3Split, @"JSONData3.json");

                            //Clear screen and prompt user
                            Console.Clear();
                            Console.WriteLine("DataFile3.txt is processed successfully!");

                            break;
                        }

                    case "4":
                    case "exit":
                        {
                            //Set bool to false to exit while loop
                            running = false;
                            break;
                        }
                }
            }
        }


        //---------- Menu Method
        private static void Menu()
        {
            Console.WriteLine("Select a file to process or to exit:\n1. DataFile1\n2. DataFile2\n3. DataFile3\n4. Exit");
        }

        //---------- Split Data File to 100 Entries of Data Method
        private static string[] SplitDataFile(string fileLocation)
        {
            //String array to hold results
            string[] dataArray;
            //A string to hold temporary data
            string temp = "";
            //A string array to hold splitter
            string[] splitter = { "!end" };

            using (StreamReader stmData = new StreamReader(fileLocation))
            {
                int i = 1;
                while (stmData.Peek() > -1)
                {
                    if (i == 1 || i == 102)
                    {
                        stmData.ReadLine();
                    }
                    else
                    {
                        temp += stmData.ReadLine();
                    }

                    i++;
                }

                //RemoveEmptyEntries will get rid of the 101th entry, which is an empty one
                dataArray = temp.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            }

            return dataArray;
        }

        //----------- Split Data into Detail and Write in Single File Method
        private static List<string> SplitToDetail(string readLocation, string writeLocation)
        {
            //Get the array containing 100 data
            string[] dataArray = SplitDataFile(readLocation);

            //Declare an array to hold result
            List<string> dataDetail = new List<string>();
            //Variables to hold temporary data
            string[] temp;
            string tempStr = "";

            //A char[] to hold splitter
            char[] splitter = { '|' };

            //Split data1 into single fields of data
            foreach (string item in dataArray)
            {
                temp = item.Split(splitter);

                foreach (string itm in temp)
                {
                    dataDetail.Add(itm);
                }

            }

          

            //Store the output in a string
            for (int i = 0; i < 15000; i++)
            {
                //Format for the last line
                if (i == 14999)
                {
                    tempStr += dataDetail[i];
                }
                else
                {
                    tempStr += (dataDetail[i] + "\n");
                }
            }


            using (StreamWriter stm = new StreamWriter(writeLocation))
            {
                //Use Write instead of WriteLine to avoid extra line output
                stm.Write(tempStr);
            }

            return dataDetail;
        }

        //---------- JSON Conversion and Write in Method
        private static void JSONConvert(string[] field, List<string> data, string fileLocation)
        {
            //String to hold the JSON
            string json = "[\n";

            for (int i = 0; i < 100; i++)
            {
                json += "{";
                for (int j = 0; j < 150; j++)
                {
                    //Format for the last data
                    if (j == 149)
                    {

                        json += $"\"{field[j]}\":\"{data[i * 150 + j]}\"";
                    }
                    else
                    {

                        json += $"\"{field[j]}\":\"{data[i * 150 + j]}\",";
                    }
                }

                //Format for the last line
                if (i == 99)
                {
                    json += "}";
                }
                else
                {
                    json += "},\n";
                }

            }

            json += "\n]";

            //Write it to a single file
            using (StreamWriter stm = new StreamWriter(fileLocation))
            {
                stm.WriteLine(json);
            }

        }
    }
}
