/*
* Created by Edward Welborn on 09/14/2019
* Class: Visual Frameworks
* Description: Project CE05
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: This is where the object and open input counters are held, as well as the application exit and list views
*/
using System;
using System.Windows.Forms;

namespace EdwardWelbornCE05
{
    public partial class MainForm : Form
    {
        int totalNumberShips;

        UserInputDialog userCreatedShip;

        private EventHandler SpaceShipSelected;

        public UserInputDialog UserCreatedShip
        {
            get => userCreatedShip;
            set => userCreatedShip = value;
        }

        // Create custom event argument class
        public class ModifyObjectEventArgs : EventArgs
        {
            // Declare spaceship object that will hold the updated objects data.
            SpaceShips SpaceShipObject;

            // Create a property for the Modify SpaceShipObject
            public SpaceShips ModifySpaceShipObject
            {
                get => SpaceShipObject;

                set => SpaceShipObject = value;
            }

            public ModifyObjectEventArgs(SpaceShips item)
            {
                SpaceShipObject = item;
            }
        }

        public SpaceShips ListViewItemSelected
        {
            get
            {
                return lvwShips.SelectedItems[0].Tag as SpaceShips;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens the input dialog and creates a new ship
            // This will bring up the UserInput Dialog, with the apply visible
            // instantiate the selectionform

            userCreatedShip = new UserInputDialog();
            userCreatedShip.AddSpaceShipToListView += HandleAddSpaceShipToListView;
            userCreatedShip.ModifyObject += HandleModifySapceShipObject;
            userCreatedShip.CloseUserInputDialogForm += HandleCloseUserInputDialogForm;
            userCreatedShip.Show(this);
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This will clear the listView
            lvwShips.Items.Clear();
            totalNumberShips = 0;
            totalSpaceShipsLabel.Text = "Total Ships: " + totalNumberShips.ToString();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // This will bring up the UserInput Dialog, with the apply visible
            // instantiate the selectionform
            
            UserInputDialog formSelect = new UserInputDialog();

            formSelect.AddSpaceShipToListView += HandleAddSpaceShipToListView;
            formSelect.ModifyObject += HandleModifySapceShipObject;
            formSelect.CloseUserInputDialogForm += HandleCloseUserInputDialogForm;
            SpaceShipSelected += formSelect.HandleSpaceShipSelected;
            
            // show the apply button
            formSelect.VisibleApplyBtn = true;
            
            formSelect.Show(this);
            
            if (SpaceShipSelected != null && lvwShips.SelectedItems.Count > 0)
            {
                SpaceShipSelected(this, new EventArgs());
            }
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (largeToolStripMenuItem.Checked != true)
            {
                largeToolStripMenuItem.Checked = true;
                smallToolStripMenuItem.Checked = false;
                lvwShips.View = View.LargeIcon;
            }
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (smallToolStripMenuItem.Checked != true)
            {
                largeToolStripMenuItem.Checked = false;
                smallToolStripMenuItem.Checked = true;
                lvwShips.View = View.SmallIcon;
            }
        }

        // public event EventHandler<UserInputDialog.ChangeClassArgs> SendData;
        private void HandleAddSpaceShipToListView(object sender, EventArgs e)
        {
            UserInputDialog dialog = sender as UserInputDialog;
            SpaceShips s = dialog.Data as SpaceShips;
            ListViewItem lvi = new ListViewItem();
            
            lvi.Text = s.ToString();
            lvi.ImageIndex = s.ImageIndex;
            lvi.Tag = s;

            lvwShips.Items.Add(lvi);

            if (totalNumberShips == 0)
            {
                totalNumberShips = 1;
                totalSpaceShipsLabel.Text = "Total Ships: " + totalNumberShips++.ToString();
            }

            else
            {
                totalSpaceShipsLabel.Text = "Total Ships: " + totalNumberShips++.ToString();
            }

        }

        private void HandleCloseUserInputDialogForm(object sender, EventArgs e)
        {
            UserInputDialog openDialog = sender as UserInputDialog;
            openDialog.Close();
        }

        private void HandleModifySapceShipObject(object sender, ModifyObjectEventArgs e)
        {
            lvwShips.SelectedItems[0].Text = e.ModifySpaceShipObject.ToString();
            lvwShips.SelectedItems[0].ImageIndex = e.ModifySpaceShipObject.ImageIndex;
            lvwShips.SelectedItems[0].Tag = e.ModifySpaceShipObject;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exits the application
            Application.Exit();
        }
    }
}
