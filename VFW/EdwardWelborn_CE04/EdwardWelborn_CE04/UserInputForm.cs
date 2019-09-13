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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class UserInputForm : Form
    {

        private EventHandler CharacterAdded;
        public MainForm FormMain;
        public int intFormCount = 0;

        public Character characterInfo
        {
            get
            {
                Character infoObject = new Character();
                infoObject.Name = tbName.Text;
                infoObject.Gender = cmbGender.Text;
                infoObject.Level = numLevel.Text;
                infoObject.Class = cmbClassName.Text;
                infoObject.Race = cmbRace.Text;
                infoObject.Role = cmbRole.Text;
                infoObject.Mentor = chkbMentor.Checked;
                return infoObject;
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

        //instantiate the person list
        List<Character> characterData = new List<Character>();

        //Property for the Persons in the list
        public List<Character> CharacterData
        {
            get
            {
                return characterData;
            }
            set
            {
                characterData = value;
            }
        }

        public UserInputForm()
        {
            InitializeComponent();
        }

        private void UserInputForm_Load(object sender, EventArgs e)
        {
            int form2Count;
            
            // On loading the user input form, it will also open the main form where the counter are.
            AddHovertip((ToolStripStatusLabel) statusStrip.Items[0], this.numLevel, "Enter Character Level");
            // add to main form open form counter
            
            form2Count = Application.OpenForms.OfType<UserInputForm>().Count();
            FormMain.tbOpenFormCount.Text = form2Count.ToString();
        }

        private void UserInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Decriment open input form count
            intFormCount--;
            FormMain = new MainForm();
            FormMain.tbOpenFormCount.Text = intFormCount.ToString();
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

        private void tspbtnAddToList_Click(object sender, EventArgs e)
        {
            // Adds the form data to the main list.
            // create information object and add it to the listbox
            CharacterData.Add(characterInfo);
            characterInfo = new Character();

            //raise the StudentAdded event
            CharacterAdded?.Invoke(this, new EventArgs());
           
            // clear the user inputs
            btnClearForm_Click(this, new EventArgs());
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            // This button will clear the data on the form only
            tbName.Text = "";
            cmbGender.SelectedIndex = -1;
            numLevel.Text = "";
            cmbClassName.SelectedIndex = -1;
            cmbRace.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
            chkbMentor.Checked = false;

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

        private void numLevel_Enter(object sender, EventArgs e)
        {
            // This clears the 0 out of the numericUpDown text so they can immediately edit without deleting the 0
            numLevel.Text = "";
        }
    }
}
