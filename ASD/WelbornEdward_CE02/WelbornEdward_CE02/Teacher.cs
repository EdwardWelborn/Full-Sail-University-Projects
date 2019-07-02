using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE02
{
    class Teacher : Person
    {
        public string[] _knowledge = new string[] { };

        
        public Teacher(string name, string description, int age, string[] knowledge) : base(name, description, age)
        {
            _name = name;
            _description = description;
            _age = age;
            _knowledge = knowledge;
        }
        public static Teacher CreateTeacher()
        {
            // Create Teacher and add their knowledge
            string sTeacherName = String.Empty;
            string[] aTeacher = new string[0];
            string sTeacherDescription = String.Empty;
            int iTeacherAge = 0;
            sTeacherName = Validataion.GetName("Please Enter the Teacher's Name: ");
            sTeacherDescription = Validataion.GetDescription("Please Enter a Description for the Teacher: ");
            iTeacherAge = Validataion.GetInt("Please Enter the Teacher's Age: (numbers only) ");
            int iKnowledge = Validataion.GetInt("How Many Areas of Knowledge for this Teacher: ");
            // Add each teacher knowledge here:
            Array.Resize(ref aTeacher, aTeacher.Length + (iKnowledge));
            for (int i = 0; i < iKnowledge; i++)
            {
                aTeacher[i] = Validataion.GetDescription("Please Enter an Area of Knowledge: ");
            }
            Teacher sCreateTeacher = new Teacher(sTeacherName, sTeacherDescription, iTeacherAge, aTeacher);
            return sCreateTeacher;
        }
    }
}


