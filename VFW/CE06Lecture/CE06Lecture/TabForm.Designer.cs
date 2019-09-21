namespace CE06Lecture
{
    partial class TabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ListViewTab = new System.Windows.Forms.TabPage();
            this.TreeViewTab = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.ListViewTab.SuspendLayout();
            this.TreeViewTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(288, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ListViewTab);
            this.tabControl.Controls.Add(this.TreeViewTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(288, 364);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // ListViewTab
            // 
            this.ListViewTab.Controls.Add(this.listView);
            this.ListViewTab.Location = new System.Drawing.Point(4, 22);
            this.ListViewTab.Name = "ListViewTab";
            this.ListViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.ListViewTab.Size = new System.Drawing.Size(280, 338);
            this.ListViewTab.TabIndex = 0;
            this.ListViewTab.Text = "ListView";
            this.ListViewTab.UseVisualStyleBackColor = true;
            // 
            // TreeViewTab
            // 
            this.TreeViewTab.Controls.Add(this.treeView1);
            this.TreeViewTab.Location = new System.Drawing.Point(4, 22);
            this.TreeViewTab.Name = "TreeViewTab";
            this.TreeViewTab.Padding = new System.Windows.Forms.Padding(3);
            this.TreeViewTab.Size = new System.Drawing.Size(280, 338);
            this.TreeViewTab.TabIndex = 1;
            this.TreeViewTab.Text = "TreeView";
            this.TreeViewTab.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "data-512.png");
            this.imageList1.Images.SetKeyName(1, "document.png");
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList1;
            this.listView.Location = new System.Drawing.Point(3, 3);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(274, 332);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(274, 332);
            this.treeView1.TabIndex = 0;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 388);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TabForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ListViewTab.ResumeLayout(false);
            this.TreeViewTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ListViewTab;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TabPage TreeViewTab;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

