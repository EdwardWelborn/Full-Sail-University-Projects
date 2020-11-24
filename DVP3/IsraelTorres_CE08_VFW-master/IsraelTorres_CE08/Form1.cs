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

/*
 * Name: Israel Torres
 * Class: Visual Frameworks - Online (MDV1830-O)
 * Term: C201905 01
 * Code Exercise: XML and TreeViews
 * Number: CE08
 */

namespace IsraelTorres_CE08
{
    public partial class Form1 : Form
    {
        // Variables to be used throughout the process
        WebClient apiConnection = new WebClient();
        // string to hold the start of the API
        string startingAPI = "https://marketdata.websol.barchart.com/getQuote.xml?apikey=ab6c71e7427531d8aaa6751bb41f78d6&symbols=";
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
                return d;
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

            BuildTree();
        }

        // method to get and read the XML
        private void ReadTheData()
        {
            //verifying with a try...catch Web connectivity before trying to download the data
            try
            {
                XmlDocument apiData = new XmlDocument();
                apiData.Load(apiEndPoint);

                foreach (XmlNode node in apiData.DocumentElement)
                {
                    if (node.Name == "item")
                    {
                        Data d = new Data();

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "name")
                            {
                                d.StockName = child.InnerText;
                            }
                            if (child.Name == "lastPrice")
                            {
                                d.LastPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "open")
                            {
                                d.OpeningPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "high")
                            {
                                d.HighPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "low")
                            {
                                d.LowPrice = Convert.ToDecimal(child.InnerText);
                            }

                            if (!new_data.Contains(d))
                            {
                                new_data.Add(d);
                            }
                            
                        }
                    }
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

        private void BuildTree()
        {
            treeView1.Nodes.Clear();

            foreach (var itemList in new_data)
            {
                TreeNode node = new TreeNode();
                Data d = itemList as Data;

                node.Text = d.StockName;
                switch (d.StockName)
                {
                    case "Facebook Inc":
                        node.ImageIndex = 0;
                        break;
                    case "Amazon.com Inc":
                        node.ImageIndex = 1;
                        break;
                    case "Apple Inc":
                        node.ImageIndex = 2;
                        break;
                    case "Netflix Inc":
                        node.ImageIndex = 3;
                        break;
                    case "Alphabet Class C":
                        node.ImageIndex = 4;
                        break;
                    default:
                        break;
                }
                node.SelectedImageIndex = 5;
                node.Nodes.Add("Last Price: " + d.LastPrice);
                node.Nodes.Add("Opening Price: " + d.OpeningPrice);
                node.Nodes.Add("High Price: " + d.HighPrice);
                node.Nodes.Add("Low Price: " + d.LowPrice);
                node.Nodes[0].ImageIndex = 6;
                node.Nodes[0].SelectedImageIndex = 5;
                node.Nodes[1].ImageIndex = 7;
                node.Nodes[1].SelectedImageIndex = 5;
                node.Nodes[2].ImageIndex = 8;
                node.Nodes[2].SelectedImageIndex = 5;
                node.Nodes[3].ImageIndex = 9;
                node.Nodes[3].SelectedImageIndex = 5;

                treeView1.Nodes.Add(node);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_data.Clear();
            treeView1.Nodes.Clear();
            listBoxListStocks.SelectedItems.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.DefaultExt = "xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // instantiate an XmlWriterSettings object
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;

                // set the indent to true
                settings.Indent = true;

                // create the XmlWriter
                using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName, settings))
                {
                    if (new_data.Count > 0)
                    {
                        // write the unique indentifier
                        writer.WriteStartElement(md5Hash);

                        foreach (var item in new_data)
                        {
                            // write the unique indentifier
                            writer.WriteStartElement("item");

                            writer.WriteElementString("name", item.StockName);
                            writer.WriteElementString("lastPrice", item.LastPrice.ToString());
                            writer.WriteElementString("open", item.OpeningPrice.ToString());
                            writer.WriteElementString("high", item.HighPrice.ToString());
                            writer.WriteElementString("low", item.LowPrice.ToString());
                            
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }
                    else
                    {
                        MessageBox.Show("There is no data to save.");
                    }
                    
                }
            }

            // clear new_data list and controls form to not overwrite values
            newToolStripMenuItem_Click(this, new EventArgs());
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;

                // reader gets only the XML data
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;

                // start reading
                XmlDocument reader = new XmlDocument();
                reader.Load(openFileDialog.FileName);

                // verify that this is our data
                if (reader.DocumentElement.Name != md5Hash)
                {
                    MessageBox.Show("This is not the correct stock data!");
                    return;
                }

                foreach (XmlNode node in reader.DocumentElement)
                {
                    if (node.Name == "item")
                    {
                        Data d = new Data();

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name == "name")
                            {
                                d.StockName = child.InnerText;
                            }
                            if (child.Name == "lastPrice")
                            {
                                d.LastPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "open")
                            {
                                d.OpeningPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "high")
                            {
                                d.HighPrice = Convert.ToDecimal(child.InnerText);
                            }
                            if (child.Name == "low")
                            {
                                d.LowPrice = Convert.ToDecimal(child.InnerText);
                            }

                            if (!new_data.Contains(d))
                            {
                                new_data.Add(d);
                            }

                        }
                    }
                }

                BuildTree();
            }
        }
    }
}
