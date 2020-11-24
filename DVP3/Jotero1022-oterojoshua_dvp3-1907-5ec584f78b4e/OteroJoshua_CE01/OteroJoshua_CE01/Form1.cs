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

namespace OteroJoshua_CE01
{
    public partial class Form1 : Form
    {
        public event EventHandler<DevClassEventArgs> SendInfo;
        List<DevClass> LoadedClasses = new List<DevClass>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // create a userinput window and assign event handlers
            UserInput newWindow = new UserInput();
            newWindow.SendInfo += LoadData;
            newWindow.ShowDialog();

        }

        public void LoadData(object sender, DevClassEventArgs e)
        {
            // Create class to load data and put into designated list box
            DevClass newItem = new DevClass();
            newItem.ClassName = e.ClassName;
            newItem.Completed = e.Completed;
            if (newItem.Completed == true)
            {
                lstBoxCompleted.Items.Add(newItem);
            }
            else
            {
                lstBoxUpcoming.Items.Add(newItem);
            }
            
        }

        private void lstBoxCompleted_DoubleClick(object sender, EventArgs e)
        {
            // Checks if an item is selected before opening a new input window and filling the window with the information from the selected item
            if (lstBoxCompleted.SelectedItem != null)
            {
                DevClass currentClass = (DevClass)lstBoxCompleted.SelectedItem;
                UserInput newWindow = new UserInput();
                newWindow.SendInfo += LoadData;
                DevClassEventArgs arg = new DevClassEventArgs();
                arg.ClassName = currentClass.ClassName;
                arg.Completed = currentClass.Completed;
                SendInfo += newWindow.LoadInfo;
                SendInfo?.Invoke(this, arg);
                lstBoxCompleted.Items.Remove(lstBoxCompleted.SelectedItem);
                newWindow.ShowDialog();
            }
           
        }

        private void lstBoxUpcoming_DoubleClick(object sender, EventArgs e)
        {
            // Checks if an item is selected before opening a new input window and filling the window with the information from the selected item
            if (lstBoxUpcoming.SelectedItem != null)
            {
                DevClass currentClass = (DevClass)lstBoxUpcoming.SelectedItem;
                UserInput newWindow = new UserInput();
                newWindow.SendInfo += LoadData;
                DevClassEventArgs arg = new DevClassEventArgs();
                arg.ClassName = currentClass.ClassName;
                arg.Completed = currentClass.Completed;
                SendInfo += newWindow.LoadInfo;
                SendInfo?.Invoke(this, arg);
                lstBoxUpcoming.Items.Remove(lstBoxUpcoming.SelectedItem);
                newWindow.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Checks if an object is selected in each list box and deletes if one is selected
            if (lstBoxCompleted.SelectedItem != null)
            {
                lstBoxCompleted.Items.Remove(lstBoxCompleted.SelectedItem);
            }
            if (lstBoxUpcoming.SelectedItem != null)
            {
                lstBoxUpcoming.Items.Remove(lstBoxUpcoming.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // sends object from the completed list box to the upcoming list box
            if (lstBoxCompleted.SelectedItem != null)
            {
                DevClass currentClass = (DevClass)lstBoxCompleted.SelectedItem;
                currentClass.Completed = false;
                lstBoxCompleted.Items.Remove(lstBoxCompleted.SelectedItem);
                lstBoxUpcoming.Items.Add(currentClass);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // sends an object from the upcoming list box to the completed list box
            if (lstBoxUpcoming.SelectedItem != null)
            {
                DevClass currentClass = (DevClass)lstBoxUpcoming.SelectedItem;
                currentClass.Completed = true;
                lstBoxUpcoming.Items.Remove(lstBoxUpcoming.SelectedItem);
                lstBoxCompleted.Items.Add(currentClass);
            }
        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
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
                    // the first element we want will define what the data is
                    writer.WriteStartElement("ClassListData");
                    for (int i = 0; i < lstBoxCompleted.Items.Count; i++)
                    {
                        DevClass newItem = (DevClass)lstBoxCompleted.Items[i];
                        writer.WriteStartElement("CompletedClass");
                        writer.WriteElementString("Class", newItem.ClassName);
                        writer.WriteElementString("Completed", newItem.Completed.ToString());
                        writer.WriteEndElement();
                    }
                    for (int i = 0; i < lstBoxUpcoming.Items.Count; i++)
                    {
                        DevClass newItem = (DevClass)lstBoxUpcoming.Items[i];
                        writer.WriteStartElement("UpcomingClass");
                        writer.WriteElementString("Class", newItem.ClassName);
                        writer.WriteElementString("Completed", newItem.Completed.ToString());
                        writer.WriteEndElement();
                    }
                    // close the initial element
                    writer.WriteEndElement();
                }
            }
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create the dialog to get the file name
            OpenFileDialog dlg = new OpenFileDialog();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                lstBoxCompleted.Items.Clear();
                lstBoxUpcoming.Items.Clear();
                LoadedClasses.Clear();
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
                    if (reader.Name != "ClassListData")
                    {
                        // return that this is not right
                        MessageBox.Show("This is not a file created from this program.");
                        return;
                    }

                    // if it is, move through the data and get what we want
                    while (reader.Read())
                    {
                        DevClass newClass = new DevClass();
                        // Reads data and saves the classes to a List of classes
                        if (reader.ReadToFollowing("Class"))
                        {
                            newClass.ClassName = reader.ReadElementContentAsString();
                            
                        }
                        if (reader.Name == "Completed" && reader.IsStartElement())
                        {
                            string boolString;
                            boolString = reader.ReadElementContentAsString();
                            newClass.Completed = bool.Parse(boolString);
                            LoadedClasses.Add(newClass);
                        }
                        if (reader.ReadToFollowing("Class"))
                        {
                            newClass.ClassName = reader.ReadElementContentAsString();
                        }
                        if (reader.Name == "Completed" && reader.IsStartElement())
                        {
                            string boolString;
                            boolString = reader.ReadElementContentAsString();
                            newClass.Completed = bool.Parse(boolString);
                            LoadedClasses.Add(newClass);
                        }

                    }
                }
                for (int i = 0; i < LoadedClasses.Count; i++)
                {
                    // Goes through the list of classes and assigns each class object to its correct list box
                    if (LoadedClasses[i].Completed == true)
                    {
                        lstBoxCompleted.Items.Add(LoadedClasses[i]);
                    }
                    else
                    {
                        lstBoxUpcoming.Items.Add(LoadedClasses[i]);
                    }
                }
            }
        }

        private void printListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Allows the user to print data
            pntDialog.ShowDialog();
        }
    }
}
