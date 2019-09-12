namespace EdwardWelborn_CE04
{
    partial class dataEntryForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbDataView = new System.Windows.Forms.GroupBox();
            this.cbImmortal = new System.Windows.Forms.CheckBox();
            this.lblRace = new System.Windows.Forms.Label();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.llblFirstname = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.gbDataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 385);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(277, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // gbDataView
            // 
            this.gbDataView.Controls.Add(this.cbImmortal);
            this.gbDataView.Controls.Add(this.lblRace);
            this.gbDataView.Controls.Add(this.cmbRace);
            this.gbDataView.Controls.Add(this.lblClass);
            this.gbDataView.Controls.Add(this.cmbClass);
            this.gbDataView.Controls.Add(this.btnAddData);
            this.gbDataView.Controls.Add(this.btnClear);
            this.gbDataView.Controls.Add(this.lblGender);
            this.gbDataView.Controls.Add(this.cmbGender);
            this.gbDataView.Controls.Add(this.tbLastName);
            this.gbDataView.Controls.Add(this.tbFirstName);
            this.gbDataView.Controls.Add(this.numAge);
            this.gbDataView.Controls.Add(this.lblAge);
            this.gbDataView.Controls.Add(this.lblLastName);
            this.gbDataView.Controls.Add(this.llblFirstname);
            this.gbDataView.Location = new System.Drawing.Point(0, 11);
            this.gbDataView.Margin = new System.Windows.Forms.Padding(2);
            this.gbDataView.Name = "gbDataView";
            this.gbDataView.Padding = new System.Windows.Forms.Padding(2);
            this.gbDataView.Size = new System.Drawing.Size(267, 373);
            this.gbDataView.TabIndex = 4;
            this.gbDataView.TabStop = false;
            this.gbDataView.Text = "Character Information";
            // 
            // cbImmortal
            // 
            this.cbImmortal.AutoSize = true;
            this.cbImmortal.Location = new System.Drawing.Point(95, 265);
            this.cbImmortal.Margin = new System.Windows.Forms.Padding(2);
            this.cbImmortal.Name = "cbImmortal";
            this.cbImmortal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbImmortal.Size = new System.Drawing.Size(71, 17);
            this.cbImmortal.TabIndex = 7;
            this.cbImmortal.Text = "?Immortal";
            this.cbImmortal.UseVisualStyleBackColor = true;
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(28, 238);
            this.lblRace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(33, 13);
            this.lblRace.TabIndex = 13;
            this.lblRace.Text = "Race";
            // 
            // cmbRace
            // 
            this.cmbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Items.AddRange(new object[] {
            "Human",
            "Dwarf",
            "Troll",
            "Tauren",
            "Elf",
            "Undead"});
            this.cmbRace.Location = new System.Drawing.Point(96, 233);
            this.cmbRace.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(82, 21);
            this.cmbRace.TabIndex = 6;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(28, 199);
            this.lblClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 11;
            this.lblClass.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "Warrior",
            "Rogue",
            "Druid",
            "Mage",
            "Priest"});
            this.cmbClass.Location = new System.Drawing.Point(96, 194);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(82, 21);
            this.cmbClass.TabIndex = 4;
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(137, 299);
            this.btnAddData.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(97, 33);
            this.btnAddData.TabIndex = 9;
            this.btnAddData.Text = "Add Data to List";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(17, 299);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 33);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(25, 153);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(95, 151);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(82, 21);
            this.cmbGender.TabIndex = 3;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(96, 78);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(139, 20);
            this.tbLastName.TabIndex = 1;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(96, 40);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(139, 20);
            this.tbFirstName.TabIndex = 0;
            // 
            // numAge
            // 
            this.numAge.AutoSize = true;
            this.numAge.Location = new System.Drawing.Point(96, 116);
            this.numAge.Margin = new System.Windows.Forms.Padding(2);
            this.numAge.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(80, 20);
            this.numAge.TabIndex = 2;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(25, 117);
            this.lblAge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(25, 81);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // llblFirstname
            // 
            this.llblFirstname.AutoSize = true;
            this.llblFirstname.Location = new System.Drawing.Point(25, 43);
            this.llblFirstname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llblFirstname.Name = "llblFirstname";
            this.llblFirstname.Size = new System.Drawing.Size(57, 13);
            this.llblFirstname.TabIndex = 0;
            this.llblFirstname.Text = "First Name";
            // 
            // dataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 407);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbDataView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "dataEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE04 Main Form";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbDataView.ResumeLayout(false);
            this.gbDataView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox gbDataView;
        private System.Windows.Forms.CheckBox cbImmortal;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblGender;
        public System.Windows.Forms.ComboBox cmbGender;
        public System.Windows.Forms.TextBox tbLastName;
        public System.Windows.Forms.TextBox tbFirstName;
        public System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label llblFirstname;
    }
}

