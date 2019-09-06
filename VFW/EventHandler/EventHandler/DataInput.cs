using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerTest
{
    public partial class DataInput : Form
    {
        // public event handler declarations
        public event System.EventHandler CloseAndCopy;

        public event System.EventHandler OnlyClose;

        // bolean to determine how the form was closed
        public bool isClosingandCopying = false;
        public DataHolder TextValues
        {
            get
            {
                DataHolder returnOblect = new DataHolder();
                returnOblect.firstName = tbFirstName.Text;
                returnOblect.lastName = tbLastName.Text;
                returnOblect.age = tbAge.Text;
                return returnOblect;
            }
            set
            {
                tbFirstName.Text = value.firstName;
                tbLastName.Text = value.lastName;
                tbAge.Text = value.age;
            }

        }

        public DataInput()
        {
            InitializeComponent();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            /// set boolean to true to tell the form the button was clicked
            isClosingandCopying = true;
            // close the form
            Close();
        }

        private void DataInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            // This is the event handler that is called whenever the form closes
            // we need to do the check to see how it is closed
            // we need to make sure the custom event handlers are not null

            if (isClosingandCopying == true && CloseAndCopy != null)
            {
                CloseAndCopy(this, new EventArgs());

            } 
            else if (OnlyClose != null)
            {
                OnlyClose(this, new EventArgs());
            }
        }

        public void CopyCurrentData(object sender, EventArgs e)
        {
            fmMain mainForm = (fmMain)sender;

            TextValues = mainForm.TextValues;
        }
    }
}
