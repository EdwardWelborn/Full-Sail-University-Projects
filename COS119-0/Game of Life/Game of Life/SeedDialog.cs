

using System;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class SeedDialog : Form
    {
        
        public SeedDialog()
        {
            InitializeComponent();
            seedNumericUpDown.Text = null;
            seedNumericUpDown.Maximum = Decimal.MaxValue;
        }

        #region << Properties >>
        
        public int Seed
        {
            get
            {
                return (int)seedNumericUpDown.Value;
            }
            set
            {
                seedNumericUpDown.Value = value;
            }
        }
        #endregion
    }

}

