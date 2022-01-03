using System;
using System.IO;
using FSPG1;

namespace Tester
{
    class Test
    {
        private static Random rng;
        private static int lines = 0;
        private static char[] versions = { 'A', 'B', 'C', 'D' };
        public static void Run(int labNumber)
        {
            rng = new Random(labNumber);
            char version = versions[new Random().Next(4)];
            string fName = Utility.BuildFileName(labNumber,version);

            string[] inputLines = null; 
            StreamReader fReader = null;
            bool fileFound = false;
            while(!fileFound)
            {
                try
                {
                    fReader = Utility.OpenFile(@fName);
                    fileFound = true;
                    lines = Int32.Parse(fReader.ReadLine());
                    inputLines = new string[lines];
                    for(int ndx = 0; ndx < inputLines.Length; ndx++)
                    {
                        inputLines[ndx] = fReader.ReadLine();
                    }
                }
                catch(FileNotFoundException fnfe)
                {
                    Console.WriteLine("Test source file not found, aborting...");
                    throw fnfe;
                }
                finally
                {
                    fReader.Close();
                }
            }
            //for(int cntr = 0; cntr < inputLines.Length; ++cntr)
            //{
            //    Console.WriteLine(inputLines[cntr]);
            //}
            //Console.WriteLine("inputLines.Length = " + inputLines.Length);
            //Console.ReadKey();
            string[,] inputs = new string[inputLines.Length, 5];
            for(int ndx = 0; ndx < inputLines.Length;ndx++)
            {
                string [] parsedLine = inputLines[ndx].Split(':');
                for(int cntr = 0; cntr < parsedLine.Length;cntr++)
                {
                    inputs[ndx, cntr] = parsedLine[cntr];
                }
            }

            double labScore = 0;
            string actual = "";
            string result = "";
            for (int line = 0; line < inputs.GetLength(0); line++)
            {
                Console.WriteLine("\tTest" + (line + 3));
                double testScore = 0;
                bool success = false;
                for (int ndx = 0; ndx < inputs.GetLength(1); ndx++)
                {
                    switch (line)
                    {
                        case 0:
                            int iActual = Int32.Parse(inputs[line, ndx]);
                            int iResult = Submission.Test3(inputs[line, ndx]);
                            actual = iActual + "";
                            result = iResult + "";
                            success = iActual == iResult;
                            break;
                        case 1:
                            sbyte sbActual = SByte.Parse(inputs[line, ndx]);
                            sbyte sbResult = Submission.Test4(inputs[line, ndx]);
                            actual = sbActual + "";
                            result = sbResult + "";
                            success = sbActual == sbResult;
                            break;
                        case 2:
                            double dActual = Double.Parse(inputs[line, ndx]);
                            double dResult = Submission.Test5(inputs[line, ndx]);
                            actual = dActual + "";
                            result = dResult + "";
                            success = dActual == dResult;
                            break;
                        case 3:
                            int usActual = UInt16.Parse(inputs[line, ndx]);
                            int usResult = Submission.Test6(inputs[line, ndx]);
                            actual = usActual + "";
                            result = usResult + "";
                            success = usActual == usResult;
                            break;
                        case 4:
                            float fActual = Single.Parse(inputs[line, ndx]);
                            float fResult = Submission.Test7(inputs[line, ndx]);
                            actual = fActual + "";
                            result = fResult + "";
                            success = fActual == fResult;
                            break;
                        case 5:
                            uint uiActual = UInt32.Parse(inputs[line, ndx]);
                            uint uiResult = Submission.Test8(inputs[line, ndx]);
                            actual = uiActual + "";
                            result = uiResult + "";
                            success = uiActual == uiResult;
                            break;
                        case 6:
                            short sActual = Int16.Parse(inputs[line, ndx]);
                            short sResult = Submission.Test9(inputs[line, ndx]);
                            actual = sActual + "";
                            result = sResult + "";
                            success = sActual == sResult;
                            break;
                        case 7:
                            ulong ulActual = UInt64.Parse(inputs[line, ndx]);
                            ulong ulResult = Submission.Test10(inputs[line, ndx]);
                            actual = ulActual + "";
                            result = ulResult + "";
                            success = ulActual == ulResult;
                            break;
                    }

                    string failed = "Fail";
                    if (success)
                    {
                        testScore += 2;
                        failed = "Pass";
                    }

                    Console.WriteLine("Pass #" + (ndx + 1) + " " + failed + " (" + 
                               Utility.AlignOutput(13,(inputs[line, ndx]+")")) + 
                               " Actual {" + Utility.AlignOutput(13,(actual+"}")) + 
                               " Submitted {" + Utility.AlignOutput(13,(result + "}")));
                }
                labScore += testScore;
                Console.WriteLine("Test" + (line +3) + " Score: " + testScore +"\n");
                testScore = 0;
            }
            Console.WriteLine("Lab score: " + labScore + "\t" + fName +" (Lab 2 portion of assignment only)");
        }
    }
}
