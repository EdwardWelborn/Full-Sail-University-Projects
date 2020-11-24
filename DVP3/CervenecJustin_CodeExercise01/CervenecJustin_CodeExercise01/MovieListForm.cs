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
    public partial class MovieListForm : Form
    {
        public EventHandler PopulateInputForm;

       private List<MovieInfo> watchedList;
        //properties for the list
        public List<MovieInfo> WatchedList
        {
            set
            {
                watchedList = value;
            }
        }
       private List<MovieInfo> notWatchedList;
        //properties for the list
        public List<MovieInfo> NotWatchedList
        {
            set
            {
                notWatchedList = value;
            }
        }

        //properties for the list box items
        public MovieInfo MovieSelected
        {
            get
            {
                if (listBoxWatched.SelectedItems.Count > 0)
                {
                    return listBoxWatched.SelectedItems[0] as MovieInfo;
                }
                else
                {
                    return new MovieInfo();
                }
            }


        }
        public MovieInfo MovieSelectedNotWatched
        {
            get
            {
                if (listBoxNotWatched.SelectedItems.Count > 0)
                {
                    return listBoxNotWatched.SelectedItems[0] as MovieInfo;
                }
                else
                {
                    return new MovieInfo();
                }
            }


        }

        public MovieListForm()
        {
            InitializeComponent();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }

        public void FillListBox(object sender, EventArgs e)
        {
            InputForm fm = sender as InputForm;
            watchedList = fm.WatchedMovieList;
            // listBoxWatched.Items.Add(watchedList[watchedList.Count - 1]);
            for (int i = 0; i < watchedList.Count; i++)
            {
                listBoxWatched.Items.Add(watchedList[i]);
            }
            //watchedList.Clear();
        }

        public void FillListNotWatched(object sender, EventArgs e)
        {
            InputForm fm = sender as InputForm;
            notWatchedList = fm.NotWatchedMovieList;
            // listBoxWatched.Items.Add(watchedList[watchedList.Count - 1]);
            for (int i = 0; i < notWatchedList.Count; i++)
            {
               listBoxNotWatched.Items.Add(notWatchedList[i]);
            }
            //notWatchedList.Clear();
        }

        private void btnMoveToNotWatched_Click(object sender, EventArgs e)
        {
            //Moves slected item from watched to not watched
            if (listBoxWatched.SelectedItem != null)
            {
                listBoxNotWatched.Items.Add(listBoxWatched.SelectedItem);
                listBoxWatched.Items.Remove(listBoxWatched.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxNotWatched.SelectedItem != null)
            {
                //moves items from not watched to watched
                listBoxWatched.Items.Add(listBoxNotWatched.SelectedItem);
                listBoxNotWatched.Items.Remove(listBoxNotWatched.SelectedItem);
            }
        }

        private void btnRemoveWatched_Click(object sender, EventArgs e)
        {
            if (listBoxWatched.SelectedItem != null)
            {
                //removes selected item from watched list
                listBoxWatched.Items.Remove(listBoxWatched.Items[listBoxWatched.SelectedIndex]);
            }
        }

        private void btnRemoveNotWatched_Click(object sender, EventArgs e)
        {
            if (listBoxNotWatched.SelectedItem != null)
            {
                //removes selected item from not watched list
                listBoxNotWatched.Items.Remove(listBoxNotWatched.Items[listBoxNotWatched.SelectedIndex]);
            }
        }

        private void listBoxWatched_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxWatched.SelectedIndex >= 0 && listBoxWatched.SelectedIndex < listBoxWatched.Items.Count)
            {

                PopulateInputForm(this, new EventArgs());
                listBoxWatched.Items.RemoveAt(listBoxWatched.SelectedIndex);
            }
        }
    }
}
