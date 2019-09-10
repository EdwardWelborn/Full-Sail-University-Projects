using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class listViewForm : Form
    {
        // event handler to copy data to the listboxform
        public event EventHandler AddtoParty;

        // property do hold data of the selected itme in the listview
        public ListViewItem SelectedCharacter
        {
            get
            {
                // verify that there is an item selected
                if (listView.SelectedItems.Count > 0)
                {
                    return listView.SelectedItems[0];
                }
                return null;
            }
        }
        public listViewForm()
        {
            InitializeComponent();
        }

        public void listViewForm_AddCharacter(object sender, EventArgs e)
        {
            // list view stores their displayed items as listviewitems
            ListViewItem lvi = new ListViewItem();

            // get the data object from the sender
            DataClass data = (sender as mainForm).Data;

            // Listview object with several properties that are setable
            lvi.Text = data.ToString();
            lvi.ImageIndex = data.imageIndex;

            // the tag property can hold a reference to the object so we can access things we need
            lvi.Tag = data;

            //add listviewitem to the listview
            listView.Items.Add(lvi);

        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddtoParty?.Invoke(this, new EventArgs());
        }

    }
}
