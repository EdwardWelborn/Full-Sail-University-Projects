// Edward Welborn
// 10/17/2018
// Custom Class Assignment
// SDI: MDV2330-O
//      C20181002
// Products.cs file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welborn_Edward_CustomClass
{
    class Product
    {
        // Variable Declaration
        string mItemName = null;
        decimal mCostToMake = 0;
        decimal mItemPrice = 0;
        decimal dProfit = 0;

        public Product(string _ItemName, decimal _CostToMake, decimal _ItemPrice)
        {
            mItemName = _ItemName;
            mCostToMake = _CostToMake;
            mItemPrice = _ItemPrice;

        }
        //Getters
        public decimal GetCostToMake()
        {
            return mCostToMake;
        }
        public string GetItemName()
        {
            return mItemName;
        }
        public decimal GetItemPrice()
        {
            return mItemPrice;
        }

        public decimal ProfitMargin(decimal _CostToMake, decimal _ItemPrice)
        {
            dProfit = _CostToMake - _ItemPrice;
            return dProfit;

        }
        // Setters
        public string SetItemName(string _ItemName)
        {
            this.mItemName = _ItemName;
            return mItemName;
        }
        public void SetCostToMake(decimal _CostToMake)
        {
            this.mCostToMake = _CostToMake;
        }
        public void SetItemCost(decimal _ItemPrice)
        {
            this.mItemPrice = _ItemPrice;
        }



    }
}
