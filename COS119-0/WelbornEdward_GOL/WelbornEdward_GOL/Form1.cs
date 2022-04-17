using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelbornEdward_GOL
{
    

    public partial class fmMain : Form
    {
        private int seed;
        // The universe array
        bool[,] universe = new bool[50, 50];

        // The Swap Universe
        bool [,] swapUniverse = new bool[50, 50];

        private int livingCells;
        private int generation;
        public int LivingCells => this.livingCells;

        public int Generation => this.generation;

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        // To contain the cell's data
        const int Alive = 1;
        const int Dead = 0;
        static int columns = 50;
        static int rows = 50;
        // string[,] cellData = new string[columns, rows];

        int neighbors = 0;

        public fmMain()
        {
            InitializeComponent();
            this.seed = 2022;
            //application title
            this.Text = Properties.Resources.AppTitle;

            //window size
            Size = new Size(800, 700);

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; 
        }

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
                            swapUniverse[x, y] = false;
                        }
                        else if (neighbors > 3)
                        {
                            swapUniverse[x, y] = false;
                        }
                        else if (neighbors == 2 || neighbors == 3)
                        {
                            swapUniverse[x, y] = true;
                        }
                    }
                    else if (universe[x, y] == false && neighbors == 3)
                    {
                        swapUniverse[x, y] = true;
                    }
                }
            }
            universe = (bool[,])swapUniverse.Clone();
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            // toolStripLivingLabel.Text = "Alive: " + 
            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void randomizeBySeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randomize(this.seed);
           
        }

        private void randomizeByTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.seed = new Random().Next();
            Randomize(this.seed);
            
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    swapUniverse[x, y] = false;
                    // resets the generation count to 0
                    generations = 0;
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
                    // Tells windows to repaint
                    graphicsPanel1.Invalidate();
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        public void Randomize(int seed)
        {

        }

        public void Clear()
        {
 
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            NextGeneration();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                    swapUniverse[x, y] = false;
                    // resets the generation count to 0
                    generations = 0;
                    toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
                    // Tells windows to repaint
                    graphicsPanel1.Invalidate();
                }
            }
        }
    }

}
