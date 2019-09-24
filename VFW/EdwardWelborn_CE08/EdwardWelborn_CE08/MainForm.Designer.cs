namespace EdwardWelborn_CE08
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
            this.grpQuoteBox = new System.Windows.Forms.GroupBox();
            this.GetData_Button = new System.Windows.Forms.Button();
            this.listBox_StockSelector = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewData_groupBox = new System.Windows.Forms.GroupBox();
            this.viewStockData_TreeView = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpQuoteBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.viewData_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpQuoteBox
            // 
            this.grpQuoteBox.Controls.Add(this.GetData_Button);
            this.grpQuoteBox.Controls.Add(this.listBox_StockSelector);
            this.grpQuoteBox.Location = new System.Drawing.Point(12, 27);
            this.grpQuoteBox.Name = "grpQuoteBox";
            this.grpQuoteBox.Size = new System.Drawing.Size(108, 203);
            this.grpQuoteBox.TabIndex = 2;
            this.grpQuoteBox.TabStop = false;
            this.grpQuoteBox.Text = "Get Stock Data";
            // 
            // GetData_Button
            // 
            this.GetData_Button.Location = new System.Drawing.Point(18, 157);
            this.GetData_Button.Name = "GetData_Button";
            this.GetData_Button.Size = new System.Drawing.Size(72, 23);
            this.GetData_Button.TabIndex = 1;
            this.GetData_Button.Text = "Get Data";
            this.GetData_Button.UseVisualStyleBackColor = true;
            this.GetData_Button.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // listBox_StockSelector
            // 
            this.listBox_StockSelector.FormattingEnabled = true;
            this.listBox_StockSelector.Items.AddRange(new object[] {
            "Amazon",
            "Google",
            "Apple",
            "Netflix",
            "Facebook"});
            this.listBox_StockSelector.Location = new System.Drawing.Point(18, 20);
            this.listBox_StockSelector.Name = "listBox_StockSelector";
            this.listBox_StockSelector.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_StockSelector.Size = new System.Drawing.Size(72, 108);
            this.listBox_StockSelector.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(333, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewData_groupBox
            // 
            this.viewData_groupBox.Controls.Add(this.viewStockData_TreeView);
            this.viewData_groupBox.Location = new System.Drawing.Point(126, 28);
            this.viewData_groupBox.Name = "viewData_groupBox";
            this.viewData_groupBox.Size = new System.Drawing.Size(197, 202);
            this.viewData_groupBox.TabIndex = 4;
            this.viewData_groupBox.TabStop = false;
            this.viewData_groupBox.Text = "View Stock Data";
            // 
            // viewStockData_TreeView
            // 
            this.viewStockData_TreeView.Location = new System.Drawing.Point(6, 19);
            this.viewStockData_TreeView.Name = "viewStockData_TreeView";
            this.viewStockData_TreeView.Size = new System.Drawing.Size(185, 177);
            this.viewStockData_TreeView.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 248);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 313);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.viewData_groupBox);
            this.Controls.Add(this.grpQuoteBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CE08 Main Form";
            this.grpQuoteBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.viewData_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpQuoteBox;
        private System.Windows.Forms.Button GetData_Button;
        private System.Windows.Forms.ListBox listBox_StockSelector;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox viewData_groupBox;
        private System.Windows.Forms.TreeView viewStockData_TreeView;
        private System.Windows.Forms.TextBox textBox1;
    }
}

