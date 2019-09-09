namespace EdwardWelborn_CE02
{
    partial class fmMain
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
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.cbGoodGuy = new System.Windows.Forms.CheckBox();
            this.btnAddData = new System.Windows.Forms.Button();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDataList = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMoveBad = new System.Windows.Forms.Button();
            this.btnMoveGood = new System.Windows.Forms.Button();
            this.lbBadGuysList = new System.Windows.Forms.ListBox();
            this.lbGoodGuyList = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbDataList.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.cbGoodGuy);
            this.gbInformation.Controls.Add(this.btnAddData);
            this.gbInformation.Controls.Add(this.lblGender);
            this.gbInformation.Controls.Add(this.cmbGender);
            this.gbInformation.Controls.Add(this.lblAge);
            this.gbInformation.Controls.Add(this.numericUpDown);
            this.gbInformation.Controls.Add(this.btnClear);
            this.gbInformation.Controls.Add(this.lblLastName);
            this.gbInformation.Controls.Add(this.lblFirstName);
            this.gbInformation.Controls.Add(this.tbLastName);
            this.gbInformation.Controls.Add(this.tbFirstName);
            this.gbInformation.Location = new System.Drawing.Point(9, 28);
            this.gbInformation.Margin = new System.Windows.Forms.Padding(2);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Padding = new System.Windows.Forms.Padding(2);
            this.gbInformation.Size = new System.Drawing.Size(292, 259);
            this.gbInformation.TabIndex = 0;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Informtion";
            // 
            // cbGoodGuy
            // 
            this.cbGoodGuy.AutoSize = true;
            this.cbGoodGuy.Location = new System.Drawing.Point(35, 170);
            this.cbGoodGuy.Name = "cbGoodGuy";
            this.cbGoodGuy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGoodGuy.Size = new System.Drawing.Size(80, 17);
            this.cbGoodGuy.TabIndex = 4;
            this.cbGoodGuy.Text = "?Good Guy";
            this.cbGoodGuy.UseVisualStyleBackColor = true;
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(35, 219);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(84, 23);
            this.btnAddData.TabIndex = 5;
            this.btnAddData.Text = "Add Data";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(33, 135);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 8;
            this.lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(84, 131);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 3;
            this.cmbGender.MouseEnter += new System.EventHandler(this.cmbGender_MouseEnter);
            this.cmbGender.MouseLeave += new System.EventHandler(this.cmbGender_MouseLeave);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(44, 98);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 6;
            this.lblAge.Text = "Age";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(84, 95);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.Enter += new System.EventHandler(this.numericUpDown_Enter_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(147, 219);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(22, 64);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(22, 30);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(84, 61);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(2);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(139, 20);
            this.tbLastName.TabIndex = 1;
            this.tbLastName.MouseEnter += new System.EventHandler(this.tbLastName_MouseEnter);
            this.tbLastName.MouseLeave += new System.EventHandler(this.tbLastName_MouseLeave);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(84, 27);
            this.tbFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(139, 20);
            this.tbFirstName.TabIndex = 0;
            this.tbFirstName.MouseEnter += new System.EventHandler(this.tbFirstName_MouseEnter);
            this.tbFirstName.MouseLeave += new System.EventHandler(this.tbFirstName_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.StatsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.openToolStripMenuItem.MouseEnter += new System.EventHandler(this.openToolStripMenuItem_MouseEnter);
            this.openToolStripMenuItem.MouseLeave += new System.EventHandler(this.openToolStripMenuItem_MouseLeave);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            this.saveToolStripMenuItem.MouseEnter += new System.EventHandler(this.saveToolStripMenuItem_MouseEnter);
            this.saveToolStripMenuItem.MouseLeave += new System.EventHandler(this.saveToolStripMenuItem_MouseLeave);
            // 
            // StatsToolStripMenuItem
            // 
            this.StatsToolStripMenuItem.Name = "StatsToolStripMenuItem";
            this.StatsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.StatsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.StatsToolStripMenuItem.Text = "Stats";
            this.StatsToolStripMenuItem.Click += new System.EventHandler(this.StatsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.exitToolStripMenuItem.MouseEnter += new System.EventHandler(this.exitToolStripMenuItem_MouseEnter);
            this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.exitToolStripMenuItem_MouseLeave);
            // 
            // gbDataList
            // 
            this.gbDataList.Controls.Add(this.btnDelete);
            this.gbDataList.Controls.Add(this.btnMoveBad);
            this.gbDataList.Controls.Add(this.btnMoveGood);
            this.gbDataList.Controls.Add(this.lbBadGuysList);
            this.gbDataList.Controls.Add(this.lbGoodGuyList);
            this.gbDataList.Location = new System.Drawing.Point(314, 28);
            this.gbDataList.Margin = new System.Windows.Forms.Padding(2);
            this.gbDataList.Name = "gbDataList";
            this.gbDataList.Padding = new System.Windows.Forms.Padding(2);
            this.gbDataList.Size = new System.Drawing.Size(594, 259);
            this.gbDataList.TabIndex = 3;
            this.gbDataList.TabStop = false;
            this.gbDataList.Text = "Data List";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(281, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMoveBad
            // 
            this.btnMoveBad.Location = new System.Drawing.Point(281, 88);
            this.btnMoveBad.Name = "btnMoveBad";
            this.btnMoveBad.Size = new System.Drawing.Size(22, 23);
            this.btnMoveBad.TabIndex = 10;
            this.btnMoveBad.Text = ">";
            this.btnMoveBad.UseVisualStyleBackColor = true;
            this.btnMoveBad.Click += new System.EventHandler(this.btnMoveBad_Click);
            // 
            // btnMoveGood
            // 
            this.btnMoveGood.Location = new System.Drawing.Point(281, 47);
            this.btnMoveGood.Name = "btnMoveGood";
            this.btnMoveGood.Size = new System.Drawing.Size(22, 23);
            this.btnMoveGood.TabIndex = 9;
            this.btnMoveGood.Text = "<";
            this.btnMoveGood.UseVisualStyleBackColor = true;
            this.btnMoveGood.Click += new System.EventHandler(this.btnMoveGood_Click);
            // 
            // lbBadGuysList
            // 
            this.lbBadGuysList.FormattingEnabled = true;
            this.lbBadGuysList.Location = new System.Drawing.Point(319, 27);
            this.lbBadGuysList.Margin = new System.Windows.Forms.Padding(2);
            this.lbBadGuysList.Name = "lbBadGuysList";
            this.lbBadGuysList.Size = new System.Drawing.Size(251, 225);
            this.lbBadGuysList.TabIndex = 8;
            this.lbBadGuysList.Click += new System.EventHandler(this.lbBadGuysList_SelectedIndexChanged);
            // 
            // lbGoodGuyList
            // 
            this.lbGoodGuyList.FormattingEnabled = true;
            this.lbGoodGuyList.Location = new System.Drawing.Point(15, 27);
            this.lbGoodGuyList.Margin = new System.Windows.Forms.Padding(2);
            this.lbGoodGuyList.Name = "lbGoodGuyList";
            this.lbGoodGuyList.Size = new System.Drawing.Size(251, 225);
            this.lbGoodGuyList.TabIndex = 7;
            this.lbGoodGuyList.Click += new System.EventHandler(this.lbGoodGuyList_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 292);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(947, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 314);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbDataList);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CE02 Main Form";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDataList.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbDataList;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.CheckBox cbGoodGuy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ListBox lbGoodGuyList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ListBox lbBadGuysList;
        private System.Windows.Forms.ToolStripMenuItem StatsToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveBad;
        private System.Windows.Forms.Button btnMoveGood;
    }
}

