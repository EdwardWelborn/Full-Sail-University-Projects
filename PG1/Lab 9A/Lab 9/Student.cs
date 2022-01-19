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


        // Add default and overloaded constructors here


        // add Getters and Setters here

























/******************************************************************************************************
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
