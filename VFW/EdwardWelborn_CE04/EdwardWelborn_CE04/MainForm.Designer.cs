namespace EdwardWelborn_CE04
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
            this.tbDataObjectCount = new System.Windows.Forms.TextBox();
            this.lblFormOpenCount = new System.Windows.Forms.Label();
            this.lblDataObjectCu = new System.Windows.Forms.Label();
            this.btnOpenInputForm = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspMainForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbOpenFormCount = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDataObjectCount
            // 
            this.tbDataObjectCount.Location = new System.Drawing.Point(132, 84);
            this.tbDataObjectCount.Name = "tbDataObjectCount";
            this.tbDataObjectCount.ReadOnly = true;
            this.tbDataObjectCount.Size = new System.Drawing.Size(100, 20);
            this.tbDataObjectCount.TabIndex = 1;
            // 
            // lblFormOpenCount
            // 
            this.lblFormOpenCount.AutoSize = true;
            this.lblFormOpenCount.Location = new System.Drawing.Point(26, 52);
            this.lblFormOpenCount.Name = "lblFormOpenCount";
            this.lblFormOpenCount.Size = new System.Drawing.Size(91, 13);
            this.lblFormOpenCount.TabIndex = 2;
            this.lblFormOpenCount.Text = "Open Input Forms";
            // 
            // lblDataObjectCu
            // 
            this.lblDataObjectCu.AutoSize = true;
            this.lblDataObjectCu.Location = new System.Drawing.Point(26, 88);
            this.lblDataObjectCu.Name = "lblDataObjectCu";
            this.lblDataObjectCu.Size = new System.Drawing.Size(95, 13);
            this.lblDataObjectCu.TabIndex = 3;
            this.lblDataObjectCu.Text = "Data Object Count";
            // 
            // btnOpenInputForm
            // 
            this.btnOpenInputForm.Location = new System.Drawing.Point(77, 116);
            this.btnOpenInputForm.Name = "btnOpenInputForm";
            this.btnOpenInputForm.Size = new System.Drawing.Size(106, 23);
            this.btnOpenInputForm.TabIndex = 4;
            this.btnOpenInputForm.Text = "Open Input Form";
            this.btnOpenInputForm.UseVisualStyleBackColor = true;
            this.btnOpenInputForm.Click += new System.EventHandler(this.btnOpenInputForm_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMainForm});
            this.statusStrip1.Location = new System.Drawing.Point(0, 152);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(250, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspMainForm
            // 
            this.tspMainForm.Name = "tspMainForm";
            this.tspMainForm.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.listToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(250, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayToolStripMenuItem,
            this.clearDataToolStripMenuItem});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.listToolStripMenuItem.Text = "List";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayToolStripMenuItem.Text = "Display";
            this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripMenuItem_Click);
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearDataToolStripMenuItem.Text = "Clear Data";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.clearDataToolStripMenuItem_Click);
            // 
            // tbOpenFormCount
            // 
            this.tbOpenFormCount.Location = new System.Drawing.Point(132, 48);
            this.tbOpenFormCount.Name = "tbOpenFormCount";
            this.tbOpenFormCount.ReadOnly = true;
            this.tbOpenFormCount.Size = new System.Drawing.Size(100, 20);
            this.tbOpenFormCount.TabIndex = 0;
            this.tbOpenFormCount.MouseEnter += new System.EventHandler(this.tbOpenFormCount_MouseEnter);
            this.tbOpenFormCount.MouseLeave += new System.EventHandler(this.Clear_StatusHintEvent);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 174);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnOpenInputForm);
            this.Controls.Add(this.lblDataObjectCu);
            this.Controls.Add(this.lblFormOpenCount);
            this.Controls.Add(this.tbDataObjectCount);
            this.Controls.Add(this.tbOpenFormCount);
            this.Location = new System.Drawing.Point(50, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFormOpenCount;
        private System.Windows.Forms.Label lblDataObjectCu;
        private System.Windows.Forms.Button btnOpenInputForm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tspMainForm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDataToolStripMenuItem;
        public System.Windows.Forms.TextBox tbDataObjectCount;
        public System.Windows.Forms.TextBox tbOpenFormCount;
    }
}