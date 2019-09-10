using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelbornEdward_CE03
{
    public partial class fmList : Form
    {
        private fmMain frmMain;
        public fmList(fmMain frmMain)
        {
            this.frmMain = frmMain;
        }

        public fmList()
        {
            InitializeComponent();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // send data from item selected to the main form
        }

        private void lbDataList_DoubleClick(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            List<string> splitter = new List<string>();
            
            if (lbDataList.SelectedItem != null)
            {
                splitter.Add(lbDataList.SelectedItem.ToString());
                foreach (string strItem in splitter)
                {
                    char[] splitChar = { ' ', ',' };
                    tempList = strItem.Split(splitChar).ToList();
                    foreach (var item in tempList)
                    {
                        frmMain.tbFirstName.Text = tempList[0];
                        frmMain.tbLastName.Text = tempList[1];
                        frmMain.udAge.Text = tempList[2];
                        frmMain.cmbGender.Text = tempList[3];
                        frmMain.chkbStudent.Checked = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
            // frmMain.Show();
        }
    }
}
