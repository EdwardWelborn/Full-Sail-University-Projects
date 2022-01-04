using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSPG1
{
    class Submission
    {
        /*
         * 
         * For this lab you are required to use the Parse() method 
         * for each conversion. No credit will be given for calls
         * using the Convert class (i.e. Convert.ToInt32)
         * 
        */

        // Given a string, using the Int32 class, convert the string 
        // to an integer. Return the integer
        public static int Test3(string input)
        {
            int intNumber;
            intNumber = int.Parse(input);
            return intNumber;
        }

        // Given a string, using the SByte class, convert the string 
        // to a signed byte. Return the signed byte
        public static sbyte Test4(string input)
        {
            sbyte sByteNumber;
            sByteNumber = sbyte.Parse(input);
            return sByteNumber;
        }

        // Given a string, using the Double class, convert the string 
        // to a double Return the double
        public static double Test5(string input)
        {
            double dblNumber;
            dblNumber = double.Parse(input);
            return dblNumber;
        }

        // Given a string, using the UInt16 class, convert the string
        // to a unsigned short. Return the unsigned short
        public static ushort Test6(string input)
        {
            ushort uShortNumber;
            uShortNumber = ushort.Parse(input);
            return uShortNumber;
        }

        // Given a string, using the Single class, convert the string 
        // to a float. Return the float
        public static float Test7(string input)
        {
            float floatNumber;
            floatNumber = float.Parse(input);
            return floatNumber;
        }

        // Given a string, using the UInt32 class, convert the string 
        // to an unsigned integer. Return the unsigned integer
        public static uint Test8(string input)
        {
            uint uintNumber;
            uintNumber = uint.Parse(input);
            return uintNumber;
        }

        // Given a string, using the Int16 class, convert the string 
        // to a short. Return the short
        public static short Test9(string input)
        {
            short shortNumber;
            shortNumber = short.Parse(input);
            return shortNumber;
        }

        // Given a string, using the UInt64 class, convert the string 
        // to an unsigned long. Return the unsigned long
        public static ulong Test10(string input)
        {
            ulong uLongNumber;
            uLongNumber = ulong.Parse(input);
            return uLongNumber;
        }
    }
}
