namespace IsraelTorres_CE07
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxListStocks = new System.Windows.Forms.ListBox();
            this.btnDownloadJSON = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownLowPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHighPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOpeningPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLastPrice = new System.Windows.Forms.NumericUpDown();
            this.textBoxStockName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpeningPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.newToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listBoxListStocks
            // 
            this.listBoxListStocks.FormattingEnabled = true;
            this.listBoxListStocks.ItemHeight = 25;
            this.listBoxListStocks.Items.AddRange(new object[] {
            "Facebook",
            "Amazon",
            "Apple",
            "Netflix",
            "Google"});
            this.listBoxListStocks.Location = new System.Drawing.Point(29, 68);
            this.listBoxListStocks.Name = "listBoxListStocks";
            this.listBoxListStocks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxListStocks.Size = new System.Drawing.Size(376, 329);
            this.listBoxListStocks.TabIndex = 1;
            // 
            // btnDownloadJSON
            // 
            this.btnDownloadJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadJSON.Location = new System.Drawing.Point(29, 428);
            this.btnDownloadJSON.Name = "btnDownloadJSON";
            this.btnDownloadJSON.Size = new System.Drawing.Size(376, 82);
            this.btnDownloadJSON.TabIndex = 2;
            this.btnDownloadJSON.Text = "Download Data";
            this.btnDownloadJSON.UseVisualStyleBackColor = true;
            this.btnDownloadJSON.Click += new System.EventHandler(this.btnDownloadJSON_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownLowPrice);
            this.groupBox1.Controls.Add(this.numericUpDownHighPrice);
            this.groupBox1.Controls.Add(this.numericUpDownOpeningPrice);
            this.groupBox1.Controls.Add(this.numericUpDownLastPrice);
            this.groupBox1.Controls.Add(this.textBoxStockName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Location = new System.Drawing.Point(427, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 442);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Stock Data";
            // 
            // numericUpDownLowPrice
            // 
            this.numericUpDownLowPrice.DecimalPlaces = 2;
            this.numericUpDownLowPrice.Location = new System.Drawing.Point(238, 259);
            this.numericUpDownLowPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownLowPrice.Name = "numericUpDownLowPrice";
            this.numericUpDownLowPrice.ReadOnly = true;
            this.numericUpDownLowPrice.Size = new System.Drawing.Size(310, 31);
            this.numericUpDownLowPrice.TabIndex = 11;
            // 
            // numericUpDownHighPrice
            // 
            this.numericUpDownHighPrice.DecimalPlaces = 2;
            this.numericUpDownHighPrice.Location = new System.Drawing.Point(238, 209);
            this.numericUpDownHighPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownHighPrice.Name = "numericUpDownHighPrice";
            this.numericUpDownHighPrice.ReadOnly = true;
            this.numericUpDownHighPrice.Size = new System.Drawing.Size(310, 31);
            this.numericUpDownHighPrice.TabIndex = 10;
            // 
            // numericUpDownOpeningPrice
            // 
            this.numericUpDownOpeningPrice.DecimalPlaces = 2;
            this.numericUpDownOpeningPrice.Location = new System.Drawing.Point(238, 157);
            this.numericUpDownOpeningPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownOpeningPrice.Name = "numericUpDownOpeningPrice";
            this.numericUpDownOpeningPrice.ReadOnly = true;
            this.numericUpDownOpeningPrice.Size = new System.Drawing.Size(310, 31);
            this.numericUpDownOpeningPrice.TabIndex = 9;
            // 
            // numericUpDownLastPrice
            // 
            this.numericUpDownLastPrice.DecimalPlaces = 2;
            this.numericUpDownLastPrice.Location = new System.Drawing.Point(238, 107);
            this.numericUpDownLastPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownLastPrice.Name = "numericUpDownLastPrice";
            this.numericUpDownLastPrice.ReadOnly = true;
            this.numericUpDownLastPrice.Size = new System.Drawing.Size(310, 31);
            this.numericUpDownLastPrice.TabIndex = 8;
            // 
            // textBoxStockName
            // 
            this.textBoxStockName.Location = new System.Drawing.Point(238, 60);
            this.textBoxStockName.Name = "textBoxStockName";
            this.textBoxStockName.ReadOnly = true;
            this.textBoxStockName.Size = new System.Drawing.Size(310, 31);
            this.textBoxStockName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Low Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "High Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Opening Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name of the stock:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(37, 340);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(230, 65);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Prev";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(318, 340);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(230, 65);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(321, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(321, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 556);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDownloadJSON);
            this.Controls.Add(this.listBoxListStocks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Stock Data Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpeningPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxListStocks;
        private System.Windows.Forms.Button btnDownloadJSON;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownLowPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownHighPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownOpeningPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownLastPrice;
        private System.Windows.Forms.TextBox textBoxStockName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

