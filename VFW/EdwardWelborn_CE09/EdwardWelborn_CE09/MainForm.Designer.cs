namespace EdwardWelborn_CE09
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewData_groupBox = new System.Windows.Forms.GroupBox();
            this.make_label = new System.Windows.Forms.Label();
            this.year_label = new System.Windows.Forms.Label();
            this.next_button = new System.Windows.Forms.Button();
            this.model_label = new System.Windows.Forms.Label();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.class_label = new System.Windows.Forms.Label();
            this.first_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.last_button = new System.Windows.Forms.Button();
            this.totalRows_Label = new System.Windows.Forms.Label();
            this.currentRow_label = new System.Windows.Forms.Label();
            this.year_combobox = new System.Windows.Forms.ComboBox();
            this.make_textbox = new System.Windows.Forms.TextBox();
            this.currentrow_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.totalrows_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.model_textBox = new System.Windows.Forms.TextBox();
            this.class_textBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.viewData_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentrow_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalrows_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewData_groupBox
            // 
            this.viewData_groupBox.Controls.Add(this.class_textBox);
            this.viewData_groupBox.Controls.Add(this.model_textBox);
            this.viewData_groupBox.Controls.Add(this.totalrows_numericUpDown);
            this.viewData_groupBox.Controls.Add(this.currentrow_numericUpDown);
            this.viewData_groupBox.Controls.Add(this.make_textbox);
            this.viewData_groupBox.Controls.Add(this.year_combobox);
            this.viewData_groupBox.Controls.Add(this.currentRow_label);
            this.viewData_groupBox.Controls.Add(this.totalRows_Label);
            this.viewData_groupBox.Controls.Add(this.last_button);
            this.viewData_groupBox.Controls.Add(this.previous_button);
            this.viewData_groupBox.Controls.Add(this.first_button);
            this.viewData_groupBox.Controls.Add(this.class_label);
            this.viewData_groupBox.Controls.Add(this.model_label);
            this.viewData_groupBox.Controls.Add(this.make_label);
            this.viewData_groupBox.Controls.Add(this.year_label);
            this.viewData_groupBox.Controls.Add(this.next_button);
            this.viewData_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewData_groupBox.Location = new System.Drawing.Point(0, 24);
            this.viewData_groupBox.Name = "viewData_groupBox";
            this.viewData_groupBox.Size = new System.Drawing.Size(533, 304);
            this.viewData_groupBox.TabIndex = 1;
            this.viewData_groupBox.TabStop = false;
            this.viewData_groupBox.Text = "Database Information";
            // 
            // make_label
            // 
            this.make_label.AutoSize = true;
            this.make_label.Location = new System.Drawing.Point(27, 80);
            this.make_label.Name = "make_label";
            this.make_label.Size = new System.Drawing.Size(34, 13);
            this.make_label.TabIndex = 2;
            this.make_label.Text = "Make";
            // 
            // year_label
            // 
            this.year_label.AutoSize = true;
            this.year_label.Location = new System.Drawing.Point(27, 41);
            this.year_label.Name = "year_label";
            this.year_label.Size = new System.Drawing.Size(29, 13);
            this.year_label.TabIndex = 1;
            this.year_label.Text = "Year";
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(270, 236);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 23);
            this.next_button.TabIndex = 0;
            this.next_button.Text = "Next >";
            this.next_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // model_label
            // 
            this.model_label.AutoSize = true;
            this.model_label.Location = new System.Drawing.Point(27, 118);
            this.model_label.Name = "model_label";
            this.model_label.Size = new System.Drawing.Size(36, 13);
            this.model_label.TabIndex = 3;
            this.model_label.Text = "Model";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // class_label
            // 
            this.class_label.AutoSize = true;
            this.class_label.Location = new System.Drawing.Point(27, 160);
            this.class_label.Name = "class_label";
            this.class_label.Size = new System.Drawing.Size(32, 13);
            this.class_label.TabIndex = 5;
            this.class_label.Text = "Class";
            // 
            // first_button
            // 
            this.first_button.Location = new System.Drawing.Point(108, 236);
            this.first_button.Name = "first_button";
            this.first_button.Size = new System.Drawing.Size(75, 23);
            this.first_button.TabIndex = 6;
            this.first_button.Text = "<< First";
            this.first_button.UseVisualStyleBackColor = true;
            this.first_button.Click += new System.EventHandler(this.first_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.Location = new System.Drawing.Point(189, 236);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(75, 23);
            this.previous_button.TabIndex = 7;
            this.previous_button.Text = "< Previous";
            this.previous_button.UseVisualStyleBackColor = true;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // last_button
            // 
            this.last_button.Location = new System.Drawing.Point(351, 236);
            this.last_button.Name = "last_button";
            this.last_button.Size = new System.Drawing.Size(75, 23);
            this.last_button.TabIndex = 8;
            this.last_button.Text = "Last >>";
            this.last_button.UseVisualStyleBackColor = true;
            this.last_button.Click += new System.EventHandler(this.last_button_Click);
            // 
            // totalRows_Label
            // 
            this.totalRows_Label.AutoSize = true;
            this.totalRows_Label.Location = new System.Drawing.Point(271, 202);
            this.totalRows_Label.Name = "totalRows_Label";
            this.totalRows_Label.Size = new System.Drawing.Size(16, 13);
            this.totalRows_Label.TabIndex = 9;
            this.totalRows_Label.Text = "of";
            // 
            // currentRow_label
            // 
            this.currentRow_label.AutoSize = true;
            this.currentRow_label.Location = new System.Drawing.Point(117, 202);
            this.currentRow_label.Name = "currentRow_label";
            this.currentRow_label.Size = new System.Drawing.Size(66, 13);
            this.currentRow_label.TabIndex = 10;
            this.currentRow_label.Text = "Current Row";
            // 
            // year_combobox
            // 
            this.year_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year_combobox.FormattingEnabled = true;
            this.year_combobox.Location = new System.Drawing.Point(93, 38);
            this.year_combobox.Name = "year_combobox";
            this.year_combobox.Size = new System.Drawing.Size(134, 21);
            this.year_combobox.TabIndex = 0;
            // 
            // make_textbox
            // 
            this.make_textbox.Location = new System.Drawing.Point(93, 77);
            this.make_textbox.Name = "make_textbox";
            this.make_textbox.Size = new System.Drawing.Size(134, 20);
            this.make_textbox.TabIndex = 12;
            // 
            // currentrow_numericUpDown
            // 
            this.currentrow_numericUpDown.Location = new System.Drawing.Point(189, 199);
            this.currentrow_numericUpDown.Name = "currentrow_numericUpDown";
            this.currentrow_numericUpDown.Size = new System.Drawing.Size(75, 20);
            this.currentrow_numericUpDown.TabIndex = 16;
            // 
            // totalrows_numericUpDown
            // 
            this.totalrows_numericUpDown.Location = new System.Drawing.Point(293, 199);
            this.totalrows_numericUpDown.Name = "totalrows_numericUpDown";
            this.totalrows_numericUpDown.Size = new System.Drawing.Size(73, 20);
            this.totalrows_numericUpDown.TabIndex = 17;
            // 
            // model_textBox
            // 
            this.model_textBox.Location = new System.Drawing.Point(93, 115);
            this.model_textBox.Name = "model_textBox";
            this.model_textBox.Size = new System.Drawing.Size(134, 20);
            this.model_textBox.TabIndex = 18;
            // 
            // class_textBox
            // 
            this.class_textBox.Location = new System.Drawing.Point(93, 156);
            this.class_textBox.Name = "class_textBox";
            this.class_textBox.Size = new System.Drawing.Size(134, 20);
            this.class_textBox.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 328);
            this.Controls.Add(this.viewData_groupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CE09 Main Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.viewData_groupBox.ResumeLayout(false);
            this.viewData_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentrow_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalrows_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox viewData_groupBox;
        private System.Windows.Forms.Label make_label;
        private System.Windows.Forms.Label year_label;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Label model_label;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ComboBox year_combobox;
        private System.Windows.Forms.Label currentRow_label;
        private System.Windows.Forms.Label totalRows_Label;
        private System.Windows.Forms.Button last_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button first_button;
        private System.Windows.Forms.Label class_label;
        private System.Windows.Forms.TextBox make_textbox;
        private System.Windows.Forms.TextBox class_textBox;
        private System.Windows.Forms.TextBox model_textBox;
        private System.Windows.Forms.NumericUpDown totalrows_numericUpDown;
        private System.Windows.Forms.NumericUpDown currentrow_numericUpDown;
    }
}

