namespace CE08Lecture
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
            this.GetStockData_groupBox = new System.Windows.Forms.GroupBox();
            this.GetStockQuote_button = new System.Windows.Forms.Button();
            this.XML_radioButton = new System.Windows.Forms.RadioButton();
            this.JSon_radioButton = new System.Windows.Forms.RadioButton();
            this.ChooseStock_ComboBox = new System.Windows.Forms.ComboBox();
            this.chooseStock_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastPrice_numbericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openingPrice_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lastPrice_Label = new System.Windows.Forms.Label();
            this.openingPrice_Label = new System.Windows.Forms.Label();
            this.saveAsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetStockData_groupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastPrice_numbericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingPrice_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GetStockData_groupBox
            // 
            this.GetStockData_groupBox.Controls.Add(this.openingPrice_Label);
            this.GetStockData_groupBox.Controls.Add(this.lastPrice_Label);
            this.GetStockData_groupBox.Controls.Add(this.openingPrice_numericUpDown);
            this.GetStockData_groupBox.Controls.Add(this.lastPrice_numbericUpDown);
            this.GetStockData_groupBox.Controls.Add(this.GetStockQuote_button);
            this.GetStockData_groupBox.Controls.Add(this.XML_radioButton);
            this.GetStockData_groupBox.Controls.Add(this.JSon_radioButton);
            this.GetStockData_groupBox.Controls.Add(this.ChooseStock_ComboBox);
            this.GetStockData_groupBox.Controls.Add(this.chooseStock_label);
            this.GetStockData_groupBox.Location = new System.Drawing.Point(13, 22);
            this.GetStockData_groupBox.Name = "GetStockData_groupBox";
            this.GetStockData_groupBox.Size = new System.Drawing.Size(612, 255);
            this.GetStockData_groupBox.TabIndex = 0;
            this.GetStockData_groupBox.TabStop = false;
            this.GetStockData_groupBox.Text = "Get Stock Data";
            // 
            // GetStockQuote_button
            // 
            this.GetStockQuote_button.Location = new System.Drawing.Point(202, 116);
            this.GetStockQuote_button.Name = "GetStockQuote_button";
            this.GetStockQuote_button.Size = new System.Drawing.Size(109, 23);
            this.GetStockQuote_button.TabIndex = 3;
            this.GetStockQuote_button.Text = "Get Stock Data";
            this.GetStockQuote_button.UseVisualStyleBackColor = true;
            this.GetStockQuote_button.Click += new System.EventHandler(this.ViewStock_Button_Click);
            // 
            // XML_radioButton
            // 
            this.XML_radioButton.AutoSize = true;
            this.XML_radioButton.Checked = true;
            this.XML_radioButton.Location = new System.Drawing.Point(335, 82);
            this.XML_radioButton.Name = "XML_radioButton";
            this.XML_radioButton.Size = new System.Drawing.Size(47, 17);
            this.XML_radioButton.TabIndex = 2;
            this.XML_radioButton.TabStop = true;
            this.XML_radioButton.Text = "XML";
            this.XML_radioButton.UseVisualStyleBackColor = true;
            // 
            // JSon_radioButton
            // 
            this.JSon_radioButton.AutoSize = true;
            this.JSon_radioButton.Location = new System.Drawing.Point(161, 82);
            this.JSon_radioButton.Name = "JSon_radioButton";
            this.JSon_radioButton.Size = new System.Drawing.Size(53, 17);
            this.JSon_radioButton.TabIndex = 1;
            this.JSon_radioButton.Text = "JSON";
            this.JSon_radioButton.UseVisualStyleBackColor = true;
            // 
            // ChooseStock_ComboBox
            // 
            this.ChooseStock_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseStock_ComboBox.FormattingEnabled = true;
            this.ChooseStock_ComboBox.Items.AddRange(new object[] {
            "Amazon",
            "Apple",
            "Google",
            "Netflix",
            "Facebook",
            "Dell"});
            this.ChooseStock_ComboBox.Location = new System.Drawing.Point(161, 42);
            this.ChooseStock_ComboBox.Name = "ChooseStock_ComboBox";
            this.ChooseStock_ComboBox.Size = new System.Drawing.Size(221, 21);
            this.ChooseStock_ComboBox.TabIndex = 0;
            // 
            // chooseStock_label
            // 
            this.chooseStock_label.AutoSize = true;
            this.chooseStock_label.Location = new System.Drawing.Point(26, 45);
            this.chooseStock_label.Name = "chooseStock_label";
            this.chooseStock_label.Size = new System.Drawing.Size(118, 13);
            this.chooseStock_label.TabIndex = 0;
            this.chooseStock_label.Text = "Please Choose a Stock";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXMLToolStripMenuItem,
            this.saveAsXMLToolStripMenuItem,
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
            // lastPrice_numbericUpDown
            // 
            this.lastPrice_numbericUpDown.DecimalPlaces = 2;
            this.lastPrice_numbericUpDown.Location = new System.Drawing.Point(161, 159);
            this.lastPrice_numbericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.lastPrice_numbericUpDown.Name = "lastPrice_numbericUpDown";
            this.lastPrice_numbericUpDown.ReadOnly = true;
            this.lastPrice_numbericUpDown.Size = new System.Drawing.Size(120, 20);
            this.lastPrice_numbericUpDown.TabIndex = 4;
            // 
            // openingPrice_numericUpDown
            // 
            this.openingPrice_numericUpDown.DecimalPlaces = 2;
            this.openingPrice_numericUpDown.Location = new System.Drawing.Point(161, 200);
            this.openingPrice_numericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.openingPrice_numericUpDown.Name = "openingPrice_numericUpDown";
            this.openingPrice_numericUpDown.ReadOnly = true;
            this.openingPrice_numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.openingPrice_numericUpDown.TabIndex = 5;
            // 
            // lastPrice_Label
            // 
            this.lastPrice_Label.AutoSize = true;
            this.lastPrice_Label.Location = new System.Drawing.Point(82, 163);
            this.lastPrice_Label.Name = "lastPrice_Label";
            this.lastPrice_Label.Size = new System.Drawing.Size(54, 13);
            this.lastPrice_Label.TabIndex = 6;
            this.lastPrice_Label.Text = "Last Price";
            // 
            // openingPrice_Label
            // 
            this.openingPrice_Label.AutoSize = true;
            this.openingPrice_Label.Location = new System.Drawing.Point(81, 204);
            this.openingPrice_Label.Name = "openingPrice_Label";
            this.openingPrice_Label.Size = new System.Drawing.Size(74, 13);
            this.openingPrice_Label.TabIndex = 7;
            this.openingPrice_Label.Text = "Opening Price";
            // 
            // saveAsXMLToolStripMenuItem
            // 
            this.saveAsXMLToolStripMenuItem.Name = "saveAsXMLToolStripMenuItem";
            this.saveAsXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsXMLToolStripMenuItem.Text = "Save As XML";
            this.saveAsXMLToolStripMenuItem.Click += new System.EventHandler(this.saveAsXMLToolStripMenuItem_Click);
            // 
            // loadXMLToolStripMenuItem
            // 
            this.loadXMLToolStripMenuItem.Name = "loadXMLToolStripMenuItem";
            this.loadXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadXMLToolStripMenuItem.Text = "Load XML";
            this.loadXMLToolStripMenuItem.Click += new System.EventHandler(this.loadXMLToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 434);
            this.Controls.Add(this.GetStockData_groupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CE08 Lecture";
            this.GetStockData_groupBox.ResumeLayout(false);
            this.GetStockData_groupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastPrice_numbericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingPrice_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GetStockData_groupBox;
        private System.Windows.Forms.Button GetStockQuote_button;
        private System.Windows.Forms.RadioButton XML_radioButton;
        private System.Windows.Forms.RadioButton JSon_radioButton;
        private System.Windows.Forms.ComboBox ChooseStock_ComboBox;
        private System.Windows.Forms.Label chooseStock_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label openingPrice_Label;
        private System.Windows.Forms.Label lastPrice_Label;
        private System.Windows.Forms.NumericUpDown openingPrice_numericUpDown;
        private System.Windows.Forms.NumericUpDown lastPrice_numbericUpDown;
        private System.Windows.Forms.ToolStripMenuItem saveAsXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadXMLToolStripMenuItem;
    }
}

