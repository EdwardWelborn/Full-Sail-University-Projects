using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_9A
{
    public class Tester
    {
        private static int idNum = 1000000;
        private static string[] fNames = new string[15];
        private static string[] lNames = new string[15];
        private static int[] idNos = new int[15];
        private static int ndx = 0;


        public static void Run()
        {
            int total = 0;
            int testTotal = 0;
            int currentTest = 0;
            GenerateNames();
            if(!Unique(lNames))
            {
                Console.WriteLine("Duplicate names occur in last name array...");
                Console.ReadKey();
            }
            if (!Unique(fNames))
            {
                Console.WriteLine("Duplicate names occur in first name array...");
                Console.ReadKey();
            }

            Random rng = new Random();
            PopulateIDs(rng);
            Student r = null;

            int passNumber = 1;
            string last = null;
            string first = null;
            int id = 0;
            string output = "";


            Console.Clear();
            Console.WriteLine("\n\tTest #1\n");
            for (int cntr = 0; cntr < 5; cntr++)
            {
                last = lNames[rng.Next(30)];
                first = fNames[rng.Next(30)];
                id = idNos[ndx++];

                r = Submission.Test1(last, first, id);
                try
                {
                    if (r != null && r.GetType() == typeof(Student))
                    {
                        if (r.GetLastName() != last || r.GetFirstName() != first || r.GetIDNumber() != id)
                        {
                            currentTest = 0;
                            output = "Failed: Parameter error";
                        }
                        else
                        {
                            currentTest = 4;
                            output = "Passed: " + r;
                        }
                    }
                    else
                    {
                        currentTest = 0;
                        output = "Failed: Invalid type returned";
                    }
                }
                catch
                {
                    currentTest = 0;
                    output = "Failed: Invalid type returned";
                }
                Console.WriteLine("Pass " + passNumber++ + ": [" + currentTest + "] " + output);
                testTotal += currentTest;
                currentTest = 0;
            }
            Console.WriteLine("Test 1 score: " + testTotal);
            total += testTotal;
            testTotal = 0;

            ndx = lNames.Length-1;
            Console.WriteLine();
            passNumber = 1;

            Console.WriteLine("\n\tTest #2\n");
            for (int cntr = 0; cntr < 5; cntr++)
            {

                r = Submission.Test2();
                try
                {
                    if(r!=null && (r.GetLastName() == "" && r.GetFirstName() == "" && r.GetIDNumber() == 1000000))
                    {
                        currentTest = 4;
                    }
                    else
                    {
                        output = "Failed: Default constructor problem detected";
                        currentTest = 0;
                    }
                    if (r != null && r.GetType() == typeof(Student))
                    {
                        last = lNames[rng.Next(lNames.Length)];
                        first = fNames[rng.Next(fNames.Length)];
                        id = idNos[ndx--];

                        r.SetLastName(last);
                        r.SetFirstName(first);
                        r.SetIDNumber(id);

                        if (currentTest == 4)
                        {
                            if (r.GetLastName() != last || r.GetFirstName() != first || r.GetIDNumber() != id)
                            {
                                currentTest = 0;
                                output = "Failed: Getter/setter problem detected";
                            }
                            else
                            {
                                currentTest = 4;
                                output = "Passed: " + r;
                            }
                        }
                    }
                }
                catch
                {
                    currentTest = 0;
                    output = "Failed: Invalid type returned";
                }
                Console.WriteLine("Pass " + passNumber++ + ": [" + currentTest + "] " + output);
                testTotal += currentTest;
                currentTest = 0;
            }
            Console.WriteLine("Test 2 score: " + testTotal);
            total += testTotal;
            testTotal = 0;

            Console.WriteLine();
            passNumber = 1;
            Console.WriteLine("\n\tTest #3\n");
            for (int cntr = 0;cntr < 5; cntr++)
            {
                Student[] kids = GenerateRandomArray(rng);
                Student[] sdik = Mod3(kids);
                last = lNames[rng.Next(lNames.Length)];
                first = fNames[rng.Next(fNames.Length)];
                id = idNos[lNames.Length - cntr - 1];
                Student s = new Student(last, first, id);
                Submission.enrollment = kids;
                bool completed = Submission.Test3(s);
                bool worked = false;
                Mod1(s, sdik);
                try
                {
                    worked = CompareArray(sdik, kids);
                }
                catch
                {
                    worked = false;
                }
                if (worked)
                {
                    currentTest = 4;
                    if (completed)
                    {
                        output = "Passed: Added:\t\t" + s;
                    }
                    else
                    {
                        output = "Passed: Could not add\t" + s;
                    }
                }
                else
                {
                    output = "Failed: Error in Test3";
                    currentTest = 0;
                }
                Console.WriteLine("Pass " + passNumber++ + ": [" + currentTest + "] " + output);
                testTotal += currentTest;
                currentTest = 0;
            }
            Console.WriteLine("Test 3 score: " + testTotal);
            total += testTotal;
            testTotal = 0;

            Console.WriteLine();
            passNumber = 1;
            Console.WriteLine("\n\tTest #4\n");
            for (int cntr = 0; cntr < 5; cntr++)
            {
                Student[] kids = GenerateRandomArray(rng);

                int inThere = rng.Next() % 7;
                
                int idNo = 0;
                int startHere = rng.Next(0, kids.Length);
                if(inThere!=0)
                {
                    for(int count=startHere;count<kids.Length;count++)
                    {
                        if (kids[count] != null)
                        {
                            idNo = kids[count].GetIDNumber();
                            if(inThere == 3 && count < kids.Length-2)
                            {
                                kids[count + 2] = kids[count];
                            }
                            break;
                        }
                    }
                }
                Student[] sdik = Mod3(kids);
                Submission.enrollment = kids;
                bool result = Submission.Test4(idNo);

                Mod2(idNo, sdik);
                bool worked = false; 
                try
                {
                    worked = CompareArray(sdik, kids);
                }
                catch
                {
                    worked = false;
                }
                if (worked)
                {
                    currentTest = 4;
                    if (result)
                    {
                        output = "Passed: Student ID # " + idNo + " removed...";
                    }
                    else
                    {
                        output = "Passed: Could not remove, Student ID not found...";
                    }
                }
                else
                {
                    output = "Failed, Error in Test4";
                    currentTest = 0;
                }
                Console.WriteLine("Pass " + passNumber++ + ": [" + currentTest + "] " + output);
                testTotal += currentTest;
                currentTest = 0;
            }
            Console.WriteLine("Test 4 score: " + testTotal);
            total += testTotal;
            testTotal = 0;

            Console.WriteLine();
            passNumber = 1;
            Console.WriteLine("\n\tTest #5\n");
            for (int cntr = 0; cntr < 5; cntr++)
            {
                Student[] kids = GenerateRandomArray(rng);

                int inThere = rng.Next() % 7;
                int idNo = 0;
                int startHere = rng.Next(0, kids.Length);


                if (inThere != 0)
                {
                    for (int count = startHere; count < kids.Length; count++)
                    {
                        if (kids[count] != null)
                        {
                            idNo = kids[count].GetIDNumber();
                            if (inThere == 3 && count < kids.Length - 2)
                            {
                                kids[count + 2] = new Student(kids[count].GetLastName(), 
                                                              kids[count].GetFirstName(), 
                                                              kids[count].GetIDNumber());

                                kids[count + 2].SetLastName("Smith");
                            }
                            break;
                        }
                    }
                }
                Student[] sdik = Mod3(kids);
                Student s = null;
                Student expected = null;
                bool worked = true;
                try
                {
                    Submission.enrollment = kids;
                    s = Submission.Test5(idNo);
                    expected = Mod4(idNo, sdik);
                }
                catch
                {
                    worked = false;
                }
                if (worked)
                {
                    if (s != null && expected != null)
                    {
                        
                        if (s.Equals(expected))
                        {
                            currentTest = 4;
                            output = "Passed: Found Student: " + s;
                        }
                        else
                        {
                            currentTest = 0;
                            output = "Failed: Incorrect Student return...";
                        }
                    }
                    else if (s == null && expected == null)
                    {
                        currentTest = 4;
                        output = "Passed: Student not found...";
                    }
                    else
                    {
                        currentTest = 0;
                        output = "Failed: Error in Test5";
                    }
                }
                else
                {
                    output = "Failed: Error in Test5";
                    currentTest = 0;
                }
                Console.WriteLine("Pass " + passNumber++ + ": [" + currentTest + "] " + output);
                testTotal += currentTest;
                currentTest = 0;
            }
            Console.WriteLine("Test 5 score: " + testTotal);
            total += testTotal;
            testTotal = 0;

            Console.WriteLine("\n\nTotal: " + total + "\n");
        }
        private static void PopulateIDs(Random rng)
        {
            idNos = new int[fNames.Length];
            int lastNumber = 0;
            int cntr = 0;
            for (cntr = 0; cntr < idNos.Length; cntr++)
            {
                lastNumber = rng.Next(lastNumber, lastNumber + 500);
                idNos[cntr] = idNum + lastNumber;
            }
        }
        static void GenerateNames()
        {
            int ndx = 0;
            int counter = 80;
            lNames = new string[counter];
            fNames = new string[counter];

            lNames[ndx++] = "Hanover";
            lNames[ndx++] = "Gomez";
            lNames[ndx++] = "Swayze";
            lNames[ndx++] = "Chan";
            lNames[ndx++] = "McDeevers";
            lNames[ndx++] = "Johnson";
            lNames[ndx++] = "St. Pierre";
            lNames[ndx++] = "Rodriquez";
            lNames[ndx++] = "Moskovitz";

            lNames[ndx++] = "Stalin";
            lNames[ndx++] = "Jones";
            lNames[ndx++] = "Smythe";
            lNames[ndx++] = "Bell";
            lNames[ndx++] = "Fisher";
            lNames[ndx++] = "Nettles";
            lNames[ndx++] = "Allen";
            lNames[ndx++] = "Harrison";
            lNames[ndx++] = "Roberts";
            lNames[ndx++] = "Neilsen";
            lNames[ndx++] = "Starkey";

            lNames[ndx++] = "Stanley";
            lNames[ndx++] = "Marshall";
            lNames[ndx++] = "Butt";
            lNames[ndx++] = "Penney";
            lNames[ndx++] = "Cox";
            lNames[ndx++] = "Bauer";
            lNames[ndx++] = "Martinez";
            lNames[ndx++] = "McCartney";
            lNames[ndx++] = "Frazier";
            lNames[ndx++] = "Lennon";     // ndx = 29

            lNames[ndx++] = "Fernandez";
            lNames[ndx++] = "Stairs";
            lNames[ndx++] = "Fuentes";
            lNames[ndx++] = "Fountain";
            lNames[ndx++] = "Einstein";
            lNames[ndx++] = "Picasso";
            lNames[ndx++] = "Pizarro";
            lNames[ndx++] = "Anderson";
            lNames[ndx++] = "Bachman";
            lNames[ndx++] = "Chandler";    // ndx = 39

            lNames[ndx++] = "Fleetwood";
            lNames[ndx++] = "Jeffries";
            lNames[ndx++] = "Bridger";
            lNames[ndx++] = "Buckman";
            lNames[ndx++] = "Deviers";
            lNames[ndx++] = "Gorbachev";
            lNames[ndx++] = "Gonzales";
            lNames[ndx++] = "Merriweather";
            lNames[ndx++] = "Reagan";
            lNames[ndx++] = "Noone";     // ndx = 49

            lNames[ndx++] = "Zavalos";
            lNames[ndx++] = "Young";
            lNames[ndx++] = "Waltham";
            lNames[ndx++] = "Villanueva";
            lNames[ndx++] = "Umbrage";
            lNames[ndx++] = "Thorsen";
            lNames[ndx++] = "Singleton";
            lNames[ndx++] = "Roland";
            lNames[ndx++] = "Quincy";
            lNames[ndx++] = "Pedersen";     // ndx = 59

            lNames[ndx++] = "Ottoman";
            lNames[ndx++] = "Negev";
            lNames[ndx++] = "Mannheim";
            lNames[ndx++] = "LeMay";
            lNames[ndx++] = "Kittridge";
            lNames[ndx++] = "Jorgensen";
            lNames[ndx++] = "Islington";
            lNames[ndx++] = "Handel";
            lNames[ndx++] = "Graham";
            lNames[ndx++] = "Flanders";     // ndx = 69

            lNames[ndx++] = "Ewing";
            lNames[ndx++] = "Dunn";
            lNames[ndx++] = "Cheney";
            lNames[ndx++] = "Bryant";
            lNames[ndx++] = "Abercrombie";
            lNames[ndx++] = "Abernathey";
            lNames[ndx++] = "Barbera";
            lNames[ndx++] = "Cardoza";
            lNames[ndx++] = "DeSilva";
            lNames[ndx++] = "Endriss";     // ndx = 79

            ndx = 0;
            fNames[ndx++] = "Allison";
            fNames[ndx++] = "Bradley";
            fNames[ndx++] = "Cheryl";
            fNames[ndx++] = "Daniel";
            fNames[ndx++] = "Esther";
            fNames[ndx++] = "Fernando";
            fNames[ndx++] = "Gloria";
            fNames[ndx++] = "Harvey";
            fNames[ndx++] = "Irene";
            fNames[ndx++] = "Jeremy";           // ndx = 9

            fNames[ndx++] = "Kaitlyn";
            fNames[ndx++] = "Lawrence";
            fNames[ndx++] = "Marsha";
            fNames[ndx++] = "Nicolai";
            fNames[ndx++] = "Olivia";
            fNames[ndx++] = "Percy";
            fNames[ndx++] = "Quinton";
            fNames[ndx++] = "Roseanne";
            fNames[ndx++] = "Suzanna";
            fNames[ndx++] = "Trevor";          // ndx = 19

            fNames[ndx++] = "Ulysses";
            fNames[ndx++] = "Velma";
            fNames[ndx++] = "Wanda";
            fNames[ndx++] = "Xavier";
            fNames[ndx++] = "Yahpet";
            fNames[ndx++] = "Zondra";
            fNames[ndx++] = "John";
            fNames[ndx++] = "Paul";
            fNames[ndx++] = "George";
            fNames[ndx++] = "Richard";         // ndx = 29

            fNames[ndx++] = "Petunia";
            fNames[ndx++] = "Tiffany";
            fNames[ndx++] = "Stacy";
            fNames[ndx++] = "Loretta";
            fNames[ndx++] = "Kathy";
            fNames[ndx++] = "Paula";
            fNames[ndx++] = "Diane";
            fNames[ndx++] = "Brady";
            fNames[ndx++] = "Gertrude";
            fNames[ndx++] = "Johan";           // ndx = 39

            fNames[ndx++] = "Arnold";
            fNames[ndx++] = "Bethany";
            fNames[ndx++] = "Cleavon";
            fNames[ndx++] = "Delores";
            fNames[ndx++] = "Eduardo";
            fNames[ndx++] = "Freda";
            fNames[ndx++] = "Geoff";
            fNames[ndx++] = "Henrietta";
            fNames[ndx++] = "Isolde";
            fNames[ndx++] = "Jake";           // ndx = 49

            fNames[ndx++] = "Keyshawn";
            fNames[ndx++] = "Lana";
            fNames[ndx++] = "Marion";
            fNames[ndx++] = "Nanette";
            fNames[ndx++] = "Oscar";
            fNames[ndx++] = "Priscilla";
            fNames[ndx++] = "Ronald";
            fNames[ndx++] = "Sarah";
            fNames[ndx++] = "Thomas";
            fNames[ndx++] = "Ursula";           // ndx = 59

            fNames[ndx++] = "Vinnie";
            fNames[ndx++] = "Wilma";
            fNames[ndx++] = "Xander";
            fNames[ndx++] = "Yvette";
            fNames[ndx++] = "Zachariah";
            fNames[ndx++] = "Amelia";
            fNames[ndx++] = "Butch";
            fNames[ndx++] = "Cora";
            fNames[ndx++] = "Drew";
            fNames[ndx++] = "Elisha";           // ndx = 69

            fNames[ndx++] = "Francisco";
            fNames[ndx++] = "Gwendolyn";
            fNames[ndx++] = "Henri";
            fNames[ndx++] = "Iona";
            fNames[ndx++] = "Jericho";
            fNames[ndx++] = "Katrina";
            fNames[ndx++] = "Linus";
            fNames[ndx++] = "Malia";
            fNames[ndx++] = "Nicodemus";
            fNames[ndx++] = "Olwen";           // ndx = 79

        }

        private static Student [] GenerateRandomArray(Random rng)
        {
            Student[] students = new Student[rng.Next(5, 16)];
            for(int cntr=0;cntr<students.Length;cntr++)
            {
                int nullOrNot = rng.Next() % 7;
                if(nullOrNot==0)
                {
                    students[cntr] = null;
                }
                else
                {
                    students[cntr] = new Student(lNames[rng.Next(30)], fNames[rng.Next(30)], idNos[cntr]);
                }
            }
            return students;
        }

        private static Student[] GenerateRandomArray(Random rng,bool duplicates)
        {
            Student[] students = new Student[rng.Next(5, 16)];
            for (int cntr = 0; cntr < students.Length; cntr++)
            {
                int nullOrNot = rng.Next() % 7;
                if (nullOrNot == 0)
                {
                    students[cntr] = null;
                }
                else
                {
                    students[cntr] = new Student(lNames[rng.Next(30)], fNames[rng.Next(30)], idNos[cntr]);
                    if(ndx < students.Length-1) // not to last element
                    {
                        int doIt = rng.Next(0, 4);
                        if(doIt == 3)
                        {
                            students[cntr + 1] = students[cntr];
                            cntr++;
                        }

                    }
                }
            }
            return students;
        }

        private static bool CompareArray(Student[] expected, Student[] result)
        {
            bool success = true;
            if (expected.Length != result.Length)
            {
                success = false;
            }
            else
            {
                for (int ndx = 0; ndx < expected.Length; ndx++)
                {
                    if (expected[ndx] != null && result[ndx] != null)
                    {
                        if (!expected[ndx].Equals(result[ndx]))
                        {
                            success = false;
                            break;
                        }
                    }
                    else if((expected[ndx]==null && result[ndx]!=null) || (expected[ndx] != null && result[ndx] == null))
                    {
                        success = false;
                        break;
                    }
                }
            }
            return success;
        }

        private static void Mod1(Student s, Student [] body)
        {
            for(int ndx=0;ndx<body.Length;ndx++)
            {
                if(body[ndx]==null)
                {
                    body[ndx] = s;
                    break;
                }
            }
        }

        private static void Mod2(int i, Student[] body)
        {
            for (int ndx = 0; ndx < body.Length; ndx++)
            {
                if (body[ndx] != null && body[ndx].GetIDNumber()==i)
                {
                    body[ndx] = null;
                    break;
                }
            }
        }

        private static bool Unique(string [] names)
        {
            bool isUnique = true;

            for(int outer = 0; outer < names.Length-1 && isUnique;outer++)
            {
                for(int inner = outer+1;inner < names.Length;inner++)
                {
                    if(names[outer] == names[inner])
                    {
                        Console.WriteLine(names[outer]);
                        isUnique = false;
                        break;
                    }
                }
            }
            return isUnique;
        }

        private static Student [] Mod3(Student [] body)
        {
            Student[] dupe = new Student[body.Length];
            for(int ndx=0;ndx<body.Length;ndx++)
            {
                dupe[ndx] = body[ndx];
            }
            return dupe;
        }

        private static Student Mod4(int id,Student [] names)
        {
            Student s = null;

            for(int ndx=0;ndx < names.Length;ndx++)
            {
                if(names[ndx] != null && names[ndx].GetIDNumber() == id)
                {
                    s = names[ndx];
                    break;
                }
            }
            return s;
        }
    }
}
