using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OteroJoshua_CE01
{
    public partial class UserInput : Form
    {
        public event EventHandler<DevClassEventArgs> SendInfo;
        public UserInput()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Adds input info to eventarg and sends back to form 1. Then closes the input form
            DevClassEventArgs arg = new DevClassEventArgs();
            arg.ClassName = txtClassName.Text;
            arg.Completed = chkCompleted.Checked;
            SendInfo?.Invoke(this, arg);
            UserInput.ActiveForm.Close();
        }

        public void LoadInfo(object sender, DevClassEventArgs e)
        {
            // Loads data from form 1 and fills in the input fields on the current user input field
            txtClassName.Text = e.ClassName;
            chkCompleted.Checked = e.Completed;
        }


    }
}
