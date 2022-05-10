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
    public partial class TimerIntervalDailog : Form
    {
        public TimerIntervalDailog()
        {
            InitializeComponent();
            timerIntervalNumericUpDown.Maximum = Decimal.MaxValue;
        }

        public int TimerInterval
        {
            get
            {
                return (int)timerIntervalNumericUpDown.Value;
            }
            set
            {
                timerIntervalNumericUpDown.Value = value;
            }
        }
    }
}
