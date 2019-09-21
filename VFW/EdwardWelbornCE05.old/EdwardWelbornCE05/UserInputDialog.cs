using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelbornCE05
{
    public partial class UserInputDialog : Form
    {
        public event EventHandler<ChangeShipArgs> Change;

        public class ChangeShipArgs : EventArgs
        {
            // instance member variable for image index
            public int intImageIndex;
            public string newName;
            public bool active;
            public decimal crewSize;

            // constructor assigns the index argument to the instance variable
            public ChangeShipArgs(int index, string name, bool activeDuty, decimal crewCapacity)
            {
                intImageIndex = index;
                newName = name;
                active = activeDuty;
                crewSize = crewCapacity;
            }
        }
        public void CatchData(object sender, ChangeShipArgs e)
        {
            txtShipName.Text = e.newName;
            chkActiveDuty.Checked = e.active;
            numCrewSize.Value = e.crewSize;

            // check radio button based on the index
            switch (e.intImageIndex)
            {
                case 1:
                {
                    rdoDestroyer.Checked = true;
                }
                    break;
                case 2:
                {
                    rdoCruiser.Checked = true;
                }
                    break;

                default:
                {
                    rdoFreighter.Checked = true;
                }
                    break;
            }

            txtShipName.Select();
        }
        public UserInputDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Add Item to the Listbox
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save the object back over to it's current record
            // Only visible during the doubleclick event from the main form.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            Close();
        }

        private void UserInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            // invoke the event handler
            if (Change != null)
            {
                txtShipName.Text = Text;
                
                // we need to check every radio button to see which one is selected
                int index = 0;
                if (rdoDestroyer.Checked)
                {
                    index = 1;
                }
                else if (rdoCruiser.Checked)
                {
                    index = 2;
                }

                // now we invoke the event handler and pass the index
                // as an argument for the custom event args
                Change(this, new ChangeShipArgs(index, txtShipName.Text, chkActiveDuty.Checked, numCrewSize.Value));
            }
        }
    }
}
