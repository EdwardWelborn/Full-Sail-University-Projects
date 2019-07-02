using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdwardWelborn_CE3
{
    class Car
    {
        private string _make;
        private string _model;
        private string _color;
        private float _mileage;
        private int _year;
        private string _currentCar;
       

        public Car(string make, string model, string color, float mileage, int year)
        {
            _make = make;
            _model = model;
            _color = color;
            _mileage = mileage;
            _year = year;
            _currentCar = make + " " + model + " " + color + " " + mileage + " " + year;

        }
        public string Make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = Make;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = Model;
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = Color;
            }
        }
        public float Mileage
        {
            get
            {
                return _mileage;
            }
            set
            {
                _mileage = Mileage;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = Year;
            }
        }
         public void DriveCar(float mileage)
        {
            _mileage += mileage;
            
            Program.GetLogger();
        }
        public string CurrentCar
        {
            get
            {
                return _currentCar;
            }
            set
            {
                _currentCar = CurrentCar;
            }
        }
        public void DestroyCurrentCar()
        {
            _currentCar = null;
            CurrentCar = null;
            _make = null;
            _model = null;
            _color = null;
            _mileage = 0;
            _year = 0;

        }

    }
}
/*
 * Car Implementation


constructor method : The new values of the car’s fields should be logged using the LogD method of the static Logger object in the Program class.  Use GetLogger().
drive method : The new mileage should be logged using the LogW method of the static Logger object in the Program class.  Use GetLogger().

 */
