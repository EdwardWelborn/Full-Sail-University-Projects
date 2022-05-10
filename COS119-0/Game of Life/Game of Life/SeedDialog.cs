

using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class SeedDialog : Form
    {
        
        public SeedDialog()
        {
            InitializeComponent();
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

