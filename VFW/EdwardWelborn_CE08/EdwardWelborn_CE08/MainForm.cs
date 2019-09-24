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
        private List<TradeQuote> newData;
        // variable to manage the List index
        int index;
        // add variables to be used throughout the process
        WebClient apiConnection = new WebClient();
        // create a string to hold the start of the API
        // apikey=951127dd655eeef190d9a3285b31e7cb
        private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.xml?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        // string to hold the complete api string
        public string apiEndPoint;



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
           // textBox1.Text = apiEndPoint;
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
            List<string> xmlData = new List<string>();
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
                    
                }
            }
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
                // textBox1.Text = obj.Name;
                viewStockData_TreeView.Nodes.Add(child1);

            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNode xmlnode;
            var fileName = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\VFW\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    fileName = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    xmldoc.Load(fileName);
                    xmlnode = xmldoc.ChildNodes[1];
                    viewStockData_TreeView.Nodes.Clear();
                    viewStockData_TreeView.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
                    TreeNode tNode;
                    tNode = viewStockData_TreeView.Nodes[0];
                    AddNode(xmlnode, tNode);
                }
            }
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
            listBox_StockSelector.SelectedItem = -1;

            listBox_StockSelector.SelectedItems.Clear();

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            listBox_StockSelector.SelectedItem = -1;
            BuildAPI();
            ReadTheData();
            // DEBUG: testing the read data method
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

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }
    }
}
