using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class fmMain : Form
    {

        // The universe array
        bool[,] universe = new bool[50, 50];
        // The scratch pad array
        bool[,] scratchPad = new bool[50, 50];

        // To contain the cell's data
        const int Alive = 1;
        const int Dead = 0;
        static int columns = 50;
        static int rows = 50;
        string[,] cellData = new string[columns, rows]; 
        bool[,] cells;
        int cellCount;

        int neighbors = 0;
        bool neighborDisplay = true;

        // Drawing colors
        Color gridColor;
        Color cellColor;
        Color backgroundColor;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        string boundryType;
        bool toroidal;
        bool finite;

        public fmMain()
        {
            InitializeComponent();
            //application title
            this.Text = Properties.Settings.Default.appTitle;

            //window size
            Size = new Size(725, 620);
            toroidal = true;
            boundryType = "Toroidal";
            toroidalToolStripMenuItem.Image = Properties.Resources.checkmark;
            finiteToolStripMenuItem.Image = null;

            // Setup the timer
            timer.Interval = Properties.Settings.Default.timeInterval;
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // do not start timer running
            // setup colors
            gridColor = Properties.Settings.Default.gridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;

            cells = new bool[columns, rows];

            // initial labels
            universeToolStripStatusLabel.Text = "Universe Size = " + columns + "x" + rows + "(" + boundryType + ")";
            generationToolStripStatusLabel.Text = "Generation = " + generations;
            aliveToolStripStatusLabel.Text = "Cells alive = " + Alive;
            timerIntervaloolStripStatusLabel.Text = "Timer Interval = 0" + timer.Interval;

        }
        // Figures out how many neighbors each cell has
        public int Neighbors(int cellX, int cellY)
        {
            int isAlive = 0;
            // checking for boundries
            for (int y = cellY - 1; y <= cellY + 1; y++)
            {
                int yNeighbor = y;
                if (y < 0)
                {
                    yNeighbor = universe.GetLength(1) - 1;
                }
                else if (y > universe.GetLength(1) - 1)
                {
                    yNeighbor = 0;
                }
                for (int x = cellX - 1; x <= cellX + 1; x++)
                {
                    int xNeighbor = x;
                    if (x < 0)
                    {
                        xNeighbor = universe.GetLength(0) - 1;
                    }
                    else if (x > universe.GetLength(0) - 1)
                    {
                        xNeighbor = 0;
                    }
                    if (universe[xNeighbor, yNeighbor] == true && (x != cellX || y != cellY))
                    {
                        isAlive++;
                    }
                }
            }
            return isAlive;
        }
        // Calculate the next generation of cells
        private void NextGeneration()
        {
            generations++;

            // Rules
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    neighbors = Neighbors(x, y);
                    if (universe[x, y] == true)
                    {
                        if (neighbors < 2)
                        {
                            scratchPad[x, y] = false;
                        }
                        else if (neighbors > 3)
                        {
                            scratchPad[x, y] = false;
                        }
                        else if (neighbors == 2 || neighbors == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                    else if (universe[x, y] == false && neighbors == 3)
                    {
                        scratchPad[x, y] = true;
                    }
                }
            }
            universe = (bool[,])scratchPad.Clone();
            universeToolStripStatusLabel.Text = "Universe Size = " + columns + "x" + rows + "(" + boundryType + ")";
            generationToolStripStatusLabel.Text = "Generation = " + generations;
            aliveToolStripStatusLabel.Text = "Cells alive = " + neighbors;
            timerIntervaloolStripStatusLabel.Text = "Timer Interval = 0" + timer.Interval;
            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            cellCount = 0;
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(1);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clears the universe and zeros out the variables
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    scratchPad[x, y] = false;
                    // resets the generation count to 0
                    generations = 0;
                    generationToolStripStatusLabel.Text = "Generations = " + generations.ToString();
                    // Tells windows to repaint
                    graphicsPanel1.Invalidate();
                }
            }
        }

        static private bool IsCells(string _filename)
        {
            int filenameLength = _filename.Length;
            if (6 < filenameLength)
                if (('.' == _filename[filenameLength - 6]) &&
                    ('c' == _filename[filenameLength - 5] || 'C' == _filename[filenameLength - 5]) &&
                    ('e' == _filename[filenameLength - 4] || 'E' == _filename[filenameLength - 4]) &&
                    ('l' == _filename[filenameLength - 3] || 'L' == _filename[filenameLength - 3]) &&
                    ('l' == _filename[filenameLength - 2] || 'L' == _filename[filenameLength - 2]) &&
                    ('s' == _filename[filenameLength - 1] || 'S' == _filename[filenameLength - 1]))
                    return true;
            return false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens a cell file
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Text File" + "|*.txt|"
                        + "Life Lexicon Plaintext File" + "|*.cells|"
                        + "All Supported Files" + " (*.txt, *.cells)|*.txt;*.cells|"
                        + "All Files" + "|*.*";
            dlg.FilterIndex = 3;


            if (DialogResult.OK == dlg.ShowDialog())
            {

                ResetUniverse();


                int universeWidth = 0;
                int universeHeight = 0;


                string s;


                StreamReader reader;


                string filename = dlg.FileName;


                reader = new StreamReader(filename);


                while (true)
                {
                    s = reader.ReadLine();
                    if (null == s)
                        break;
                    if (0 == s.Length)
                        continue;
                    if ('!' != s[0])
                    {
                        universeWidth = (s.Length > universeWidth) ? s.Length : universeWidth;
                        ++universeHeight;
                    }
                }
                reader.Close();


                if (0 < universeHeight && 0 < universeWidth)
                {

                    bool isCells = IsCells(filename);


                    int startX, startY;


                    if (isCells)
                    {

                        columns = (columns > (15 + universeWidth)) ? columns : (15 + universeWidth);
                        rows = (rows > (15 + universeHeight)) ? rows : (15 + universeHeight);


                        startX = (columns >> 1) - (universeWidth >> 1);
                        startY = (rows >> 1) - (universeHeight >> 1);


                        if (startX < 0) startX = 0;
                        if (startY < 0) startY = 0;
                    }

                    else
                    {

                        columns = universeWidth;
                        rows = universeHeight;


                        startX = 0;
                        startY = 0;
                    }


                    cells = new bool[columns, rows];


                    reader = new StreamReader(filename);


                    int x, y = 0;
                    while (true)
                    {

                        s = reader.ReadLine();

                        if (null == s)
                            break;

                        if (0 == s.Length)
                            continue;

                        if ('!' != s[0])
                        {

                            for (x = 0; x < universeWidth; ++x)
                            {

                                if (s.Length <= x)
                                    break;


                                if ('O' != s[x] && '.' != s[x])
                                    continue;


                                cells[x + startX, y + startY] = 'O' == s[x];
                            }

                            ++y;
                        }
                    }

                    reader.Close();


                    graphicsPanel1.Invalidate();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();


            dlg.Filter = "Cell File" + "|*.cell|"
                                     + "All Files" + "|*.*";
            dlg.FilterIndex = 1;
            dlg.DefaultExt = "cell";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                int y = 0, x;

                for (; y < rows; ++y)
                {
                    for (x = 0; x < columns; ++x)

                        writer.Write(cells[x, y] ? 'O' : '.');
                    writer.Write('\n');
                }

                writer.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exits the application
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            NextGeneration();
        }

        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fromTimerSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void universSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }
        private void ResetUniverse()
        {

            DisableSimulation();


            generations = 0;


            cells = new bool[columns, rows];


            graphicsPanel1.Invalidate();
        }
        private void DisableSimulation()
        {

            timer.Enabled = false;


            startToolStripButton.Enabled = true;
            startToolStripMenuItem.Enabled = true;


            pauseToolStripButton.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
        }

        private void EnableSimulation()
        {

            timer.Enabled = true;


            startToolStripButton.Enabled = false;
            startToolStripMenuItem.Enabled = false;


            pauseToolStripButton.Enabled = true;
            pauseToolStripMenuItem.Enabled = true;
        }

        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to toroidal
            toroidal = true;
            finite = false;
            finiteToolStripMenuItem.Image = null;
            toroidalToolStripMenuItem.Image = Properties.Resources.checkmark;
        }

        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to finite
            toroidal = false;
            finite = true;
            finiteToolStripMenuItem.Image = Properties.Resources.checkmark; ;
            toroidalToolStripMenuItem.Image = null;
        }
    }
}
