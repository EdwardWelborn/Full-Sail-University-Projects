using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class universeSizeDialog : Form
    {
        public universeSizeDialog()
        {
            InitializeComponent();
            xSizeNumericUpDown.Maximum = Decimal.MaxValue;
            ySizeNumericUpDown.Maximum = Decimal.MaxValue;
        }

        public int UniverseYResize
        {
            get
            {
                return (int)ySizeNumericUpDown.Value;
            }
            set
            {
                ySizeNumericUpDown.Value = value;
                
            }
        }

        public int UniverseXResize
        {
            get
            {
                return (int)xSizeNumericUpDown.Value;
            }
            set
            {
                xSizeNumericUpDown.Value = value;

            }
        }
    }
}
