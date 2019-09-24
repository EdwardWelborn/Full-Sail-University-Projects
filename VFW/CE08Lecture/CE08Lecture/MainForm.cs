using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// add directive to use newtonsoft json package
using Newtonsoft.Json.Linq;
// add directive to include web connectivity
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace CE08Lecture
{
    public partial class MainForm : Form
    {
        // apikey=951127dd655eeef190d9a3285b31e7cb
//      DEBUG: original String
//      private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        private string startingAPIPart1 = "https://marketdata.websol.barchart.com/getQuote.";
        private string startingAPIPart2 = "?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
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
            string[] stockSymbols = new string[] { "AMZN", "AAPL", "GOOG", "NFLX", "FB", "DELL" };

            // get the corresponding symbol for the company selected in combobox
            symbol = stockSymbols[ChooseStock_ComboBox.SelectedIndex];

            return symbol;

        }
        // method build api string
        private void BuildAPI()
        {
            string symbol = ReturnStockSymbol();

            string jsonOrXml = "xml";
            if (JSon_radioButton.Checked)
            {
                jsonOrXml = "json";
            }
            // complete the API String
            apiEndpoint = startingAPIPart1 + jsonOrXml + startingAPIPart2 + symbol;
            // DEBUG: Test the API
//            textBox1.Text = apiEndpoint;
        }
        // method to pull and read the data
        private void ReadTheJsonData()
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

        private void ReadTheXMLData()
        {
            // variable to hold the data
            decimal lastPrice = 0;
            decimal openingPrice = 0;
            // get and read the xml
            using (XmlReader apiData = XmlReader.Create(apiEndpoint))
            {
                // loop through xml data
                while (apiData.Read())
                {
                    if (apiData.Name == "lastPrice")
                    {
                        lastPrice = apiData.ReadElementContentAsDecimal();
                        
                    }
                    if (apiData.Name == "open")
                    {
                        openingPrice = apiData.ReadElementContentAsDecimal();
                    }
                }
                // populate the controls with the values
                lastPrice_numbericUpDown.Value = lastPrice;
                openingPrice_numericUpDown.Value = openingPrice;
            }
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
            if (JSon_radioButton.Checked)
            {
                ReadTheJsonData();
            }
            else
            {
                ReadTheXMLData();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChooseStock_ComboBox.SelectedIndex = 0;
        }

        private void saveAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // instantiate a save dialog
            SaveFileDialog dlg = new SaveFileDialog();
            // add default extention as xml
            dlg.DefaultExt = "xml";
            // if user clicks ok
            if (DialogResult.OK == dlg.ShowDialog())
            {
                // instantiate a xmlwritersettings object
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.Indent = true;

                // create the xmlwriter
                using (XmlWriter writer = XmlWriter.Create(dlg.FileName, settings))
                {
                    // firest element we want to write what the xml document contains
                    writer.WriteStartElement("StockData");
                    // save the name of the stock
                    writer.WriteElementString("Stock", ChooseStock_ComboBox.SelectedItem.ToString());
                    // write the new element for the last price
                    writer.WriteElementString("Last", lastPrice_numbericUpDown.Text);
                    // write the new element for the opening price
                    writer.WriteElementString("open", openingPrice_numericUpDown.Text);
                    // write the end element for the data
                    writer.WriteEndElement();

                }
            }
        }

        private void loadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the dialog
            OpenFileDialog dlg = new OpenFileDialog();
            // verify user clicked ok
            if (DialogResult.OK == dlg.ShowDialog())
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                // start reading
                using (XmlReader reader = XmlReader.Create(dlg.FileName, settings))
                {
                    // skip meta data
                    reader.MoveToContent();
                    // verify that this is the correct data
                    if (reader.Name != "StockData")
                    {
                        // tell the user this is not the right data
                        MessageBox.Show("This is not the correct stock data");
                        return;
                    }
                    // if it is the correct data, we can keep going
                    while (reader.Read())
                    {
                        // because there might be some other data other than last, or open, make sure 
                        // we are seeing out data
                        if (reader.Name == "Stock" && reader.IsStartElement())
                        {
                            ChooseStock_ComboBox.Text = reader.ReadElementContentAsString();
                        }

                        if (reader.Name == "Last" && reader.IsStartElement())
                        {
                            lastPrice_numbericUpDown.Value = reader.ReadElementContentAsDecimal();
                        }
                        if (reader.Name == "Open" && reader.IsStartElement())
                        {
                            openingPrice_numericUpDown.Value = reader.ReadElementContentAsDecimal();
                        }
                    }
                }
            }
        }
    }
}
