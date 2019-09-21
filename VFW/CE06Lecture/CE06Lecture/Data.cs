using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE06Lecture
{
    class Data
    {
        private int dataNumber;
        private int height;
        private int weight;
        List<Data> containedData = new List<Data>();

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int DataNumber
        {
            get { return dataNumber; }
            set { dataNumber = value; }
        }
        public List<Data> ContainedData
        {
            get { return containedData; }
            set { containedData = value; }
        }

        public override string ToString()
        {
            return ("Data Number: " + DataNumber);
        }
    }
}
