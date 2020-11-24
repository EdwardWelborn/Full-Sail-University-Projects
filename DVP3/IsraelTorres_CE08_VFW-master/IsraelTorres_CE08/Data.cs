using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Israel Torres
 * Class: Visual Frameworks - Online (MDV1830-O)
 * Term: C201905 01
 * Code Exercise: XML and TreeViews
 * Number: CE08
 */

namespace IsraelTorres_CE08
{
    public class Data
    {
        private string _stockName;
        private decimal _lastPrice;
        private decimal _openingPrice;
        private decimal _highPrice;
        private decimal _lowPrice;

        public string StockName
        {
            get { return _stockName; }
            set { _stockName = value; }
        }
        public decimal LastPrice
        {
            get { return _lastPrice; }
            set { _lastPrice = value; }
        }
        public decimal OpeningPrice
        {
            get { return _openingPrice; }
            set { _openingPrice = value; }
        }
        public decimal HighPrice
        {
            get { return _highPrice; }
            set { _highPrice = value; }
        }
        public decimal LowPrice
        {
            get { return _lowPrice; }
            set { _lowPrice = value; }
        }

        public override string ToString()
        {
            return StockName + "-" + LastPrice + "-" + OpeningPrice + "-" + HighPrice + "-" + LowPrice;
        }

        public static readonly List<Data> _Data = new List<Data>();

        public static List<Data> DataList
        {
            get
            {
                if (_Data.Count < 1)
                {
                    //Load Data data
                }
                return _Data;
            }
        }
    }
}
