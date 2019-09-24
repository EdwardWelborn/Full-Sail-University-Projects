using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace EdwardWelborn_CE08
{
    public partial class MainForm : Form
    {
        //list to hold the stock data
        private readonly List<TradeQuote> newData;
        // variable to manage the List index
        int index;
        // add variables to be used throughout the process
        WebClient apiConnection = new WebClient();
        // create a string to hold the start of the API
        // apikey=951127dd655eeef190d9a3285b31e7cb
        private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.xml?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        // string to hold the completed API
        // unique Identifier
        // private string uniqueIdentifier = "bb75bb6f59198fa85943cec05f25d64d";
        // private string apiEndpoint;
        //string to hold the completed API
        public string apiEndPoint;

/*       public TradeQuote data
        {
            get
            {
                TradeQuote d = new TradeQuote();
                d.Name = CompanyName_TextBox.Text;
                d.Symbol = Symbol_textBox.Text;
                d.LastPrice = lastPrice_numericUpDown.Value;
                d.OpeningPrice = openingPrice_numericUpDown.Value;
                d.HighPrice = highPrice_numbericUpDown.Value;
                d.LowPrice = lastPrice_numericUpDown.Value;

                return d;
            }

            set
            {
                CompanyName_TextBox.Text = value.Name;
                Symbol_textBox.Text = value.Symbol;
                lastPrice_numericUpDown.Value = value.LastPrice;
                openingPrice_numericUpDown.Value = value.OpeningPrice;
                highPrice_numbericUpDown.Value = value.HighPrice;
                lowPrice_numericUpDown.Value = value.LowPrice;
            }
        }
        */

        public MainForm()
        {
            InitializeComponent();
            newData = TradeQuote.DataList;
        }
        private OpenFileDialog openFileDialog1;

        // this method will find the stock symbol of the selected company
        //*
        private List<string> ReturnStockSymbols()
        {
            // list to hold the selected stock symbols
            List<string> symbols = new List<string>();

            // array to hold the stock symbols
            string[] stockSymbols = { "AMZN", "GOOG", "AAPL", "NFLX", "FB" };

            // get the corresponding symbols fo the companies selected in the ListBox
            foreach (var i in listBox_StockSelector.SelectedItems)
            {
                symbols.Add(stockSymbols[listBox_StockSelector.Items.IndexOf(i)]);
            }

            return symbols;
        }
        // method to build the API String
        //*
        private void BuildAPI()
        {
            // variable to hold the stock symbols string
            string stringSymbols = "";

            foreach (var sym in ReturnStockSymbols())
            {
                stringSymbols += sym + ",";
            }

            // complete the API string
            apiEndPoint = startingAPI + stringSymbols.TrimEnd(',');

            // DEBUG: Test the API
            textBox1.Text = apiEndPoint;
        }

        private void ReadTheData()
        {
            viewStockData_TreeView.Nodes.Clear();
            string stockName = "";
            string symbol = "";
            decimal lastPrice = 0;
            decimal openingPrice = 0;
            decimal highPrice = 0;
            decimal lowPrice = 0;
            // variable to hold the data

            // get and read the xml
            using (XmlReader apiData = XmlReader.Create(apiEndPoint))
            {
                // loop through xml data
                while (apiData.Read())
                {
                    if (apiData.Name == "name")
                    {
                        stockName = apiData.ReadElementContentAsString();
                    }
                    if (apiData.Name == "symbol")
                    {
                        symbol = apiData.ReadElementContentAsString();
                    }
                    if (apiData.Name == "lastPrice")
                    {
                        lastPrice = apiData.ReadElementContentAsDecimal();
                    }
                    if (apiData.Name == "open")
                    {
                        openingPrice = apiData.ReadElementContentAsDecimal();
                    }
                    if (apiData.Name == "high")
                    {
                        highPrice = apiData.ReadElementContentAsDecimal();
                    }
                    if (apiData.Name == "low")
                    {
                        lowPrice = apiData.ReadElementContentAsDecimal();
                    }

                    textBox1.Text = stockName;
                    openingPrice_numericUpDown.Value = openingPrice;
                    lastPrice_numbericUpDown.Value = lastPrice;
                }
                // populate the controls with the values
                
            }
            //verifying with a try...catch Web connectivity before trying to download the data
            /*            using (XmlReader reader = XmlReader.Create(apiEndPoint))
                        {
                            // loop through xml data
                            while (reader.Read())
                            {
                                if (reader.Name == "name")
                                {
                                    stockName = reader.ReadElementContentAsString();
                                }

                                if (reader.Name == "symbol")
                                {
                                    symbol = reader.ReadElementContentAsString();
                                }

                                if (reader.Name == "lastPrice")
                                {
                                    lastPrice = reader.ReadElementContentAsDecimal();
                                }

                                if (reader.Name == "open")
                                {
                                    openingPrice = reader.ReadElementContentAsDecimal();
                                }

                                if (reader.Name == "high")
                                {
                                    highPrice = reader.ReadElementContentAsDecimal();
                                }

                                if (reader.Name == "low")
                                {
                                    lowPrice = reader.ReadElementContentAsDecimal();
                                }
                                TradeQuote t = new TradeQuote();
                                t.Name = stockName;
                                t.Symbol = symbol;
                                t.LastPrice = lastPrice;
                                t.HighPrice = highPrice;
                                t.OpeningPrice = openingPrice;
                                t.LowPrice = lowPrice;
                                newData.Add(t);
                                textBox1.Text = t.Name;
                            }
                        }
            */
        }

        private void BuildTreeList(List<TradeQuote> tradeQuote)
        {
            // We are going to build the tree list here
            // need to add the images to the index, miles = document, hours = plus, mode = x
            viewStockData_TreeView.Nodes.Clear();
            foreach (var obj in tradeQuote)
            {
                TreeNode rootNode = viewStockData_TreeView.Nodes.Add(obj.Name);
                rootNode.Nodes.Add(obj.Symbol);

                // buid child node
                TreeNode child1 = rootNode.Nodes.Add("last: " + obj.LastPrice);
                child1 = rootNode.Nodes.Add("opening: " + obj.OpeningPrice);
                child1 = rootNode.Nodes.Add("high: " + obj.HighPrice);
                child1 = rootNode.Nodes.Add("low: " + obj.LowPrice);
                textBox1.Text = obj.Name;
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            // clear new_data list and controls form to not overwrite values
            newToolStripMenuItem_Click(this, new EventArgs());
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File-> New menu click option, this will clear the data, and start fresh
            newData.Clear();


            listBox_StockSelector.SelectedItems.Clear();

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            BuildAPI();

            ReadTheData();
            textBox1.Text = newData.Count.ToString();
            BuildTreeList(newData);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < newData.Count - 1)
            {
                index += 1;
 
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index -= 1;

            }
        }


    }
}
