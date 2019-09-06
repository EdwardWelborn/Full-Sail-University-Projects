using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerTest
{
    public partial class fmMain : Form
    {
        // public even handlder to subscribe to the event handler on the data input form
        public event System.EventHandler CopyCurrentData;

        // property for modifying and extracting the text box values
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
        public fmMain()
        {
            InitializeComponent();
        }

        private void btnOpenInputForm_Click(object sender, EventArgs e)
        {
            // instantiate the input form
            DataInput newWindow = new DataInput();

            // set the new windows events to be handled
            newWindow.OnlyClose += NewWindow_OnlyClose;
            newWindow.CloseAndCopy += NewWindow_CloseAndCopy;

            // subscribe to the new window's event to be handled
            CopyCurrentData += newWindow.CopyCurrentData; 

            //Show the form as modeless
            newWindow.Show();
        }

        private void NewWindow_OnlyClose(object sender, EventArgs e)
        {
            // clear the text boxes
            tbFirstName.Clear();
            tbLastName.Clear();
            tbAge.Clear();
        }

        private void NewWindow_CloseAndCopy(object sender, EventArgs e)
        {
            // when we call this methid, the inputform will be closed
            // but, the sender object, which will have all the data
            // from the form.  So, we can access that property by
            // instantiating the sender form as the new form

            DataInput theInputForm = (DataInput) sender;

            // get the text values from the closed window and set
            // the main form's fields to those values

            TextValues = theInputForm.TextValues;
            
        }
    }
}
