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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspStatusBarHelper = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbUserInputForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.gbUserInputForm.Location = new System.Drawing.Point(0, 47);
            this.gbUserInputForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbUserInputForm.Name = "gbUserInputForm";
            this.gbUserInputForm.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbUserInputForm.Size = new System.Drawing.Size(423, 496);
            this.gbUserInputForm.TabIndex = 0;
            this.gbUserInputForm.TabStop = false;
            this.gbUserInputForm.Text = "User Input";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(114, 438);
            this.btnClearForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(150, 35);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // chkbMentor
            // 
            this.chkbMentor.AutoSize = true;
            this.chkbMentor.Location = new System.Drawing.Point(150, 395);
            this.chkbMentor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkbMentor.Name = "chkbMentor";
            this.chkbMentor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbMentor.Size = new System.Drawing.Size(94, 24);
            this.chkbMentor.TabIndex = 11;
            this.chkbMentor.Text = "?Mentor";
            this.chkbMentor.UseVisualStyleBackColor = true;
            this.chkbMentor.MouseEnter += new System.EventHandler(this.chkbMentor_MouseEnter);
            this.chkbMentor.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(63, 343);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 20);
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
            this.cmbRole.Location = new System.Drawing.Point(150, 335);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(180, 28);
            this.cmbRole.TabIndex = 9;
            this.cmbRole.MouseEnter += new System.EventHandler(this.cmbRole_MouseEnter);
            this.cmbRole.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 282);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
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
            this.cmbClassName.Location = new System.Drawing.Point(150, 274);
            this.cmbClassName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClassName.Name = "cmbClassName";
            this.cmbClassName.Size = new System.Drawing.Size(180, 28);
            this.cmbClassName.TabIndex = 7;
            this.cmbClassName.MouseEnter += new System.EventHandler(this.cmbClassName_MouseEnter);
            this.cmbClassName.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(63, 222);
            this.lblRace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(47, 20);
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
            this.cmbRace.Location = new System.Drawing.Point(150, 215);
            this.cmbRace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(180, 28);
            this.cmbRace.TabIndex = 3;
            this.cmbRace.MouseEnter += new System.EventHandler(this.cmbRace_MouseEnter);
            this.cmbRace.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(63, 166);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(46, 20);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level";
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(150, 160);
            this.numLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(180, 26);
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
            this.cmbGender.Location = new System.Drawing.Point(150, 102);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(180, 28);
            this.cmbGender.TabIndex = 1;
            this.cmbGender.MouseEnter += new System.EventHandler(this.cmbGender_MouseEnter);
            this.cmbGender.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(63, 109);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 20);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "Gender";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(150, 45);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(178, 26);
            this.tbName.TabIndex = 0;
            this.tbName.MouseEnter += new System.EventHandler(this.tbName_MouseEnter);
            this.tbName.MouseLeave += new System.EventHandler(this.ClearStatusText_Event);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(63, 49);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
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
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(423, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspbtnAddToList
            // 
            this.tspbtnAddToList.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnAddToList.Image")));
            this.tspbtnAddToList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnAddToList.Name = "tspbtnAddToList";
            this.tspbtnAddToList.Size = new System.Drawing.Size(206, 29);
            this.tspbtnAddToList.Text = "Add Character to List";
            this.tspbtnAddToList.Click += new System.EventHandler(this.tspbtnAddToList_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspStatusBarHelper});
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(423, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspStatusBarHelper
            // 
            this.tspStatusBarHelper.Name = "tspStatusBarHelper";
            this.tspStatusBarHelper.Size = new System.Drawing.Size(0, 17);
            // 
            // UserInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 578);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbUserInputForm);
            this.Location = new System.Drawing.Point(350, 100);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE04 User Input Form";
            this.Load += new System.EventHandler(this.UserInputForm_Load);
            this.gbUserInputForm.ResumeLayout(false);
            this.gbUserInputForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUserInputForm;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspbtnAddToList;
        private System.Windows.Forms.StatusStrip statusStrip1;
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
    }
}

