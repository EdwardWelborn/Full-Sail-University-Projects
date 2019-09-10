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
    class People
    {
        public string firstname;
        public string lastname;
        public string age;
        public string gender;
        public bool student;

        public override string ToString()
        {
            return firstname + " " + lastname + " " + age + " " + gender + " " + student;
        }

    }
}
