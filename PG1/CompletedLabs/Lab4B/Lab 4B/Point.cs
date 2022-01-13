using System;

namespace FS_Supplemental
{
    class Point
    {
        //TODO: You are to add  2 integer member fields (xPos and yPos) to the  Point class (this class).
        //      The fields should not be accessible outside the current object.
        private double xPos;
        private double yPos;

        //      Write 2 constructors for Point; A default (no arguments) that will set both member 
        //      fields to 0; and an overload constructor that accepts 2 integer parameters and will 
        //      set the member fields to the values received as parameters. 
        public Point()
        {
            xPos = 0;
            yPos = 0;
        }

        public Point(double x, double y)
        {
            xPos = x;
            yPos = y;
        }

        //      Provide accessor and mutator (getter and setter) methods for each member field.
        public double GetXPos()
        {
            return xPos;
        }

        public double GetYPos()
        {
            return yPos;
        }

        public void SetXPos(double x)
        {
            xPos = x;
        }

        public void SetYPos(double y)
        {
            yPos = y;
        }

        //      Write a method to determine how far apart two Point objects are.
        public double DistanceApart(Point p2)
        {
            return Math.Sqrt(Math.Pow(xPos - p2.GetXPos(), 2) + Math.Pow(yPos - p2.GetYPos(), 2));
        }

        //      Override the default Equals, ToString and GetHashCode methods. Use the default GetHashCode 
        //      method that VS provides. 
        public override bool Equals(object obj)
        {
            Point p2 = (Point)obj;
            bool sameAs = true;
            if(xPos != p2.GetXPos() || yPos != p2.GetYPos())
            {
                sameAs = false;
            }
            return sameAs;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "(" + Math.Round(xPos,3) + "," + Math.Round(yPos,3)+ ")";
        }
    }
}
