/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Framworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* User Input Form
* Summary: This form is utilized for entering the data to populate the list and list view form
*/
using System;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class UserInputForm : Form
    {
        public UserInputForm()
        {
            InitializeComponent();
        }

        private void UserInputForm_Load(object sender, EventArgs e)
        {
            // On loading the user input form, it will also open the main form where the counter are.
            MainForm frmMain = new MainForm();

            frmMain.Show();
        }

        private void tspbtnAddToList_Click(object sender, EventArgs e)
        {
            // Adds the form data to the main list.
        }
        private void tbName_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for tbName
            tspStatusBarHelper.Text = "Enter Character Name";
        }

        private void cmbGender_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for cmbGender
            tspStatusBarHelper.Text = "Choose Character's Gender";
        }

        private void cmbRace_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for cmbRace
            tspStatusBarHelper.Text = "Choose Character's Race";
        }

        private void cmbClassName_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for cmbClass
            tspStatusBarHelper.Text = "Choose Character's Class";
        }

        private void cmbRole_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for cmbRole
            tspStatusBarHelper.Text = "Choose Character's Role";
        }

        private void chkbMentor_MouseEnter(object sender, EventArgs e)
        {
            // Status tooltip for for chkbMentor
            tspStatusBarHelper.Text = "Is This Character a Mentor?";
        }
        private void ClearStatusText_Event(object sender, EventArgs e)
        {
            // clears the tooltip text on mouse exit of the control
            tspStatusBarHelper.Text = "";
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            // This button will clear the data on the form only

        }
    }
}
