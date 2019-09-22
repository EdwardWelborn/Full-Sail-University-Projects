namespace EdwardWelborn_CE07
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpQuoteBox = new System.Windows.Forms.GroupBox();
            this.GetData_Button = new System.Windows.Forms.Button();
            this.listBox_StockSelector = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.next_button = new System.Windows.Forms.Button();
            this.prev_button = new System.Windows.Forms.Button();
            this.lowPrice_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lowPrice_Label = new System.Windows.Forms.Label();
            this.highPrice_numbericUpDown = new System.Windows.Forms.NumericUpDown();
            this.highPrice_Label = new System.Windows.Forms.Label();
            this.openingPrice_Label = new System.Windows.Forms.Label();
            this.openingPrice_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lastPriceLabel = new System.Windows.Forms.Label();
            this.lastPrice_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Symbol_textBox = new System.Windows.Forms.TextBox();
            this.symbolLabel = new System.Windows.Forms.Label();
            this.CompanyName_TextBox = new System.Windows.Forms.TextBox();
            this.companyLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.grpQuoteBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowPrice_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highPrice_numbericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingPrice_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastPrice_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 0;
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
            // grpQuoteBox
            // 
            this.grpQuoteBox.Controls.Add(this.GetData_Button);
            this.grpQuoteBox.Controls.Add(this.listBox_StockSelector);
            this.grpQuoteBox.Location = new System.Drawing.Point(12, 27);
            this.grpQuoteBox.Name = "grpQuoteBox";
            this.grpQuoteBox.Size = new System.Drawing.Size(118, 265);
            this.grpQuoteBox.TabIndex = 1;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.next_button);
            this.groupBox1.Controls.Add(this.prev_button);
            this.groupBox1.Controls.Add(this.lowPrice_numericUpDown);
            this.groupBox1.Controls.Add(this.lowPrice_Label);
            this.groupBox1.Controls.Add(this.highPrice_numbericUpDown);
            this.groupBox1.Controls.Add(this.highPrice_Label);
            this.groupBox1.Controls.Add(this.openingPrice_Label);
            this.groupBox1.Controls.Add(this.openingPrice_numericUpDown);
            this.groupBox1.Controls.Add(this.lastPriceLabel);
            this.groupBox1.Controls.Add(this.lastPrice_numericUpDown);
            this.groupBox1.Controls.Add(this.Symbol_textBox);
            this.groupBox1.Controls.Add(this.symbolLabel);
            this.groupBox1.Controls.Add(this.CompanyName_TextBox);
            this.groupBox1.Controls.Add(this.companyLabel);
            this.groupBox1.Location = new System.Drawing.Point(146, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 265);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Stock Data";
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(182, 220);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 23);
            this.next_button.TabIndex = 13;
            this.next_button.Text = "Next";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // prev_button
            // 
            this.prev_button.Location = new System.Drawing.Point(41, 220);
            this.prev_button.Name = "prev_button";
            this.prev_button.Size = new System.Drawing.Size(75, 23);
            this.prev_button.TabIndex = 12;
            this.prev_button.Text = "Previous";
            this.prev_button.UseVisualStyleBackColor = true;
            this.prev_button.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lowPrice_numericUpDown
            // 
            this.lowPrice_numericUpDown.Location = new System.Drawing.Point(107, 181);
            this.lowPrice_numericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.lowPrice_numericUpDown.Name = "lowPrice_numericUpDown";
            this.lowPrice_numericUpDown.ReadOnly = true;
            this.lowPrice_numericUpDown.Size = new System.Drawing.Size(175, 20);
            this.lowPrice_numericUpDown.TabIndex = 11;
            // 
            // lowPrice_Label
            // 
            this.lowPrice_Label.AutoSize = true;
            this.lowPrice_Label.Location = new System.Drawing.Point(17, 185);
            this.lowPrice_Label.Name = "lowPrice_Label";
            this.lowPrice_Label.Size = new System.Drawing.Size(54, 13);
            this.lowPrice_Label.TabIndex = 10;
            this.lowPrice_Label.Text = "Low Price";
            // 
            // highPrice_numbericUpDown
            // 
            this.highPrice_numbericUpDown.Location = new System.Drawing.Point(107, 145);
            this.highPrice_numbericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.highPrice_numbericUpDown.Name = "highPrice_numbericUpDown";
            this.highPrice_numbericUpDown.ReadOnly = true;
            this.highPrice_numbericUpDown.Size = new System.Drawing.Size(175, 20);
            this.highPrice_numbericUpDown.TabIndex = 9;
            // 
            // highPrice_Label
            // 
            this.highPrice_Label.AutoSize = true;
            this.highPrice_Label.Location = new System.Drawing.Point(18, 149);
            this.highPrice_Label.Name = "highPrice_Label";
            this.highPrice_Label.Size = new System.Drawing.Size(56, 13);
            this.highPrice_Label.TabIndex = 8;
            this.highPrice_Label.Text = "High Price";
            // 
            // openingPrice_Label
            // 
            this.openingPrice_Label.AutoSize = true;
            this.openingPrice_Label.Location = new System.Drawing.Point(18, 114);
            this.openingPrice_Label.Name = "openingPrice_Label";
            this.openingPrice_Label.Size = new System.Drawing.Size(74, 13);
            this.openingPrice_Label.TabIndex = 7;
            this.openingPrice_Label.Text = "Opening Price";
            // 
            // openingPrice_numericUpDown
            // 
            this.openingPrice_numericUpDown.Location = new System.Drawing.Point(107, 111);
            this.openingPrice_numericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.openingPrice_numericUpDown.Name = "openingPrice_numericUpDown";
            this.openingPrice_numericUpDown.ReadOnly = true;
            this.openingPrice_numericUpDown.Size = new System.Drawing.Size(175, 20);
            this.openingPrice_numericUpDown.TabIndex = 6;
            // 
            // lastPriceLabel
            // 
            this.lastPriceLabel.AutoSize = true;
            this.lastPriceLabel.Location = new System.Drawing.Point(17, 83);
            this.lastPriceLabel.Name = "lastPriceLabel";
            this.lastPriceLabel.Size = new System.Drawing.Size(54, 13);
            this.lastPriceLabel.TabIndex = 5;
            this.lastPriceLabel.Text = "Last Price";
            // 
            // lastPrice_numericUpDown
            // 
            this.lastPrice_numericUpDown.Location = new System.Drawing.Point(107, 80);
            this.lastPrice_numericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.lastPrice_numericUpDown.Name = "lastPrice_numericUpDown";
            this.lastPrice_numericUpDown.ReadOnly = true;
            this.lastPrice_numericUpDown.Size = new System.Drawing.Size(175, 20);
            this.lastPrice_numericUpDown.TabIndex = 4;
            // 
            // Symbol_textBox
            // 
            this.Symbol_textBox.Location = new System.Drawing.Point(107, 49);
            this.Symbol_textBox.Name = "Symbol_textBox";
            this.Symbol_textBox.ReadOnly = true;
            this.Symbol_textBox.Size = new System.Drawing.Size(175, 20);
            this.Symbol_textBox.TabIndex = 3;
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(17, 53);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(72, 13);
            this.symbolLabel.TabIndex = 2;
            this.symbolLabel.Text = "Stock Symbol";
            // 
            // CompanyName_TextBox
            // 
            this.CompanyName_TextBox.Location = new System.Drawing.Point(107, 20);
            this.CompanyName_TextBox.Name = "CompanyName_TextBox";
            this.CompanyName_TextBox.ReadOnly = true;
            this.CompanyName_TextBox.Size = new System.Drawing.Size(175, 20);
            this.CompanyName_TextBox.TabIndex = 1;
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(14, 23);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(82, 13);
            this.companyLabel.TabIndex = 0;
            this.companyLabel.Text = "Company Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpQuoteBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CE07 Main Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpQuoteBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowPrice_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highPrice_numbericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingPrice_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lastPrice_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpQuoteBox;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_StockSelector;
        private System.Windows.Forms.Button GetData_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label symbolLabel;
        private System.Windows.Forms.TextBox CompanyName_TextBox;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.TextBox Symbol_textBox;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button prev_button;
        private System.Windows.Forms.NumericUpDown lowPrice_numericUpDown;
        private System.Windows.Forms.Label lowPrice_Label;
        private System.Windows.Forms.NumericUpDown highPrice_numbericUpDown;
        private System.Windows.Forms.Label highPrice_Label;
        private System.Windows.Forms.Label openingPrice_Label;
        private System.Windows.Forms.NumericUpDown openingPrice_numericUpDown;
        private System.Windows.Forms.Label lastPriceLabel;
        private System.Windows.Forms.NumericUpDown lastPrice_numericUpDown;
    }
}

