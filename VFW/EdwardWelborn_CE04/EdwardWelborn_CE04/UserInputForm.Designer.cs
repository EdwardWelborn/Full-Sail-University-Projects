namespace EdwardWelborn_CE04
{
    partial class UserInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInputForm));
            this.gbUserInputForm = new System.Windows.Forms.GroupBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.chkbMentor = new System.Windows.Forms.CheckBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClassName = new System.Windows.Forms.ComboBox();
            this.lblRace = new System.Windows.Forms.Label();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspbtnAddToList = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tspStatusBarHelper = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbUserInputForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUserInputForm
            // 
            this.gbUserInputForm.Controls.Add(this.btnClearForm);
            this.gbUserInputForm.Controls.Add(this.chkbMentor);
            this.gbUserInputForm.Controls.Add(this.lblRole);
            this.gbUserInputForm.Controls.Add(this.cmbRole);
            this.gbUserInputForm.Controls.Add(this.label1);
            this.gbUserInputForm.Controls.Add(this.cmbClassName);
            this.gbUserInputForm.Controls.Add(this.lblRace);
            this.gbUserInputForm.Controls.Add(this.cmbRace);
            this.gbUserInputForm.Controls.Add(this.lblLevel);
            this.gbUserInputForm.Controls.Add(this.numLevel);
            this.gbUserInputForm.Controls.Add(this.cmbGender);
            this.gbUserInputForm.Controls.Add(this.lblGender);
            this.gbUserInputForm.Controls.Add(this.tbName);
            this.gbUserInputForm.Controls.Add(this.lblName);
            this.gbUserInputForm.Location = new System.Drawing.Point(0, 31);
            this.gbUserInputForm.Name = "gbUserInputForm";
            this.gbUserInputForm.Size = new System.Drawing.Size(282, 322);
            this.gbUserInputForm.TabIndex = 0;
            this.gbUserInputForm.TabStop = false;
            this.gbUserInputForm.Text = "User Input";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(76, 285);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(100, 23);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // chkbMentor
            // 
            this.chkbMentor.AutoSize = true;
            this.chkbMentor.Location = new System.Drawing.Point(100, 257);
            this.chkbMentor.Name = "chkbMentor";
            this.chkbMentor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbMentor.Size = new System.Drawing.Size(65, 17);
            this.chkbMentor.TabIndex = 11;
            this.chkbMentor.Text = "?Mentor";
            this.chkbMentor.UseVisualStyleBackColor = true;
            this.chkbMentor.MouseEnter += new System.EventHandler(this.chkbMentor_MouseEnter);
            this.chkbMentor.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(42, 223);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Tank",
            "DPS",
            "Support",
            "Healer"});
            this.cmbRole.Location = new System.Drawing.Point(100, 218);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 21);
            this.cmbRole.TabIndex = 9;
            this.cmbRole.MouseEnter += new System.EventHandler(this.cmbRole_MouseEnter);
            this.cmbRole.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Class";
            // 
            // cmbClassName
            // 
            this.cmbClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassName.FormattingEnabled = true;
            this.cmbClassName.Items.AddRange(new object[] {
            "Warrior",
            "Rogue",
            "Druid",
            "Mage",
            "Priest"});
            this.cmbClassName.Location = new System.Drawing.Point(100, 178);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(121, 21);
            this.cmbClassName.TabIndex = 7;
            this.cmbClassName.MouseEnter += new System.EventHandler(this.cmbClassName_MouseEnter);
            this.cmbClassName.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(42, 144);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(33, 13);
            this.lblRace.TabIndex = 6;
            this.lblRace.Text = "Race";
            // 
            // cmbRace
            // 
            this.cmbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Items.AddRange(new object[] {
            "Human",
            "Dwarf",
            "Elf",
            "Tauren",
            "Undead",
            "Troll"});
            this.cmbRace.Location = new System.Drawing.Point(100, 140);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(121, 21);
            this.cmbRace.TabIndex = 3;
            this.cmbRace.MouseEnter += new System.EventHandler(this.cmbRace_MouseEnter);
            this.cmbRace.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(42, 108);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level";
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(100, 104);
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(120, 20);
            this.numLevel.TabIndex = 2;
            this.numLevel.Enter += new System.EventHandler(this.numLevel_Enter);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(100, 66);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 1;
            this.cmbGender.MouseEnter += new System.EventHandler(this.cmbGender_MouseEnter);
            this.cmbGender.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(42, 71);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "Gender";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(100, 29);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(120, 20);
            this.tbName.TabIndex = 0;
            this.tbName.MouseEnter += new System.EventHandler(this.tbName_MouseEnter);
            this.tbName.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(42, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbtnAddToList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(282, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspbtnAddToList
            // 
            this.tspbtnAddToList.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnAddToList.Image")));
            this.tspbtnAddToList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnAddToList.Name = "tspbtnAddToList";
            this.tspbtnAddToList.Size = new System.Drawing.Size(146, 28);
            this.tspbtnAddToList.Text = "Add Character to List";
            this.tspbtnAddToList.Click += new System.EventHandler(this.tspbtnAddToList_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspStatusBarHelper,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 354);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(282, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // tspStatusBarHelper
            // 
            this.tspStatusBarHelper.Name = "tspStatusBarHelper";
            this.tspStatusBarHelper.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // UserInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 376);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbUserInputForm);
            this.Location = new System.Drawing.Point(350, 100);
            this.Name = "UserInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE04 User Input Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInputForm_FormClosed);
            this.Load += new System.EventHandler(this.UserInputForm_Load);
            this.gbUserInputForm.ResumeLayout(false);
            this.gbUserInputForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUserInputForm;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspbtnAddToList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClassName;
        private System.Windows.Forms.Label lblRace;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox chkbMentor;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.ToolStripStatusLabel tspStatusBarHelper;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

