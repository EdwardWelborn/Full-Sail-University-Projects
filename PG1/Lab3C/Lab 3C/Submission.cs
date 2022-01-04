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
         * This lab is NOT interactive - that means there should be no 
         * calls to the Console class (no Write/WriteLine/ReadLine/ReadKey)
         * */

        private string retort;
        private int hidden;

        public Submission()
        {
            retort = "Whoa, are you colorblind or something?";
            hidden = 38;
        }

        // Test 1 - write an overloaded constructor that will accept 
        // a string value (only a string) to intialize retort.  Do 
        // not accept an int and do not initialize hidden
        public Submission(string strValue)
        {

        }

        // Test 2 - Write a getter for retort (GetRetort)
        // Getters return the data type matching the field they are
        // 'getting' and do not accept parameters (for now)

        public void GetRetort(string strRetort)
        {

        }
        // Test 3 - Write a setter for retort (SetRetort)
        // Setters don't return anything and accept a parameter that
        // matches the member field they are 'setting'

        public void SetRetort(string strRetort)
        {

        }
        // Test 4 - Write a property for hidden named Hidden
        // The property must update/access the hidden member field


        // Test 5 - Write a method named YellAtMe that accepts
        // no parameters and returns the value of retort as 
        // all capital letters - Use the ToUpper method. ToUpper is
        // a member of the string class (so use the dot operator 
        // to access it from any string. The definition of ToUpper is:
        // public string ToUpper()


        // Test 6 - Complete the method so that it returns 
        // the input value multiplied by 4
        public static int Test6(int input)
        {
            return 0;
        }

        // Test 7 - Complete the method so that it returns
        // the square root of the input value as a float
        // Use Math.Sqrt and cast the returned value to float
        public static float Test7(float input)
        {
            return 0;
        }

        // Test 8 - Complete the method so that it returns
        // a random int based on the seed provided, The return
        // value must be between min (inclusive) and max 
        // (exclusive). To complete this Test, you need to
        // create a Random object, passing the seed provided
        // the Random's constructor

        public static int Test8(int min, int max, int seed)
        {
            return 0;
        }

        // Test 9 - Complete the method so that it returns 
        // the integer quotient when number1 is divided by 
        // number2

        public static int Test9(int number1, int number2)
        {
            return 0;
        }

        // Test 10 - Complete the method so that it return
        // the integer  remainder when number1 is divided 
        // by number2

        public static int Test10(int number1, int number2)
        {
            return 0;
        }
    }
}
