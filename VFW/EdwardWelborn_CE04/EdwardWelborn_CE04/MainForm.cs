/*
* Created by Edward Welborn on 09/11/2019
* Class: Visual Frameworks
* Description: Project CE04
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: This is where the object and open input counters are held, as well as the application exit and list views
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EdwardWelborn_CE04
{

    public partial class MainForm : Form
    {
        public UserInputForm userInputForm;
        public ListViewForm listViewForm;

        public int intFormCount;

        List<Character> characterList = new List<Character>();

        // public property to get counts
        private EventHandler ClearCharacterList;

        public MainForm()
        {
            InitializeComponent();
        }
        
        public List<Character> CharacterList
        {
            get => characterList;

            set => characterList = value;
        }
        
        public UserInputForm UsrInpf
        {
            get => userInputForm;

            set => userInputForm = value;
        }
        
        public ListViewForm Lsvf
        {
            get => listViewForm;

            set => listViewForm = value;
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Lsvf == null || Lsvf.IsDisposed == true)
            {
                //create a listview form
                //subscribe all the revelent events to the form
                Lsvf = new ListViewForm();
                Lsvf.ClosedListViewForm += HandleClosedListViewForm;
                Lsvf.ClearCharacterListViewForm += HandleClearCharacterListViewForm;
                ClearCharacterList += Lsvf.HandleClearCharacterList;
                Lsvf.DoubleClickListViewFormObject += HandleDoubleClickListViewFormObject;
                //add every item in the list on the mainForm to the listview on the listview form.
                foreach (Character c in characterList)
                {
                    Lsvf.CharacterListView = c;
                }
                //show the listview form modeless
                Lsvf.Show(this);
                //check the display tool strip menu item
                displayToolStripMenuItem.Checked = true;
            }
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            characterList.Clear();
            tbNumberofCharacters.Text = characterList.Count.ToString();
            if (ClearCharacterList != null)
            {
                ClearCharacterList(this, new EventArgs());
            }
        }

        private void btnOpenInputForm_Click(object sender, EventArgs e)
        {
            UsrInpf = new UserInputForm();
            UsrInpf.CharacterAddedToList += HandleCharacterAddedToList;
            UsrInpf.CharacterAddedToListView += HandleCharacterAddedToListView;
            UsrInpf.CloseUserInputWindow += HandleCloseUserInputFormWindow;

            UsrInpf.Show(this);

            intFormCount++;

            tbOpenFormCount.Text = intFormCount.ToString();

        }

        public bool ToolTipChecked
        {
            set => displayToolStripMenuItem.Checked = value;
        }

        public void HandleCharacterAddedToList(object sender, EventArgs e)
        {
            
            UserInputForm activeUserInputForm = sender as UserInputForm;

            if (activeUserInputForm != null) characterList.Add(activeUserInputForm.characterInfo);

            tbNumberofCharacters.Text = characterList.Count.ToString();
        }

        public void HandleCharacterAddedToListView(object sender, EventArgs e)
        {
            if (Lsvf != null)
            {
                UserInputForm activeUserInputForm = sender as UserInputForm;
                Character c = new Character();
                if (activeUserInputForm != null) c = activeUserInputForm.characterInfo;
                Lsvf.CharacterListView = c;
            }
        }

        public void HandleCloseUserInputFormWindow(object sender, EventArgs e)
        {
            intFormCount--;
            tbOpenFormCount.Text = intFormCount.ToString();
        }

        public void HandleDoubleClickListViewFormObject(object sender, EventArgs e)
        {
            btnOpenInputForm_Click(sender, e);

            ListViewForm openLsvf = sender as ListViewForm;

            UsrInpf.characterInfo = openLsvf.SelectedCharacter;
        }

        public void HandleClosedListViewForm(object sender, EventArgs e)
        {
            displayToolStripMenuItem.Checked = false;
        }

        public void HandleClearCharacterListViewForm(object sender, EventArgs e)
        {
            
            characterList.Clear();

            tbNumberofCharacters.Text = characterList.Count.ToString();

        }


        private void tbOpenFormCount_MouseEnter(object sender, EventArgs e)
        {
            // Shows a hint in the status bar
            tspMainForm.Text = "The Count of Open Input Windows";
        }

        private void Clear_StatusHintEvent(object sender, EventArgs e)
        {
            tspMainForm.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit Application when the exit is pressed from the main menu
            Application.Exit();
        }
    }
}
