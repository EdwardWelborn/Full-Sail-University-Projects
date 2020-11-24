namespace CervenecJustin_CodeExercise01
{
    partial class MovieListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieListForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMoveToNotWatched = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxNotWatched = new System.Windows.Forms.ListBox();
            this.listBoxWatched = new System.Windows.Forms.ListBox();
            this.btnRemoveWatched = new System.Windows.Forms.Button();
            this.btnRemoveNotWatched = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWatchedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNotWatchedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.Location = new System.Drawing.Point(258, 1158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 89);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close Form";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMoveToNotWatched
            // 
            this.btnMoveToNotWatched.Location = new System.Drawing.Point(59, 767);
            this.btnMoveToNotWatched.Name = "btnMoveToNotWatched";
            this.btnMoveToNotWatched.Size = new System.Drawing.Size(165, 87);
            this.btnMoveToNotWatched.TabIndex = 5;
            this.btnMoveToNotWatched.Text = "Move To Not Watched";
            this.btnMoveToNotWatched.UseVisualStyleBackColor = true;
            this.btnMoveToNotWatched.Click += new System.EventHandler(this.btnMoveToNotWatched_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 767);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 87);
            this.button1.TabIndex = 6;
            this.button1.Text = "Move To Watched";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxNotWatched
            // 
            this.listBoxNotWatched.FormattingEnabled = true;
            this.listBoxNotWatched.ItemHeight = 25;
            this.listBoxNotWatched.Location = new System.Drawing.Point(358, 261);
            this.listBoxNotWatched.Name = "listBoxNotWatched";
            this.listBoxNotWatched.Size = new System.Drawing.Size(251, 479);
            this.listBoxNotWatched.TabIndex = 8;
            // 
            // listBoxWatched
            // 
            this.listBoxWatched.FormattingEnabled = true;
            this.listBoxWatched.ItemHeight = 25;
            this.listBoxWatched.Location = new System.Drawing.Point(59, 261);
            this.listBoxWatched.Name = "listBoxWatched";
            this.listBoxWatched.Size = new System.Drawing.Size(251, 479);
            this.listBoxWatched.TabIndex = 7;
            this.listBoxWatched.DoubleClick += new System.EventHandler(this.listBoxWatched_DoubleClick);
            // 
            // btnRemoveWatched
            // 
            this.btnRemoveWatched.Location = new System.Drawing.Point(59, 907);
            this.btnRemoveWatched.Name = "btnRemoveWatched";
            this.btnRemoveWatched.Size = new System.Drawing.Size(165, 87);
            this.btnRemoveWatched.TabIndex = 9;
            this.btnRemoveWatched.Text = "Remove Watched Item";
            this.btnRemoveWatched.UseVisualStyleBackColor = true;
            this.btnRemoveWatched.Click += new System.EventHandler(this.btnRemoveWatched_Click);
            // 
            // btnRemoveNotWatched
            // 
            this.btnRemoveNotWatched.Location = new System.Drawing.Point(441, 907);
            this.btnRemoveNotWatched.Name = "btnRemoveNotWatched";
            this.btnRemoveNotWatched.Size = new System.Drawing.Size(165, 87);
            this.btnRemoveNotWatched.TabIndex = 10;
            this.btnRemoveNotWatched.Text = "Remove Not Watched Item";
            this.btnRemoveNotWatched.UseVisualStyleBackColor = true;
            this.btnRemoveNotWatched.Click += new System.EventHandler(this.btnRemoveNotWatched_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Location = new System.Drawing.Point(59, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 64);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 27);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(541, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveWatchedToolStripMenuItem,
            this.saveNotWatchedToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveWatchedToolStripMenuItem
            // 
            this.saveWatchedToolStripMenuItem.Name = "saveWatchedToolStripMenuItem";
            this.saveWatchedToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.saveWatchedToolStripMenuItem.Text = "Save Watched";
            // 
            // saveNotWatchedToolStripMenuItem
            // 
            this.saveNotWatchedToolStripMenuItem.Name = "saveNotWatchedToolStripMenuItem";
            this.saveNotWatchedToolStripMenuItem.Size = new System.Drawing.Size(311, 38);
            this.saveNotWatchedToolStripMenuItem.Text = "Save Not Watched";
            // 
            // MovieListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(661, 1280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoveNotWatched);
            this.Controls.Add(this.btnRemoveWatched);
            this.Controls.Add(this.listBoxNotWatched);
            this.Controls.Add(this.listBoxWatched);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMoveToNotWatched);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MovieListForm";
            this.Text = "Movie List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMoveToNotWatched;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxNotWatched;
        private System.Windows.Forms.Button btnRemoveWatched;
        private System.Windows.Forms.Button btnRemoveNotWatched;
        private System.Windows.Forms.ListBox listBoxWatched;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWatchedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNotWatchedToolStripMenuItem;
    }
}