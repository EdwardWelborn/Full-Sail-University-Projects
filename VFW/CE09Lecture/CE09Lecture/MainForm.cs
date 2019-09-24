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

namespace CE09Lecture
{
    public partial class MainForm : Form
    {
        // public global database connection
        MySqlConnection conn = new MySqlConnection();
        // variable to indicate the current row
        int currentRow = 0;
        // instantiate the data table to hold the recordset
        DataTable dataTable = new DataTable();
        public MainForm()
        {
            InitializeComponent();
            // invoke the connectionmethd
            string cs = DBUtils.BuildConnectionString();
            conn = DBUtils.Connect(cs);

            RetrieveData();
        }
        // method to retrieved data
        private bool RetrieveData()
        {
            // create the SQL statement
            string sqlStatement = "SELECT title, releaseDate FROM item LIMIT 10";
            // create the data adapter
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStatement, conn);
            // set the type for the SELECT command
            adapter.SelectCommand.CommandType = CommandType.Text;
 
            // fill method adds rows to math the datasource
            adapter.Fill(dataTable);
            // get count of rows using the select method sending no argument, which gets 
            // an array of the datarow objects
            int numOfRows = dataTable.Select().Length;

            // put the first records data into the form
            title_textbox.Text = dataTable.Rows[0]["title"].ToString();
            releaseDate_textbox.Text = dataTable.Rows[0]["releaseDate"].ToString();
            rows_Label.Text = numOfRows.ToString();

            return true;
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            // make sure we don't go past the end
            if (currentRow < dataTable.Select().Length- 1)
            {

                next_button.Visible = true;
                currentRow++;
                title_textbox.Text = dataTable.Rows[currentRow]["title"].ToString();
                releaseDate_textbox.Text = dataTable.Rows[currentRow]["releaseDate"].ToString();
            }
            else
            {
                next_button.Visible = false;
            }
        }

    }
}
