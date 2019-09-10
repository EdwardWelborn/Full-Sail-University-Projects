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

        public fmList formList;

        public fmMain()
        {
            InitializeComponent();
        }

        //Create the event delegate.
        private EventHandler PersonAdded;

        public People Information
        {
            get
            {
                People infoObject = new People();
                infoObject.Firstname = tbFirstName.Text;
                infoObject.Lastname = tbLastName.Text;
                infoObject.Student = chkbStudent.Checked;
                infoObject.Gender = cmbGender.Text;
                infoObject.Age = udAge.Text;
                return infoObject;
            }

            set
            {

                tbFirstName.Text = value.Firstname;
                tbLastName.Text = value.Lastname;
                chkbStudent.Checked = value.Student;
                cmbGender.Text = value.Gender;
                udAge.Text = value.Age;


            }

        }

        //public List<string> lstUserData = new List<string>();

        //Property for the Persons in the list
        public List<People> PersonData
        {
            get
            {
                return personData;
            }

            set
            {
                personData = value;
            }
        }




        //instantiate the person list
        List<People> personData = new List<People>();


        private void btnAddData_Click(object sender, EventArgs e)
        {
            // create information object and add it to the listbox
            PersonData.Add(Information);

            Information = new People();


            //raise the StudentAdded event
            PersonAdded?.Invoke(this, new EventArgs());


            // clear the user inputs
            //ClearForm_Event(this, new EventArgs());



        }

        public void ClearForm_Event(object sender, EventArgs e)
        {
            // Clears the data form
            //tbFirstName.Text = "";
            //tbLastName.Text = "";
            //udAge.Text = "";
            //cmbGender.Text = "";
            //chkbStudent.Checked = false;

            People p = new People();

            Information = p;
        }


        public void clearUserInput()
        {
            People p = new People();

            Information = p;
        }
        
        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmList frmList = new fmList();

            //for (int x = 0; x < personData.Count; x++)
            //{
            //    frmList.lbDataList.Items.Add(personData[x]);
            //}
            //frmList.ShowDialog();


            if (formList == null || formList.IsDisposed == true)
            {

                formList = new fmList(this);
                
                PersonAdded += formList.HandlePersonAdded;
                

                foreach (People p in PersonData)
                {
                    formList.PersonsListBox = p;
                }

                formList.Show();

                
                displayToolStripMenuItem.Checked = true;
            }

            
        }

        private void udAge_Enter(object sender, EventArgs e)
        {
            // udAge.Text = "";
        }

       

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int totalPersons = PersonData.Count;

            while (--totalPersons >= 0)
            {
                formList.PersonsRemove = totalPersons;
            }

            //clear the list<>
            PersonData.Clear();

        }

        public bool ToolTipChecked
        {
            set
            {
                displayToolStripMenuItem.Checked = value;
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public void LeaveField_Event(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
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

       
    }
}
