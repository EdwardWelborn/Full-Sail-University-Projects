using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE02
{
    class Student : Person
    {
        public int _grade = 0;
 
        public int Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
            }
        }
        // Commented out base attributes per feedback
        public  Student(string name, string description, int age, int grade) : base(name, description, age)
        {
           // _name = name;
           // _description = description;
           // _age = age;
            _grade = grade;
        }
        public static Student AddStudent()
        {
            // Add Student and the grade for the course
            int iGrade = 0;
            string sStudentName = String.Empty;
            string sStudentDescription = String.Empty;
            int iStudentAge = 0;
            sStudentName = Validataion.GetName("Please Enter the Student's Name: ");
            sStudentDescription = Validataion.GetDescription("Please Enter a Description for the Student: ");
            iStudentAge = Validataion.GetInt("Please Enter the Student's Age: (numbers only) ");
            iGrade = Validataion.GetIntRange(0, 100, "Please Enter the student's grade for this course: ");
            Student sCreateStudent = new Student(sStudentName, sStudentDescription, iStudentAge, iGrade);
            return sCreateStudent;
        }
        public static Student[] ChangeGrade(Course sCourse)
        {
            int i = 0;
            foreach (var element in sCourse._aStudents)
            {
                i++;
                Console.WriteLine($"[{i}]: {element.Name}           Grade: {element.Grade}");
            }
            int iStudent = Validataion.GetInt("Please Choose a student to change their grade: ");
            if ((iStudent < sCourse._aStudents.Length - 1) || (iStudent > sCourse._aStudents.Length - 1))
            {
                Console.WriteLine("No Student Chosen");
                Utility.PressAnyKey("pause");
            }
            else
            {
                int iNewGrade = Validataion.GetIntRange(0, 100, "Please Choose new Grade: ");
                sCourse._aStudents[iStudent - 1].Grade = iNewGrade;
            }
            return sCourse._aStudents;

        }
        public static Student[] NewStudent(Course sCourse)
        {

            // Add each Student Here
            // Still broken if adding over 1 new student
            int iCourseCount = 0;
            Student[] aStudent = new Student[] { };
            try
            {
                if (sCourse == null)
                {
                    Console.WriteLine("No Course Information, Please create a course");
                    Utility.PressAnyKey("Press any key to continue");
                }
                else
                {
                    iCourseCount = Validataion.GetInt("How Many Students are enrolled in this course: (numbers only) ");

                    // Add each Student Here
                    Array.Resize(ref aStudent, aStudent.Length + (iCourseCount));
                    for (int i = 0; i < iCourseCount; i++)
                    {
                        aStudent[i] = Student.AddStudent();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error adding students");
                Utility.PressAnyKey("Press any key to continue");
            }
            sCourse._iStudentCount = iCourseCount;
            return aStudent;
        }
    }
}

