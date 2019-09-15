/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Framworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: This is where the object and open input counters are held, as well as the application exit and list views
*/
using System;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{

    public partial class MainForm : Form
    {
        public UserInputForm formUserInput = new UserInputForm();
        public ListViewForm formList;
        public int intFormCount;

        // public property to get counts
        private EventHandler CharacterAdded;

        
        public MainForm()
        {
            InitializeComponent();
        }
        private void tbOpenFormCount_TextChanged(object sender, EventArgs e)
        {
            //Send Notification to all subscribers
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit Application when the exit is pressed from the main menu
            Application.Exit();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formList == null || formList.IsDisposed == true)
            {
                formList = new ListViewForm(this);

                CharacterAdded += formList.CharacterAddedHandler;

                foreach (Character c in formUserInput.CharacterData)
                {
                    formList.CharacterListBox = c;
                }

                formList.Show();

                displayToolStripMenuItem.Checked = true;
            }
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clears the main list, as well as the Listview
        }

        private void btnOpenInputForm_Click(object sender, EventArgs e)
        {
            intFormCount++;
            tbOpenFormCount.Text = intFormCount.ToString();
            UserInputForm formUserInputForm = new UserInputForm();
            // opens new input form, and increments the counter
            formUserInputForm.Updated += (se, ev) => tbOpenFormCount.Text = intFormCount.ToString(); ; // update textbox
            formUserInput.Show();
        }
        public bool ToolTipChecked
        {
            set
            {
                displayToolStripMenuItem.Checked = value;
            }
        }
 
        private void tbOpenFormCount_MouseEnter(object sender, EventArgs e)
        {
            // Shows a hint in the status bar
            tspMainForm.Text = "The Count of Open Input Windows";
        }

        private void Clear_StatusHintEvent(object sender, EventArgs e)
        {
            tspMainForm.Text = "";
        }
    }
}
