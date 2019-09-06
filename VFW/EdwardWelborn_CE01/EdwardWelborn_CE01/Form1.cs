using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE01
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            addHovertip((ToolStripStatusLabel)statusStrip.Items[0], this.numericUpDown, "Enter Age");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Closes the Application
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens file dialog to open correct text file.
            string fileContent = string.Empty;
            string filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\VFW\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            //            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //            {
            

                // split line
                

                // Read data list, split the string
                List<string> tempList = new List<string>();
                List<string> splitter = new List<string>();
                splitter.Add(fileContent);
                foreach (string strItem in splitter)
                {
                    char[] splitChar = { '|' };
                    tempList = strItem.Split(splitChar).ToList();
                    
                }

                tbFirstName.Text = tempList[0];
                tbLastName.Text = tempList[1];
                numericUpDown.Text = tempList[2];
                cmbGender.Text = tempList[3];
                if (tempList[4] == "Checked")
                {
                    cbStudent.Checked = true;
                }
                else
                {
                    cbStudent.Checked = false;
                }

//            }
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
                // if the user hits okay, then save data to the file.
                StreamWriter myStreamWriter = new StreamWriter(saveFileDialog1.FileName);
                myStreamWriter.Write(tbFirstName.Text + "|");
                myStreamWriter.Write(tbLastName.Text + "|");
                myStreamWriter.Write(numericUpDown.Text + "|");
                myStreamWriter.Write(cmbGender.Text + "|");
                myStreamWriter.Write(cbStudent.CheckState + "|");
                myStreamWriter.Close();
            }

            //clear form after saving the file

            btnClear_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            numericUpDown.Text = "0";
            cmbGender.Text = "";
            cbStudent.Checked = false;

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

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            
            toolStripStatusLabel1.Text = "Enter Age";
        }

        private void numericUpDown_Leave(object sender, EventArgs e)
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
        public static void addHovertip(ToolStripStatusLabel lb, Control c, string tip)
        {
            c.MouseEnter += (sender, e) =>
            {
                // Debug.WriteLine(String.Format("enter {0}", c));
                lb.Text = tip;
            };

            c.MouseLeave += (sender, e) =>
            {
                // Debug.WriteLine(String.Format("Leave {0}", c));
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
    }
}
