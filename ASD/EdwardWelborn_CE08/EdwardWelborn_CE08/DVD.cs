using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EdwardWelborn_CE08
{
    class DVD
    {
        string _title = string.Empty;
        decimal _price = 0;
        float _rating = 0;
        
        public DVD(string Title, decimal Price, float Rating)
        {
            _title = Title;
            _price = Price;
            _rating = Rating;
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public decimal Price
        {
            get
            {
                return _price;
            }
        }
        public float Rating
        {
            get
            {
                return _rating;
            }
        }
        public override string ToString()
        {

            string dvdString = $"{this.Title,-70} ${this.Price,-15} {this.Rating}";
            return dvdString;
        }
    }
}
