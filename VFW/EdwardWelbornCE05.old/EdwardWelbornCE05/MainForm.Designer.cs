namespace EdwardWelbornCE05
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssplblNumberOfItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwShips = new System.Windows.Forms.ListView();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imbLarge = new System.Windows.Forms.ImageList(this.components);
            this.imbSmall = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shipToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(367, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // shipToolStripMenuItem
            // 
            this.shipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.shipToolStripMenuItem.Name = "shipToolStripMenuItem";
            this.shipToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.shipToolStripMenuItem.Text = "Ship";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeToolStripMenuItem,
            this.smallToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.largeToolStripMenuItem.Text = "Large";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smallToolStripMenuItem.Text = "Small";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.smallToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssplblNumberOfItems});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(367, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssplblNumberOfItems
            // 
            this.tssplblNumberOfItems.Name = "tssplblNumberOfItems";
            this.tssplblNumberOfItems.Size = new System.Drawing.Size(0, 17);
            // 
            // lvwShips
            // 
            this.lvwShips.HideSelection = false;
            this.lvwShips.LargeImageList = this.imbLarge;
            this.lvwShips.Location = new System.Drawing.Point(0, 28);
            this.lvwShips.Name = "lvwShips";
            this.lvwShips.Size = new System.Drawing.Size(367, 388);
            this.lvwShips.SmallImageList = this.imbSmall;
            this.lvwShips.TabIndex = 2;
            this.lvwShips.UseCompatibleStateImageBehavior = false;
            this.lvwShips.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearDataToolStripMenuItem.Text = "Clear Data";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.clearDataToolStripMenuItem_Click);
            // 
            // imbLarge
            // 
            this.imbLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imbLarge.ImageStream")));
            this.imbLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imbLarge.Images.SetKeyName(0, "freighterLarge.png");
            this.imbLarge.Images.SetKeyName(1, "destroyerLarge.png");
            this.imbLarge.Images.SetKeyName(2, "cruiserLarge.png");
            // 
            // imbSmall
            // 
            this.imbSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imbSmall.ImageStream")));
            this.imbSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imbSmall.Images.SetKeyName(0, "freighterSmall.png");
            this.imbSmall.Images.SetKeyName(1, "destroyerSmall.png");
            this.imbSmall.Images.SetKeyName(2, "cruiserSmall.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 441);
            this.Controls.Add(this.lvwShips);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CE05 MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssplblNumberOfItems;
        private System.Windows.Forms.ListView lvwShips;
        private System.Windows.Forms.ToolStripMenuItem clearDataToolStripMenuItem;
        private System.Windows.Forms.ImageList imbLarge;
        private System.Windows.Forms.ImageList imbSmall;
    }
}

