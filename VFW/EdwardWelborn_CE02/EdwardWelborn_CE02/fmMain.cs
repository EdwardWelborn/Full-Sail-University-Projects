/*
* Created by Edward Welborn on 09/06/2019
* Class: Visual Framworks
* Description: Project CE02
* Copyright © 2019 Roy Welborn. All rights reserved
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: Main form for the program, this form is mainly read only, data is brought over from input form.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE02
{
    public partial class fmMain : Form
    {
        // Property for the people we put in the listbox
        People Information
        {
            get
            {
                People infoObject = new People();
                infoObject.firstname = tbFirstName.Text;
                infoObject.lastname = tbLastName.Text;
                infoObject.GuyType = cbGoodGuy.Checked;
                infoObject.gender = cmbGender.Text;
                infoObject.age = numericUpDown.Text;
                return infoObject;
            }

        }
        public fmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // call custom event handler to clear data
            ClearForm_Event(this, new EventArgs());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clears the list data
            lbGoodGuyList.Items.Clear();
            lbBadGuysList.Items.Clear();
            // opens file dialog to open correct text file.
            string fileContent = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\VFW\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                List<string> tempList = new List<string>();
                List<string> splitter = new List<string>();

                // need to read in the data from the file and be able to seperate the two different lists
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while ((fileContent = reader.ReadLine()) != null)
                        {
                            // Read data list, split the string
                            if (fileContent.Contains("True"))
                            {
                                lbGoodGuyList.Items.Add(fileContent);
                            }
                            else
                            {
                                lbBadGuysList.Items.Add(fileContent);
                            }
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open Save file Dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\\VFW\\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter myStreamWriter = new StreamWriter(saveFileDialog1.FileName);

                foreach (var item in lbGoodGuyList.Items)
                {
                    myStreamWriter.WriteLine(item.ToString());
                }

                foreach (var item in lbBadGuysList.Items)
                {
                    myStreamWriter.WriteLine(item.ToString());
                }
                // if the user hits okay, then save data to the file.
                // need to write out both list boxes in one file

                myStreamWriter.Close();

            }
                    


            //clear form after saving the file

            ClearForm_Event(sender, e);
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            // create information object and add it to the listbox
            if (cbGoodGuy.Checked)
            {
                lbGoodGuyList.Items.Add(Information);
            }
            else
            {
                lbBadGuysList.Items.Add(Information);
            }
            

            // clear the user inputs
            ClearForm_Event(this, new EventArgs());
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            addHovertip((ToolStripStatusLabel)statusStrip.Items[0], this.numericUpDown, "Enter Age");
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

        private void tbFirstName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter First Name";
        }

        private void tbFirstName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void tbLastName_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Last Name";
        }

        private void tbLastName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void cmbGender_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Gender";
        }

        private void cmbGender_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void cbStudent_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click if Student";
        }

        private void cbStudent_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Clears all Form Data";
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void openToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Open File";
        }

        private void openToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void saveToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Save Form to File";
        }

        private void saveToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Exit Program";
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void btnAddData_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Exit Program";
        }

        private void btnAddData_MouseLeave(object sender, EventArgs e)
        {
        toolStripStatusLabel1.Text = "";
        }

        private void numericUpDown_Enter_1(object sender, EventArgs e)
        {
            numericUpDown.Text = "";
        }

        public void ClearForm_Event(object sender, EventArgs e)
        {
            // Clears the data form
            tbFirstName.Text = "";
            tbLastName.Text = "";
            numericUpDown.Text = "";
            cmbGender.Text = "";
            cbGoodGuy.Checked = false;
        }

        private void StatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmInputForm iForm = new fmInputForm();

            iForm.GoodGuyCount = lbGoodGuyList.Items.Count.ToString();
            iForm.BadGuyCount = lbBadGuysList.Items.Count.ToString();

            iForm.ShowDialog();
        }

        private void lbGoodGuyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            List<string> splitter = new List<string>();
            if (lbGoodGuyList.SelectedItem != null)
            {
                splitter.Add(lbGoodGuyList.SelectedItem.ToString());
                foreach (string strItem in splitter)
                {
                    char[] splitChar = {' ', ','};
                    tempList = strItem.Split(splitChar).ToList();
                    foreach (var item in tempList)
                    {
                        tbFirstName.Text = tempList[0];
                        tbLastName.Text = tempList[1];
                        numericUpDown.Text = tempList[2];
                        cmbGender.Text = tempList[3];
                        if (tempList[4] == "True")
                        {
                            cbGoodGuy.Checked = true;
                        }
                        else
                        {
                            cbGoodGuy.Checked = false;
                        }
                    }
                }
            }
        }

        private void lbBadGuysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            List<string> splitter = new List<string>();
            if (lbBadGuysList.SelectedItem != null)
            {
                splitter.Add(lbBadGuysList.SelectedItem.ToString());
                foreach (string strItem in splitter)
                {
                    char[] splitChar = {' '};
                    tempList = strItem.Split(splitChar).ToList();
                    foreach (var item in tempList)
                    {
                        tbFirstName.Text = tempList[0];
                        tbLastName.Text = tempList[1];
                        numericUpDown.Text = tempList[2];
                        cmbGender.Text = tempList[3];
                        if (tempList[4] == "True")
                        {
                            cbGoodGuy.Checked = true;
                        }
                        else
                        {
                            cbGoodGuy.Checked = false;
                        }
                    }
                }
            }
        }

        private void btnMoveGood_Click(object sender, EventArgs e)
        {
            if (lbBadGuysList.SelectedItem != null)
            {
                lbGoodGuyList.Items.Add(lbBadGuysList.SelectedItem);
                lbBadGuysList.Items.Remove(lbBadGuysList.SelectedItem);
                lbBadGuysList.Refresh();
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }

        }

        private void btnMoveBad_Click(object sender, EventArgs e)
        {
            if (lbGoodGuyList.SelectedItem != null)
            {
                lbBadGuysList.Items.Add(lbGoodGuyList.SelectedItem);
                lbGoodGuyList.Items.Remove(lbGoodGuyList.SelectedItem);
                lbGoodGuyList.Refresh();
            }
            else
            {
                MessageBox.Show(("No Item Selected"));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbGoodGuyList.SelectedItem != null)
            {
                lbGoodGuyList.Items.Remove(lbGoodGuyList.SelectedItem);
                lbGoodGuyList.Refresh();
            }
            else if (lbBadGuysList.SelectedItem != null)
            {
                lbBadGuysList.Items.Remove(lbBadGuysList.SelectedItem);
                lbBadGuysList.Refresh();
            }
            else
            {
                MessageBox.Show(("No Item Selected"));
            }
        }
    }
}
