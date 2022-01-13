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
            string[] inputs10 = inputLines[10].Split(':');
            string[] inputs11 = inputLines[11].Split(':');
            string[] inputs12 = inputLines[12].Split(':');
            string[] inputs13 = inputLines[13].Split(':');
            string[] inputs14 = inputLines[14].Split(':');
            string[] inputs15 = inputLines[15].Split(':');
            string[] inputs16 = inputLines[16].Split(':');
            string[] inputs17 = inputLines[17].Split(':');
            string[] inputs18 = inputLines[18].Split(':');
            string[] inputs19 = inputLines[19].Split(':');

            double labScore = 0;

            double testScore = 0;

            int[] start1s = new int[inputs0.Length];
            for (int ndx = 0; ndx < start1s.Length; ndx++)
            {
                start1s[ndx] = Int32.Parse(inputs0[ndx]);
            }

            int[] end1s = new int[inputs1.Length];
            for (int ndx = 0; ndx < end1s.Length; ndx++)
            {
                end1s[ndx] = Int32.Parse(inputs1[ndx]);
            }

            int[] factor1s = new int[inputs2.Length];
            for (int ndx = 0; ndx < factor1s.Length; ndx++)
            {
                factor1s[ndx] = Int32.Parse(inputs2[ndx]);
            }

            int[] factorials = new int[inputs3.Length];
            for (int ndx = 0; ndx < factorials.Length; ndx++)
            {
                factorials[ndx] = Int32.Parse(inputs3[ndx]);
            }

            int[] roots = new int[inputs4.Length];
            for (int ndx = 0; ndx < roots.Length; ndx++)
            {
                roots[ndx] = Int32.Parse(inputs4[ndx]);
            }

            int[] exponents = new int[inputs5.Length];
            for (int ndx = 0; ndx < exponents.Length; ndx++)
            {
                exponents[ndx] = Int32.Parse(inputs5[ndx]);
            }

            double[] onHands = new double[inputs6.Length];
            for (int ndx = 0; ndx < onHands.Length; ndx++)
            {
                onHands[ndx] = Math.Round(Double.Parse(inputs6[ndx]),3);
            }

            double[] consumes = new double[inputs7.Length];
            for (int ndx = 0; ndx < consumes.Length; ndx++)
            {
                consumes[ndx] = Math.Round(Double.Parse(inputs7[ndx]),3);
            }

            int[] primes = new int[inputs8.Length];
            for (int ndx = 0; ndx < primes.Length; ndx++)
            {
                primes[ndx] = Int32.Parse(inputs8[ndx]);
            }

            char[] letters = new char[inputs9.Length];
            for (int ndx = 0; ndx < letters.Length; ndx++)
            {
                letters[ndx] = inputs9[ndx][0];
            }

            int[] repeats = new int[inputs10.Length];
            for (int ndx = 0; ndx < repeats.Length; ndx++)
            {
                repeats[ndx] = Int32.Parse(inputs10[ndx]);
            }

            double[] coins = new double[inputs11.Length];
            for (int ndx = 0; ndx < coins.Length; ndx++)
            {
                coins[ndx] = Double.Parse(inputs11[ndx]);
            }

            int[] factor2s = new int[inputs12.Length];
            for (int ndx = 0; ndx < factor2s.Length; ndx++)
            {
                factor2s[ndx] = Int32.Parse(inputs12[ndx]);
            }

            int[] qty1s = new int[inputs13.Length];
            for (int ndx = 0; ndx < qty1s.Length; ndx++)
            {
                qty1s[ndx] = Int32.Parse(inputs13[ndx]);
            }

            int[] start2s = new int[inputs14.Length];
            for (int ndx = 0; ndx < start2s.Length; ndx++)
            {
                start2s[ndx] = Int32.Parse(inputs14[ndx]);
            }

            int[] end2s = new int[inputs15.Length];
            for (int ndx = 0; ndx < end2s.Length; ndx++)
            {
                end2s[ndx] = Int32.Parse(inputs15[ndx]);
            }

            int[] seeds = new int[inputs16.Length];
            for (int ndx = 0; ndx < seeds.Length; ndx++)
            {
                seeds[ndx] = Int32.Parse(inputs16[ndx]);
            }

            int[] mins = new int[inputs17.Length];
            for (int ndx = 0; ndx < mins.Length; ndx++)
            {
                mins[ndx] = Int32.Parse(inputs17[ndx]);
            }

            int[] maxes = new int[inputs18.Length];
            for (int ndx = 0; ndx < maxes.Length; ndx++)
            {
                maxes[ndx] = Int32.Parse(inputs18[ndx]);
            }

            int[] qty2s = new int[inputs19.Length];
            for (int ndx = 0; ndx < qty2s.Length; ndx++)
            {
                qty2s[ndx] = Int32.Parse(inputs19[ndx]);
            }

            Console.WriteLine("\n\tTest1 Processing");
            // Test1
            for (int ndx = 0; ndx < start1s.Length; ndx++)
            {
                testScore = 0;
                int expected = 0;
                for(int cntr = start1s[ndx];cntr <= end1s[ndx];cntr++)
                {
                    if (cntr % factor1s[ndx] == 0)
                    {
                        expected++;
                    }
                }
                // int expected = ;
                int submitted = Submission.Test1(start1s[ndx], end1s[ndx], factor1s[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + start1s[ndx] + ", " + end1s[ndx] + ", " +
                                  factor1s[ndx] + "]\tExpected: " + expected + 
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest2 Processing");
            // Test2
            for (int ndx = 0; ndx < factorials.Length; ndx++)
            {
                testScore = 0;
                int expected = GetFact(factorials[ndx]);
                int submitted = Submission.Test2(factorials[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + factorials[ndx] + "]\tExpected: " + expected +
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest3 Processing");
            // Test3
            for (int ndx = 0; ndx < roots.Length; ndx++)
            {
                testScore = 0;
                int expected = (int)Math.Pow(roots[ndx],exponents[ndx]);
                int submitted = Submission.Test3(roots[ndx],exponents[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + roots[ndx]  + ", " + exponents[ndx] + 
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest4 Processing");
            // Test4
            for (int ndx = 0; ndx < onHands.Length; ndx++)
            {
                testScore = 0;
                int expected = CountEm(onHands[ndx], consumes[ndx]);
                int submitted = Submission.Test4(onHands[ndx], consumes[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(onHands[ndx], 3) + ", " +
                                  Math.Round(consumes[ndx], 3) + "]\tExpected: " + 
                                  expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest5 Processing");
            // Test5
            for (int ndx = 0; ndx < primes.Length; ndx++)
            {
                testScore = 0;
                bool expected = Check4Prime(primes[ndx]);
                bool submitted = Submission.Test5(primes[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + primes[ndx] + "]\tExpected: " +
                                  expected + "\tSubmitted: " + submitted);

                labScore += testScore;
            }

            Console.WriteLine("\n\tTest6 Processing");
            // Test6
            for (int ndx = 0; ndx < letters.Length; ndx++)
            {
                testScore = 0;
                string expected = "";
                char ltr = letters[ndx];
                for(int cntr = 0; cntr < repeats[ndx];cntr++)
                {
                    expected += ltr;
                    ltr = (char)(ltr + 1);
                }
                string submitted = Submission.Test6(letters[ndx], repeats[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[ '" + letters[ndx] + "', " + repeats[ndx] +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest7 Processing");
            // Test7
            for (int ndx = 0; ndx < coins.Length; ndx++)
            {
                testScore = 0;
                int expected = CoinCounter(coins[ndx]); ;
                int submitted = Submission.Test7(coins[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + Math.Round(coins[ndx], 2) + 
                                  "]\tExpected: " + expected +
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest8 Processing");
            // Test8
            for (int ndx = 0; ndx < factor2s.Length; ndx++)
            {
                testScore = 0;
                string expected = "";
                for (int cntr = 0; cntr < qty1s[ndx]; cntr++)
                {
                    expected += (factor2s[ndx] * (cntr + 1)) + " ";
                }
                string submitted = Submission.Test8(factor2s[ndx], qty1s[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                            "\t[" + factor2s[ndx] + ", " + qty1s[ndx] +
                            "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest9 Processing");
            // Test9
            for (int ndx = 0; ndx < start2s.Length; ndx++)
            {
                testScore = 0;
                int expected = 0;
                for(int cntr=start2s[ndx]; cntr <= end2s[ndx];cntr++)
                {
                    expected += cntr;
                }
                int submitted = Submission.Test9(start2s[ndx], end2s[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                            "\t[" + start2s[ndx] + ", " + end2s[ndx] +
                            "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest10 Processing");
            // Test10
            for (int ndx = 0; ndx < seeds.Length; ndx++)
            {
                Random gener = new Random(seeds[ndx]);
                Random rng = new Random(seeds[ndx]);
                testScore = 0;
                int expected = AddEmUp(gener, mins[ndx], maxes[ndx], qty2s[ndx]);
                int submitted = Submission.Test10(rng, mins[ndx], maxes[ndx], qty2s[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                            "\t[" + mins[ndx] + ", " + maxes[ndx] + ", " + qty2s[ndx] +
                            "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tLab score: " + labScore + "\t" + fName);
        }

        private static int GetFact(int x)
        {
            int v = x;

            for (int cntr = v - 1; cntr > 1; cntr--)
            {
                v *= cntr;
            }
            return v;
        }

        private static int CountEm(double o, double c)
        {
            int v = 0;
            while(o >= c)
            {
                o = Math.Round(o-c,3);
                v++;
            }
            return v;
        }

        private static bool Check4Prime(int v)
        {
            bool p = true;
            if(v < 2)                       // negatives, 0 and 1
            {
                p = false;
            }
            else if(v % 2 == 0 && v > 2)    // even but not 2
            {
                p = false;
            }
            else
            {
                for(int cntr = 3; cntr < v/2; cntr+=2)
                {
                    if(v%cntr == 0)
                    {
                        p = false;
                        break;
                    }
                }
            }

            return p;
        }

        private static int CoinCounter(double m)
        {
            int q = 0;
            int d = 0;
            int n = 0;
            int p = 0;

            q = (int)(m / .25);  // gets quarters
            m = Math.Round(m - (q * .25),2);   // removes quarters from amount

            d = (int)(m / .10);  // gets dimes
            m = Math.Round(m - (d * .10),2);   // removes dimes from amount

            n = (int)(m / .05);  // gets nickels
            m = Math.Round(m - (n * .05),2);   // removes nickels from amount

            p += (int) (m * 100);      // gets pennies

            return q + d + n + p;
        }

        private static int AddEmUp(Random r, int min, int max,int q)
        {
            int sum = 0;
            for(int ndx = 0;ndx <q;ndx++)
            {
                sum += r.Next(min, max);
            }

            return sum;
        }
    }
}
