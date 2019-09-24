namespace CE07Lecture
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chooseStock_Label = new System.Windows.Forms.Label();
            this.ChooseStock_ComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ViewStock_Button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ViewStock_Button);
            this.groupBox1.Controls.Add(this.chooseStock_Label);
            this.groupBox1.Controls.Add(this.ChooseStock_ComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // chooseStock_Label
            // 
            this.chooseStock_Label.AutoSize = true;
            this.chooseStock_Label.Location = new System.Drawing.Point(19, 33);
            this.chooseStock_Label.Name = "chooseStock_Label";
            this.chooseStock_Label.Size = new System.Drawing.Size(118, 13);
            this.chooseStock_Label.TabIndex = 1;
            this.chooseStock_Label.Text = "Please Choose a Stock";
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
            this.ChooseStock_ComboBox.Location = new System.Drawing.Point(143, 30);
            this.ChooseStock_ComboBox.Name = "ChooseStock_ComboBox";
            this.ChooseStock_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ChooseStock_ComboBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(414, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 286);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ViewStock_Button
            // 
            this.ViewStock_Button.Location = new System.Drawing.Point(143, 95);
            this.ViewStock_Button.Name = "ViewStock_Button";
            this.ViewStock_Button.Size = new System.Drawing.Size(112, 23);
            this.ViewStock_Button.TabIndex = 2;
            this.ViewStock_Button.Text = "View Stock Data";
            this.ViewStock_Button.UseVisualStyleBackColor = true;
            this.ViewStock_Button.Click += new System.EventHandler(this.ViewStock_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 334);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CE07 Lecture";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label chooseStock_Label;
        private System.Windows.Forms.ComboBox ChooseStock_ComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ViewStock_Button;
    }
}

