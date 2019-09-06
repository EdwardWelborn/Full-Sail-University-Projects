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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE02
{
    public partial class fmMain : Form
    {
        
        public fmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
