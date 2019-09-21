/*
* Created by Edward Welborn on 09/19/2019
* Class: Visual Frameworks
* Description: Project CE06
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Data Class
* Summary: Data Holder class
*/
using System.Collections.Generic;

namespace EdwardWelborn_CE06
{
    public class TripData
    {
        // Class for Trip data on Trip Planner
        public int imageIndex;

        public string direction;
        public decimal miles;
        public decimal hours;
        public string mode;

        List<TripData> tripList = new List<TripData>();

        public string Direction
        {
            get => direction;
            set => direction = value;
        }

        public decimal Miles
        {
            get => miles;
            set => miles = value;
        }

        public decimal Hours
        {
            get => hours;
            set => hours = value;
        }

        public string Mode
        {
            get => mode;
            set => mode = value;
        }

        public int ImageIndex
        {
            get
            {
                if (Direction == "North")
                    imageIndex = 0;

                if (Direction == "South")
                    imageIndex = 1;

                if (Direction == "East")
                    imageIndex = 2;

                if (Direction == "West")
                    imageIndex = 3;

                return imageIndex;
            }

            set => imageIndex = value;
        }
        public List<TripData> TripList
        {
            get => tripList;
            set => tripList = value;
        }

        public override string ToString()
        {
            return (" Direction: " + direction);
        }
    }
}
