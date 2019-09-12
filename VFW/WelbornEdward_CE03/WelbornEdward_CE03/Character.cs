/*
* Created by Edward Welborn on 09/09/2019
* Class: Visual Framworks
* Description: Project CE02
* Copyright © 2019 Roy Welborn. All rights reserved
*
* People Class
* Summary: Input form for the program, here is where the data will be input then sent over to the main form.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace WelbornEdward_CE03
{
    public class People
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public bool Student { get; set; }


        public override string ToString()
        {
            return Firstname + " " + Lastname +" ";
        }

       

    }
}
