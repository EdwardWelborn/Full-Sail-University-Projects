using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9A
{
    public class Student
    {
        // Add member fields here
        public string firstName;
        public string lastName;
        public int studentID;

        // Add default and overloaded constructors here
        public Student()
        {
            lastName = "";
            firstName = "";
            studentID = 1000000;
        }

        public Student(string last, string first, int id)
        {
            lastName = last;
            firstName = first;
            studentID = id;
        }

        // add Getters and Setters here

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetIDNumber()
        {
            return studentID;
        }

        public void SetFirstName(string first)
        {
            firstName = first;
        }

        public void SetLastName(string last)
        {
            lastName = last;
        }

        public void SetIDNumber(int id)
        {
            studentID = id;
        }

        /*****************************************************************************************************
        *                                                                                                     *
        *                                                                                                     *
        *                                                                                                     *
        *                                                                                                     *
        *                      do not modify any of the following code                                        *
        *                                                                                                     *
        *                                                                                                     *
        *                                                                                                     *
        *                                                                                                     *
        *                                                                                                     *
        ******************************************************************************************************/
        public override string ToString()
        {
            return "ID #: " + GetIDNumber() + "\tName: " + GetLastName() + ", " + GetFirstName();
        }

        public override bool Equals(object obj)
        {
            bool same = true;
            Student s2 = (Student)obj;
            if (this.GetLastName() != s2.GetLastName() || this.GetFirstName() != s2.GetFirstName() || this.GetIDNumber() != s2.GetIDNumber())
            {
                same = false;
            }
            return same;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
