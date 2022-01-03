using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug_Exercise
{
    class Support
    {
        public const int MAX = 199;
        public const int MIN = 110;
        static int seed = new Random().Next();

        public static int GetSeed()
        {
            return seed;
        }

        public static string GetName(string name)
        {
            name = ReverseString(name);
            return name;
        }

        public static int GetAge(int age)
        {
            return age-100;
        }

        private static string ReverseString(string source)
        {
            string result = "";
            for(int ndx=source.Length-1;ndx>=0;ndx--)
            {
                result += source[ndx];
            }
            return result;
        }
    }
}
