using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace OteroJoshua_CE02
{
    public partial class Form1 : Form
    {
        // Set's up a MySqlConnection
        MySqlConnection conn = new MySqlConnection();
        // Set's up a Data Table to store Database information
        DataTable tableData = new DataTable();

        public Form1()
        {
            InitializeComponent();
            // Starts the Combo Box on Movie instead of being empty

            //invoke the method to build the connection string
            string connString = DBUtilities.BuildConnectionString();

            // Invoke the method to make the connect
            conn = DBUtilities.Connect(connString);

            // If RetrieveData returns false, automatically closes the application
            if (RetrieveData() == false)
            {
                Environment.Exit(1);
            }
        }

        // method to retrieve data
        private bool RetrieveData()
        {
            try
            {
                // create the SQL statement with a Limit of 10
                string sql = "SELECT Title, YearReleased, Publisher, Author, Director, Genre, Icon FROM seriestitles LIMIT 10;";

                // Create the data adapter
                MySqlDataAdapter adr = new MySqlDataAdapter(sql, conn);

                // set the type for the SELECT command
                adr.SelectCommand.CommandType = CommandType.Text;


                // The Fill method adds rows to match the data source
                adr.Fill(tableData);

                // we can also get a count of the rows
                int numOfRows = tableData.Select().Length;

                // now we can fill in the form
                txtTitle.Text = tableData.Rows[0]["title"].ToString();

                txtRelease.Text = DateTime.Parse(tableData.Rows[0]["YearReleased"].ToString()).ToString("MMMM dd, yyyy");

                txtPublisher.Text = tableData.Rows[0]["publisher"].ToString();

                txtAuthor.Text = tableData.Rows[0]["author"].ToString();

                txtDirector.Text = tableData.Rows[0]["director"].ToString();

                txtGenre.Text = tableData.Rows[0]["Genre"].ToString();

                cmbIcon.SelectedIndex = int.Parse(tableData.Rows[0]["Icon"].ToString());
                // For Loop to enter all data from database into List View
                for (int i = 0; i < tableData.Select().Length; i++)
                {
                    Series newSeries = new Series();
                    newSeries.Title = tableData.Rows[i]["title"].ToString();

                    newSeries.ReleaseDate = DateTime.Parse(tableData.Rows[i]["YearReleased"].ToString()).ToString("MMMM dd, yyyy");

                    newSeries.Publisher = tableData.Rows[i]["publisher"].ToString();

                    newSeries.Author = tableData.Rows[i]["author"].ToString();

                    newSeries.Director = tableData.Rows[i]["director"].ToString();

                    newSeries.Genre = tableData.Rows[i]["Genre"].ToString();

                    newSeries.Icon = int.Parse(tableData.Rows[i]["Icon"].ToString());
                    // Create List View Item to populate List View
                    ListViewItem lvi = new ListViewItem();

                    lvi.Text = newSeries.ToString();
                    // add the obnject to the Tag property
                    lvi.Tag = newSeries;
                    // add the ImageIndex to the ListViewItem
                    lvi.ImageIndex = newSeries.Icon;
                    // add the ListViewItem to the ListView
                    lvfData.Items.Add(lvi);
                }

                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No Database Connection, Program will not run.");
                return false;
            }

            


        }

        private void lvfData_DoubleClick(object sender, EventArgs e)
        {
            // Creates a Series Object and populates it with the data from the list view object clicked
            Series newSeries = (Series)lvfData.SelectedItems[0].Tag;
            // Then sends all the data recieved into the fields
            txtTitle.Text = newSeries.Title;
            txtRelease.Text = newSeries.ReleaseDate;
            txtPublisher.Text = newSeries.Publisher;
            txtAuthor.Text = newSeries.Author;
            txtDirector.Text = newSeries.Director;
            txtGenre.Text = newSeries.Genre;
            cmbIcon.SelectedIndex = newSeries.Icon;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pntDialog.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Series newSeries = new Series();
            // Then recieves all the data from the fields to use in the update process of both list view and database
            newSeries.Title = txtTitle.Text;
            newSeries.ReleaseDate = txtRelease.Text;
            newSeries.Publisher = txtPublisher.Text;
            newSeries.Author = txtAuthor.Text;
            newSeries.Director = txtDirector.Text;
            newSeries.Genre = txtGenre.Text;
            newSeries.Icon = cmbIcon.SelectedIndex;
            try
            {
                // Check to make sure the date is able to be entered in the database. If it cannot an error will inform the user to check the date.
                DateTime check = DateTime.Parse(newSeries.ReleaseDate);
                // checks if a connection is open and then Updates the database
                if (conn.State == ConnectionState.Open)
                {
                    
                    string stm = "Update seriestitles SET title = @title, YearReleased = @year, Publisher = @pub, Author = @author, Director = @direct, Genre = @genre, Icon = @icon WHERE title = @title";

                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.Parameters.AddWithValue("@title", newSeries.Title);
                    cmd.Parameters.AddWithValue("@year", DateTime.Parse(newSeries.ReleaseDate));
                    cmd.Parameters.AddWithValue("@pub", newSeries.Publisher);
                    cmd.Parameters.AddWithValue("@author", newSeries.Author);
                    cmd.Parameters.AddWithValue("@direct", newSeries.Director);
                    cmd.Parameters.AddWithValue("@genre", newSeries.Genre);
                    cmd.Parameters.AddWithValue("@Icon", newSeries.Icon);

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                }
                else
                {
                    conn.Open();
                    string stm = "Update seriestitles SET title = @title, YearReleased = @year, Publisher = @pub, Author = @author, Director = @direct, Genre = @genre, Icon = @icon WHERE title = @title";

                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.Parameters.AddWithValue("@title", newSeries.Title);
                    cmd.Parameters.AddWithValue("@year", DateTime.Parse(newSeries.ReleaseDate));
                    cmd.Parameters.AddWithValue("@pub", newSeries.Publisher);
                    cmd.Parameters.AddWithValue("@author", newSeries.Author);
                    cmd.Parameters.AddWithValue("@direct", newSeries.Director);
                    cmd.Parameters.AddWithValue("@genre", newSeries.Genre);
                    cmd.Parameters.AddWithValue("@Icon", newSeries.Icon);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                    conn.Close();
                }
                // Updates the List View Afterwards
                lvfData.SelectedItems[0].Tag = newSeries;
                lvfData.SelectedItems[0].Text = newSeries.ToString();
                lvfData.SelectedItems[0].ImageIndex = newSeries.Icon;
            }
            catch (Exception er)
            {
                MessageBox.Show("Update Failed, Please Make sure object already exists in List View before Updating.\r\nAlso check the release date and make sure it follows a format of \"yyyy-MM-dd\" or similar formats");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Series newSeries = new Series();
            // Then recieves all the data from the fields to insert into the database and the list view
            newSeries.Title = txtTitle.Text;
            newSeries.ReleaseDate = txtRelease.Text;
            newSeries.Publisher = txtPublisher.Text;
            newSeries.Author = txtAuthor.Text;
            newSeries.Director = txtDirector.Text;
            newSeries.Genre = txtGenre.Text;
            newSeries.Icon = cmbIcon.SelectedIndex;
            try
            {
                // Check to make sure the date is able to be entered in the database. If it cannot an error will inform the user to check the date.
                DateTime check = DateTime.Parse(newSeries.ReleaseDate);
                // checks if a connection is open and then inserts new data into th database.
                if (conn.State == ConnectionState.Open)
                {

                    string stm = "INSERT INTO seriestitles (title, YearReleased, Publisher, Author, Director, Genre, Icon) VALUES (@title, @year, @pub, @author, @direct, @genre, @icon)";

                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.Parameters.AddWithValue("@title", newSeries.Title);
                    cmd.Parameters.AddWithValue("@year", DateTime.Parse(newSeries.ReleaseDate));
                    cmd.Parameters.AddWithValue("@pub", newSeries.Publisher);
                    cmd.Parameters.AddWithValue("@author", newSeries.Author);
                    cmd.Parameters.AddWithValue("@direct", newSeries.Director);
                    cmd.Parameters.AddWithValue("@genre", newSeries.Genre);
                    cmd.Parameters.AddWithValue("@Icon", newSeries.Icon);

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                }
                else
                {
                    conn.Open();
                    string stm = "INSERT INTO seriestitles (title, YearReleased, Publisher, Author, Director, Genre, Icon) VALUES (@title, @year, @pub, @author, @direct, @genre, @icon)";

                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    cmd.Parameters.AddWithValue("@title", newSeries.Title);
                    cmd.Parameters.AddWithValue("@year", DateTime.Parse(newSeries.ReleaseDate));
                    cmd.Parameters.AddWithValue("@pub", newSeries.Publisher);
                    cmd.Parameters.AddWithValue("@author", newSeries.Author);
                    cmd.Parameters.AddWithValue("@direct", newSeries.Director);
                    cmd.Parameters.AddWithValue("@genre", newSeries.Genre);
                    cmd.Parameters.AddWithValue("@Icon", newSeries.Icon);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();
                    conn.Close();
                }
                // Updates the List View Afterwards
                ListViewItem lvi = new ListViewItem();

                lvi.Text = newSeries.ToString();
                // add the obnject to the Tag property
                lvi.Tag = newSeries;
                // add the ImageIndex to the ListViewItem
                lvi.ImageIndex = newSeries.Icon;
                // add the ListViewItem to the ListView
                lvfData.Items.Add(lvi);
            }
            catch (Exception er)
            {
                MessageBox.Show("Update Failed, Please Make sure object already exists in List View before Updating.\r\nAlso check the release date and make sure it follows a format of \"yyyy-MM-dd\" or similar formats");
            }
        }
    }
}
