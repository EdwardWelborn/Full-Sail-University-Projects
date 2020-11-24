using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CasimirJustin_Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void HandleClientWindowSize()
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.4f;
            float WidthValueToChange = 6.0f;

            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height / HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width / WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);
        }

        //Everything is subscribed here this is where the Forms connect.
        private void buttonInput_Click(object sender, EventArgs e)
        {
            UserInput newWindow = new UserInput();

            newWindow.UpdateHave += Update_Have;
            newWindow.UpdateNeed += Update_Need;


            newWindow.Show();
        }

        // Updates the have list

        private void Update_Have(object sender, EventArgs e)
        {
            UserInput copyData = (UserInput)sender;

            listBoxHave.Items.Add(copyData.textBoxItem.Text);


        }
        
        // Updates the need list
        private void Update_Need(object sender, EventArgs e)
        {
            UserInput copyData = (UserInput)sender;

            listBoxNeed.Items.Add(copyData.textBoxItem.Text);

        }
       
        // deletes selected items.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxHave.SelectedItem != null)
            {
                listBoxHave.Items.Remove(listBoxHave.SelectedItem);
            }
            if (listBoxNeed.SelectedItem != null)
            {
                listBoxNeed.Items.Remove(listBoxNeed.SelectedItem);
            }
        }
        // Changes list
        private void buttonHaveToNeed_Click(object sender, EventArgs e)
        {
            if (listBoxHave.SelectedItem != null)
            {
                listBoxNeed.Items.Add(listBoxHave.SelectedItem);
                listBoxHave.Items.Remove(listBoxHave.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item from the NEED list.");
            }
        }

        //Changes List
        private void buttonNeedToHave_Click(object sender, EventArgs e)
        {
            if (listBoxNeed.SelectedItem != null)
            {
                listBoxHave.Items.Add(listBoxNeed.SelectedItem);
                listBoxNeed.Items.Remove(listBoxNeed.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item from the HAVE list.");
            }
        }

        //Saves both list and labels them
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {


                    sw.WriteLine("HAVE:");

                    foreach (var item in listBoxHave.Items)
                    {
                        sw.WriteLine(item);
                    }
                    sw.WriteLine("");
                    sw.WriteLine("NEED:");

                    foreach (var item in listBoxNeed.Items)
                    {
                        sw.WriteLine(item);
                    }








                }
            }
        }
    }
}


