using System;

namespace FSPG1
{
    public class Circle
    {
        private float horizontal;
        private float verticle;
        private float mRadius;

        public Circle(float x, float y, float radius)
        {
            horizontal = x;
            verticle = y;
            mRadius = radius;
        }

        public float GetX()
        {
            return horizontal;
        }

        public float GetY()
        {
            return verticle;
        }

        public float GetRadius()
        {
            return mRadius;
        }

        public float GetArea()
        {
            return (float)((float)Math.PI * Math.Pow(mRadius, 2));
        }

        public bool Contains(float px, float py)
        {
            bool Contain = false;
            if ((Math.Pow(px - horizontal, 2)) + (Math.Pow(py - verticle, 2)) <= (Math.Pow(mRadius, 2)))
            {
                Contain = true;
            }
            return Contain;
        }

        public float GetCircumference()
        {
            return (2 * (float)Math.PI * mRadius);
        }

    }


}