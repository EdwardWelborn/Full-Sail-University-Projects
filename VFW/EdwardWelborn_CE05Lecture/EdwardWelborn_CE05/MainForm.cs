using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE05
{
    public partial class MainForm : Form
    {
        // event handler to send data forward
        public event EventHandler<SelectionForm.ChangeClassArgs> SendData;
        public MainForm()
        {
            InitializeComponent();
            // invoke method to populate
            PrePopulateListView();
        }
        // method to prepopulate the listview
        private void PrePopulateListView()
        {
            for (int i = 1; i <= 5; i++)
            {
                // create listview items
                ListViewItem lvi = new ListViewItem();
                // generic text for party member
                lvi.Text = $"Party Member: {i}";
                // assign first image to the LVI
                lvi.ImageIndex = 0;
                //add party member to the lvi
                lvwCharacters.Items.Add(lvi);
            }
        }

        private void lvwCharacters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // instantiate the selectionform
            SelectionForm formSelect = new SelectionForm();
            // subscribe to the event handler method 
            formSelect.Change += FormSelect_Change;
            SendData += formSelect.CatchData;
            SendData?.Invoke(this, new SelectionForm.ChangeClassArgs(lvwCharacters.SelectedItems[0].ImageIndex, lvwCharacters.SelectedItems[0].Text));
            // show the form as modal
            formSelect.ShowDialog();
        }

        private void FormSelect_Change(object sender, SelectionForm.ChangeClassArgs e)
        {
            // e.imageindex will have the index of the selected radio button
            lvwCharacters.SelectedItems[0].ImageIndex = e.intImageIndex;
            lvwCharacters.SelectedItems[0].Text = e.newName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
