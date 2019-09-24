using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EdwardWelborn_CE08
{
    public class TradeQuote
    {
        private string name;
        private string symbol;
        private decimal lastPrice;
        private decimal openingPrice;
        private decimal highPrice;
        private decimal lowPrice;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Symbol
        {
            get => symbol;
            set => symbol = value;
        }

        public decimal LastPrice
        {
            get => lastPrice;
            set => lastPrice = value;
        }

        public decimal OpeningPrice
        {
            get => openingPrice;
            set => openingPrice = value;
        }
        public decimal HighPrice
        {
            get => highPrice;
            set => highPrice = value;
        }
        public decimal LowPrice
        {
            get => lowPrice;
            set => lowPrice = value;
        }
        public override string ToString()
        {
            string quoteString = Name + "-" + Symbol + "-" + LastPrice + "-" + OpeningPrice + "-" + HighPrice + "-" + LowPrice;
            return quoteString;
        }
        public static readonly List<TradeQuote> _Data = new List<TradeQuote>();

        public static List<TradeQuote> DataList
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
