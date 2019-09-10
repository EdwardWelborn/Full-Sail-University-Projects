namespace EdwardWelborn_CE04
{
    partial class mainForm
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
            this.udAge = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.llblFirstname = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.gbDataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAge)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 604);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip.Size = new System.Drawing.Size(416, 22);
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
            this.gbDataView.Controls.Add(this.udAge);
            this.gbDataView.Controls.Add(this.lblAge);
            this.gbDataView.Controls.Add(this.lblLastName);
            this.gbDataView.Controls.Add(this.llblFirstname);
            this.gbDataView.Location = new System.Drawing.Point(15, 49);
            this.gbDataView.Name = "gbDataView";
            this.gbDataView.Size = new System.Drawing.Size(386, 542);
            this.gbDataView.TabIndex = 4;
            this.gbDataView.TabStop = false;
            this.gbDataView.Text = "Data View";
            // 
            // cbImmortal
            // 
            this.cbImmortal.AutoSize = true;
            this.cbImmortal.Location = new System.Drawing.Point(142, 407);
            this.cbImmortal.Name = "cbImmortal";
            this.cbImmortal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbImmortal.Size = new System.Drawing.Size(106, 24);
            this.cbImmortal.TabIndex = 14;
            this.cbImmortal.Text = "?Immortal";
            this.cbImmortal.UseVisualStyleBackColor = true;
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(42, 366);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(47, 20);
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
            this.cmbRace.Location = new System.Drawing.Point(144, 359);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(121, 28);
            this.cmbRace.TabIndex = 12;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(42, 306);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(48, 20);
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
            this.cmbClass.Location = new System.Drawing.Point(144, 299);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 28);
            this.cmbClass.TabIndex = 10;
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(206, 460);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(146, 51);
            this.btnAddData.TabIndex = 9;
            this.btnAddData.Text = "Add Data to List";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(26, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 51);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(38, 235);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 20);
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
            this.cmbGender.Location = new System.Drawing.Point(142, 232);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 28);
            this.cmbGender.TabIndex = 3;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(144, 120);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(206, 26);
            this.tbLastName.TabIndex = 1;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(144, 62);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(206, 26);
            this.tbFirstName.TabIndex = 0;
            // 
            // udAge
            // 
            this.udAge.Location = new System.Drawing.Point(144, 178);
            this.udAge.Name = "udAge";
            this.udAge.Size = new System.Drawing.Size(120, 26);
            this.udAge.TabIndex = 2;
            this.udAge.Enter += new System.EventHandler(this.udAge_Enter);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(38, 180);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 20);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(38, 125);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(86, 20);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // llblFirstname
            // 
            this.llblFirstname.AutoSize = true;
            this.llblFirstname.Location = new System.Drawing.Point(38, 66);
            this.llblFirstname.Name = "llblFirstname";
            this.llblFirstname.Size = new System.Drawing.Size(86, 20);
            this.llblFirstname.TabIndex = 0;
            this.llblFirstname.Text = "First Name";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.listToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(416, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.listToolStripMenuItem.Text = "List";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.displayToolStripMenuItem.Text = "&Display";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.clearToolStripMenuItem.Text = "&Clear";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 626);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbDataView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE04 Main Form";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.gbDataView.ResumeLayout(false);
            this.gbDataView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAge)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        public System.Windows.Forms.NumericUpDown udAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label llblFirstname;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}

