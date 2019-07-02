using System;
using System.Collections.Generic;

namespace LectureProject
{
    class Character
    {
        //primitive type member variables
        private int health;
        private int baseAttack;
        private string name;
        double accuracy;

        //default constructor
        public Character()
        {
            name = "Default";
            health = Program.rand.Next(75, 125);
            baseAttack = Program.rand.Next(1, 10);
            accuracy = Program.rand.Next(70, 99) + Program.rand.NextDouble();
        }

        //constructor to create a Character from a loaded string
        public Character(string str) : this()
        {
        }

        //access baseAttack
        public int BaseAttack
        {
            get { return baseAttack; }
            set {  baseAttack = value; }
        }

        //access health
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        //access name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //access accuracy
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("Name: " + Name + "\n");
            retVal += ("Health: " + Health + "\n");
            retVal += ("Base Attack: " + BaseAttack + "\n");
            retVal += ("Accuracy: " + Accuracy + "\n");

            return retVal;
        }

        //string to save this object out
        public string GetStringToSave()
        {
            string retVal = "";

            return retVal;
        }
    }
}
