/*
* Created by Edward Welborn on 09/09/2019
* Class: Visual Framworks
* Description: Project CE03
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: Main form for the program, this form is mainly read only, data is brought over from input form.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelbornEdward_CE03
{
    public partial class fmMain : Form
    {
        
        People Information
        {
            get
            {
                People infoObject = new People();
                infoObject.firstname = tbFirstName.Text;
                infoObject.lastname = tbLastName.Text;
                infoObject.Gender = chkbStudent.Checked;
                infoObject.gender = cmbGender.Text;
                infoObject.age = udAge.Text;
                return infoObject;
            }
        }

        public List<string> lstUserData = new List<string>();

        public fmMain()
        {
            InitializeComponent();
        }
        private void fmMain_Load(object sender, EventArgs e)
        {
            addHovertip((ToolStripStatusLabel)statusStrip.Items[0], this.udAge, "Enter Age");
        }


        public static void addHovertip(ToolStripStatusLabel lb, Control c, string tip)
        {
            c.MouseEnter += (sender, e) =>
            {
                lb.Text = tip;
            };

            c.MouseLeave += (sender, e) =>
            {
                lb.Text = "";
            };

            // iterate over any child controls
            foreach (Control child in c.Controls)
            {
                // and add the hover tip on 
                // those childs as well
                addHovertip(lb, child, tip);
            }
        }

        private void tbFirstName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Enter First Name";
        }

        private void tbLastName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Enter Last Name";
        }

        private void cmbGender_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Enter User Gender";
        }

        private void chkbStudent_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Is User a Student?";
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Exit Application";
        }

        private void displayToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Display Information";
        }

        private void clearToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Clear Information";
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            // create information object and add it to the listbox
            lstUserData.Add(Information.ToString());
            
            // clear the user inputs
            ClearForm_Event(this, new EventArgs());
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmList frmList = new fmList();
            for (int x = 0; x < lstUserData.Count; x++)
            {
                frmList.lbDataList.Items.Add(lstUserData[x]);
            }
            frmList.ShowDialog();
        }

        private void udAge_Enter(object sender, EventArgs e)
        {
            udAge.Text = "";
        }
        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Clear Data Form";
        }
        private void btnAddData_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Add Date to List";
        }
        public void LeaveField_Event(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        public void ClearForm_Event(object sender, EventArgs e)
        {
            // Clears the data form
            tbFirstName.Text = "";
            tbLastName.Text = "";
            udAge.Text = "";
            cmbGender.Text = "";
            chkbStudent.Checked = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
