/*
* Created by Edward Welborn on 09/06/2019
* Class: Visual Framworks
* Description: Project CE02
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Input Form
* Summary: Input form for the program, here is where the data will be input then sent over to the main form.
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

namespace EdwardWelborn_CE02
{
    public partial class fmInputForm : Form
    {

        public string GoodGuyCount
        {
            set
            {
                tbGoodGuys.Text = value;
            }
        }

        public string BadGuyCount
        {
            set
            {
                tbBadGuys.Text = value;
            }
        }
        public fmInputForm()
        {
            InitializeComponent();
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Deletes the current listbox record
            this.Close();
        }
    }
}
