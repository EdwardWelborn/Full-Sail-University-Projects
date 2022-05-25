using System;
using System.Drawing;
using System.IO;
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

        // setup starting variables
        static int columns;
        static int rows;
         
        bool[,] cells;
        int cellCount;
        int seed;
        int gridWidth;

        bool neighborCountDisplay = true;
        int counter = 0;

        private Random rnd;
        private int runTo = 1;
        bool border;
        string boundryType;

        // Drawing colors, brush and pen variables
        Color gridColor;
        Color cellColor;
        Color backgroundColor;
        Brush cellBrush;
        Pen gridPen;

        // The Timer class
        Timer timer = new Timer();
    
        // Generation count
        int generations = 1;
        private int randomizedSeed;
         
        // Main Method. It all starts here
        public fmMain()
        {
            InitializeComponent();
            //application title
            this.Text = Properties.Settings.Default.appTitle;

            //window size and set default columns/rows
            Size = new Size(725, 620);
            columns = Properties.Settings.Default.columns;
            rows = Properties.Settings.Default.rows;
            cells = new bool[columns, rows];
            gridWidth = Properties.Settings.Default.lineWidth;

            // set border to finite and check appropriated boxes
            border = false;
            boundryType = "Finite";
            finiteToolStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Checked = false;
            neighborCountToolStripMenuItem.Checked = true;

            // Setup the timer
            timer.Interval = Properties.Settings.Default.timeInterval;
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // do not start timer running
            timer.Tag = 0;
            
            // set the default seed
            seed = Properties.Settings.Default.seed;

            // setup default colors
            gridColor = Properties.Settings.Default.gridColor;
            cellColor = Properties.Settings.Default.cellColor;
            backgroundColor = Properties.Settings.Default.backgroundColor;

            
            // initialize universe
            ResizeUniverse();
            // initialize labels
            UpdateStatusLabels();
            // initialize colors
            UpdateColors();

        }

        // Figures out how many neighbors each cell has when the boundytype is finite
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

                        if (yOffset == 0 && xOffset == 0)
                        {
                            continue;
                        }
                        if (xCheck < 0)
                        {
                            continue;
                        }
                        if (yCheck < 0)
                        {
                            continue;
                        }
                        if (xCheck >= xLen)
                        {
                            continue;
                        }
                        if (yCheck >= yLen)
                        {
                            continue;
                        }

                        if (universe[xCheck, yCheck] == true)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }

        // Figures out how many neighbors each cell has when the boundytype is toroidal
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
                    if (border)
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
            if (runTo > 1)
            {
                counter++;
                if (counter >= runTo)
                {
                    DisableSimulation();
                }
            }
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
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

                        if (neighborCountDisplay)
                        {
                            Font font = new Font("Arial", 10f);

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

        // clears the grid and resets all variables.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetUniverse();
        }

        // opens the open file dialog and imports the .cell file they point to
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

        // saves the current grid to a file that can be imported back into the program
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

        // exits the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exits the application
            Application.Exit();
        }

        // starts the simulation via the menu item or the toolstip button for start
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            counter = 1;
            runTo = 1;
            EnableSimulation();
        }

        // pauses the simulation via the menu item or the toolstip button for pause
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DisableSimulation();
        }

        // stops the simulation via the menu item or the toolstip button for stop
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DisableSimulation();
        }

        // pauses the simulation, and lets you step through the generatsions 1 by 1
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableSimulation();
            NextGeneration();
        }

        // randomizes the grid from the current seed
        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeCells(seed);
            UpdateStatusLabels();
        }

        // opens a dialog and lets the user enter a new seed to randomly populate the grid
        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedDialog dlg = new SeedDialog();

            dlg.Seed = seed;

            if (DialogResult.OK == dlg.ShowDialog())

                RandomizeCells(dlg.Seed);

            UpdateStatusLabels();
        }

        // randomizes the grid from the current timer setting
        private void fromTimerSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeCells(new Random((int)DateTime.Now.Ticks).Next());
            UpdateStatusLabels();
        }

        // opens a dialog to change the grid background color
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

        // opens a dialog to change the grid cell color
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

        // opens a dialog to change the grid border color
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

        // Clears the cells on the grid
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

        // opens a dialog to change the timer interval setting
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

        // Opens a dialog to change the default universe size
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

        // Opens the about dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }
        
        // this method resets the universe, stops any time, and clears the grid
        private void ResetUniverse()
        {
            DisableSimulation();
            Clear();
            generations = 0;
            counter = 1;
            runTo = 1;

            cells = new bool[columns, rows];

            graphicsPanel1.Invalidate();
        }

        // stops the simulation, and resets any counters, also disables the controls that are not needed
        private void DisableSimulation()
        {
            counter = 1;
            runTo = 1;

            timer.Enabled = false;

            startToolStripButton.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            stopToolStripButton.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            pauseToolStripButton.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
        }

        // starts the simulation, enables and disables controls that are not needed while the simulation runs
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

        // Changes the boundry to toroidal (cells can cross edges)
        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to toroidal
            border = true;
            finiteToolStripMenuItem.Checked = false;
            toroidalToolStripMenuItem.Checked = true;
            boundryType = "Toroidal";
            UpdateStatusLabels();
        }

        // Changes the boundry to finite (cells cannot cross edges)
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change universe style to finite
            border = false;
            finiteToolStripMenuItem.Checked = true;
            toroidalToolStripMenuItem.Checked = false;
            boundryType = "Finite";
            UpdateStatusLabels();
        }

        // Updates color scheme per default or user defined settings
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

        // resets colors back to default settings
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

        // randomizes the grid and places lives in the cells
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

        // used by randomizecells to populate the cells
        private void Reseed(int newSeed)
        {
            seed = newSeed;
            rnd = new Random(seed);
            UpdateStatusLabels();
        }
 
        // updates status label to reflect any changes to the toolstrip labels
        private void UpdateStatusLabels()
        {
            universeToolStripStatusLabel.Text = "Universe Size = " + columns + "x" + rows + " (" + boundryType + ")";
            generationToolStripStatusLabel.Text = "Generation = " + generations;
            aliveToolStripStatusLabel.Text = "Cells alive = " + cellCount;
            timerIntervaloolStripStatusLabel.Text = "Timer Interval = " + timer.Interval;
            seedToolStripStatusLabel.Text = "Seed = " + seed;
        }

        // opens the dialog for the user to run the simulation to a certain number
        private void runToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            counter = 1;
            runTo = 1;
            RunToDialog dlg = new RunToDialog();

            dlg.RunTo = runTo;
            dlg.runToNumericUpDown.Text = null;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                runTo = dlg.RunTo;
                RunTo(runTo);
            }
        }

        // sets the counter to 1, and enables the simulation
        private void RunTo(int runTo)
        {
            // This method fires instantaneously instead of like the simulation with timer.interval
            counter = 1;
            EnableSimulation();
            

        }

        // resizes the universe after any changes to the grid columns and rows
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

        // Clears the cells and grid
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

        // shows or hides the neighbor count 
        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountToolStripMenuItem.Checked == true)
            {
                neighborCountDisplay = true;
            }
            else
            {
                neighborCountDisplay = false;
            }

            graphicsPanel1.Invalidate();
        }
    }
}

// MARK: TODO
//
// NOTHING ALL DONE, thank goodness