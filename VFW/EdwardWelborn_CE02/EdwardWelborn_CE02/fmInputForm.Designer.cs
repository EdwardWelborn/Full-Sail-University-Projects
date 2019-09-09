/*
* Created by Edward Welborn on 09/06/2019
* Class: Visual Framworks
* Description: Project CE02
* Copyright © 2019 Roy Welborn. All rights reserved
*
* Input Form
* Summary: Input form for the program, here is where the data will be input then sent over to the main form.
*/
namespace EdwardWelborn_CE02
{
    partial class fmInputForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblGoodGuys = new System.Windows.Forms.Label();
            this.lblBadGuys = new System.Windows.Forms.Label();
            this.tbGoodGuys = new System.Windows.Forms.TextBox();
            this.tbBadGuys = new System.Windows.Forms.TextBox();
            this.gbInformation.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.tbBadGuys);
            this.gbInformation.Controls.Add(this.tbGoodGuys);
            this.gbInformation.Controls.Add(this.lblBadGuys);
            this.gbInformation.Controls.Add(this.lblGoodGuys);
            this.gbInformation.Controls.Add(this.btnOK);
            this.gbInformation.Location = new System.Drawing.Point(14, 31);
            this.gbInformation.Margin = new System.Windows.Forms.Padding(2);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Padding = new System.Windows.Forms.Padding(2);
            this.gbInformation.Size = new System.Drawing.Size(292, 175);
            this.gbInformation.TabIndex = 1;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Informtion";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(94, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeWindowToolStripMenuItem,
            this.toolStripSeparator1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeWindowToolStripMenuItem
            // 
            this.closeWindowToolStripMenuItem.Name = "closeWindowToolStripMenuItem";
            this.closeWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.closeWindowToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.closeWindowToolStripMenuItem.Text = "Close Window";
            this.closeWindowToolStripMenuItem.Click += new System.EventHandler(this.closeWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // lblGoodGuys
            // 
            this.lblGoodGuys.AutoSize = true;
            this.lblGoodGuys.Location = new System.Drawing.Point(18, 40);
            this.lblGoodGuys.Name = "lblGoodGuys";
            this.lblGoodGuys.Size = new System.Drawing.Size(60, 13);
            this.lblGoodGuys.TabIndex = 6;
            this.lblGoodGuys.Text = "Good Guys";
            // 
            // lblBadGuys
            // 
            this.lblBadGuys.AutoSize = true;
            this.lblBadGuys.Location = new System.Drawing.Point(21, 77);
            this.lblBadGuys.Name = "lblBadGuys";
            this.lblBadGuys.Size = new System.Drawing.Size(53, 13);
            this.lblBadGuys.TabIndex = 7;
            this.lblBadGuys.Text = "Bad Guys";
            // 
            // tbGoodGuys
            // 
            this.tbGoodGuys.Location = new System.Drawing.Point(94, 38);
            this.tbGoodGuys.Name = "tbGoodGuys";
            this.tbGoodGuys.ReadOnly = true;
            this.tbGoodGuys.Size = new System.Drawing.Size(100, 20);
            this.tbGoodGuys.TabIndex = 8;
            // 
            // tbBadGuys
            // 
            this.tbBadGuys.Location = new System.Drawing.Point(94, 75);
            this.tbBadGuys.Name = "tbBadGuys";
            this.tbBadGuys.ReadOnly = true;
            this.tbBadGuys.Size = new System.Drawing.Size(100, 20);
            this.tbBadGuys.TabIndex = 9;
            // 
            // fmInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 213);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CE02 Input Form";
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox tbBadGuys;
        private System.Windows.Forms.TextBox tbGoodGuys;
        private System.Windows.Forms.Label lblBadGuys;
        private System.Windows.Forms.Label lblGoodGuys;
    }
}