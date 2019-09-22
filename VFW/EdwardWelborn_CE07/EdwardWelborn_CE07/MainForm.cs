using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
// add directive to use newtonsoft json package
using Newtonsoft.Json.Linq;
// add directive to include web connectivity
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace EdwardWelborn_CE07
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
        private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        // string to hold the completed API
        // unique Identifier
        private string uniqueIdentifier = "bb75bb6f59198fa85943cec05f25d64d";
        // private string apiEndpoint;
        //string to hold the completed API
        string apiEndPoint;

        public TradeQuote data
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
        public MainForm()
        {
            InitializeComponent();
            newData = TradeQuote.DataList;
        }
        private OpenFileDialog openFileDialog1;

        // this method will find the stock symbol of the selected company
        private List<string> ReturnStockSymbols()
        {
            // list to hold the selected stock symbols
            List<string> symbols = new List<string>();

            // array to hold the stock symbols
            string[] stockSymbols = {"AMZN", "GOOG", "AAPL", "NFLX", "FB"};

            // get the corresponding symbols fo the companies selected in the ListBox
            foreach (var i in listBox_StockSelector.SelectedItems)
            {
                symbols.Add(stockSymbols[listBox_StockSelector.Items.IndexOf(i)]);
            }

            return symbols;
        }
        // method to build the API String
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
            //textBox1.Text = apiEndPoint;
        }

        private void ReadTheData()
        {
            //verifying with a try...catch Web connectivity before trying to download the data
            try
            {
                var apiData = apiConnection.DownloadString(apiEndPoint);

                // parse the data string to a JObject
                JObject jobj = JObject.Parse(apiData);

                foreach (var obj in jobj["results"])
                {
                    TradeQuote d = new TradeQuote();
                    d.Name = obj["name"].ToString();
                    d.Symbol = obj["symbol"].ToString();
                    d.LastPrice = Convert.ToDecimal(obj["lastPrice"]);
                    d.OpeningPrice = Convert.ToDecimal(obj["open"]);
                    d.HighPrice = Convert.ToDecimal(obj["high"]);
                    d.LowPrice = Convert.ToDecimal(obj["low"]);

                    newData.Add(d);
                }

                if (index == 0)
                {

                    CompanyName_TextBox.Text = newData[index].Name;
                    Symbol_textBox.Text = newData[index].Symbol;
                    lastPrice_numericUpDown.Value = newData[index].LastPrice;
                    openingPrice_numericUpDown.Value = newData[index].OpeningPrice;
                    highPrice_numbericUpDown.Value = newData[index].HighPrice;
                    lowPrice_numericUpDown.Value = newData[index].LowPrice;
                }
            }
            catch (Exception wex)
            {
                if (wex is WebException)
                {
                    MessageBox.Show(wex.Message);
                    return;
                }
                else
                    throw;
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
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
                        //load character data
                        using (StreamReader inStrean = new StreamReader(fileStream))
                        {
                            string[] lines = File.ReadAllLines(filePath);

                            if (lines[0] == uniqueIdentifier)
                            {
                                string[] stringDataLine = lines[1].Split(',');

                                foreach (var dataLine in stringDataLine)
                                {
                                    string[] value = dataLine.Split('-');

                                    TradeQuote d = new TradeQuote();
                                    d.Name = value[0].ToString();
                                    d.Symbol = value[1].ToString();
                                    d.LastPrice = Convert.ToDecimal(value[2]);
                                    d.OpeningPrice = Convert.ToDecimal(value[3]);
                                    d.HighPrice = Convert.ToDecimal(value[4]);
                                    d.LowPrice = Convert.ToDecimal(value[5]);

                                    newData.Add(d);
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                if (index == 0)
                {
                    CompanyName_TextBox.Text = newData[index].Name;
                    Symbol_textBox.Text = newData[index].Symbol;
                    lastPrice_numericUpDown.Value = newData[index].LastPrice;
                    openingPrice_numericUpDown.Value = newData[index].OpeningPrice;
                    highPrice_numbericUpDown.Value = newData[index].HighPrice;
                    lowPrice_numericUpDown.Value = newData[index].LowPrice;
                }
            }
            catch (Exception err)
            {
                if (err is ArgumentOutOfRangeException)
                {
                    MessageBox.Show("You have encountered an error: Please load the correct file");
                    return;
                }
                else
                    throw;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream saveStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((saveStream = saveFileDialog.OpenFile()) != null)
                {
                    //save data
                    using (StreamWriter outStream = new StreamWriter(saveStream))
                    {
                        // Save an string key as unique identifier of the text file
                        outStream.WriteLine(uniqueIdentifier);

                        // Save the stock data
                        string stringData = "";

                        if (newData.Count > 0)
                        {
                            foreach (var sData in newData)
                            {
                                TradeQuote d = new TradeQuote();
                                d.Name = sData.Name;
                                d.Symbol = sData.Symbol;
                                d.LastPrice = sData.LastPrice;
                                d.OpeningPrice = sData.OpeningPrice;
                                d.HighPrice = sData.HighPrice;
                                d.LowPrice = sData.LowPrice;

                                stringData += d.ToString() + ",";
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no data to save.");
                        }
                        outStream.WriteLine(stringData.TrimEnd(','));
                    }
                    saveStream.Close();
                }
            }
            // clear new_data list and controls form to not overwrite values
            newToolStripMenuItem_Click(this, new EventArgs());
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // File-> New menu click option, this will clear the data, and start fresh
            newData.Clear();
            CompanyName_TextBox.Text = "";
            Symbol_textBox.Text = "";
            lastPrice_numericUpDown.Value = 0;
            openingPrice_numericUpDown.Value = 0;
            highPrice_numbericUpDown.Value = 0;
            lowPrice_numericUpDown.Value = 0;

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
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < newData.Count - 1)
            {
                index += 1;
                CompanyName_TextBox.Text = newData[index].Name;
                Symbol_textBox.Text = newData[index].Symbol;
                lastPrice_numericUpDown.Value = newData[index].LastPrice;
                openingPrice_numericUpDown.Value = newData[index].OpeningPrice;
                highPrice_numbericUpDown.Value = newData[index].HighPrice;
                lowPrice_numericUpDown.Value = newData[index].LowPrice;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index -= 1;
                CompanyName_TextBox.Text = newData[index].Name;
                Symbol_textBox.Text = newData[index].Symbol;
                lastPrice_numericUpDown.Value = newData[index].LastPrice;
                openingPrice_numericUpDown.Value = newData[index].OpeningPrice;
                highPrice_numbericUpDown.Value = newData[index].HighPrice;
                lowPrice_numericUpDown.Value = newData[index].LowPrice;
            }
        }
    }
}


