using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    class Student
    {
        static int _nextStudentIDNum = 1000;

        string _firstName;
        string _lastName;
        string _email;
        string _address;
        string _phoneNumber;
        int _age;
        int _studentIdNum;
        List<Course> _courses;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _studentIdNum = ++_nextStudentIDNum;
            _courses = new List<Course>();
        }

        public string Name
        {
            get
            {
                return $"{_lastName}, {_firstName}";
            }

        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Phone
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public int StudentNumber
        {
            get
            {
                return _studentIdNum;
            }
            set
            {
                _studentIdNum = value;
            }
        }
        public List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        private int SelectCourse(string message)
        {
            int len = _courses.Count;
            int index = -1;

            if (len > 0)
            {
                for (index = 0; index < len; ++index)
                {
                    Console.WriteLine($"{index + 1}. {_courses[index].Title}");
                }
                Console.Write(message);
                string selection = Console.ReadLine();

                while (!int.TryParse(selection, out index) || (index < 1 || index > len))
                {
                    Console.Write("Please make a valid selection: ");
                    selection = Console.ReadLine();
                }

                --index;
            }

            return index;
        }

        public void AddACourse()
        {
            string input;

            Console.Write("How many assignments are in the course? ");
            input = Console.ReadLine();
            int numAssignments = 0;

            while (!int.TryParse(input, out numAssignments))
            {
                Console.Write("Please enter a number: ");
                input = Console.ReadLine();
            }

            Course course = new Course(numAssignments);

            Console.Write("What is the courses title? ");
            course.Title = Console.ReadLine();

            Console.Write("What is the courses description? ");
            course.Description = Console.ReadLine();

            _courses.Add(course);
        }

        public void RemoveACourse()
        {
            int index = SelectCourse("Select a course to remove. (Enter the number): ");

            if (index == -1)
            {
                Console.WriteLine("No courses to remove.  Try adding one first.");
            }
            else
            {
                _courses.RemoveAt(index);
            }
        }

        public void AddGradesForACourse()
        {
            int index = SelectCourse("Select a course to add grades for. (Enter the number): ");

            if (index == -1)
            {
                Console.WriteLine("No course to add grades to.  Try adding one first.");
            }
            else
            {
                _courses[index].AddGrades();
            }
        }

        public void DisplayGradesForACourse()
        {
            int index = SelectCourse("Select a course to display grades for. (Enter the number): ");

            if (index == -1)
            {
                Console.WriteLine("No course to display grades for.  Try adding one first.");
            }
            else
            {
                _courses[index].DisplayGrades();
            }
        }

        public void DisplayAllGrades()
        {
            foreach (Course c in _courses)
            {
                c.DisplayGrades();
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nAge: {Age}\nAddress: {Address}\nPhone: {Phone}\nEmail: {Email}");
        }
    }
}

