using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DelegatesWinFormsDemo
{
    public partial class FrmChild1 : Form
    {
        private static int _id = 0;
        public FrmChild1()
        {
            InitializeComponent();
            _id++;
            this.Text += " [" + _id.ToString() + "]";
        }

        public void SetParamValueCallbackFn(string param)
        {
            txtParam.Text = param;
        }
    }
}