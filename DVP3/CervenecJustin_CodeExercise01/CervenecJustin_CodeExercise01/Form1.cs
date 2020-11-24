using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace CervenecJustin_CodeExercise01
{
    public partial class InputForm : Form
    {
        public EventHandler AddToListBox;//Adds to watched listbox
        public EventHandler AddNotWatched;//Adds to Not watched listbox

        public MovieInfo Movie
        {
            get
            {
                MovieInfo movie = new MovieInfo();
                movie.Title = textTitle.Text;
                movie.Genre = textGenre.Text;
                movie.LeadActor = textActor.Text;
                movie.ReleaseYear = numericReleaseYear.Value;
                return movie;
            }
            set
            {
                textTitle.Text = value.Title;
                textGenre.Text = value.Genre;
                textActor.Text = value.LeadActor;
                numericReleaseYear.Value = value.ReleaseYear;
            }
        }


       // List for watched movies
        private List<MovieInfo> watched = new List<MovieInfo>();



        //list properties
        public List<MovieInfo> WatchedMovieList 

        {
            get
            {
                return watched;
            }

            set
            {
                watched = value;
            }
        }
        //List for not watched
        private List<MovieInfo> notWatched = new List<MovieInfo>();
        public List<MovieInfo> NotWatchedMovieList

        {
            get
            {
                return notWatched;
            }

            set
            {
                notWatched = value;
            }
        }

        public InputForm()
        {
            InitializeComponent();
            //Place this inside the class space in the form you would like to size.
            //Call this method AFTER InitializeComponent() inside the form's constructor.
            HandleClientWindowSize();

        }


        void HandleClientWindowSize()
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.4f;
            float WidthValueToChange = 6.0f;

            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height / HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width / WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);
            //this.Size = new Size(376, 720);
        }


        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void displayListsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MovieListForm listForm = new MovieListForm();


            if (listForm != null && displayListsToolStripMenuItem.Checked == true)
            {
            }
            else if (displayListsToolStripMenuItem.Checked == false && watched.Count > 0 || notWatched.Count > 0)
            {
                //below subcribes to the relavent event handlers
                listForm.Load += LoadList;

                //  listForm.Load += listForm.FillListBox;
                AddToListBox += listForm.FillListBox;
             
                AddToListBox += listForm.FillListNotWatched;
                // AddNotWatched += listForm.FillListNotWatched;
                listForm.PopulateInputForm += HandlePopulate;



                listForm.Show();
                displayListsToolStripMenuItem.Checked = true;
            }
            else
            {
                MessageBox.Show("Please add movies before displaying list");
            }
            
        }

        private void btnClearForm_Click(object sender, EventArgs e)//Clear Form when button is pressed
        {
            Clear();
        }

        private void btnAddToWatched_Click(object sender, EventArgs e)
        {
            watched.Add(Movie);//Adds to watched list 
           Movie = new MovieInfo();

            if (AddToListBox != null)
            {
                
                AddToListBox(this, new EventArgs());
            }

            Clear();
        }
        private void LoadList(object sender, EventArgs e)
        {
           // ListBox Lform = (ListBox)sender;
            AddToListBox(this, new EventArgs());
          // AddNotWatched(this, new EventArgs());
            //watched.Clear();
            //notWatched.Clear();
            //Movie = new MovieInfo();
            
        }

        private void btnAddToNotWatched_Click(object sender, EventArgs e)
        {
            notWatched.Add(Movie);//Adds to not watched list
            Movie = new MovieInfo();
            if (AddToListBox != null)
            {

                AddToListBox(this, new EventArgs());
            }
            Clear();
        }

        public void Clear()//method to call when the input fields need reset
        {
            textTitle.Text = null;
            textGenre.Text = null;
            textActor.Text = null;
            numericReleaseYear.Value = 0;
        }

        private void HandlePopulate(object sender, EventArgs e)
        {
           
            MovieListForm watched = sender as MovieListForm;
           Movie = new MovieInfo();
            Movie = watched.MovieSelected;
          
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Saves items populated into input from to xml file
            SaveFileDialog dlg = new SaveFileDialog();
            
            dlg.DefaultExt = "xml";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                settings.Indent = true;

                //Writes to xml doc in xml format
                using (XmlWriter writer = XmlWriter.Create(dlg.FileName, settings))
                {
                    writer.WriteStartElement("Movies");
                    writer.WriteElementString("Title", textTitle.Text.ToString());
                    writer.WriteElementString("Genre", textGenre.Text.ToString());
                    writer.WriteElementString("Actor", textActor.Text.ToString());
                    writer.WriteElementString("Year", numericReleaseYear.Value.ToString());

                    writer.WriteEndElement();
                }
            }
        }
    }
}
