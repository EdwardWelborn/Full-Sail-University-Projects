using System;
using System.Data;
using System.Windows.Forms;
// add directive to use newtonsoft json package
using Newtonsoft.Json.Linq;
// add directive to include web connectivity
using System.Net;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace EdwardWelborn_CE07
{
    public partial class MainForm : Form
    {
        // add variables to be used throughout the process
        WebClient apiConnection = new WebClient();
        // create a string to hold the start of the API
        // apikey=951127dd655eeef190d9a3285b31e7cb
        private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        // string to hold the completed API
        private string apiEndpoint;

        public MainForm()
        {
            InitializeComponent();
        }

        // this method will find the stock symbol of the selected company
        private string ReturnStockSymbol(int i)
        {
            // variable to hold the stop symbol
            string symbol = "";
            // array to hold the stock symbols we want to use
            string[] stockSymbols = new[] {"AMZN", "GOOG", "AAPL", "NFLX", "FB"};
            // get the corresponding symbol for the company selected in combobox
            symbol = stockSymbols[i];
            return symbol;
        }
        // method to build the API String
        private string BuildAPI(int i)
        {
            // variable to hold stock symbol
            string symbol = ReturnStockSymbol(i);
            // Complete the API String
            apiEndpoint = startingAPI + symbol;
            return symbol;
        }

        // method to get and read the data
        private void ReadData(string symbol)
        {
            string apiData = apiConnection.DownloadString(startingAPI + symbol);

            
            // DEBUG: messagebox to display the data
            MessageBox.Show("The String: \n" + apiData);
            // parse the data string to a JObject
            JObject o = JObject.Parse(apiData);
            // string to hold the specific data from the json
            string specifics = o.ToString();
            // DEBUG: messagebox to show the object
            MessageBox.Show("The JObject: \n" + specifics);

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File-> Load Menu Click option, this will load the json file

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File->Save menu click option, this will save the data to a json file
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File-> New menu click option, this will clear the data, and start fresh
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            string item = "";
            string symbol;
            foreach (int i in lstStockSelector.SelectedIndices)
            {
                item += lstStockSelector.Items[i] + Environment.NewLine;
                // DEBUG: checking to see if we get the right information
                MessageBox.Show(item);
                symbol = BuildAPI(i);
                ReadData(symbol);
            }
        }
    }
}
// TODO: Check that the system received the data response: 200, otherwise show error

