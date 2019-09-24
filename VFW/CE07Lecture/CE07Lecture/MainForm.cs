using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CE07Lecture
{

    public partial class MainForm : Form
    {
        // apikey=951127dd655eeef190d9a3285b31e7cb
        private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        WebClient apiConnection = new WebClient();
        private string apiEndpoint;

        public MainForm()
        {
            InitializeComponent();
        }

        // method to find the stock symbol of the selected company
        private string ReturnStockSymbol()
        {
            // variable string to hold the stock symbol
            string symbol = "";

            // array of the stock symbols
            string[] stockSymbols = new string[] {"AMZN", "AAPL", "GOOG", "NFLX", "FB", "DELL"};

            // get the corresponding symbol for the company selected in combobox
            symbol = stockSymbols[ChooseStock_ComboBox.SelectedIndex];

            return symbol;

        }
        // method build api string
        private void BuildAPI()
        {
            string symbol = ReturnStockSymbol();
            // complete the API String
            apiEndpoint = startingAPI + symbol;
            // DEBUG: Test the API
            textBox1.Text = apiEndpoint;
        }
        // method to pull and read the data
        private void ReadTheData()
        {
            // variable to hold that data
            var apiData = apiConnection.DownloadString(apiEndpoint);
            // DEBUG: create a message box to display data recieved
            MessageBox.Show("The String: \n" + apiData);
            // parse the data as a json object
            JObject o = JObject.Parse(apiData);

            // string to hold specific data frm the JSON
            string specifics = o.ToString();

            // DEBUG: create a message box to display that in JSON format
            MessageBox.Show(specifics);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ViewStock_Button_Click(object sender, EventArgs e)
        {
            // invoke the API Builder
            BuildAPI();
            // invoke the method to get the data
            ReadTheData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChooseStock_ComboBox.SelectedIndex = 0;
        }
    }
}
