using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercisesProject.Exercises
{
    // 0124 - Calculate Age of Person in Days
    class CalcPersonAgeInDays_Demo
    {
        //static void Main(string[] args)
        public static void Run ()
        {
            Console.WriteLine("0124 - CalcPersonAgeInDays_Demo");
            Console.WriteLine();

            DateTime birthday = new DateTime(1980, 11, 29);

            Console.WriteLine("BirthDay: {0:yyy-MM-dd}", birthday.Date);

            TimeSpan diff = DateTime.Now.Date - birthday.Date;
            Console.WriteLine("Age in days: {0}", diff.TotalDays );


            Console.ReadKey();
        }
    }
}
