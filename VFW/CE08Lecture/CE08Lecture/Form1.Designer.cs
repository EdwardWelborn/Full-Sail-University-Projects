namespace CE08Lecture
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
            this.GetStockData_groupBox = new System.Windows.Forms.GroupBox();
            this.chooseStock_label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.JSon_radioButton = new System.Windows.Forms.RadioButton();
            this.XML_radioButton = new System.Windows.Forms.RadioButton();
            this.GetStockQuote_button = new System.Windows.Forms.Button();
            this.GetStockData_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetStockData_groupBox
            // 
            this.GetStockData_groupBox.Controls.Add(this.GetStockQuote_button);
            this.GetStockData_groupBox.Controls.Add(this.XML_radioButton);
            this.GetStockData_groupBox.Controls.Add(this.JSon_radioButton);
            this.GetStockData_groupBox.Controls.Add(this.comboBox1);
            this.GetStockData_groupBox.Controls.Add(this.chooseStock_label);
            this.GetStockData_groupBox.Location = new System.Drawing.Point(13, 22);
            this.GetStockData_groupBox.Name = "GetStockData_groupBox";
            this.GetStockData_groupBox.Size = new System.Drawing.Size(612, 400);
            this.GetStockData_groupBox.TabIndex = 0;
            this.GetStockData_groupBox.TabStop = false;
            this.GetStockData_groupBox.Text = "Get Stock Data";
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Amazon",
            "Google",
            "Apple",
            "Netflix",
            "Facebook"});
            this.comboBox1.Location = new System.Drawing.Point(161, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 21);
            this.comboBox1.TabIndex = 0;
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
            // GetStockQuote_button
            // 
            this.GetStockQuote_button.Location = new System.Drawing.Point(202, 116);
            this.GetStockQuote_button.Name = "GetStockQuote_button";
            this.GetStockQuote_button.Size = new System.Drawing.Size(109, 23);
            this.GetStockQuote_button.TabIndex = 3;
            this.GetStockQuote_button.Text = "Get Stock Data";
            this.GetStockQuote_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 434);
            this.Controls.Add(this.GetStockData_groupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GetStockData_groupBox.ResumeLayout(false);
            this.GetStockData_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GetStockData_groupBox;
        private System.Windows.Forms.Button GetStockQuote_button;
        private System.Windows.Forms.RadioButton XML_radioButton;
        private System.Windows.Forms.RadioButton JSon_radioButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseStock_label;
    }
}

