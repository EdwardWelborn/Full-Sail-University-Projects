using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsIntro
{
    public partial class Form1 : Form
    {
        private event System.EventHandler ItemCountChanged;

        public 

        public Form1()
        {
            InitializeComponent();
        }

        public void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Default";
            checkboxStudent.Checked = false;
        }
    }
}
