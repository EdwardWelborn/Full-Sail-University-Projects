using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasimirJustin_Assignment1
{
    public partial class UserInput : Form
    {
        public event EventHandler UpdateHave;
        public event EventHandler UpdateNeed;



        public UserInput()
        {
            InitializeComponent();
        }

        //invokes eventhandler
        private void buttonHAVE_Click(object sender, EventArgs e)
        {
            UpdateHave?.Invoke(this, new EventArgs());

        }

        //invokes eventhandler
        private void buttonNEED_Click(object sender, EventArgs e)
        {
            UpdateNeed?.Invoke(this, new EventArgs());

        }
    }
}
