﻿/*
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
        ListViewForm formList = new ListViewForm();
        // public property to get counts
        public string ListCountDisplay
        {
            set
            {
                tbNumberofCharacters.Text = value;

            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit Application when the exit is pressed from the main menu
            Application.Exit();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens Listview form if not already open
            if (formList == null || formList.IsDisposed == true)
            {

                formList = new ListViewForm(this);

                CharacterAdded += formList.HandleCharacterAdded;


                foreach (Character p in CharacterData)
                {
                    formList.CharacterList = p;
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
            // opens new input form, and increments the counter
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

        private void tbNumberofCharacters_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
