using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    class Grade
    {
        string _description;
        float _percentEarned;
        float _weight;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public float PercentEarned
        {
            get
            {
                return _percentEarned;
            }

            set
            {
                if (value < 0.0f || value > 100.0f)
                {
                    _percentEarned = 0;
                    Console.WriteLine("Percent earned was less than 0 or greater than 100 so value was set to 0.");
                }
                else
                {
                    _percentEarned = value;
                }
            }
        }
        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if(value < 0.0f || value > 100.0f)
                {
                    _weight = 0;
                    Console.WriteLine("Weight was less than 0 or greater than 100 so value was set to 0.");
                }
                else
                {
                    _weight = value;
                }
            }
        }
        public float GetPercentOfFinalGrade()
        {
            float result = (_percentEarned * _weight) / 100;
            return result;
        }
    }
}
