using System;
using System.IO;
using FSPG1;

namespace Tester
{
    class Test
    {
        private static Random rng;
        private static int lines = 0;
        private static char[] versions = { 'A', 'B', 'C' };
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

            // string[] inputs = new string[inputLines.Length];
            string [] insults = inputLines[0].Split(':');
            string[] inputs1 = inputLines[1].Split(':');
            string[] inputs2 = inputLines[2].Split(':');
            string[] inputs3 = inputLines[3].Split(':');
            string[] inputs4 = inputLines[4].Split(':');
            string[] inputs5 = inputLines[5].Split(':');
            string[] inputs6 = inputLines[6].Split(':');
            string[] inputs7 = inputLines[7].Split(':');
            string[] inputs8 = inputLines[8].Split(':');

            int[] hidden = new int[inputs1.Length];
            for(int ndx=0;ndx<hidden.Length;ndx++)
            {
                hidden[ndx] = Int32.Parse(inputs1[ndx]);
            }

            int[] by4 = new int[inputs2.Length];
            for (int ndx = 0; ndx < by4.Length; ndx++)
            {
                by4[ndx] = Int32.Parse(inputs2[ndx]);
            }

            float[] rooters = new float[inputs3.Length];
            for (int ndx = 0; ndx < rooters.Length; ndx++)
            {
                rooters[ndx] = Single.Parse(inputs3[ndx]);
            }

            int [] mins = new int[inputs4.Length];
            for (int ndx = 0; ndx < mins.Length; ndx++)
            {
                mins[ndx] = Int32.Parse(inputs4[ndx]);
            }

            int[] maxes = new int[inputs5.Length];
            for (int ndx = 0; ndx < maxes.Length; ndx++)
            {
                maxes[ndx] = Int32.Parse(inputs5[ndx]);
            }

            int[] seeds = new int[inputs6.Length];
            for (int ndx = 0; ndx < seeds.Length; ndx++)
            {
                seeds[ndx] = Int32.Parse(inputs6[ndx]);
            }

            int[] numers = new int[inputs7.Length];
            for (int ndx = 0; ndx < numers.Length; ndx++)
            {
                numers[ndx] = Int32.Parse(inputs7[ndx]);
            }

            int[] denoms = new int[inputs8.Length];
            for (int ndx = 0; ndx < denoms.Length; ndx++)
            {
                denoms[ndx] = Int32.Parse(inputs8[ndx]);
            }

            int testScore = 0;
            double labScore = 0;
            string actual = "";
            string result = "";
            string feedback = "";

            // test 1-5
            Console.WriteLine("\n\tTests 1 through 5 testing\n");
            for(int ndx = 0; ndx < insults.Length; ndx++)
            {
                testScore = 0;
                feedback = "";

                Submission sb = null;
                if (ndx % 2 == 0)
                {
                    sb = new Submission(insults[ndx]);
                    sb.Hidden = hidden[ndx];
                }
                else
                {
                    sb = new Submission();
                    sb.SetRetort(insults[ndx]);
                    hidden[ndx] = 38;
                }

                // test1, test2 & test3 
                actual = insults[ndx];
                result = sb.GetRetort();
                if(actual == result)
                {
                    testScore += 6;
                    if(insults[ndx].ToUpper() == sb.YellAtMe())
                    {
                        testScore += 2;
                    }
                    else
                    {
                        feedback += "  Error in YellAtMe method.";
                    }
                }
                else
                {
                    feedback += "  Error in constructor or getter/setter.";
                }
                
                if(hidden[ndx]==sb.Hidden)
                {
                    testScore += 2;
                }
                else
                {
                    feedback += "  Error in Hidden property.";
                }
                if(feedback=="")
                {
                    feedback = "Tests 1-5 all pass.";
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore + 
                                               "   " + feedback + "  " + 
                                               insults[ndx].ToUpper());
                labScore += testScore;
            }

            Console.WriteLine("\tTest6 Testing\n");
// Test6
            for(int ndx = 0; ndx < by4.Length;ndx++)
            {
                testScore = 0;
                int expected = by4[ndx] * 4;
                int submitted = Submission.Test6(by4[ndx]);
                bool success = expected == submitted;
                if(success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t["+by4[ndx]+"]\tExpected: "+expected + 
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\tTest7 Testing\n");
            // Test7
            for (int ndx = 0; ndx < rooters.Length; ndx++)
            {
                testScore = 0;
                float expected = (float)Math.Round(Math.Sqrt(rooters[ndx]),3);
                float submitted = (float)Math.Round(Submission.Test7(rooters[ndx]),3);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + rooters[ndx] + "]\tExpected: " + expected +
                                  "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\tTest8 Testing\n");
            // Test8
            for (int ndx = 0; ndx < mins.Length; ndx++)
            {
                testScore = 0;
                int expected = new Random(seeds[ndx]).Next(mins[ndx], maxes[ndx]);
                int submitted = Submission.Test8(mins[ndx],maxes[ndx],seeds[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + seeds[ndx] + ", " + mins[ndx] + ", " + maxes[ndx] +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }


            Console.WriteLine("\tTest9 Testing\n");
            // Test9
            for (int ndx = 0; ndx < numers.Length; ndx++)
            {
                testScore = 0;
                int expected = numers[ndx] / denoms[ndx];
                int submitted = Submission.Test9(numers[ndx], denoms[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + numers[ndx] + ", " + denoms[ndx] + 
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\tTest10 Testing\n");
            // Test10
            for (int ndx = 0; ndx < numers.Length; ndx++)
            {
                testScore = 0;
                int expected = numers[ndx] % denoms[ndx];
                int submitted = Submission.Test10(numers[ndx], denoms[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  "\t[" + numers[ndx] + ", " + denoms[ndx] +
                                  "]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tLab score: " + labScore + "\t" + fName);
        }
    }
}
