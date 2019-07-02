using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDR_Reporting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<Item>> PendingSales = new Dictionary<string, List<Item>>();

            Dictionary<string, ItemEx> Inventory = new Dictionary<string, ItemEx>();
            ItemEx item1 = new ItemEx
            {
                ID = "BK312",
                Description = "Clutch Brake",
                OnHand = 2000,
                ReorderLevel = 500,
                ReorderQty = 2000
            };
            Inventory.Add(item1.ID, item1);

            ItemEx item2 = new ItemEx
            {
                ID = "GH0001",
                Description = "Glad Hand",
                OnHand = 2000,
                ReorderLevel = 500,
                ReorderQty = 2000
            };
            Inventory.Add(item2.ID, item2);

            ItemEx item3 = new ItemEx
            {
                ID = "T20090",
                Description = "Air Tank",
                OnHand = 5,
                ReorderLevel = 1,
                ReorderQty = 5
            };
            Inventory.Add(item3.ID, item3);

            ItemEx item4 = new ItemEx
            {
                ID = "C20156",
                Description = "Compressor",
                OnHand = 2,
                ReorderLevel = 1,
                ReorderQty = 2
            };
            Inventory.Add(item4.ID, item4);

            ItemEx item5 = new ItemEx
            {
                ID = "LC3030",
                Description = "Spring Brake",
                OnHand = 100,
                ReorderLevel = 48,
                ReorderQty = 96
            };
            Inventory.Add(item5.ID, item5);

            List<Item> Cust1Cart = new List<Item>();
            if (Inventory.ContainsKey("LC3030"))
            {
                Item val;
                val = Inventory["LC3030"];
                Cust1Cart.Add((Item)val);
            }
            if (Inventory.ContainsKey("GH0001"))
            {
                Item val;
                val = Inventory["GH0001"];
                Cust1Cart.Add((Item)val);
            }
            PendingSales.Add("Cust0001", Cust1Cart);

            List<Item> Cust2Cart = new List<Item>();
            if (Inventory.ContainsKey("C20156"))
            {
                Item val;
                val = Inventory["C20156"];
                Cust2Cart.Add((Item)val);
            }
            if (Inventory.ContainsKey("T20090"))
            {
                Item val;
                val = Inventory["T20090"];
                Cust2Cart.Add((Item)val);
            }
            PendingSales.Add("Cust0002", Cust2Cart);

            List<Item> Cust3Cart = new List<Item>();
            if (Inventory.ContainsKey("BK312"))
            {
                Item val;
                val = Inventory["BK312"];
                Cust3Cart.Add((Item)val);
            }
            PendingSales.Add("Cust0003", Cust3Cart);

            foreach (KeyValuePair<string, List<Item>> pair in PendingSales)
            {
                textBox1.AppendText($"Customer { pair.Key} is purchasing:" + Environment.NewLine);
                foreach (Item i in pair.Value)
                    textBox1.AppendText($"{i.ID}  {i.Description}" + Environment.NewLine);
            }
        }
    }

    public class Item
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }
    }

    public class ItemEx: Item
    {
        public int OnHand { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQty { get; set; }
        public double Cost { get; set; }
        public string VendorID { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
