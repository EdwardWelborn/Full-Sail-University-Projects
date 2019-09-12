using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class dataEntryForm : Form
    {
        public DataClass Data
        {
            get
            {
                DataClass c = new DataClass();
                c.imageIndex = cmbClass.SelectedIndex;
                c.age = numAge.Value;
                c.firstName = tbFirstName.Text;
                c.lastName = tbLastName.Text;
                c.gender = cmbGender.Text;
                c.immortal = cbImmortal.Checked;
                c.className = cmbClass.Text;
                c.race = cmbRace.Text;
                // This will get the index for the selected class

                return c;
            }
            set
            {
                numAge.Value = value.age;
                tbFirstName.Text = value.firstName;
                tbLastName.Text = value.lastName;
                cmbGender.Text = value.gender;
                cmbClass.Text = value.className;
                cmbRace.Text = value.race;
                cbImmortal.Checked = value.immortal;

            }
        }

        public event EventHandler AddCharacter;

        public dataEntryForm()
        {
            InitializeComponent();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            // check that the event handler has been subscribed to a method
            if (AddCharacter != null)
            {
                // sender for this event will be the form
                AddCharacter(this, new EventArgs());
            }

            ClearForm();
        }
        // Method to clear the form

        private void ClearForm()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            numAge.Text = "";
            cmbGender.Text = "";
            cbImmortal.Checked = false;
            cmbClass.Text = "";
            cmbRace.Text = "";
        }
    }
}
