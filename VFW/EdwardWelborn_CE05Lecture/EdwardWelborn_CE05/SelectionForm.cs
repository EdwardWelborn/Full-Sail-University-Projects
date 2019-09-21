using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE05
{
    public partial class SelectionForm : Form
    {
        // the event handler delegate to call the event handler method
        public event EventHandler<ChangeClassArgs> Change;

        // custom event arguments class
        public class ChangeClassArgs : EventArgs
        {
            // instance member variable for image index
            public int intImageIndex;
            public string newName;

            // constructor assigns the index argument to the instance variable
            public ChangeClassArgs(int index, string name)
            {
                intImageIndex = index;
                newName = name;
            }
        }
        public SelectionForm()
        {
            InitializeComponent();
        }
        // event handler method to catch data coming from the main form
        public void CatchData(object sender, ChangeClassArgs e)
        {
            tbName.Text = e.newName;
            
            // check radio button based on the index
            switch (e.intImageIndex)
            {
                case 1:
                {
                    rbtnDruid.Checked = true;
                }
                    break;
                case 2:
                {
                    rbtnHunter.Checked = true;
                }
                    break;
                case 3:
                {
                    rbtnMage.Checked = true;
                }
                    break;
                case 4:
                {
                    rbtnPriest.Checked = true;
                }
                    break;
                case 5:
                {
                    rbtnRogue.Checked = true;
                }
                    break;
                case 6:
                {
                    rbtnShaman.Checked = true;
                }
                    break;
                case 7:
                {
                    rbtnWarlock.Checked = true;
                }
                    break;
                default:
                {
                    rbtnWarrior.Checked = true;
                }
                    break;
            }

            tbName.Select();
        }

        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // invoke the event handler
            if (Change != null)
            {
                // we need to check every radio button to see which one is selected
                int index = 0;
                if (rbtnDruid.Checked)
                {
                    index = 1;
                }
                else if (rbtnHunter.Checked)
                {
                    index = 2;
                } else if (rbtnMage.Checked)
                {
                    index = 3;
                } else if (rbtnPriest.Checked)
                {
                    index = 4;
                } else if (rbtnRogue.Checked)
                {
                    index = 5;
                } else if (rbtnShaman.Checked)
                {
                    index = 6;
                } else if (rbtnWarlock.Checked)
                {
                    index = 7;
                }
                // now we invoke the event handler and pass the index
                // as an argument for the custom event args
                Change(this, new ChangeClassArgs(index, tbName.Text));
            }
        }
    }
}
