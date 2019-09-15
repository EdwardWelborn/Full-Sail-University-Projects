/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Framworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* List View Form
* Summary: This is where the list is displayed, as well as being able to click open a new user input form.
*/
using System;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{
    public partial class ListViewForm : Form
    {
        public EventHandler ClosedListViewForm;
        public EventHandler ClearCharacterListViewForm;
        public EventHandler DoubleClickListViewFormObject;

        // public MainForm formMain;
        public Character CharacterListView
        {
            set
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = value.ToString();
                lvi.ImageIndex = value.ImageIndex;
                lvi.Tag = value;

                lvwCharacters.Items.Add(lvi);
            }
        }
        
        public Character SelectedCharacter
        {
            get
            {
                return lvwCharacters.SelectedItems[0].Tag as Character;
            }
        }
        
        public ListViewForm()
        {
            InitializeComponent();
        }
        
        private void tspbtnClearData_Click(object sender, EventArgs e)
        {
            // This will clear the list, the list view box, and clear the data object counter on main form

            ClearCharacterListViewForm?.Invoke(this, new EventArgs());

            lvwCharacters.Clear();
        }
        
        private void ListViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //raise the closedlistview event
            ClosedListViewForm?.Invoke(this, new EventArgs());
        }
        
        public void HandleClearCharacterList(object sender, EventArgs e)
        {
            //remove all items from the listview
            lvwCharacters.Clear();
        }

        private void CharacterListView_DoubleClick(object sender, EventArgs e)
        {
            //raise the doubleclicklistviewobject event
            DoubleClickListViewFormObject?.Invoke(this, new EventArgs());
        }



















        //public Character CharacterListBox
        //{
        //    set
        //    {
        //        lvwCharacters.Items.Add(value);
        //    }
        //}

        //public int CharacterRemove
        //{
        //    set
        //    {
        //        lvwCharacters.Items.RemoveAt(value);
        //    }
        //}


    }
}
