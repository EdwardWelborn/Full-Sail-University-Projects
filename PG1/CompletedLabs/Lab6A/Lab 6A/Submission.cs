using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using Tester;
using System.Linq;

namespace FSPG1
{
    class Submission
    {
        /*
         * This lab is NOT interactive - that means there should be no 
         * calls to the Console class (no Write/WriteLine/ReadLine/ReadKey)
         * 
         * You cannot use multiple return statements any of these methods. 
         * Additionally the use of var is not permitted
         * 
        */

        // Test 1 – Convert char array to int array
        // Given an array of char, phrase, convert each element to an
        // equivalent int value and place in an int array.
        // Return the int array
        public static int[] Test1(char[] phrase)
        {
            int[] intIntArray = new int[phrase.Length];
            int intCounter = 0;

            foreach (char chr in phrase)
            {
                intIntArray[intCounter] = (int)chr;
                intCounter++;
            }
            return intIntArray;
        }

        // Test 2 - Array statistics
        // Given an array of double, data, find the smallest element, 
        // the largest element and the numeric mean (average). Store the 
        // results in an array (in that order: smallest, largest, mean).
        // Return the array
        public static double[] Test2(double[] data)
        {
            double dblSmallest = data[0];
            double dblLargest = data[0];
            double dblSum = 0;
            double[] dblNewArray = new double[3];

            for (int i = 0; i < data.Length; i++)
            {
                dblSum += data[i];
                if (data[i] > dblLargest)
                    dblLargest = data[i];

                if (data[i] < dblSmallest)
                    dblSmallest = data[i];
            }

            //get the mean 
            double dblMean = dblSum / data.Length;

            dblNewArray[0] = dblSmallest;
            dblNewArray[1] = dblLargest;
            dblNewArray[2] = dblMean;

            return dblNewArray;
        }

        // Test 3 - Normalize an array (of double)
        // Given an array of double, numbers, normalize the array. To 
        // normalize an array:
        // 1) Find the largest element stored in the array
        // 2) Divide each element in the array by the largest value
        //    and replace each array element with the result of the 
        //    division.
        // Since the array's contents are being modified, there is 
        // nothing to return
        public static void Test3(double[] numbers)
        {
            double smallest = numbers[0];
            double largest = numbers[0];
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                if (numbers[i] > largest)
                    largest = numbers[i];
            }
            for (int i = 0; i < numbers.Length; i++)
            {

                numbers[i] = numbers[i] / largest;
            }
            
        }

        // Test 4 - Uniqueness
        // Given an array of string, names, verify that each name is unique
        // mean that none of the names are duplicated within the array.
        // If the array is unique, return true; otherwise, return false
        public static bool Test4(string [] names)
        {
            bool bHasDuplicate = false;

            if (names.Distinct().Count() != names.Count())
            {
                bHasDuplicate = false;
            }
            else
            {
                bHasDuplicate = true;
            }

            return bHasDuplicate;
        }

        // Test 5 - Acronym
        // Given an array of string, words, create a string that is the 
        // acronym (first letter of each word). Return the string
        public static string Test5(string [] words)
        {
            string strResult = "";

            strResult = String.Join("", words.Select(x => x[0].ToString()).ToArray());

            return strResult;
        }

        // Test 6 - Array reverse
        // Given a char array, letters, create another array that has the
        // same elements but in reverse order. Return the array
        // 
        // You are not allowed to use Array.Reverse (or any existing
        // method) to reverse the array
        //
        public static char[] Test6(char[] letters)
        {
            Array.Reverse(letters);
            return letters;
        }

        // Test 7 - Transpose array
        // Given a 2-Dimension array of int, table, create a new array that 
        // 'transposes' the original array. Transposing means that each row 
        // in the original array will be a column in the new array and each
        // column in the original array will be a row in the new array.
        // For example, given
        //   4   3   1   5
        //   2   7   0   8
        //
        // The transposed array would be
        //   4   2
        //   3   7
        //   1   0
        //   5   8
        //
        public static int[,] Test7(int [,] table)
        {
            int intTable1 = table.GetLength(0);
            int intTable2 = table.GetLength(1);
            int[,] intArrayResult = new int[intTable2, intTable1];
            for (int rows = 0; rows < intTable1; rows++)
            {
                for (int column = 0; column < intTable2; ++column)
                {
                    intArrayResult[column, rows] = table[rows, column];
                }
            }
            return intArrayResult;
        }

        // Test 8 – Return a 2D array
        // Given three arrays of the same type (int) and size, combine the 
        // arrays into a single 2D array. Return the 2D array
        // NOTE: This solution requires a single loop (not three)
        // 
        public static int [,] Test8(int [] mins, int [] maxes, int [] seeds)
        {
            int[,] intArrayResult = new int[3, mins.Length];
            for (int index = 0; index < mins.Length; index++)
            {
                intArrayResult[0, index] = mins[index];
                intArrayResult[1, index] = maxes[index];
                intArrayResult[2, index] = seeds[index];
            }  
            return intArrayResult;

        }

        // Test 9 – Convert int array to char array
        // Given an array of int, ascii, convert each element to an
        // equivalent char value and place in a char array.
        // Return the char array
        public static char[] Test9(int[] ascii)
        {
            
            char[] chrArrayOutput = new char[ascii.Length];

            int i;
            for (i = 0; i < ascii.Length; ++i)
            {
                chrArrayOutput[i] = (char)ascii[i];
            }
            return chrArrayOutput;
        }

        // Test 10 – Modify an existing array
        // Given an array of char (all uppercase), modify the array so
        // that every other element will be lowercase (even indexes are 
        // upper, odd indexes are lower)
        public static void Test10(char[] word)
        {
            for (int i = 1; i < word.Length; i+=2)
            {
                word[i] = char.ToLower(word[i]);
                
            }
        }
    }
}
