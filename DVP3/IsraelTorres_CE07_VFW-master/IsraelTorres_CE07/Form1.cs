using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

/*
 * Name: Israel Torres
 * Class: Visual Frameworks - Online (MDV1830-O)
 * Term: C201905 01
 * Code Exercise: JSON and Web Connectivity
 * Number: CE07
 */

namespace IsraelTorres_CE07
{
    public partial class Form1 : Form
    {
        // Variables to be used throughout the process
        WebClient apiConnection = new WebClient();
        // string to hold the start of the API
        string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=ab6c71e7427531d8aaa6751bb41f78d6&symbols=";
        //string to hold the completed API
        string apiEndPoint;

        //list to hold the stock data
        private List<Data> new_data = null;

        // variable to manage the List index
        int index = 0;

        // MD5 hash string to make a unique identifier for my text file. It has been creted using my api key with a MD5 generator (https://www.md5hashgenerator.com/)
        string md5Hash = "db8cde68cbeb8635ec1c81d7ded7d1f9";

        public Data data
        {
            get
            {
                Data d = new Data();
                d.StockName = textBoxStockName.Text;
                d.LastPrice = numericUpDownLastPrice.Value;
                d.OpeningPrice = numericUpDownOpeningPrice.Value;
                d.HighPrice = numericUpDownHighPrice.Value;
                d.LowPrice = numericUpDownLowPrice.Value;

                return d;
            }

            set
            {
                textBoxStockName.Text = value.StockName;
                numericUpDownLastPrice.Value = value.LastPrice;
                numericUpDownOpeningPrice.Value = value.OpeningPrice;
                numericUpDownHighPrice.Value = value.HighPrice;
                numericUpDownLowPrice.Value = value.LowPrice;
            }
        }

        public Form1()
        {
            InitializeComponent();

            new_data = Data.DataList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private List<string> ReturnStockSymbols()
        {
            // list to hold the selected stock symbols
            List<string> symbols = new List<string>();

            // array to hold the stock symbols
            string[] stockSymbols = new string[] { "FB", "AMZN", "AAPL", "NFLX", "GOOG" };

            // get the corresponding symbols fo the companies selected in the ListBox
            foreach (var i in listBoxListStocks.SelectedItems)
            {
                symbols.Add(stockSymbols[listBoxListStocks.Items.IndexOf(i)]);
            }

            return symbols;
        }

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

        private void btnDownloadJSON_Click(object sender, EventArgs e)
        {
            BuildAPI();

            ReadTheData();
        }

        // method to get and read the JSON
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
                    Data d = new Data();
                    d.StockName = obj["name"].ToString();
                    d.LastPrice = Convert.ToDecimal(obj["lastPrice"]);
                    d.OpeningPrice = Convert.ToDecimal(obj["open"]);
                    d.HighPrice = Convert.ToDecimal(obj["high"]);
                    d.LowPrice = Convert.ToDecimal(obj["low"]);

                    new_data.Add(d);
                }

                if (index == 0)
                {
                    textBoxStockName.Text = new_data[index].StockName;
                    numericUpDownLastPrice.Value = new_data[index].LastPrice;
                    numericUpDownOpeningPrice.Value = new_data[index].OpeningPrice;
                    numericUpDownHighPrice.Value = new_data[index].HighPrice;
                    numericUpDownLowPrice.Value = new_data[index].LowPrice;
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
                        outStream.WriteLine(md5Hash);

                        // Save the stock data
                        string stringData = "";

                        if(new_data.Count > 0)
                        {
                            foreach (var sData in new_data)
                            {
                                Data d = new Data();
                                d.StockName = sData.StockName;
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

                            if (lines[0] == md5Hash)
                            {
                                string[] stringDataLine = lines[1].Split(',');

                                foreach (var dataLine in stringDataLine)
                                {
                                    string[] value = dataLine.Split('-');

                                    Data d = new Data();
                                    d.StockName = value[0].ToString();
                                    d.LastPrice = Convert.ToDecimal(value[1]);
                                    d.OpeningPrice = Convert.ToDecimal(value[2]);
                                    d.HighPrice = Convert.ToDecimal(value[3]);
                                    d.LowPrice = Convert.ToDecimal(value[4]);

                                    new_data.Add(d);
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
                    textBoxStockName.Text = new_data[index].StockName;
                    numericUpDownLastPrice.Value = new_data[index].LastPrice;
                    numericUpDownOpeningPrice.Value = new_data[index].OpeningPrice;
                    numericUpDownHighPrice.Value = new_data[index].HighPrice;
                    numericUpDownLowPrice.Value = new_data[index].LowPrice;
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_data.Clear();

            textBoxStockName.Text = "";
            numericUpDownLastPrice.Value = 0;
            numericUpDownOpeningPrice.Value = 0;
            numericUpDownHighPrice.Value = 0;
            numericUpDownLowPrice.Value = 0;

            listBoxListStocks.SelectedItems.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (index < new_data.Count - 1)
            {
                index += 1;
                textBoxStockName.Text = new_data[index].StockName;
                numericUpDownLastPrice.Value = new_data[index].LastPrice;
                numericUpDownOpeningPrice.Value = new_data[index].OpeningPrice;
                numericUpDownHighPrice.Value = new_data[index].HighPrice;
                numericUpDownLowPrice.Value = new_data[index].LowPrice;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(index > 0)
            {
                index -= 1;
                textBoxStockName.Text = new_data[index].StockName;
                numericUpDownLastPrice.Value = new_data[index].LastPrice;
                numericUpDownOpeningPrice.Value = new_data[index].OpeningPrice;
                numericUpDownHighPrice.Value = new_data[index].HighPrice;
                numericUpDownLowPrice.Value = new_data[index].LowPrice;
            }
        }
    }
}
