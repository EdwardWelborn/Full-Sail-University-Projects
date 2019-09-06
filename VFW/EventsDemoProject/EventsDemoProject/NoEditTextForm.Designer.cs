namespace EventsDemoProject
{
    partial class NoEditTextForm
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
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.textOneLabel = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.TextBox();
            this.textTwoLabel = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.TextBox();
            this.textThreeLabel = new System.Windows.Forms.Label();
            this.text3 = new System.Windows.Forms.TextBox();
            this.displayEditButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.textGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(220, 24);
            this.menuStrip1.TabIndex = 0;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.copyButton);
            this.textGroupBox.Controls.Add(this.displayEditButton);
            this.textGroupBox.Controls.Add(this.text3);
            this.textGroupBox.Controls.Add(this.textThreeLabel);
            this.textGroupBox.Controls.Add(this.text2);
            this.textGroupBox.Controls.Add(this.textTwoLabel);
            this.textGroupBox.Controls.Add(this.text1);
            this.textGroupBox.Controls.Add(this.textOneLabel);
            this.textGroupBox.Location = new System.Drawing.Point(13, 28);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Size = new System.Drawing.Size(186, 174);
            this.textGroupBox.TabIndex = 1;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text Displays";
            // 
            // textOneLabel
            // 
            this.textOneLabel.AutoSize = true;
            this.textOneLabel.Location = new System.Drawing.Point(7, 20);
            this.textOneLabel.Name = "textOneLabel";
            this.textOneLabel.Size = new System.Drawing.Size(37, 13);
            this.textOneLabel.TabIndex = 0;
            this.textOneLabel.Text = "Text 1";
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(7, 37);
            this.text1.Name = "text1";
            this.text1.ReadOnly = true;
            this.text1.Size = new System.Drawing.Size(173, 20);
            this.text1.TabIndex = 1;
            // 
            // textTwoLabel
            // 
            this.textTwoLabel.AutoSize = true;
            this.textTwoLabel.Location = new System.Drawing.Point(7, 60);
            this.textTwoLabel.Name = "textTwoLabel";
            this.textTwoLabel.Size = new System.Drawing.Size(37, 13);
            this.textTwoLabel.TabIndex = 2;
            this.textTwoLabel.Text = "Text 2";
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(7, 76);
            this.text2.Name = "text2";
            this.text2.ReadOnly = true;
            this.text2.Size = new System.Drawing.Size(173, 20);
            this.text2.TabIndex = 3;
            // 
            // textThreeLabel
            // 
            this.textThreeLabel.AutoSize = true;
            this.textThreeLabel.Location = new System.Drawing.Point(7, 99);
            this.textThreeLabel.Name = "textThreeLabel";
            this.textThreeLabel.Size = new System.Drawing.Size(37, 13);
            this.textThreeLabel.TabIndex = 4;
            this.textThreeLabel.Text = "Text 3";
            // 
            // text3
            // 
            this.text3.Location = new System.Drawing.Point(7, 116);
            this.text3.Name = "text3";
            this.text3.ReadOnly = true;
            this.text3.Size = new System.Drawing.Size(173, 20);
            this.text3.TabIndex = 5;
            // 
            // displayEditButton
            // 
            this.displayEditButton.Location = new System.Drawing.Point(6, 145);
            this.displayEditButton.Name = "displayEditButton";
            this.displayEditButton.Size = new System.Drawing.Size(83, 23);
            this.displayEditButton.TabIndex = 6;
            this.displayEditButton.Text = "Editor";
            this.displayEditButton.UseVisualStyleBackColor = true;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(96, 145);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(84, 23);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "Copy Text";
            this.copyButton.UseVisualStyleBackColor = true;
            // 
            // NoEditTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 220);
            this.Controls.Add(this.textGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NoEditTextForm";
            this.Text = "EventsDemoProject";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.TextBox text3;
        private System.Windows.Forms.Label textThreeLabel;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.Label textTwoLabel;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.Label textOneLabel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button displayEditButton;
    }
}

