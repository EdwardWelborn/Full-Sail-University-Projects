/*
* Created by Edward Welborn on 09/09/2019
* Class: Visual Framworks
* Description: Project CE03
* Copyright © 2019 Roy Welborn. All rights reserved
*
* list Form
* Summary: list form for the program, this form is to list the data
*/
using System;
using System.Windows.Forms;

namespace WelbornEdward_CE03
{
    public partial class fmList : Form
    {
        public fmMain formMain;

        public fmList(fmMain FmMain)
        {
            InitializeComponent();
            this.formMain = FmMain;
        }

        public People PersonsListBox
        {
            set
            {
                lbDataList.Items.Add(value);
            }
        }

        public int PersonsRemove
        {
            set
            {
                lbDataList.Items.RemoveAt(value);
            }
        }

        //Event Handler for when a Person is added to the LB
        public void HandlePersonAdded(object sender, EventArgs e)
        {
            //fmMain is passed in as the Sender object
            //turn sender object into mainForm as a Form1
            fmMain formMain = sender as fmMain;

            //add each list<> item from the fmMain into the lbDataList on fmList.
            foreach (People p in formMain.PersonData)
            {
                //if the listBox doesn't contain the Person object already then add it.
                if (!lbDataList.Items.Contains(p))
                {
                    lbDataList.Items.Add(p);
                }

            }
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            lbDataList.Items.Clear();
            formMain.PersonData.Clear();
            formMain.clearUserInput();
        }


        private void personListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check to make sure a valid selection is made before running if statement
            if (lbDataList.SelectedIndex >= 0 && lbDataList.SelectedIndex <= lbDataList.Items.Count - 1)
            {
                //set the input user control data equal to the person selected's data.
                formMain.Information = (People)lbDataList.Items[lbDataList.SelectedIndex] as People;
            }
        }

        //Event handler for when the display form is closed
        private void fmList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //uncheck the display menu tool tip item.
            formMain.ToolTipChecked = false;
        }
    }
}
