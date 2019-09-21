using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelbornCE05
{
    public partial class MainForm : Form
    {
        public event EventHandler<UserInputDialog.ChangeShipArgs> SendData;
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exits the application
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens the input dialog and creates a new ship
            // This will bring up the UserInput Dialog, with the apply visible
            // instantiate the selectionform
            UserInputDialog formSelect = new UserInputDialog();
            // subscribe to the event handler method 
            //            formSelect.Change += FormSelect_Change;
            SendData += formSelect.CatchData;
            SendData?.Invoke(this, new UserInputDialog.ChangeShipArgs(lvwShips.SelectedItems[0].ImageIndex,
                lvwShips.SelectedItems[0].Name, lvwShips.SelectedItems[0].Checked, lvwShips.SelectedItems[0].));
            // show the form as modal
            formSelect.ShowDialog();



        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will clear the listView
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // This will bring up the UserInput Dialog, with the apply visible
            // instantiate the selectionform
            UserInputDialog formSelect = new UserInputDialog();
            // subscribe to the event handler method 
//            formSelect.Change += FormSelect_Change;
            SendData += formSelect.CatchData;
            SendData?.Invoke(this, new UserInputDialog.ChangeShipArgs(lvwShips.SelectedItems[0].ImageIndex, 
                lvwShips.SelectedItems[0].Name, lvwShips.SelectedItems[0].Checked, lvwShips.SelectedItems[0].Index));
            // show the form as modal
            formSelect.ShowDialog();

        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwShips.View = View.LargeIcon;
            lvwShips.Refresh();
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwShips.View = View.SmallIcon;
            lvwShips.Refresh();
        }
    }
}
