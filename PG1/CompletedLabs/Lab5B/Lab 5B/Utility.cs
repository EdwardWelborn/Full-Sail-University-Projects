using System;
using System.IO;
using FSPG1;

namespace Tester
{
    public class Utility
    {
        public static string BuildFileName(int testNumber)
        {
            return "Lab" + testNumber + "Data.txt";
        }
        public static string BuildFileName(int testNumber, char version)
        {
            return "Lab" + testNumber + version +"Data.txt";
        }
        public static string BuildFileName(string path, int testNumber)
        {
            string retPath = path + "Lab" + testNumber + "Data-Evaluation.txt";
            return retPath;
        }

        public static StreamReader OpenFile(string fName) // throws FileNotFoundException { }
        {
            StreamReader retFile = null;
            try
            {
                retFile = new StreamReader(fName);
            }
            catch(FileNotFoundException nfe)
            {
                Console.WriteLine(nfe.Message);
                throw nfe;
            }
            return retFile;
        }

        public static string AlignOutput(int width, string str)
        {
            string result = str;
            for (int cntr = str.Length; cntr < width; cntr++)
            {
                result += " ";
            }
            return result;
        }

        public static char GetGrade(double x)
        {
            char g = '?';
            if(x >= 90 && x <=100)
            {
                g = 'A';
            }
            else if (x >= 80 && x < 90)
            {
                g = 'B';
            }
            else if (x >= 73 && x < 80)
            {
                g = 'C';
            }
            else if (x >= 70 && x < 73)
            {
                g = 'D';
            }
            else if (x >= 0 && x < 70)
            {
                g = 'F';
            }

            return g;
        }

        public static double DoubleOp(double d1,double d2)
        {
            return d1 + d2;
        }

        public static int GetAction(int speed)
        {
            int action = 0;

            if(speed > 5 && speed <= 10)
            {
                action = 1;
            }
            else if(speed > 10 && speed <=25)
            {
                action = 2;
            }
            else if(speed > 25)
            {
                action = 3;
            }
            return action;
        }
    }
}
