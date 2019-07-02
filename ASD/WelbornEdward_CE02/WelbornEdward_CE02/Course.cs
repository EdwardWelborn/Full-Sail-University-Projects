using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE02
{

    class Course
    {
        private string _sTitle = null;
        private string _sDescription = null;
        public int _iStudentCount = 0;
        public Teacher _teacher;
        public Student[] _aStudents = new Student[] { };

        public string Title
        {

            get
            {
                return _sTitle;
            }
            set
            {
                _sTitle = value;
            }
        }
        
        public string Description
        {
            get
            {
                return _sDescription;
            }
            set
            {
                _sDescription = value;
            }
        }
        public Course(string title, string description, Teacher Teacher, int iStudentCount, Student[] aStudents)
        {
            _sTitle = title;
            _sDescription = description;
            _iStudentCount = iStudentCount;
            _teacher = Teacher;
            _aStudents = aStudents;
        }

        public static void DisplayInfo(Course sCourse)
        {
            // Display Course, Teacher, and each student with grade

            try
            {
                if (sCourse == null)
                {
                    Console.WriteLine("\r\nCourse Information");
                    Console.WriteLine($"\r\nCourse Title:            None");
                    Console.WriteLine($"Course Description:      None");
                }
                else
                {
                    Console.WriteLine("\r\nCourse Information");
                    Console.WriteLine($"\r\nCourse Title:            {sCourse.Title}");
                    Console.WriteLine($"Course Description:      {sCourse.Description}");
                }
            }
            catch
            {
                Console.WriteLine("\r\nCourse Information");
                Console.WriteLine($"\r\nCourse Title:            {sCourse.Title}");
                Console.WriteLine($"Course Description:      {sCourse.Description}");
            }
            try
            {
                if (!string.IsNullOrEmpty(sCourse._teacher.ToString()))
                {
                    Console.WriteLine($"Teacher Name:            {sCourse._teacher.Name}");
                    foreach (object element in sCourse._teacher._knowledge)
                    {
                        Console.WriteLine($"Teacher Knowledge:         {element.ToString()}");
                    }
                }
                else
                {
                    Console.WriteLine($"Teacher Name:            None Selected");
                }
            }
            catch
            {
                Console.WriteLine($"Teacher Name:            None Selected");
            }
            try
            {
                if (sCourse._iStudentCount >= 0)
                {
                    Console.WriteLine($"Enrolled Students Count: {sCourse._iStudentCount}");
                    foreach (var element in sCourse._aStudents)
                    {
                        Console.WriteLine($"Enrolled Student's Name: {element.Name} \tGrade: {element.Grade}");
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Enrolled Students Count: 0");
            }
            Utility.PressAnyKey("Press any key to Continue");

        }
        public override string ToString()
        {
            string sCourseString = null;
            sCourseString = $"{this._sTitle}  {this._sDescription} {this._iStudentCount} {this._teacher}";
        
         
            return sCourseString;
        }
    }
}

