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
// add directive to use newtonsoft json package
using Newtonsoft.Json.Linq;
// add directive to include web connectivity
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CE08Lecture
{
    public partial class Form1 : Form
    {
        WebClient apiConnection = new WebClient();
        // create a string to hold the start of the API
        // apikey=951127dd655eeef190d9a3285b31e7cb
        // DEBUG: private string startingAPI = "https://marketdata.websol.barchart.com/getQuote.json?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        private string startingAPIPart1 = "https://marketdata.websol.barchart.com/getQuote.";
        private string startingAPIPart2 = "?apikey=951127dd655eeef190d9a3285b31e7cb&symbols=";
        // string to hold the completed API
        // unique Identifier
        private string uniqueIdentifier = "bb75bb6f59198fa85943cec05f25d64d";
        // private string apiEndpoint;
        //string to hold the completed API
        string apiEndPoint;
        public Form1()
        {
            InitializeComponent();
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
    }
}
