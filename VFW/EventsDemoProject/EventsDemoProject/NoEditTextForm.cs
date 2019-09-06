using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsDemoProject
{
    public partial class NoEditTextForm : Form
    {
        public TextData TextValues
        {
            get
            {
                TextData data = new TextData();
                data.Text1 = text1.Text;
                data.Text2 = text2.Text;
                data.Text3 = text3.Text;
                return data;
            }

            set
            {
                text1.Text = value.Text1;
                text2.Text = value.Text2;
                text3.Text = value.Text3;
            }
        }

        public NoEditTextForm()
        {
            InitializeComponent();
        }
    }
}
