namespace EdwardWelborn_CE06
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ssHelper = new System.Windows.Forms.StatusStrip();
            this.tslblHelper = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabTrip = new System.Windows.Forms.TabControl();
            this.legTab = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.grpLeg = new System.Windows.Forms.GroupBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.textMode = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblMiles = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.numMiles = new System.Windows.Forms.NumericUpDown();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.totalsTab = new System.Windows.Forms.TabPage();
            this.textTotalLegs = new System.Windows.Forms.TextBox();
            this.textTotalHours = new System.Windows.Forms.TextBox();
            this.textTotalMiles = new System.Windows.Forms.TextBox();
            this.lblTotalLegs = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblTotalMiles = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tvwTripTotal = new System.Windows.Forms.TreeView();
            this.ssHelper.SuspendLayout();
            this.tabTrip.SuspendLayout();
            this.legTab.SuspendLayout();
            this.grpLeg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).BeginInit();
            this.totalsTab.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssHelper
            // 
            this.ssHelper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblHelper});
            this.ssHelper.Location = new System.Drawing.Point(0, 291);
            this.ssHelper.Name = "ssHelper";
            this.ssHelper.Size = new System.Drawing.Size(544, 22);
            this.ssHelper.TabIndex = 7;
            // 
            // tslblHelper
            // 
            this.tslblHelper.Name = "tslblHelper";
            this.tslblHelper.Size = new System.Drawing.Size(0, 17);
            // 
            // tabTrip
            // 
            this.tabTrip.Controls.Add(this.legTab);
            this.tabTrip.Controls.Add(this.totalsTab);
            this.tabTrip.Location = new System.Drawing.Point(2, 28);
            this.tabTrip.Name = "tabTrip";
            this.tabTrip.SelectedIndex = 0;
            this.tabTrip.Size = new System.Drawing.Size(255, 262);
            this.tabTrip.TabIndex = 6;
            // 
            // legTab
            // 
            this.legTab.Controls.Add(this.btnAdd);
            this.legTab.Controls.Add(this.grpLeg);
            this.legTab.Location = new System.Drawing.Point(4, 22);
            this.legTab.Name = "legTab";
            this.legTab.Padding = new System.Windows.Forms.Padding(3);
            this.legTab.Size = new System.Drawing.Size(247, 236);
            this.legTab.TabIndex = 0;
            this.legTab.Text = "Leg";
            this.legTab.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageList = this.ilMain;
            this.btnAdd.Location = new System.Drawing.Point(56, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "   Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "upArrow.jpg");
            this.ilMain.Images.SetKeyName(1, "downArrow.jpg");
            this.ilMain.Images.SetKeyName(2, "rightArrow.jpg");
            this.ilMain.Images.SetKeyName(3, "leftArrow.jpg");
            this.ilMain.Images.SetKeyName(4, "document.png");
            this.ilMain.Images.SetKeyName(5, "gearIcon.png");
            this.ilMain.Images.SetKeyName(6, "plusSign.png");
            this.ilMain.Images.SetKeyName(7, "xIcon.png");
            // 
            // grpLeg
            // 
            this.grpLeg.Controls.Add(this.lblMode);
            this.grpLeg.Controls.Add(this.textMode);
            this.grpLeg.Controls.Add(this.lblHours);
            this.grpLeg.Controls.Add(this.lblMiles);
            this.grpLeg.Controls.Add(this.numHours);
            this.grpLeg.Controls.Add(this.numMiles);
            this.grpLeg.Controls.Add(this.cboDirection);
            this.grpLeg.Controls.Add(this.lblDirection);
            this.grpLeg.Location = new System.Drawing.Point(6, 6);
            this.grpLeg.Name = "grpLeg";
            this.grpLeg.Size = new System.Drawing.Size(218, 189);
            this.grpLeg.TabIndex = 0;
            this.grpLeg.TabStop = false;
            this.grpLeg.Text = "Leg";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(7, 152);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 7;
            this.lblMode.Text = "Mode";
            // 
            // textMode
            // 
            this.textMode.Location = new System.Drawing.Point(63, 150);
            this.textMode.Name = "textMode";
            this.textMode.Size = new System.Drawing.Size(120, 20);
            this.textMode.TabIndex = 6;
            this.textMode.MouseEnter += new System.EventHandler(this.textMode_MouseEnter);
            this.textMode.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(7, 113);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(35, 13);
            this.lblHours.TabIndex = 5;
            this.lblHours.Text = "Hours";
            // 
            // lblMiles
            // 
            this.lblMiles.AutoSize = true;
            this.lblMiles.Location = new System.Drawing.Point(7, 68);
            this.lblMiles.Name = "lblMiles";
            this.lblMiles.Size = new System.Drawing.Size(31, 13);
            this.lblMiles.TabIndex = 4;
            this.lblMiles.Text = "Miles";
            // 
            // numHours
            // 
            this.numHours.DecimalPlaces = 2;
            this.numHours.Location = new System.Drawing.Point(63, 109);
            this.numHours.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(120, 20);
            this.numHours.TabIndex = 3;
            this.numHours.Enter += new System.EventHandler(this.numHours_Enter);
            // 
            // numMiles
            // 
            this.numMiles.DecimalPlaces = 2;
            this.numMiles.Location = new System.Drawing.Point(63, 65);
            this.numMiles.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numMiles.Name = "numMiles";
            this.numMiles.Size = new System.Drawing.Size(120, 20);
            this.numMiles.TabIndex = 2;
            this.numMiles.ThousandsSeparator = true;
            this.numMiles.Enter += new System.EventHandler(this.numMiles_Enter);
            // 
            // cboDirection
            // 
            this.cboDirection.AutoCompleteCustomSource.AddRange(new string[] {
            "North",
            "South",
            "East",
            "West",
            "NoWhere"});
            this.cboDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDirection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "No Where",
            "North",
            "South",
            "East",
            "West"});
            this.cboDirection.Location = new System.Drawing.Point(63, 20);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(121, 21);
            this.cboDirection.TabIndex = 0;
            this.cboDirection.MouseEnter += new System.EventHandler(this.cboDirection_MouseEnter);
            this.cboDirection.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(7, 24);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(49, 13);
            this.lblDirection.TabIndex = 0;
            this.lblDirection.Text = "Direction";
            // 
            // totalsTab
            // 
            this.totalsTab.Controls.Add(this.textTotalLegs);
            this.totalsTab.Controls.Add(this.textTotalHours);
            this.totalsTab.Controls.Add(this.textTotalMiles);
            this.totalsTab.Controls.Add(this.lblTotalLegs);
            this.totalsTab.Controls.Add(this.lblTotalHours);
            this.totalsTab.Controls.Add(this.lblTotalMiles);
            this.totalsTab.Location = new System.Drawing.Point(4, 22);
            this.totalsTab.Name = "totalsTab";
            this.totalsTab.Padding = new System.Windows.Forms.Padding(3);
            this.totalsTab.Size = new System.Drawing.Size(247, 236);
            this.totalsTab.TabIndex = 1;
            this.totalsTab.Text = "Totals";
            this.totalsTab.UseVisualStyleBackColor = true;
            this.totalsTab.Enter += new System.EventHandler(this.totalsTab_Enter);
            // 
            // textTotalLegs
            // 
            this.textTotalLegs.Location = new System.Drawing.Point(82, 103);
            this.textTotalLegs.Name = "textTotalLegs";
            this.textTotalLegs.ReadOnly = true;
            this.textTotalLegs.Size = new System.Drawing.Size(100, 20);
            this.textTotalLegs.TabIndex = 5;
            this.textTotalLegs.MouseEnter += new System.EventHandler(this.textTotalLegs_MouseEnter);
            this.textTotalLegs.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // textTotalHours
            // 
            this.textTotalHours.Location = new System.Drawing.Point(82, 61);
            this.textTotalHours.Name = "textTotalHours";
            this.textTotalHours.ReadOnly = true;
            this.textTotalHours.Size = new System.Drawing.Size(100, 20);
            this.textTotalHours.TabIndex = 4;
            this.textTotalHours.MouseEnter += new System.EventHandler(this.textTotalHours_MouseEnter);
            this.textTotalHours.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // textTotalMiles
            // 
            this.textTotalMiles.Location = new System.Drawing.Point(82, 17);
            this.textTotalMiles.Name = "textTotalMiles";
            this.textTotalMiles.ReadOnly = true;
            this.textTotalMiles.Size = new System.Drawing.Size(100, 20);
            this.textTotalMiles.TabIndex = 3;
            this.textTotalMiles.MouseEnter += new System.EventHandler(this.textTotalMiles_MouseEnter);
            this.textTotalMiles.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // lblTotalLegs
            // 
            this.lblTotalLegs.AutoSize = true;
            this.lblTotalLegs.Location = new System.Drawing.Point(16, 106);
            this.lblTotalLegs.Name = "lblTotalLegs";
            this.lblTotalLegs.Size = new System.Drawing.Size(30, 13);
            this.lblTotalLegs.TabIndex = 2;
            this.lblTotalLegs.Text = "Legs";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(16, 65);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(35, 13);
            this.lblTotalHours.TabIndex = 1;
            this.lblTotalHours.Text = "Hours";
            // 
            // lblTotalMiles
            // 
            this.lblTotalMiles.AutoSize = true;
            this.lblTotalMiles.Location = new System.Drawing.Point(16, 21);
            this.lblTotalMiles.Name = "lblTotalMiles";
            this.lblTotalMiles.Size = new System.Drawing.Size(31, 13);
            this.lblTotalMiles.TabIndex = 0;
            this.lblTotalMiles.Text = "Miles";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(544, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Image = global::EdwardWelborn_CE06.Properties.Resources.document;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNew.Size = new System.Drawing.Size(180, 22);
            this.tsmiNew.Text = "New";
            this.tsmiNew.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            this.tsmiNew.MouseEnter += new System.EventHandler(this.tsmiNew_MouseEnter);
            this.tsmiNew.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(180, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.tsmiExit.MouseEnter += new System.EventHandler(this.tsmiExit_MouseEnter);
            this.tsmiExit.MouseLeave += new System.EventHandler(this.LeaveField_Event);
            // 
            // tvwTripTotal
            // 
            this.tvwTripTotal.ImageIndex = 0;
            this.tvwTripTotal.ImageList = this.ilMain;
            this.tvwTripTotal.Location = new System.Drawing.Point(260, 50);
            this.tvwTripTotal.Name = "tvwTripTotal";
            this.tvwTripTotal.SelectedImageIndex = 0;
            this.tvwTripTotal.Size = new System.Drawing.Size(272, 236);
            this.tvwTripTotal.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 313);
            this.Controls.Add(this.tvwTripTotal);
            this.Controls.Add(this.ssHelper);
            this.Controls.Add(this.tabTrip);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trip Planner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ssHelper.ResumeLayout(false);
            this.ssHelper.PerformLayout();
            this.tabTrip.ResumeLayout(false);
            this.legTab.ResumeLayout(false);
            this.grpLeg.ResumeLayout(false);
            this.grpLeg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiles)).EndInit();
            this.totalsTab.ResumeLayout(false);
            this.totalsTab.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssHelper;
        private System.Windows.Forms.ToolStripStatusLabel tslblHelper;
        private System.Windows.Forms.TabControl tabTrip;
        private System.Windows.Forms.TabPage legTab;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpLeg;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TextBox textMode;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblMiles;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.NumericUpDown numMiles;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TabPage totalsTab;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.TreeView tvwTripTotal;
        private System.Windows.Forms.TextBox textTotalLegs;
        private System.Windows.Forms.TextBox textTotalHours;
        private System.Windows.Forms.TextBox textTotalMiles;
        private System.Windows.Forms.Label lblTotalLegs;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label lblTotalMiles;
        private System.Windows.Forms.ImageList ilMain;
    }
}

