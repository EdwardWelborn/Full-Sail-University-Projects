﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Student currentStudent = null;

            bool running = true;
            string input = "";
            int age = 0;

            while(running)
            {
                // display menu
                Console.Clear();
                Console.WriteLine("Main menu: ");
                Console.WriteLine("1. Create a student");
                Console.WriteLine("2. Add a course to the current student");
                Console.WriteLine("3. Remove a course from the current student");
                Console.WriteLine("4. Add grades for a course");
                Console.WriteLine("5. Display student info");
                Console.WriteLine("6. Display grades for a course");
                Console.WriteLine("7. Display all grades");
                Console.WriteLine("8. Exit");
                Console.Write("Enter a selection: (1 - 8): ");
                input = Console.ReadLine().ToLower();

                Console.WriteLine();
                // handle choices
                switch(input)
                {
                    case "1":
                    case "create a student":
                        {
                            Console.Write("What is the students first name? ");
                            string firstName = Console.ReadLine();

                            Console.Write("What is the students last name? ");
                            string lastName = Console.ReadLine();
                            currentStudent = new Student(firstName, lastName);

                            Console.Write("How old is the student? ");
                            input = Console.ReadLine();
                            while(!int.TryParse(input, out age))
                            {
                                Console.Write("Please enter a number: ");
                                input = Console.ReadLine();
                            }

                            currentStudent.Age = age;

                            Console.Write("What is the students address? ");
                            currentStudent.Address = Console.ReadLine();

                            Console.Write("What is the students email? ");
                            currentStudent.Email = Console.ReadLine();

                            Console.Write("What is the students phone number? ");
                            currentStudent.Phone = Console.ReadLine();
                        }
                        break;
                    case "2":
                    case "add a course to the current student":
                        {
                            if(currentStudent != null)
                            {
                                currentStudent.AddACourse();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "3":
                    case "remove a course from the current student":
                        {
                            if (currentStudent != null)
                            {
                                currentStudent.RemoveACourse();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "4":
                    case "add grades for a course":
                        {
                            if (currentStudent != null)
                            {
                                currentStudent.AddGradesForACourse();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "5":
                    case "display student info":
                        {
                            if (currentStudent != null)
                            {
                                currentStudent.DisplayInfo();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "6":
                    case "display grades for a course":
                        {
                            if (currentStudent != null)
                            {
                                currentStudent.DisplayGradesForACourse();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "7":
                    case "display all grades":
                        {
                            if (currentStudent != null)
                            {
                                currentStudent.DisplayAllGrades();
                            }
                            else
                            {
                                Console.WriteLine("Please create a student first.");
                            }
                        }
                        break;
                    case "8":
                    case "exit":
                        {
                            running = false;
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press a key to continue.");
                Console.ReadKey();
            }
        }
    }
}

