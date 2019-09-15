﻿/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Framworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* User Input Form
* Summary: This form is utilized for entering the data to populate the list and list view form
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class UserInputForm : Form
    {

        public EventHandler CharacterAddedToList;
        public EventHandler CharacterAddedToListView;
        public EventHandler CloseUserInputWindow;
     

        public UserInputForm()
        {
            InitializeComponent();
        }

        public Character characterInfo
        {
            get
            {
                Character c = new Character();
                c.Name = tbName.Text;
                c.Gender = cmbGender.Text;
                c.Level = numLevel.Text;
                c.Class = cmbClassName.Text;
                c.Race = cmbRace.Text;
                c.Role = cmbRole.Text;
                c.Mentor = chkbMentor.Checked;
                c.ImageIndex = cmbClassName.SelectedIndex;
                return c;
            }
            set
            {

                tbName.Text = value.Name;
                cmbGender.Text = value.Gender;
                numLevel.Text = value.Level;
                cmbClassName.Text = value.Class;
                cmbRace.Text = value.Race;
                cmbRole.Text = value.Role;
                chkbMentor.Checked = value.Mentor;
            }
        }

        private void UserInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseUserInputWindow?.Invoke(this, new EventArgs());
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            characterInfo = new Character();
        }


        private void tspbtnAddToList_Click(object sender, EventArgs e)
        {
            CharacterAddedToList?.Invoke(this, new EventArgs());

            CharacterAddedToListView?.Invoke(this, new EventArgs());

            characterInfo = new Character();
        }





















        private void UserInputForm_Load(object sender, EventArgs e)
        {
            // On loading the user input form, it will also open the main form where the counter are.
            AddHovertip((ToolStripStatusLabel)statusStrip.Items[0], this.numLevel, "Enter Character Level");
        }

        public static void AddHovertip(ToolStripStatusLabel lb, Control c, string tip)
        {
            c.MouseEnter += (sender, e) =>
            {
                lb.Text = tip;
            };

            c.MouseLeave += (sender, e) =>
            {
                lb.Text = "";
            };

            // iterate over any child controls
            foreach (Control child in c.Controls)
            {
                // and add the hover tip on 
                // those childs as well
                AddHovertip(lb, child, tip);
            }
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

        private void numLevel_Enter(object sender, EventArgs e)
        {
            // This clears the 0 out of the numericUpDown text so they can immediately edit without deleting the 0
            numLevel.Text = "";
        }

        private void ClearStatusText_Event(object sender, EventArgs e)
        {
            // clears the tooltip text on mouse exit of the control
            tspStatusBarHelper.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Updated != null)
            //{
            //    Updated(sender, new EventArgs()); //Raise a change.
            //}
        }
    }
}
