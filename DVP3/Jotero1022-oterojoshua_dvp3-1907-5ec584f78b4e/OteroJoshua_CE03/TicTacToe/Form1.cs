using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TicTacToe
{
    public partial class frmTicTacToe : Form
    {
        // NAME: Joshua Otero
        // CLASS AND TERM: MDV 1907
        // PROJECT: Tic Tac Toe
        // When set to true, XO will make double clicking apply an X. When set to false, double clicking a box will apply an O.
        bool XO = true;

        public frmTicTacToe()
        {
            InitializeComponent();
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks if the blue tool stip menu item is already checked
            if (blueToolStripMenuItem.Checked == false)
            {
                // If not, check the blue tool stip menu item and uncheck the red one.
                blueToolStripMenuItem.Checked = true;
                redToolStripMenuItem.Checked = false;
                // Then change the imagelist on all boxes to blue.
                r1c1button.ImageList = blueImages;
                r1c2button.ImageList = blueImages;
                r1c3button.ImageList = blueImages;
                r2c1button.ImageList = blueImages;
                r2c2button.ImageList = blueImages;
                r2c3button.ImageList = blueImages;
                r3c1button.ImageList = blueImages;
                r3c2button.ImageList = blueImages;
                r3c3button.ImageList = blueImages;
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks if the red tool stip menu item is already checked
            if (redToolStripMenuItem.Checked == false)
            {
                // If not, check the red tool stip menu item and uncheck the blue one.
                redToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                // Then change the imagelist on all boxes to red.
                r1c1button.ImageList = redImages;
                r1c2button.ImageList = redImages;
                r1c3button.ImageList = redImages;
                r2c1button.ImageList = redImages;
                r2c2button.ImageList = redImages;
                r2c3button.ImageList = redImages;
                r3c1button.ImageList = redImages;
                r3c2button.ImageList = redImages;
                r3c3button.ImageList = redImages;
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks if X option is checked.
            if (xToolStripMenuItem.Checked == false && FirstMoveCheck() == true)
            {
                // if not, check the X option and uncheck the O option.
                xToolStripMenuItem.Checked = true;
                oToolStripMenuItem.Checked = false;
                XO = true;
            }
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks if O option is checked.
            if (oToolStripMenuItem.Checked == false && FirstMoveCheck() == true)
            {
                // if not, check the O option and uncheck the X option.
                oToolStripMenuItem.Checked = true;
                xToolStripMenuItem.Checked = false;
                XO = false;
            }
        }

        public bool FirstMoveCheck()
        {
            // Goes through every box to see if a game has already begun.
            bool firstMove = true;
            if (r1c1button.ImageIndex == 0 || r1c1button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r1c2button.ImageIndex == 0 || r1c2button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r1c3button.ImageIndex == 0 || r1c3button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r2c1button.ImageIndex == 0 || r2c1button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r2c2button.ImageIndex == 0 || r2c2button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r2c3button.ImageIndex == 0 || r2c3button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r3c1button.ImageIndex == 0 || r3c1button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r3c2button.ImageIndex == 0 || r3c2button.ImageIndex == 1)
            {
                firstMove = false;
            }
            if (r3c3button.ImageIndex == 0 || r3c3button.ImageIndex == 1)
            {
                firstMove = false;
            }
            // If a game has started and firstMove was turned to false, A message box will explain to the user why they cannot change from X to O.
            if (firstMove == false)
            {
                MessageBox.Show("Cannot assign X or O because first move was already made.");
            }
            return firstMove;
        }

        private void r1c1button_MouseClick(object sender, MouseEventArgs e)
        {
            // Checks if the box has been clicked already
            if (r1c1button.ImageIndex == 0 || r1c1button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r1c1button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r1c1button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r1c2button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r1c2button.ImageIndex == 0 || r1c2button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r1c2button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r1c2button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r1c3button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r1c3button.ImageIndex == 0 || r1c3button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r1c3button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r1c3button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r2c1button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r2c1button.ImageIndex == 0 || r2c1button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r2c1button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r2c1button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r2c2button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r2c2button.ImageIndex == 0 || r2c2button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r2c2button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r2c2button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r2c3button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r2c3button.ImageIndex == 0 || r2c3button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r2c3button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r2c3button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r3c1button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r3c1button.ImageIndex == 0 || r3c1button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r3c1button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r3c1button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r3c2button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r3c2button.ImageIndex == 0 || r3c2button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r3c2button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r3c2button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void r3c3button_Click(object sender, EventArgs e)
        {
            // Checks if the box has been clicked already
            if (r3c3button.ImageIndex == 0 || r3c3button.ImageIndex == 1)
            {
                // If it has, nothing will happen.
            }
            else
            {
                // If it has not, it will check to see who's turn it is and apply either X or O to it.
                if (XO == false)
                {
                    r3c3button.ImageIndex = 0;
                    XO = true;
                }
                else
                {
                    r3c3button.ImageIndex = 1;
                    XO = false;
                }
                // Checks if a user won the game or a Stalemate has occured.
                GameWon();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Sets the images of all boxes to nothing.
            r1c1button.ImageIndex = -1;
            r1c2button.ImageIndex = -1;
            r1c3button.ImageIndex = -1;
            r2c1button.ImageIndex = -1;
            r2c2button.ImageIndex = -1;
            r2c3button.ImageIndex = -1;
            r3c1button.ImageIndex = -1;
            r3c2button.ImageIndex = -1;
            r3c3button.ImageIndex = -1;
            // Then checks which menu button is checked for the first move, X or O and assigns the XO bool to whichever is checked.
            if (xToolStripMenuItem.Checked == true)
            {
                XO = true;
            }
            else
            {
                XO = false;
            }
        }

        public void GameWon()
        {
            // Bool used to check if stalemate message should appear or not.
            bool gameEnded = false;
            // Method checks to see if any player has won or if there is a stalemate.
            if (r1c1button.ImageIndex == r1c2button.ImageIndex && r1c1button.ImageIndex == r1c3button.ImageIndex)
            {
                if (r1c1button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c1button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r1c1button.ImageIndex == r2c2button.ImageIndex && r1c1button.ImageIndex == r3c3button.ImageIndex)
            {
                if (r1c1button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c1button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r1c1button.ImageIndex == r2c1button.ImageIndex && r1c1button.ImageIndex == r3c1button.ImageIndex)
            {
                if (r1c1button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c1button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r1c2button.ImageIndex == r2c2button.ImageIndex && r1c2button.ImageIndex == r3c2button.ImageIndex)
            {
                if (r1c2button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c2button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r1c3button.ImageIndex == r2c2button.ImageIndex && r1c3button.ImageIndex == r3c1button.ImageIndex)
            {
                if (r1c3button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c3button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r1c3button.ImageIndex == r2c3button.ImageIndex && r1c3button.ImageIndex == r3c3button.ImageIndex)
            {
                if (r1c3button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r1c3button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            if (r2c1button.ImageIndex == r2c2button.ImageIndex && r2c1button.ImageIndex == r2c3button.ImageIndex)
            {
                if (r2c1button.ImageIndex == 0)
                {
                    MessageBox.Show("O has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
                else if (r2c1button.ImageIndex == 1)
                {
                    MessageBox.Show("X has won! Press New Game to start a new game.");
                    gameEnded = true;
                }
            }
            // Stalemate Check
            int stalemate = 0;
            if (r1c1button.ImageIndex == 0 || r1c1button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r1c2button.ImageIndex == 0 || r1c2button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r1c3button.ImageIndex == 0 || r1c3button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r2c1button.ImageIndex == 0 || r2c1button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r2c2button.ImageIndex == 0 || r2c2button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r2c3button.ImageIndex == 0 || r2c3button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r3c1button.ImageIndex == 0 || r3c1button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r3c2button.ImageIndex == 0 || r3c2button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            if (r3c3button.ImageIndex == 0 || r3c3button.ImageIndex == 1)
            {
                stalemate += 1;
            }
            // If a game has started and firstMove was turned to false, A message box will explain to the user why they cannot change from X to O.
            if (stalemate == 9 && gameEnded == false)
            {
                MessageBox.Show("The game has ended in a stalemate! Press New Game to play a new game.");
            }


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // a new instance of the Save dialog
            SaveFileDialog dlg = new SaveFileDialog();

            // set the default extension
            dlg.DefaultExt = "xml";

            // if the user clicks the OK button
            if (DialogResult.OK == dlg.ShowDialog())
            {
                // we'll create a new instance of the XmlWriterSettings
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;

                // we'll also set the indentation of the XML
                settings.Indent = true;

                // instantiate the XmlWriter
                using (XmlWriter writer = XmlWriter.Create(dlg.FileName, settings))
                {
                    // the saving the data as string.
                    writer.WriteStartElement("TicTacToeData");
                    writer.WriteStartElement("Buttons");
                    writer.WriteElementString("r1c1", r1c1button.ImageIndex.ToString());
                    writer.WriteElementString("r1c2", r1c2button.ImageIndex.ToString());
                    writer.WriteElementString("r1c3", r1c3button.ImageIndex.ToString());
                    writer.WriteElementString("r2c1", r2c1button.ImageIndex.ToString());
                    writer.WriteElementString("r2c2", r2c2button.ImageIndex.ToString());
                    writer.WriteElementString("r2c3", r2c3button.ImageIndex.ToString());
                    writer.WriteElementString("r3c1", r3c1button.ImageIndex.ToString());
                    writer.WriteElementString("r3c2", r3c2button.ImageIndex.ToString());
                    writer.WriteElementString("r3c3", r3c3button.ImageIndex.ToString());
                    writer.WriteElementString("XO", XO.ToString());
                    writer.WriteEndElement();
                }
            }
        }

        private void frmTicTacToe_Load(object sender, EventArgs e)
        {
            
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the dialog to get the file name
            OpenFileDialog dlg = new OpenFileDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                // Reset images for buttons
                r1c1button.ImageIndex = -1;
                r1c2button.ImageIndex = -1;
                r1c3button.ImageIndex = -1;
                r2c1button.ImageIndex = -1;
                r2c2button.ImageIndex = -1;
                r2c3button.ImageIndex = -1;
                r3c1button.ImageIndex = -1;
                r3c2button.ImageIndex = -1;
                r3c3button.ImageIndex = -1;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;

                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;

                // using the XmlReader
                using (XmlReader reader = XmlReader.Create(dlg.FileName, settings))
                {
                    // skip the metadata
                    reader.MoveToContent();

                    // verify that this is our class data
                    if (reader.Name != "TicTacToeData")
                    {
                        // return that this is not right
                        MessageBox.Show("This is not a file created from this program.");
                        return;
                    }

                    // if it is, move through the data and get what we want
                    while (reader.Read())
                    {
                        // Reads data and applies changes to buttons
                        if (reader.ReadToFollowing("r1c1"))
                        {
                            r1c1button.ImageIndex = reader.ReadElementContentAsInt();
                            r1c2button.ImageIndex = reader.ReadElementContentAsInt();
                            r1c3button.ImageIndex = reader.ReadElementContentAsInt();
                            r2c1button.ImageIndex = reader.ReadElementContentAsInt();
                            r2c2button.ImageIndex = reader.ReadElementContentAsInt();
                            r2c3button.ImageIndex = reader.ReadElementContentAsInt();
                            r3c1button.ImageIndex = reader.ReadElementContentAsInt();
                            r3c2button.ImageIndex = reader.ReadElementContentAsInt();
                            r3c3button.ImageIndex = reader.ReadElementContentAsInt();
                            XO = bool.Parse(reader.ReadElementContentAsString());
                        }
                        
                    }


                }
            }
        }
    }
    
}
