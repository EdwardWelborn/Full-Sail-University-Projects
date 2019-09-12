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
    public partial class listBoxForm : Form
    {
        dataEntryForm dataEntryFrm;
        listViewForm listViewFrm;


        public listBoxForm()
        {
            InitializeComponent();
        }

        private void listBoxForm_Load(object sender, EventArgs e)
        {
            // when this form loads, it is going to also open the other two forms.
            dataEntryFrm = new dataEntryForm();
            listViewFrm = new listViewForm();

            dataEntryFrm.AddCharacter += listViewFrm.listViewForm_AddCharacter;
            listViewFrm.AddtoParty += ListViewFrm_AddtoParty;
            // show the windows as modeless
            dataEntryFrm.Show();
            listViewFrm.Show();
        }

        private void ListViewFrm_AddtoParty(object sender, EventArgs e)
        {
            // get the object data from the listviewitem tag property
            lstParty.Items.Add(sender as listViewForm).SelectedCharacter.Tag;
        }

        private void listBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
