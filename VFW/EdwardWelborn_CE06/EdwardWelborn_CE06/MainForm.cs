/*
* Created by Edward Welborn on 09/19/2019
* Class: Visual Frameworks
* Description: Project CE06
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Main Form
* Summary: This is where the object and open input counters are held, as well as the application exit and list views
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EdwardWelborn_CE06
{
    public partial class MainForm : Form
    {
        public List<TripData> totalsList = new List<TripData>();
        public decimal totalMiles = 0;
        public decimal totalHours = 0;
        public int totalLegs = 0;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cboDirection.Text = "No Where";
            btnAdd.ImageIndex = 6;
            addHovertip((ToolStripStatusLabel)ssHelper.Items[0], this.numMiles, "Enter Miles");
            addHovertip((ToolStripStatusLabel)ssHelper.Items[0], this.numHours, "Enter Hours");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear list and contents of the listview
            tvwTripTotal.Nodes.Clear();
            totalsList.Clear();
            // sets the viewing tab back to 0
            tabTrip.SelectTab(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // add the Direction travelled into the list IF it is NOT nowhere
            if (cboDirection.Text != "No Where")
            {
                
                TripData leg = new TripData();
                leg.Direction = cboDirection.Text;
                leg.Miles = numMiles.Value;
                leg.Hours = numHours.Value;
                leg.Mode = textMode.Text;
                totalsList.Add(leg);
                totalMiles = totalMiles + numMiles.Value;
                totalHours = totalHours + numHours.Value;
                totalLegs++;
                // Build Tree View and calculate totals here..
                BuildTreeList(totalsList);
            }
            else
            {
                MessageBox.Show("Please Choose a Direction Before Adding it to the leg",
                    "Oooopps!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            // Clear the Form
            cboDirection.Text = "No Where";
            numMiles.Text = "0.00";
            numHours.Text = "0.00";
            textMode.Text = "";
        }

        private void BuildTreeList(List<TripData> tripList)
        {
            // We are going to build the tree list here
            // need to add the images to the index, miles = document, hours = plus, mode = x
            tvwTripTotal.Nodes.Clear();
            foreach (var obj in tripList)
            {
                TreeNode rootNode = tvwTripTotal.Nodes.Add(obj.ToString());
                if (obj.Direction == "North")
                    rootNode.ImageIndex = 0;
                if (obj.Direction == "South")
                    rootNode.ImageIndex = 1;
                if (obj.Direction == "East")
                    rootNode.ImageIndex = 2;
                if (obj.Direction == "West")
                    rootNode.ImageIndex = 3;
                // buid child node
                TreeNode child1 = rootNode.Nodes.Add("Miles: " + obj.Miles);
                child1.ImageIndex = 4;
                child1 = rootNode.Nodes.Add("Hours: " + obj.Hours);
                child1.ImageIndex = 6;
                child1 = rootNode.Nodes.Add("Mode: " + obj.Mode);
                child1.ImageIndex = 7;
            }
        }

        public static void addHovertip(ToolStripStatusLabel lb, Control c, string tip)
        {
            c.MouseEnter += (sender, e) =>
            {
                lb.Text = tip;
            };

            c.MouseLeave += (sender, e) =>
            {
                lb.Text = "";
            };

            // iterate over any child controls
            foreach (Control child in c.Controls)
            {
                // and add the hover tip on 
                // those children as well
                addHovertip(lb, child, tip);
            }
        }

        private void cboDirection_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Enter Miles for this leg.";
        }

        private void textMode_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Enter a Driving Mode: i.e. Walking, Driving, Etc,";
        }

        private void tsmiNew_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Create a New Trip";
        }

        private void tsmiExit_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Exit the Application";
        }

        private void textTotalMiles_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Total Miles for this Trip";
        }

        private void textTotalHours_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Total Hours for this Trip";
        }

        private void textTotalLegs_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Totals Legs for this Trip";
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            tslblHelper.Text = "Add this leg to the Trip";
        }
        private void numMiles_Enter(object sender, EventArgs e)
        {
            numMiles.Text = "";
        }

        private void numHours_Enter(object sender, EventArgs e)
        {
            numHours.Text = "";
        }

        public void LeaveField_Event(object sender, EventArgs e)
        {
            tslblHelper.Text = "";
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void totalsTab_Enter(object sender, EventArgs e)
        {
            textTotalMiles.Text = totalMiles.ToString();
            textTotalHours.Text = totalHours.ToString();
            textTotalLegs.Text = totalLegs.ToString();
        }
    }
}
