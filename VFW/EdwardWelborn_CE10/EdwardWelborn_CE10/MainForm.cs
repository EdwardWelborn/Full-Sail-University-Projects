using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace EdwardWelborn_CE10
{
    public partial class MainForm : Form
    {
        // public global database connection
        MySqlConnection conn = new MySqlConnection();
        
        public MainForm()
        {
            InitializeComponent();
            string cs = DBUtils.BuildConnectionString();
            conn = DBUtils.Connect(cs);
            year_numericUpDown.Text = "";
            vehicldID_numericUpDown.Text = "";
            // Retrieve data from database 
            Populate_Listview();
        }

        private void Populate_Listview()
        {
            // create the SQL statement
            string sql = "SELECT vehicleId, make, model, year, vclass FROM vehicle ORDER BY RAND() LIMIT 25";
            // create the data adapter
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader Reader = cmd.ExecuteReader();

            // put the first records data into the form
            dataSelector_listView.Items.Clear();

            dataSelector_listView.View = View.SmallIcon;
            smallIconsToolStripMenuItem.Checked = true;

            while (Reader.Read())
            {
                ListViewItem lv = new ListViewItem(Reader.GetString(1));
                lv.SubItems.Add(Reader.GetInt32(0).ToString());
                lv.SubItems.Add(Reader.GetString(2));
                lv.SubItems.Add(Reader.GetInt32(3).ToString());
                lv.SubItems.Add(Reader.GetString(4));
                lv.ImageIndex = 0;
                dataSelector_listView.Items.Add(lv);
            }
            Reader.Close();
            conn.Close();
        }

        private void dataSelector_listView_DoubleClick(object sender, EventArgs e)
        {
            // populate controls via doubleclick of the dataselector_listview
            if (dataSelector_listView.SelectedItems.Count == 0)
                return;

            ListViewItem item = dataSelector_listView.SelectedItems[0];
            //fill the text boxes
            vehicldID_numericUpDown.Text = item.SubItems[1].Text;
            make_textBox.Text = item.SubItems[0].Text;
            model_textBox.Text = item.SubItems[2].Text;
            year_numericUpDown.Text = item.SubItems[3].Text;
            class_textBox.Text = item.SubItems[4].Text;
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            // Updates the database from the controls entered
            string sql = "UPDATE vehicle set make= @Make, "  + " model= @Model, " +
                         " year= @Year, " + " vclass= @VClass" +
                         " WHERE vehicleId= @VehicleId;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader;
            conn.Open();
            try
            {
                cmd.Parameters.AddWithValue("@VehicleId", vehicldID_numericUpDown.Value);
                cmd.Parameters.AddWithValue("@Make", make_textBox.Text);
                cmd.Parameters.AddWithValue("@Model", model_textBox.Text);
                cmd.Parameters.AddWithValue("@Year", year_numericUpDown.Value);
                cmd.Parameters.AddWithValue("@VClass", class_textBox.Text);
                reader = cmd.ExecuteReader();
                
                reader.Close();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            ListViewItem item = dataSelector_listView.SelectedItems[0];
            //refresh the data in the listview
            item.SubItems[1].Text = vehicldID_numericUpDown.Text;
            item.SubItems[0].Text = make_textBox.Text;
            item.SubItems[2].Text = model_textBox.Text;
            item.SubItems[3].Text = year_numericUpDown.Text;
            item.SubItems[4].Text = class_textBox.Text;

            cancel_button_Click(sender, e);
            dataSelector_listView.Refresh();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            // clears the controls, and '0's out the listview selection
            dataSelector_listView.SelectedItems.Clear();
            vehicldID_numericUpDown.Text = "";
            make_textBox.Text = "";
            model_textBox.Text = "";
            year_numericUpDown.Text = "";
            class_textBox.Text = "";
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (largeIconsToolStripMenuItem.Checked != true)
            {
                largeIconsToolStripMenuItem.Checked = true;
                smallIconsToolStripMenuItem.Checked = false;
                dataSelector_listView.View = View.LargeIcon;
            }
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (smallIconsToolStripMenuItem.Checked != true)
            {
                largeIconsToolStripMenuItem.Checked = false;
                smallIconsToolStripMenuItem.Checked = true;
                dataSelector_listView.View = View.SmallIcon;
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit application from the file>exit menu option
            Application.Exit();
        }
    }
}
