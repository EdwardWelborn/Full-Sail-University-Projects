using System;
using System.IO;
using FSPG1;

namespace Tester
{
    class Test
    {
        private static Random rng;
        private static int lines = 0;
        private static char[] versions = { 'A' , 'B' , 'C' };
        public static void Run(int labNumber)
        {
            rng = new Random(labNumber);
            char version = versions[new Random().Next(versions.Length)];

            string fName = Utility.BuildFileName(labNumber, version);

            string[] inputLines = null;
            StreamReader fReader = null;
            bool fileFound = false;
            while (!fileFound)
            {
                try
                {
                    fReader = Utility.OpenFile(@fName);
                    fileFound = true;
                    lines = Int32.Parse(fReader.ReadLine());
                    inputLines = new string[lines];
                    for (int ndx = 0; ndx < inputLines.Length; ndx++)
                    {
                        inputLines[ndx] = fReader.ReadLine();
                    }
                }
                catch (FileNotFoundException fnfe)
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
            string[] word1s = inputs0;

            string[] inputs1 = inputLines[1].Split(':');
            string[] inputs2 = inputLines[2].Split(':');
            string[] inputs3 = inputLines[3].Split(':');
            string[] inputs4 = inputLines[4].Split(':');
            string[] inputs5 = inputLines[5].Split(':');
            double[][] stats = new double[inputs1.Length][];
            stats[0] = new double[5];
            for (int cols = 0; cols < inputs1.Length; cols++)
            {
                stats[0][cols] = Double.Parse(inputs1[cols]);
            }
            stats[1] = new double[5];
            for (int cols = 0; cols < inputs2.Length; cols++)
            {
                stats[1][cols] = Double.Parse(inputs2[cols]);
            }
            stats[2] = new double[5];
            for (int cols = 0; cols < inputs3.Length; cols++)
            {
                stats[2][cols] = Double.Parse(inputs3[cols]);
            }
            stats[3] = new double[5];
            for (int cols = 0; cols < inputs4.Length; cols++)
            {
                stats[3][cols] = Double.Parse(inputs4[cols]);
            }
            stats[4] = new double[5];
            for (int cols = 0; cols < inputs5.Length; cols++)
            {
                stats[4][cols] = Double.Parse(inputs5[cols]);
            }

            string[] inputs6 = inputLines[6].Split(':');
            string[] inputs7 = inputLines[7].Split(':');
            string[] inputs8 = inputLines[8].Split(':');
            string[] inputs9 = inputLines[9].Split(':');
            string[] inputs10 = inputLines[10].Split(':');
            double[][] normals = new double[inputs6.Length][];
            normals[0] = new double[5];
            for (int cols = 0; cols < inputs6.Length; cols++)
            {
                normals[0][cols] = Double.Parse(inputs6[cols]);
            }
            normals[1] = new double[5];
            for (int cols = 0; cols < inputs7.Length; cols++)
            {
                normals[1][cols] = Double.Parse(inputs7[cols]);
            }
            normals[2] = new double[5];
            for (int cols = 0; cols < inputs8.Length; cols++)
            {
                normals[2][cols] = Double.Parse(inputs8[cols]);
            }
            normals[3] = new double[5];
            for (int cols = 0; cols < inputs9.Length; cols++)
            {
                normals[3][cols] = Double.Parse(inputs9[cols]);
            }
            normals[4] = new double[5];
            for (int cols = 0; cols < inputs10.Length; cols++)
            {
                normals[4][cols] = Double.Parse(inputs10[cols]);
            }

            string[] inputs11 = inputLines[11].Split(':');
            string[] inputs12 = inputLines[12].Split(':');
            string[] inputs13 = inputLines[13].Split(':');
            string[] inputs14 = inputLines[14].Split(':');
            string[] inputs15 = inputLines[15].Split(':');
            string[][] uniques = new string[inputs11.Length][];
            uniques[0] = inputs11;
            uniques[1] = inputs12;
            uniques[2] = inputs13;
            uniques[3] = inputs14;
            uniques[4] = inputs15;

            string[] inputs16 = inputLines[16].Split(':');
            string[] inputs17 = inputLines[17].Split(':');
            string[] inputs18 = inputLines[18].Split(':');
            string[] inputs19 = inputLines[19].Split(':');
            string[] inputs20 = inputLines[20].Split(':');
            string[][] acros = new string[inputs16.Length][];
            acros[0] = inputs16;
            acros[1] = inputs17;
            acros[2] = inputs18;
            acros[3] = inputs19;
            acros[4] = inputs20;

            string[] inputs21 = inputLines[21].Split(':');
            string[] word2s = inputs21;

            string[] inputs22 = inputLines[22].Split(':');
            int[] seeds = new int[inputs22.Length];
            for (int ndx = 0; ndx < inputs22.Length; ndx++)
            {
                seeds[ndx] = Int32.Parse(inputs22[ndx]);
            }

            string[] inputs23 = inputLines[23].Split(':');

            int[] seed2s = new int[inputs23.Length];
            for (int ndx = 0; ndx < inputs23.Length; ndx++)
            {
                seed2s[ndx] = Int32.Parse(inputs23[ndx]);
            }

            string[] inputs24 = inputLines[24].Split(':');
            string[] inputs25 = inputLines[25].Split(':');
            string[] inputs26 = inputLines[26].Split(':');
            string[] inputs27 = inputLines[27].Split(':');
            string[] inputs28 = inputLines[28].Split(':');
            int[][] asciis = new int[inputs24.Length][];
            asciis[0] = new int[5];
            for (int ndx = 0; ndx < inputs24.Length; ndx++)
            {
                asciis[0][ndx] = Int32.Parse(inputs24[ndx]);
            }
            asciis[1] = new int[5];
            for (int ndx = 0; ndx < inputs25.Length; ndx++)
            {
                asciis[1][ndx] = Int32.Parse(inputs25[ndx]);
            }
            asciis[2] = new int[5];
            for (int ndx = 0; ndx < inputs26.Length; ndx++)
            {
                asciis[2][ndx] = Int32.Parse(inputs26[ndx]);
            }
            asciis[3] = new int[5];
            for (int ndx = 0; ndx < inputs27.Length; ndx++)
            {
                asciis[3][ndx] = Int32.Parse(inputs27[ndx]);
            }
            asciis[4] = new int[5];
            for (int ndx = 0; ndx < inputs28.Length; ndx++)
            {
                asciis[4][ndx] = Int32.Parse(inputs28[ndx]);
            }

            string[] inputs29 = inputLines[29].Split(':');
            string[] word3s = inputs29;

            double labScore = 0;
            double testScore = 0;

            Console.WriteLine("\n\tTest1 Processing");
            // Test1
            for (int ndx = 0; ndx < word1s.Length; ndx++)
            {
                string s = word1s[ndx];
                testScore = 0;
                int[] expected = new int[s.Length];
                for (int cntr = 0; cntr < s.Length; cntr++)
                {
                    expected[cntr] = (int)s[cntr];
                }
                int[] submitted = Submission.Test1(s.ToCharArray());
                bool success = CompareArrays(expected, submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore +
                                  " [ " + s + " " + "]\tExpected: ");
                PrintArray(expected);
                Console.Write("\tSubmitted: ");
                PrintArray(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest2 Processing");
            // Test2
            for (int ndx = 0; ndx < stats.Length; ndx++)
            {
                testScore = 0;
                double[] expected = GetStats(stats[ndx]);
                double[] submitted = Submission.Test2(stats[ndx]);
                bool success = CompareArrays(expected, submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore + " [ ");
                PrintArray(stats[ndx]);
                Console.Write("]\tExpected: ");
                PrintArray(expected);
                Console.Write("\tSubmitted: ");
                PrintArray(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest3 Processing");
            // Test3
            for (int ndx = 0; ndx < normals.Length; ndx++)
            {
                testScore = 0;
                double[] keepIt = DuplicateArray(normals[ndx]);
                Normalize(keepIt);
                double[] expected = keepIt;
                double[] passItOn = DuplicateArray(normals[ndx]);
                Submission.Test3(passItOn);
                double[] submitted = passItOn;
                bool success = CompareArrays(expected, submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore + " [ ");
                PrintArray(normals[ndx]);
                Console.Write("]\tExpected: ");
                PrintArray(expected);
                Console.Write("\tSubmitted: ");
                PrintArray(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest4 Processing");
            // Test4
            for (int ndx = 0; ndx < uniques.Length; ndx++)
            {
                testScore = 0;
                bool expected = IsUnique(uniques[ndx]);
                bool submitted = Submission.Test4(uniques[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore + " [ ");
                PrintArray(uniques[ndx]);
                Console.WriteLine("]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest5 Processing");
            // Test5
            for (int ndx = 0; ndx < acros.Length; ndx++)
            {
                testScore = 0;
                string expected = Acronym(acros[ndx]);
                string submitted = Submission.Test5(acros[ndx]);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore + " [ ");
                PrintArray(acros[ndx]);
                Console.WriteLine("]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest6 Processing");
            // Test6
            for (int ndx = 0; ndx < word2s.Length; ndx++)
            {
                testScore = 0;
                string expected = new string(ReverseMe(word2s[ndx].ToCharArray()));
                string submitted = new string(Submission.Test6(word2s[ndx].ToCharArray()));
                bool success = expected == submitted; //  CompareArrays(expected,submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore + " [ ");
                Console.Write(word2s[ndx]);
                Console.Write(" ]\tExpected: ");
                Console.Write(expected);
                Console.Write("\tSubmitted: ");
                Console.Write(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest7 Processing");
            // Test7
            for (int ndx = 0; ndx < seeds.Length; ndx++)
            {
                Random rng = new Random(seeds[ndx]);
                int r = rng.Next(2, 4);
                int c = rng.Next(3, 5);
                int[,] source = new int[r, c];
                for (int row = 0; row < source.GetLength(0); row++)
                {
                    for (int col = 0; col < source.GetLength(1); col++)
                    {
                        source[row, col] = rng.Next(1, 10);
                    }
                }
                testScore = 0;
                int[,] expected = Transpose(source);
                int[,] submitted = Submission.Test7(source);
                bool success = Compare2DArrays(expected, submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore +" [ ");
                Print2DArray(source);
                Console.Write(" ]\tExpected: ");
                Print2DArray(expected);
                Console.Write("\tSubmitted: ");
                Print2DArray(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest8 Processing");
            // Test8
            for (int ndx = 0; ndx < seed2s.Length; ndx++)
            {
                testScore = 0;
                Random rng = new Random(seed2s[ndx]);
                int size = rng.Next(2, 5);
                int[] ar1 = new int[size];
                int[] ar2 = new int[size];
                int[] ar3 = new int[size];

                for (int cntr = 0; cntr < ar1.Length; cntr++)
                {
                    ar1[cntr] = rng.Next(1, 10);
                    ar2[cntr] = rng.Next(1, 6);
                    ar3[cntr] = rng.Next(6, 10);
                }
                int[,] expected = Build2DArray(ar1, ar2, ar3);
                int [,] submitted = Submission.Test8(ar1,ar2,ar3);
                bool success = Compare2DArrays(expected,submitted);
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore +" [ ");
                PrintArray(ar1);
                Console.Write("/ ");
                PrintArray(ar2);
                Console.Write("/ ");
                PrintArray(ar3);
                Console.Write("]\tExpected: ");
                Print2DArray(expected);
                Console.Write("\tSubmitted: ");
                Print2DArray(submitted);
                Console.WriteLine();
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest9 Processing");
            // Test9
            for (int ndx = 0; ndx < asciis.Length; ndx++)
            {
                testScore = 0;
                string expected = new string(GetWords(asciis[ndx]));
                string submitted = new string(Submission.Test9(asciis[ndx]));
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.Write("Pass[" + (ndx + 1) + "]: score = " + testScore +" [ ");
                PrintArray(asciis[ndx]);
                Console.WriteLine("]\tExpected: " + expected + "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tTest10 Processing");
            // Test10
            for (int ndx = 0; ndx < word3s.Length; ndx++)
            {
                testScore = 0;
                char[] exp = Choppy(DuplicateArray(word3s[ndx].ToCharArray()));
                string expected = new string(exp);
                char[] sub = DuplicateArray(word3s[ndx].ToCharArray());
                Submission.Test10(sub);
                string submitted = new string(sub);
                bool success = expected == submitted;
                if (success)
                {
                    testScore = 2;
                }
                Console.WriteLine("Pass[" + (ndx + 1) + "]: score = " + testScore +
                            " [ " +word3s[ndx] + " ]\tExpected: " + expected + 
                            "\tSubmitted: " + submitted);
                labScore += testScore;
            }

            Console.WriteLine("\n\tLab score: " + labScore + "\t" + fName);
        }

        public static bool CompareArrays(int[] expected, int[] submitted)
        {
            bool yes = true;
            if (submitted == null)
            {
                yes = false;
            }
            else if (expected.Length != submitted.Length)
            {
                yes = false;
            }
            else
            {
                for (int c = 0; c < expected.Length; c++)
                {
                    if (expected[c] != submitted[c])
                    {
                        yes = false;
                        break;
                    }
                }
            }
            return yes;
        }
        public static bool CompareArrays(char[] expected, char[] submitted)
        {
            bool yes = true;
            if (submitted == null)
            {
                yes = false;
            }
            else if (expected.Length != submitted.Length)
            {
                yes = false;
            }
            else
            {
                for (int c = 0; c < expected.Length; c++)
                {
                    if (expected[c] != submitted[c])
                    {
                        yes = false;
                        break;
                    }
                }
            }
            return yes;
        }
        public static bool CompareArrays(double[] expected, double[] submitted)
        {
            bool yes = true;
            if (submitted == null)
            {
                yes = false;
            }
            else if (expected.Length != submitted.Length)
            {
                yes = false;
            }
            else
            {
                for (int c = 0; c < expected.Length; c++)
                {
                    if (Math.Round(expected[c], 2) != Math.Round(submitted[c], 2))
                    {
                        yes = false;
                        break;
                    }
                }
            }
            return yes;
        }
        public static bool Compare2DArrays(int[,] expected, int[,] submitted)
        {
            bool yes = true;
            if (submitted == null)
            {
                yes = false;
            }
            else if (expected.GetLength(0) != submitted.GetLength(0) ||
                     expected.GetLength(1) != submitted.GetLength(1))
            {
                yes = false;
            }
            else
            {
                for (int r = 0; r < expected.GetLength(0) && yes; r++)
                {
                    for (int c = 0; c < expected.GetLength(1); c++)
                    {
                        if (expected[r,c] != submitted[r,c])
                        {
                            yes = false;
                            break;
                        }
                    }
                }
            }
            return yes;
        }
        public static void PrintArray(string[] array)
        {
            if (array != null)
            {
                foreach (string s in array)
                {
                    Console.Write(s + " ");
                }
            }
        }
        public static void PrintArray(int[] array)
        {
            if (array != null)
            {
                foreach (int i in array)
                {
                    Console.Write(i + " ");
                }
            }
        }
        public static void PrintArray(char[] array)
        {
            if (array != null)
            {
                foreach (char c in array)
                {
                    Console.Write(c + " ");
                }
            }
        }
        public static void PrintArray(double [] array)
        {
            if (array != null)
            {
                foreach (double d in array)
                {
                    Console.Write(Math.Round(d,3) + " ");
                }
            }
        }
        public static void Print2DArray(int[,] array)
        {
            if (array != null)
            {
                Console.Write("{ ");
                for (int r=0;r<array.GetLength(0);r++)
                {
                    Console.Write("{");
                    for (int c=0;c< array.GetLength(1) - 1; c++)
                    {
                        Console.Write(array[r,c] + ",");
                    }
                    if(r!=array.GetLength(0)-1)
                        Console.Write(array[r, array.GetLength(1) - 1]+"},");
                    else
                        Console.Write(array[r, array.GetLength(1) - 1] + "}");
                }
                Console.Write(" }");
            }
        }
        public static double [] GetStats(double [] source)
        {
            double[] stat = new double[3];
            stat[0] = source[0];
            stat[1] = source[0];
            double average = source[0];
            for(int ndx=1;ndx<source.Length;ndx++)
            {
                if(source[ndx]<stat[0])
                {
                    stat[0] = source[ndx];
                }
                else if(source[ndx] > stat[1])
                {
                    stat[1] = source[ndx];
                }
                average += source[ndx];
            }
            stat[2] = average / source.Length;
            return stat;
        }
        public static void Normalize(double [] source)
        {
            double largest = source[0];
            for (int ndx = 1; ndx < source.Length; ndx++)
            {
                if (source[ndx] > largest)
                {
                    largest = source[ndx];
                }
            }
            for(int ndx=0;ndx < source.Length;ndx++)
            {
                source[ndx] /= largest;
            }
        }
        public static char[] DuplicateArray(char[] source)
        {
            char[] c = new char[source.Length];
            for (int ndx = 0; ndx < source.Length; ndx++)
            {
                c[ndx] = source[ndx];
            }
            return c;
        }
        public static double [] DuplicateArray(double [] source)
        {
            double[] d = new double[source.Length];
            for(int ndx=0;ndx<source.Length;ndx++)
            {
                d[ndx] = source[ndx];
            }
            return d;
        }
        public static bool IsUnique(string [] words)
        {
            bool yep = true;
            for(int ndx=0;ndx<words.Length-1 && yep;ndx++)
            {
                for(int cntr=ndx+1;cntr<words.Length;cntr++)
                {
                    if(words[ndx]==words[cntr])
                    {
                        yep = false;
                        break;
                    }
                }
            }
            return yep;
        }
        public static string Acronym(string [] words)
        {
            string acro = "";
            foreach(string w in words)
            {
                acro += w[0];
            }
            return acro;
        }
        public static char [] ReverseMe(char [] source)
        {
            char[] backward = new char[source.Length];
            
            int end = source.Length - 1;
            for(int start = 0; start<source.Length;start++)
            {
                backward[start] = source[end - start];
            }
            return backward;
        }
        public static int[,] Transpose(int[,] source)
        {
            int r = source.GetLength(0);
            int c = source.GetLength(1);
            int[,] back = new int[c, r];

            for(int row=0;row<r;row++)
            {
                for(int col=0;col<c;col++)
                {
                    back[col,row] = source[row, col];
                }
            }
            return back;
        }
        public static int [,] Build2DArray(int [] s1,int [] s2, int [] s3)
        {
            int[,] table = new int[3, s1.Length];

            for(int cntr=0;cntr < s1.Length;cntr++)
            {
                table[0, cntr] = s1[cntr];
                table[1, cntr] = s2[cntr];
                table[2, cntr] = s3[cntr];
            }
            return table;
        }
        public static char [] GetWords(int[]src)
        {
            char[] answer = new char[src.Length];
            for(int ndx = 0;ndx<src.Length;ndx++)
            {
                answer[ndx] = (char)src[ndx];
            }
            return answer;
        }
        public static char [] Choppy(char [] src)
        {
            char [] retVal = new char[src.Length];
            for(int ndx=0;ndx<src.Length;ndx++)
            {
                if (ndx % 2 == 0)
                    retVal[ndx] = src[ndx];
                else
                    retVal[ndx] = (char)(src[ndx]+32);
            }
            return retVal;
        }
    }
}
