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
    public partial class MainForm : Form
    {
        public ListViewForm fmListView;

        public MainForm()
        {
            InitializeComponent();
        }

        private EventHandler PersonAdded;
        //public List<string> lstUserData = new List<string>();


        //Property for the Persons in the list

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fmListView == null || fmListView.IsDisposed == true)
            {

              fmListView.Show();


                displayToolStripMenuItem.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit the application
            Application.Exit();
        }
    }
}
