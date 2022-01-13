using System;
using System.IO;
using FSPG1;
using FS_Supplemental;

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
            char version = versions[new Random().Next(versions.Length)];

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
            //for (int cntr = 0; cntr < inputLines.Length; ++cntr)
            //{
            //    Console.WriteLine(inputLines[cntr]);
            //}
            //Console.WriteLine("inputLines.Length = " + inputLines.Length);
            //Console.ReadKey();

            string[] inputs = new string[inputLines.Length];
            string[] inputs0 = inputLines[0].Split(':');
            string[] inputs1 = inputLines[1].Split(':');
            string[] inputs2 = inputLines[2].Split(':');
            string[] inputs3 = inputLines[3].Split(':');
            string[] inputs4 = inputLines[4].Split(':');
            string[] inputs5 = inputLines[5].Split(':');
            string[] inputs6 = inputLines[6].Split(':');
            string[] inputs7 = inputLines[7].Split(':');
            string[] inputs8 = inputLines[8].Split(':');
            string[] inputs9 = inputLines[9].Split(':');
            string[] inputsA = inputLines[10].Split(':');
            string[] inputsB = inputLines[11].Split(':');
            string[] inputsC = inputLines[12].Split(':');
            string[] inputsD = inputLines[13].Split(':');

            int[] multiples = new int[inputs0.Length];
            for (int ndx = 0; ndx < multiples.Length; ndx++)
            {
                multiples[ndx] = Int32.Parse(inputs0[ndx]);
            }

            int[] factors = new int[inputs1.Length];
            for (int ndx = 0; ndx < factors.Length; ndx++)
            {
                factors[ndx] = Int32.Parse(inputs1[ndx]);
            }

            double[] fahrenheits = new double[inputs2.Length];
            for (int ndx = 0; ndx < fahrenheits.Length; ndx++)
            {
                fahrenheits[ndx] = Math.Round(Double.Parse(inputs2[ndx]),3);
            }

            double[] celsii = new double[inputs3.Length];
            for (int ndx = 0; ndx < celsii.Length; ndx++)
            {
                celsii[ndx] = Math.Round(Double.Parse(inputs3[ndx]),3);
            }

            double[] grades = new double[inputs4.Length];
            for (int ndx = 0; ndx < grades.Length; ndx++)
            {
                grades[ndx] = Double.Parse(inputs4[ndx]);
            }

            double[] num1s = new double[inputs5.Length];
            for (int ndx = 0; ndx < num1s.Length; ndx++)
            {
                num1s[ndx] = Double.Parse(inputs5[ndx]);
            }

            double[] num2s = new double[inputs6.Length];
            for (int ndx = 0; ndx < num2s.Length; ndx++)
            {
                num2s[ndx] = Double.Parse(inputs6[ndx]);
            }

            MathOperator [] mOps = new MathOperator[inputs7.Length];
            for (int ndx = 0; ndx < mOps.Length; ndx++)
            {
                int x = Int32.Parse(inputs7[ndx]);
                mOps[ndx] = GetOp(x);
            }

            int[] speeds = new int[inputs8.Length];
            for (int ndx = 0; ndx < speeds.Length; ndx++)
            {
                speeds[ndx] = Int32.Parse(inputs8[ndx]);
            }

            Point[] point1s = new Point[inputs8.Length];
            Point[] point2s = new Point[inputs8.Length];
            for(int ndx = 0; ndx < point1s.Length; ndx++)
            {
                Random rng = new Random(speeds[ndx]);
                double x = rng.NextDouble() * multiples[ndx];
                double y = rng.NextDouble() * factors[ndx];
                point1s[ndx] = new Point(x, y);
                if(speeds[ndx] % 2 == 0)
                {
                    point2s[ndx] = new Point(x, y);
                }
                else
                {
                    point2s[ndx] = new Point(y*2, x/2);
                }
            }

            double[] prices = new double[inputs9.Length];
            for (int ndx = 0; ndx < prices.Length; ndx++)
            {
                prices[ndx] = Double.Parse(inputs9[ndx]);
            }

            double[] taxes = new double[inputsA.Length];
            for (int ndx = 0; ndx < taxes.Length; ndx++)
            {
                taxes[ndx] = Double.Parse(inputsA[ndx]);
            }

            double[] cashes = new double[inputsB.Length];
            for (int ndx = 0; ndx < cashes.Length; ndx++)
            {
                cashes[ndx] = Double.Parse(inputsB[ndx]);
            }

            double[] miles = new double[inputsC.Length];
            for (int ndx = 0; ndx < miles.Length; ndx++)
            {
                miles[ndx] = Double.Parse(inputsC[ndx]);
            }

            double[] kms = new double[inputsD.Length];
            for (int ndx = 0; ndx < kms.Length; ndx++)
            {
                kms[ndx] = Double.Parse(inputsD[ndx]);
            }

            double testScore = 0;
            double labScore = 0;

            Console.WriteLine("\n\tTest1 Processing");
            // Test1
            for (int ndx = 0; ndx < multiples.Length; ndx++)
            {
                testScore = 0;
                bool expected = multiples[ndx] % factors[ndx] == 0;
                bool submitted = Submission.Test1(multiples[ndx], factors[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + multiples[ndx] + ", " + factors[ndx] +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest2 Processing");
            // Test2
            for (int ndx = 0; ndx < fahrenheits.Length; ndx++)
            {
                testScore = 0;
                bool expected = (fahrenheits[ndx]-32.0) * (5.0/9.0) == celsii[ndx];
                bool submitted = Submission.Test2(fahrenheits[ndx], celsii[ndx]);
                bool success = expected == submitted;
                if (!success)
                {
                    expected = (celsii[ndx]*(9.0/5.0)+32.0) == fahrenheits[ndx];
                    success = expected == submitted;
                }
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(fahrenheits[ndx],3) + ", " + 
                                  Math.Round(celsii[ndx],3) +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest3 Processing");
            // Test3
            for (int ndx = 0; ndx < grades.Length; ndx++)
            {
                testScore = 0;
                char expected = Utility.GetGrade(grades[ndx]);
                char submitted = Submission.Test3(grades[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(grades[ndx],2) + 
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest4 Processing");
            // Test4
            for (int ndx = 0; ndx < mOps.Length; ndx++)
            {
                testScore = 0;
                double expected = Utility.UseMathOp(num1s[ndx], num2s[ndx], mOps[ndx]);
                double submitted = Submission.Test4(num1s[ndx], num2s[ndx], mOps[ndx]);
                expected = Math.Round(expected, 2);
                submitted = Math.Round(submitted, 2);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(num1s[ndx],3) + ", " + 
                                  Math.Round(num2s[ndx],3) + ", " +  mOps[ndx] +
                                  "]\tExpected: " + Math.Round(expected,3) + "\tSubmitted: " + 
                                  Math.Round(submitted,2));
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest5 Processing");
            // Test5
            for (int ndx = 0; ndx < speeds.Length; ndx++)
            {
                testScore = 0;
                int expected = Utility.GetAction(speeds[ndx]);
                int submitted = Submission.Test5(speeds[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + speeds[ndx] +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }


            Console.WriteLine("\n\tTest6 Processing");
            // Test6
            for (int ndx = 0; ndx < point1s.Length; ndx++)
            {
                testScore = 0;
                bool expected = point1s[ndx].Equals(point2s[ndx]);
                bool submitted = Submission.Test6(point1s[ndx], point2s[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + point1s[ndx] + ", " + point2s[ndx] + 
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest7 Processing");
            // Test7
            for (int ndx = 0; ndx < prices.Length; ndx++)
            {
                testScore = 0;
                bool expected = (prices[ndx] * (1+taxes[ndx])) <= cashes[ndx];
                bool submitted = Submission.Test7(prices[ndx],taxes[ndx],cashes[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(prices[ndx],2) + ", " + 
                                  Math.Round(taxes[ndx],2) + ", " + 
                                  Math.Round(cashes[ndx],2) +
                                  "]\tExpected: " + expected +
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest8 Processing");
            // Test8
            for (int ndx = 0; ndx < miles.Length; ndx++)
            {
                testScore = 0;
                double expected = (miles[ndx]*1.609) >= kms[ndx] ? miles[ndx] : kms[ndx];
                double submitted = Submission.Test8(miles[ndx], kms[ndx]);
                bool success = expected == submitted;
                if(!success)
                {
                    expected = (kms[ndx] * 0.621) >= miles[ndx] ? kms[ndx] : miles[ndx];
                    success = expected == submitted;
                }
                if (success)
                {
                    testScore = 2.5;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(miles[ndx],3) + ", " + 
                                  Math.Round(kms[ndx],3) +
                                  "]\tExpected: " + Math.Round(expected,3)
                                  + "\tSubmitted: " + Math.Round(submitted,3));
                labScore += testScore;
            }

            Console.WriteLine("\n\tLab score: " + labScore + "\tFile: " + fName);
        }

        private static MathOperator GetOp(int i)
        {
            MathOperator op = MathOperator.Divide;

            switch(i)
            {
                case 1:
                    op = MathOperator.Add;
                    break;
                case 2:
                    op = MathOperator.Subtract;
                    break;
                case 3:
                    op = MathOperator.Multiply;
                    break;
                case 4:
                    op = MathOperator.Divide;
                    break;
            }

            return op;
        }
    }
}
