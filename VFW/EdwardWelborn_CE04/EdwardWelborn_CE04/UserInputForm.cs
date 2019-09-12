using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class UserInputForm : Form
    {
        public List<string> lstCharacters = new List<string>();
        public UserInputForm()
        {
            InitializeComponent();
        }

        private void tsbAddData_Click(object sender, EventArgs e)
        {
            // Add data to the list
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            // Clears the list as well as the data form
            lstCharacters.Clear();
        }
    }
}
