/*
* Created by Edward Welborn on 09/14/2019
* Class: Visual Frameworks
* Description: Project CE05
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Input Dialog Form
* Summary: This is where the object is edited. And returned back to the mainform list
*/
using System;
using System.Windows.Forms;

namespace EdwardWelbornCE05
{
    public partial class UserInputDialog : Form
    {

        public UserInputDialog()
        {
            InitializeComponent();
        }

        // Creates an Event delegate with EventArgs needing to modify the object
        public EventHandler<MainForm.ModifyObjectEventArgs> ModifyObject;

        public EventHandler AddSpaceShipToListView;
        
        public EventHandler CloseUserInputDialogForm;

        public SpaceShips Data
        {
            get
            {
                //Create a new spaceship with the fields taken from the user
                SpaceShips s = new SpaceShips();
                s.Name = txtShipName.Text;
                s.CrewSize = numCrewSize.Value;
                s.Active = chkActiveDuty.Checked;
                s.Cruiser = rdoCruiser.Checked;
                s.Destroyer = rdoDestroyer.Checked;
                s.Freighter = rdoFreighter.Checked;
                return s;
            }

            set
            {
                //Use this setter when needing to reset the user input fields back to default
                txtShipName.Text = value.Name;
                numCrewSize.Value = value.CrewSize;
                chkActiveDuty.Checked = value.Active;
                rdoCruiser.Checked = value.Cruiser;
                rdoDestroyer.Checked = value.Destroyer;
                rdoFreighter.Checked = value.Freighter;
            }
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            //raise the AddShipToListView event
            if (AddSpaceShipToListView != null)
            {
                AddSpaceShipToListView(this, new EventArgs());
            }
            //set the user input fields back to default
            Data = new SpaceShips();
        }
        
        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save the object back over to it's current record
            // Only visible during the doubleclick event from the main form.
            //raise the AddShipToListView event
            if (AddSpaceShipToListView != null)
            {
                AddSpaceShipToListView(this, new EventArgs());
            }
            //set the user input fields back to default
            Data = new SpaceShips();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            if (CloseUserInputDialogForm != null)
            {
                CloseUserInputDialogForm(this, new EventArgs());
            }
        }

        // Custom event handler for Selected Space Ship
        public void HandleSpaceShipSelected(object sender, EventArgs e)
        {
            MainForm m = sender as MainForm;
            Data = m.ListViewItemSelected as SpaceShips;
        }
        public bool VisibleApplyBtn
        {
            set
            {
                btnApply.Visible = value;
            }
        }
    }
}
