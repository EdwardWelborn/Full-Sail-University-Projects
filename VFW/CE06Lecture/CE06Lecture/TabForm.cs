using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CE06Lecture
{
    public partial class TabForm : Form
    {
        Random rand = new Random();

        public TabForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            List<Data> objectToPopulate = GeneratedData(5);
            foreach (Data obj in objectToPopulate)
            {
                ListViewItem lvi = new ListViewItem(obj.ToString(), 1);
                lvi.Tag = obj;

                listView.Items.Add(lvi);
            }
        }

        private List<Data> GeneratedData(int countDown)
        {
            List<Data> dataList = new List<Data>();
            for (int i = 0; i < countDown; i++)
            {
                Data dataObject = new Data();
                dataObject.DataNumber = (i + 1);
                dataObject.Height = rand.Next(50, 190);
                dataObject.Weight = rand.Next(70, 250);
                int numData = rand.Next(1, 7);
                for (int x = 0; x < numData; x++)
                {
                    Data internalDataObject = new Data();
                    internalDataObject.DataNumber = (x + 1);
                    internalDataObject.Height = rand.Next(50, 150);
                    internalDataObject.Weight = rand.Next(70, 250);
                    dataObject.ContainedData.Add(internalDataObject);
                }

                dataList.Add(dataObject);
            }

            return dataList;
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exits the application when clicked
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            InitializeData();

            tabControl.SelectTab(0);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "TreeViewTab")
            {
                BuildTree();
            } 
        }

        private void BuildTree()
        {
            treeView1.Nodes.Clear();
            foreach (ListViewItem lvi in listView.SelectedItems)
            {
                TreeNode node = new TreeNode();
                Data data = lvi.Tag as Data;

                node.Text = data.ToString();
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                node.Nodes.Add("Height: " + data.Height);
                node.Nodes.Add("Weight: " + data.Weight);

                foreach (Data dataObj in data.ContainedData)
                {
                    TreeNode nestedNode = new TreeNode();
                    nestedNode.Text = dataObj.ToString();
                    nestedNode.ImageIndex = 1;
                    nestedNode.SelectedImageIndex = 1;
                    nestedNode.Nodes.Add("Height: " + dataObj.Height);
                    nestedNode.Nodes.Add("Weight: " + dataObj.Weight);

                    node.Nodes.Add(nestedNode);
                }

                treeView1.Nodes.Add(node); 
            }
        }
    }
}
