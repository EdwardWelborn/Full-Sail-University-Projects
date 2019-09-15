using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelegatesWinFormsDemo
{
    
    public partial class FrmDialog : Form
    {
        //Declare delagete callback function, the owner of communication
        public AddItemDelegate AddItemCallback;
        public FrmDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemCallback(txtItem.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}