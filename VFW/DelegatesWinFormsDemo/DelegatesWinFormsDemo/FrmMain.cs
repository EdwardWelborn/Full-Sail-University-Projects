using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelegatesWinFormsDemo
{
    public delegate void SetParameterValueDelegate(string value);
    public delegate void AddItemDelegate(string item);

    public partial class FrmMain : Form
    {
        //Declare delagete callback function, the owner of communication
        public SetParameterValueDelegate SetParameterValueCallback;
        public FrmMain()
        {
            InitializeComponent();
            
        }

        private void btnOpenFrm1_Click(object sender, EventArgs e)
        {
            FrmChild1 frm = new FrmChild1();
            //Subscribe frm for Callback
            this.SetParameterValueCallback += new SetParameterValueDelegate(frm.SetParamValueCallbackFn);
            frm.Show();
        }

        private void btnOpenFrm2_Click(object sender, EventArgs e)
        {
            FrmChild2 frm = new FrmChild2();
            //Subscribe frm for Callback
            this.SetParameterValueCallback += new SetParameterValueDelegate(frm.SetParamValueCallbackFn);
            frm.Show();
        }

        private void txtParam_TextChanged(object sender, EventArgs e)
        {
            //Send Notification to all subscribers
            SetParameterValueCallback(txtParam.Text);
        }

        private void btnScenario2_Click(object sender, EventArgs e)
        {
            FrmDialog dlg = new FrmDialog();
            //Subscribe this form for callback
            dlg.AddItemCallback = new AddItemDelegate(this.AddItemCallbackFn);
            dlg.ShowDialog();
        }

        private void AddItemCallbackFn(string item)
        {
            lstBx.Items.Add(item);
        }
    }
}