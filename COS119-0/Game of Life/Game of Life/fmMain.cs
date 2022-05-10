using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Game_of_Life
{
    public partial class fmMain : Form
    {

        // The universe array
        bool[,] universe = new bool[50, 50];
        // The scratch pad array
        bool[,] scratchPad = new bool[50, 50];

        // To contain the cell's data
        
        static int columns = 50;
        static int rows = 50;
         
        bool[,] cells;
        int cellCount;
        int seed;
        int gridWidth;
        int gridHeight;
        int gridX;
        int gridY;
        int gridZ;

        int neighbors = 0;
        bool nCount = true;

        // Drawing colors
        Color gridColor;
        Color cellColor;
        Color backgroundColor;
        Brush cellBrush;

        Pen gridPen;

        // The Timer class
        Timer timer = new Timer();
    

        // Generation count
        int generations = 0;
        private int randomizedSeed;

        string boundryType;
        bool toroidal;
        bool finite;
        private Random rnd;
        private int runTo = 0;
        bool countType = false;

        public fmMain()
        {
            InitializeComponent();
            //application title
            this.Text = Properties.Settings.Default.appTitle;

            //window size
            Size = new Size(725, 620);

            countType = false;
            finiteToolStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Checked = false;
            neighborCountToolStripMenuItem.Checked = true;

            // Setup the timer
            timer.Interval = Properties.Settings.Default.timeInterval;
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // do not start timer running
            timer.Tag = 0;

            seed = Properties.Settings.Default.seed;
            // setup colors
            gridColor = Properties.Settings.Default.gridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;

            cells = new bool[columns, rows];
            gridWidth = Properties.Settings.Default.lineWidth;
            // initialize universe
            ResizeUniverse();
            // initialize labels
            UpdateStatusLabels();
            // initialize colors
            UpdateColors();

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

        private int CountNeighborsFinite(int x, int y)
        {

            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }

                    if (universe[xCheck, yCheck] == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }

                    if (universe[xCheck, yCheck] == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int neighborCount = 0;
                    scratchPad[x, y] = false;
                    if (countType)
                    {
                        neighborCount = CountNeighborsToroidal(x, y);
                    }
                    else
                    {
                        neighborCount = CountNeighborsFinite(x, y);
                    }
                    if (universe[x, y])
                    {
                        if (neighborCount < 2)
                        {
                            scratchPad[x, y] = false;
                        }
                        if (neighborCount > 3)
                        {
                            scratchPad[x, y] = false;
                        }
                        if (neighborCount == 2 || neighborCount == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                    else
                    {
                        if (neighborCount == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                }
            }
            bool[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;

            //sets numAlive back to 0
            cellCount = 0;

            //loops through new universe to check alive count
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y])
                    {
                        cellCount++;

                    }
                }
            }


            // Increment generation count
            generations++;

            // Update status strip generations
            UpdateStatusLabels();

            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            /*
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
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
                        /*
                                                if (nCount)
                                                {
                                                    Font font = new Font("Arial", 20f);

                                                    StringFormat stringFormat = new StringFormat();
                                                    stringFormat.Alignment = StringAlignment.Center;
                                                    stringFormat.LineAlignment = StringAlignment.Center;

                                                    int neighbors = CountNeighborsFinite(x, y);

                                                    if (neighbors > 3 || neighbors < 2)
                                                    {
                                                        e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Crimson, cellRect, stringFormat);
                                                    }
                                                    else
                                                    {
                                                        e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Green, cellRect, stringFormat);
                                                    }
                                                }
                        // *
                        if (nCount == true)
                        {
                            Brush brush = Brushes.Green;
                            neighbors = Neighbors(x, y);
                            if (neighbors >= 3)
                            {
                                brush = Brushes.Red;
                            }
                            StringFormat format = new StringFormat();
                            format.Alignment = StringAlignment.Center;
                            format.LineAlignment = StringAlignment.Center;
                            Rectangle rectangle = new Rectangle(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                            if (neighbors != 0)
                            {
                                e.Graphics.DrawString(neighbors.ToString(), Font, brush, rectangle, format);
                            }
                        }
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
            */

            //Convert to FLOATS! https://youtu.be/aD-Y-3PT1Oo
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
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
                    //RectangleF floatRect;
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }
                    if (scratchPad[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }
                    else if (nCount == true)
                    {
                        Brush brush = Brushes.Green;
                        neighbors = Neighbors(x, y);
                        if (neighbors >= 3)
                        {
                            brush = Brushes.Red;
                        }
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        Rectangle rectangle = new Rectangle(cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                        if (neighbors != 0)
                        {
                            e.Graphics.DrawString(neighbors.ToString(), Font, brush, rectangle, format);
                        }
                    }
                }
            }
            // Cleaning up pens and brushes (helps garbage collector)
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
            ResetUniverse();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    maxHeight++;

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    if (maxWidth < row.Length)
                    {
                        maxWidth = row.Length;
                    }
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.

                universe = new bool[maxWidth, maxHeight];
                scratchPad = new bool[maxWidth, maxHeight];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                int yPos = 0;

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }

                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        // If row[xPos] is a 'O' (capital O) then
                        // set the corresponding cell in the universe to alive.
                        if (row[xPos] == 'O')
                        {
                            universe[xPos, yPos] = true;
                        }
                        if (row[xPos] == '.')
                        {
                            universe[xPos, yPos] = false;
                        }

                        // If row[xPos] is a '.' (period) then
                        // set the corresponding cell in the universe to dead.
                    }
                    yPos++;
                }

                // Close the file.
                graphicsPanel1.Invalidate();
                reader.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;
            dlg.DefaultExt = "cells";

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                writer.WriteLine("!" + DateTime.Now);

                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    String currentRow = string.Empty;
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y])
                        {
                            currentRow += 'O';
                        }
                        else
                        {
                            currentRow += '.';
                        }
                    }

                    writer.WriteLine(currentRow);
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
            EnableSimulation();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableSimulation();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableSimulation();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableSimulation();
            NextGeneration();
        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeCells(seed);
        }

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedDialog dlg = new SeedDialog();


            dlg.Seed = seed;


            if (DialogResult.OK == dlg.ShowDialog())

                RandomizeCells(dlg.Seed);
        }

        private void fromTimerSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeCells(new Random((int)DateTime.Now.Ticks).Next());
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();


            dlg.Color = backgroundColor;


            if (DialogResult.OK == dlg.ShowDialog())
            {

                backgroundColor = dlg.Color;


                UpdateColors();
            }
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();


            dlg.Color = cellColor;


            if (DialogResult.OK == dlg.ShowDialog())
            {

                cellColor = dlg.Color;


                UpdateColors();
            }
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();


            dlg.Color = gridColor;


            if (DialogResult.OK == dlg.ShowDialog())
            {

                gridColor = dlg.Color;


                UpdateColors();
            }
        }

        private void newSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SeedDialog dlg = new SeedDialog();

            dlg.Seed = randomizedSeed;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                RandomizeCells(dlg.Seed);
                seed = dlg.Seed;
            }
            else
            {
                seed = Properties.Settings.Default.seed;
            }

            seedToolStripStatusLabel.Text = "Seed = " + seed;

        }

        private void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerIntervalDailog dlg = new TimerIntervalDailog();

            dlg.TimerInterval = timer.Interval;

            if (DialogResult.OK == dlg.ShowDialog())
                timer.Interval = dlg.TimerInterval;
            else
            {
                timer.Interval = Properties.Settings.Default.timeInterval;
            }

            timerIntervaloolStripStatusLabel.Text = "Timer Interval = " + timer.Interval;
        }

        private void universSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universeSizeDialog dlg = new universeSizeDialog();

            dlg.UniverseYResize = columns;
            dlg.UniverseXResize = rows;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                columns = dlg.UniverseYResize;
                rows = dlg.UniverseXResize;
            }
            ResizeUniverse();
            UpdateStatusLabels();
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
            Clear();
            generations = 0;

            cells = new bool[columns, rows];

            graphicsPanel1.Invalidate();
        }
        private void DisableSimulation()
        {

            timer.Enabled = false;

            startToolStripButton.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            stopToolStripButton.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            pauseToolStripButton.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
        }

        private void EnableSimulation()
        {

            timer.Enabled = true;

            startToolStripButton.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            stopToolStripButton.Enabled = true;
            pauseToolStripButton.Enabled = true;
            pauseToolStripMenuItem.Enabled = true;
        }

        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to toroidal
            countType = true;
            finiteToolStripMenuItem.Checked = false;
            toroidalToolStripMenuItem.Checked = true;
        }

        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to finite
            countType = false;
            finiteToolStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Checked = false;
        }

        private void UpdateColors()
        {

            cellBrush = new SolidBrush(cellColor);

            gridPen = new Pen(gridColor, 0 < gridWidth ? gridWidth : -gridWidth);

            graphicsPanel1.BackColor = backgroundColor;

            backgroundColorToolStripMenuItem.BackColor = backgroundColor;
            cellColorToolStripMenuItem.BackColor = cellColor;
            gridColorToolStripMenuItem.BackColor = gridColor;

            backgroundColorToolStripMenuItem.ForeColor = Color.FromArgb(~(backgroundColor.ToArgb()));
            cellColorToolStripMenuItem.ForeColor = Color.FromArgb(~(cellColor.ToArgb()));
            gridColorToolStripMenuItem.ForeColor = Color.FromArgb(~(gridColor.ToArgb()));

            graphicsPanel1.Invalidate();
        }

        private void resetColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cellBrush = new SolidBrush(Properties.Settings.Default.cellColor);


            gridPen = new Pen(gridColor, 0 < gridWidth ? gridWidth : -gridWidth);


            graphicsPanel1.BackColor = Properties.Settings.Default.backgroundColor;


            backgroundColorToolStripMenuItem.BackColor = backgroundColor;
            cellColorToolStripMenuItem.BackColor = cellColor;
            gridColorToolStripMenuItem.BackColor = gridColor;


            backgroundColorToolStripMenuItem.ForeColor = Color.FromArgb(~(backgroundColor.ToArgb()));
            cellColorToolStripMenuItem.ForeColor = Color.FromArgb(~(cellColor.ToArgb()));
            gridColorToolStripMenuItem.ForeColor = Color.FromArgb(~(gridColor.ToArgb()));

            graphicsPanel1.Invalidate();
        }

        private void RandomizeCells(int _seed)
        {

            Reseed(_seed);

            DisableSimulation();
            generations = 0;
            Clear();

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (rnd.Next(0, 3) == 0)
                    {
                        universe[x, y] = true;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }


        private void Reseed(int newSeed)
        {
            seed = newSeed;
            rnd = new Random(seed);
            UpdateStatusLabels();
        }

        private void UpdateStatusLabels()
        {
            universeToolStripStatusLabel.Text = "Universe Size = " + columns + "x" + rows + " (" + boundryType + ")";
            generationToolStripStatusLabel.Text = "Generation = " + generations;
            aliveToolStripStatusLabel.Text = "Cells alive = " + cellCount;
            timerIntervaloolStripStatusLabel.Text = "Timer Interval = " + timer.Interval;
            seedToolStripStatusLabel.Text = "Seed = " + seed;
        }

        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunToDialog dlg = new RunToDialog();

            dlg.RunTo = runTo;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                runTo = dlg.RunTo;
                RunTo(runTo);
            }
        }

        private void RunTo(int runTo)
        {
            
            timer.Start();
            // timer won't stop
            for (int x = 1; x <= runTo; x++)
            {
                if (x >= runTo)
                    timer.Stop();
            }
        }
        private void ResizeUniverse()
        {
            bool[,] newCells = new bool[columns, rows];

            int x = 0, y;

            for (; x < columns && x < cells.GetLength(0); ++x)
            for (y = 0; y < rows && y < cells.GetLength(1); ++y)
                newCells[x, y] = cells[x, y];

            cells = newCells;

            graphicsPanel1.Invalidate();
        }
        private void Clear()
        {
            timer.Enabled = false;
            for (int i = 0; i < universe.GetLength(1); i++)
            {
                for (int j = 0; j < universe.GetLength(0); j++)
                {
                    universe[j, i] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountToolStripMenuItem.Checked == true)
            {
                nCount = true;
            }
            else
            {
                nCount = false;
            }

            graphicsPanel1.Invalidate();
        }
    }
}

// MARK: TODO
// 
// 1.. FIX RANDOMIZE = DNE!!!!
// 2.. Universe Size settings Form = DONE!!
// 3.. living cell count is not working = DONE!
// 4.. RunTo goes to generations instantly rather than via the timer.interval
// 5.. Finite / Toroidal not working.. stuck in toroidal mode
// 6.. Show Hide Neighbors count