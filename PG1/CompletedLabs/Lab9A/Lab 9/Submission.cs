using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9A
{
    public class Submission
    {
        public static Student[] enrollment = new Student[0];

        public static Student Test1(string last, string first, int idNo)
        {
            Student newStudent = new Student(last, first, idNo);
            return newStudent;
        }

        public static Student Test2()
        {
            Student newStudent = new Student();
            return newStudent;
        }

        public static bool Test3(Student enrolled)
        {
            bool isStudent = false;
            for (int i = 0; i < enrollment.Length; i++)
            {
                if (enrollment[i] == null)
                {
                    enrollment[i] = enrolled;
                    isStudent = true;
                    break;
                }
            }
            return isStudent;
        }

        public static bool Test4(int idNumber)
        {
            bool isStudent = false;

            for (int i = 0; i < enrollment.Length; i++)
            {
                if (enrollment[i] != null)
                {
                    if (enrollment[i].GetIDNumber() == idNumber)
                    {
                        enrollment[i].SetIDNumber(0);
                        isStudent = true;
                        break;
                    }
                }
            }

            return isStudent;
        }

        public static Student Test5(int idNumber)
        {
            Student studentFound = null;
            for (int i = 0; i < enrollment.Length; i++)
            {
                if (enrollment[i] != null)
                {
                    if (enrollment[i].GetIDNumber() == idNumber)
                    {
                        studentFound = enrollment[i];
                        break;
                    }
                }
            }

            return studentFound;
        }
    }
}
