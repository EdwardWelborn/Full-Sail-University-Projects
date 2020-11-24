using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasimirJustin_Assignment2
{
    public partial class UserInput : Form
    {
        public event EventHandler UpdateContent;


        public UserInput()
        {
            InitializeComponent();
        }

        //Invokes Method
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            UpdateContent?.Invoke(this, new EventArgs());
            this.Close();
        }
    }
}
