using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindErrorsClasses
{
    class Movie
    {
        //Member Variables
        string mMovieTitle;
        decimal mCostToMake;
        decimal mMoneyMade;
        int mYearMade;

        //Create the constructor function
        public Movie(string _movieTitle, decimal _costToMake, decimal _moneyMade, int _yearMade)
        {
            //Use the incoming parameters to initialize our original member variables
            mMovieTitle = _movieTitle;
            mCostToMake = _costToMake;
            mMoneyMade = _moneyMade;
            mYearMade = _yearMade;
        }

        //Getters - returns the information back to where it was called
        public string GetMovieTitle()
        {
            //Return the movie title
            return mMovieTitle;
        }

        public decimal GetCostToMake()
        {
            //Return the movie title
            return mCostToMake;
        }

        public decimal GetMoneyMade()
        {
            //Return the movie title
            return mMoneyMade;
        }

        public int GetYearMade()
        {
            //Return the movie title
            return mYearMade;
        }


        //Settters change the member variables

        public string SetMoiveTitle(string _movieTitle)
        {
            //Use the parameter to change the member variable
            this.mMovieTitle = _movieTitle;
            return mMovieTitle;
        }

        public void SetCostTomake(decimal _costToMake)
        {
            //Use the parameter to change the member variable
            this.mCostToMake = _costToMake;
        }

        public void SetMoneyMade(decimal _moneyMade)
        {
            //Use the parameter to change the member variable
            this.mMoneyMade = _moneyMade;
        }

        public void SetYearMade(int _yearMade)
        {
            //Use the parameter to change the member variable
            this.mYearMade = _yearMade;
        }



        //Custom function to return how much profit the movie made
        public decimal ProfitMade()
        {
            //Calculate the profit
            // How much it made minus how much it cost to make.
            decimal profit = mMoneyMade - mCostToMake;

            //return profit
            return profit;

        }

    }
}
