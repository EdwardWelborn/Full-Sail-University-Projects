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

namespace EdwardWelborn_CE10
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
            string cs = DBUtils.BuildConnectionString();
            conn = DBUtils.Connect(cs);
            // Retrieve data from database 
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
