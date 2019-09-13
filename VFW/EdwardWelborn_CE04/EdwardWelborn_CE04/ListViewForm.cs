/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Framworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* List View Form
* Summary: This is where the list is displayed, as well as being able to click open a new user input form.
*/
using System;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class ListViewForm : Form
    {
        public MainForm formMain;

        public Character CharacterListBox
        {
            set
            {
                lbCharacters.Items.Add(value);
            }
        }

        public int CharacterRemove
        {
            set
            {
                lbCharacters.Items.RemoveAt(value);
            }
        }

        //Event Handler for when a Person is added to the LB
        public void HandleCharacterAdded(object sender, EventArgs e)
        {
            //fmMain is passed in as the Sender object
            //turn sender object into mainForm as a Form1
            UserInputForm formInput = sender as UserInputForm;

            //add each list<> item from the fmMain into the lbDataList on fmList.
            foreach (Character c in formInput.CharacterData)
            {
                //if the listBox doesn't contain the Person object already then add it.
                if (!lbCharacters.Items.Contains(c))
                {
                    lbCharacters.Items.Add(c);
                }
            }
        }

        public ListViewForm(MainForm formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void tspbtnClearData_Click(object sender, EventArgs e)
        {
            // This will clear the list, the list view box, and clear the data object counter on main form

        }
    }
}
