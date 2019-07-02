using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EdwardWelborn_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bProgramRunning = true;

            while (bProgramRunning)
            {
                Console.Clear();
                Console.WriteLine(
                        "      CE07 Assignment\n" +
                        "---------------------------\n" +
                        "[1]..  Parse File 1\n" +
                        "[2]..  Parse File 2\n" +
                        "[3]..  Parse File 3\n" +
                        "[4]..  Exit Program\n" +
                        "---------------------------\n");
                Console.WriteLine("Select an Option: ");
                Console.Write("Please Input the phrase, or use 1, 2, 3 or 4: ");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "parse file 1":
                        {
                            ReadDataFile(1);
                        }
                        break;
                    case "2":
                    case "parse file 2":
                        {
                            ReadDataFile(2);
                        }
                        break;
                    case "3":
                    case "parse file 3":
                        {
                            ReadDataFile(3);
                        }
                        break;
                    case "4":
                    case "e":
                    case "exit":
                        {
                            bProgramRunning = false;
                        }
                        break;
                    default:
                    {
                        Console.WriteLine("Please Input the phrase, or use 1, 2, 3, 4: ");
                    }
                        break;
                }
                if (!bProgramRunning)
                {
                    Utility.PressAnyKeyToContinue("Press Any Key To Exit");
                }

            }

        }
        public static void ReadDataFile(int iChoice)
        {
            // This method brings in the user choice, iterates through the appropriate file based on user input
            // Reads the data from the files, adds them to a list, 
            // Then Splits the list into another list for the key:value pairs
            // when completed, it will write the output file.

            string headerPath = @"../../../DataFieldsLayout.txt";
            string dataPath = $@"../../../DataFile{iChoice}.txt";
            string outPutPath = $@"../../../OutPut{iChoice}.json";
            List<String> header = new List<String>();
            List<string> data = new List<string>();
            List<string> totalString = new List<string>();
            List<List<string>> splitter = new List<List<string>> ();
            List<string> quotedString = new List<string>();

            StreamReader headerFile = new StreamReader(headerPath);
            StreamReader dataFile = new StreamReader(dataPath);
            string headerLine;
            string dataLine;

            Console.WriteLine($"\r\nCreating Output File: {iChoice}");

            try
            {
                // Check if file exists with its full path    
                if (File.Exists(outPutPath))
                {
                    // If file found, delete it    
                    File.Delete(outPutPath);
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            
            StreamWriter OutFile = new StreamWriter(outPutPath);

            // Read the headerfile and add it to a list 
            while ((headerLine = headerFile.ReadLine()) != null)
            {
                header.Add($"       \"{headerLine}\"" + ": ");
            }

            // Read Datafile and add to a list
            while ((dataLine = dataFile.ReadLine()) != null)
            {
                if (!(dataLine.Contains("BOF")))
                {
                    if (!(dataLine.Contains("EOF")))
                    {
                        data.Add(dataLine);
                    }
                }
            }
            // Read data list, split the string
            List<string> tempList = new List<string>();
            foreach(string strItem in data)
            {
                char[] splitChar = { '|' };
                tempList = strItem.Split(splitChar).ToList();
                splitter.Add(tempList);
            }

            // read through the splitter list, and add the new value string pattern
            foreach (List<string> lstItem in splitter)
            {
                foreach (string strItem in lstItem)
                {
                    if (!strItem.Contains("!end"))
                    {
                        quotedString.Add($"\"{strItem}\",");
                    }
                    else
                    {
                        quotedString.Add($"\"{strItem}\"");
                    }
                }
            }
            // Add header list, and quoted string list to the total string
            int iTemp = 0;
            foreach (string strQuoted in quotedString)
            {
                if (iTemp >= header.Count)
                {
                    iTemp = 0;
                }
                totalString.Add(header[iTemp] + strQuoted);
                iTemp++;
            }
            // Write file header
            OutFile.WriteLine("[");
            // output total string to output file.
            for (int iOutPut = 0; iOutPut < totalString.Count; iOutPut++)
            {
                string strDunsHeader = "\"DUNS\":";
                if (totalString[iOutPut].Contains(strDunsHeader))
                {
                    OutFile.WriteLine("    {");
                }
                OutFile.WriteLine((totalString[iOutPut]));
                if ((totalString[iOutPut].Contains("!end") && (iOutPut != totalString.Count - 1)))
                {
                    OutFile.WriteLine("    },");
                }

                if (iOutPut == totalString.Count - 1)
                {
                    OutFile.WriteLine("    }");
                }
            }

            // Write file footer
            OutFile.WriteLine("]");
            // close all files
            headerFile.Close();
            OutFile.Close();
            // Inform user the file has been created
            Console.WriteLine($"Output File: {iChoice} created.");
            // Wait for user to continue back to menu.  
            Utility.PressAnyKeyToContinue("Press Any Key To Continue");
        }
    }
}

