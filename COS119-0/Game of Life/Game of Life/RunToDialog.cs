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
    public partial class RunToDialog : Form
    {
        public RunToDialog()
        {
            InitializeComponent();
            runToNumericUpDown.Maximum = Decimal.MaxValue;
        }

        public int RunTo
        {
            get
            {
                return (int)runToNumericUpDown.Value;
            }
            set
            {
                runToNumericUpDown.Value = value;
            }
        }
    }
}
