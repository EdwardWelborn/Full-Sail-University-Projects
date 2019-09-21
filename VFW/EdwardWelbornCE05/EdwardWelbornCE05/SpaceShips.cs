/*
* Created by Edward Welborn on 09/14/2019
* Class: Visual Frameworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Ships Form
* Summary: Class used by the program for data manipulation
*/

namespace EdwardWelbornCE05
{
    public class SpaceShips
    {
        public string name;
        public bool active;
        public decimal crewSize;

        public bool cruiser;
        public bool destroyer;
        public bool freighter;

        public int imageIndex;

        public override string ToString()
        {
            return "Name: " + name + " Active: " + active;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal CrewSize
        {
            get => crewSize;
            set => crewSize = value;
        }

        public bool Active
        {
            get => active;
            set => active = value;
        }

        public bool Cruiser
        {
            get => cruiser;
            set => cruiser = value;
        }

        public bool Destroyer
        {
            get => destroyer;
            set => destroyer = value;
        }

        public bool Freighter
        {
            get => freighter;
            set => freighter = value;
        }

        public int ImageIndex
        {
            get
            {
                if (cruiser == true)
                {
                    imageIndex = 0;
                }

                if (destroyer == true)
                {
                    imageIndex = 1;
                }

                if (freighter == true)
                {
                    imageIndex = 2;
                }

                return imageIndex;
            }

            set => imageIndex = value;
        }
    }
}
