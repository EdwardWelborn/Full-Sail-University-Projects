using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEdwardWelborn_CE09;
using MySql.Data.MySqlClient;
using System.Xml;

namespace EdwardWelborn_CE09
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
            // Retrieve data from database 

            if (!RetrieveData())
            {
                MessageBox.Show("An Error occured while retrieving data");
            }
        }


        private bool RetrieveData()
        {
            // create the SQL statement
            string sqlStatement = "SELECT year, model, make, vclass FROM vehicle ORDER BY make LIMIT 25";
            // create the data adapter
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlStatement, conn);
            // set the type for the SELECT command
            adapter.SelectCommand.CommandType = CommandType.Text;

            // fill method adds rows to math the datasource
            adapter.Fill(dataTable);
            // get count of rows using the select method sending no argument, which gets 
            // an array of the datarow objects
            int numOfRows = dataTable.Select().Length;
            // TODO: year is not populating.. maybe change the control?
            // put the first records data into the form
            year_combobox.Text = dataTable.Rows[0]["year"].ToString();
            make_textbox.Text = dataTable.Rows[0]["make"].ToString();
            model_textBox.Text = dataTable.Rows[0]["model"].ToString();
            class_textBox.Text = dataTable.Rows[0]["vclass"].ToString();
            totalrows_numericUpDown.Value = numOfRows;
            return true;
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            // make sure we don't go past the end
            if (currentRow < dataTable.Select().Length - 1)
            {
                currentRow++;
                year_combobox.Text = dataTable.Rows[currentRow]["year"].ToString();
                make_textbox.Text = dataTable.Rows[currentRow]["make"].ToString();
                model_textBox.Text = dataTable.Rows[currentRow]["model"].ToString();
                class_textBox.Text = dataTable.Rows[currentRow]["vclass"].ToString();
                currentrow_numericUpDown.Value = currentRow + 1;
            }
        }
        private void previous_button_Click(object sender, EventArgs e)
        {
            // make sure we don't go past the end
            if (currentRow > 0)
            {
                currentRow--;
                year_combobox.Text = dataTable.Rows[currentRow]["year"].ToString();
                make_textbox.Text = dataTable.Rows[currentRow]["make"].ToString();
                model_textBox.Text = dataTable.Rows[currentRow]["model"].ToString();
                class_textBox.Text = dataTable.Rows[currentRow]["vclass"].ToString();
                currentrow_numericUpDown.Value = currentRow + 1;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save database to xml
            // TODO: save data to an xml file

        }

        private void first_button_Click(object sender, EventArgs e)
        {
            currentRow = 0;
            // make sure we don't go past the end
            year_combobox.Text = dataTable.Rows[currentRow]["year"].ToString();
            make_textbox.Text = dataTable.Rows[currentRow]["make"].ToString();
            model_textBox.Text = dataTable.Rows[currentRow]["model"].ToString();
            class_textBox.Text = dataTable.Rows[currentRow]["vclass"].ToString();
            currentrow_numericUpDown.Value = 1;
        }

        private void last_button_Click(object sender, EventArgs e)
        {
            currentRow = dataTable.Select().Length - 1;
            // make sure we don't go past the end
                year_combobox.Text = dataTable.Rows[currentRow]["year"].ToString();
                make_textbox.Text = dataTable.Rows[currentRow]["make"].ToString();
                model_textBox.Text = dataTable.Rows[currentRow]["model"].ToString();
                class_textBox.Text = dataTable.Rows[currentRow]["vclass"].ToString();
                currentrow_numericUpDown.Value = currentRow;
        }
    }
}
