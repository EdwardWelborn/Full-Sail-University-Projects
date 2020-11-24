namespace CervenecJustin_CodeExercise01
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.btnClearForm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericReleaseYear = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textGenre = new System.Windows.Forms.TextBox();
            this.textActor = new System.Windows.Forms.TextBox();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.btnAddToWatched = new System.Windows.Forms.Button();
            this.btnAddToNotWatched = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericReleaseYear)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(108, 827);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(150, 83);
            this.btnClearForm.TabIndex = 17;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 644);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Year Released";
            // 
            // numericReleaseYear
            // 
            this.numericReleaseYear.Location = new System.Drawing.Point(283, 642);
            this.numericReleaseYear.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericReleaseYear.Name = "numericReleaseYear";
            this.numericReleaseYear.Size = new System.Drawing.Size(120, 31);
            this.numericReleaseYear.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Genre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 539);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lead Actor";
            // 
            // textGenre
            // 
            this.textGenre.Location = new System.Drawing.Point(283, 424);
            this.textGenre.Name = "textGenre";
            this.textGenre.Size = new System.Drawing.Size(278, 31);
            this.textGenre.TabIndex = 11;
            // 
            // textActor
            // 
            this.textActor.Location = new System.Drawing.Point(283, 536);
            this.textActor.Name = "textActor";
            this.textActor.Size = new System.Drawing.Size(278, 31);
            this.textActor.TabIndex = 10;
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(283, 296);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(278, 31);
            this.textTitle.TabIndex = 9;
            // 
            // btnAddToWatched
            // 
            this.btnAddToWatched.Location = new System.Drawing.Point(381, 753);
            this.btnAddToWatched.Name = "btnAddToWatched";
            this.btnAddToWatched.Size = new System.Drawing.Size(150, 83);
            this.btnAddToWatched.TabIndex = 18;
            this.btnAddToWatched.Text = "Add to Watched Movies";
            this.btnAddToWatched.UseVisualStyleBackColor = true;
            this.btnAddToWatched.Click += new System.EventHandler(this.btnAddToWatched_Click);
            // 
            // btnAddToNotWatched
            // 
            this.btnAddToNotWatched.Location = new System.Drawing.Point(381, 893);
            this.btnAddToNotWatched.Name = "btnAddToNotWatched";
            this.btnAddToNotWatched.Size = new System.Drawing.Size(150, 83);
            this.btnAddToNotWatched.TabIndex = 19;
            this.btnAddToNotWatched.Text = "Add to Not Watched Movies";
            this.btnAddToNotWatched.UseVisualStyleBackColor = true;
            this.btnAddToNotWatched.Click += new System.EventHandler(this.btnAddToNotWatched_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Location = new System.Drawing.Point(57, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 74);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.listToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 27);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(552, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayListsToolStripMenuItem,
            this.printListsToolStripMenuItem});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(62, 38);
            this.listToolStripMenuItem.Text = "List";
            // 
            // displayListsToolStripMenuItem
            // 
            this.displayListsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.displayListsToolStripMenuItem.Name = "displayListsToolStripMenuItem";
            this.displayListsToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.displayListsToolStripMenuItem.Text = "Display Lists";
            this.displayListsToolStripMenuItem.Click += new System.EventHandler(this.displayListsToolStripMenuItem_Click_1);
            // 
            // printListsToolStripMenuItem
            // 
            this.printListsToolStripMenuItem.Name = "printListsToolStripMenuItem";
            this.printListsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printListsToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.printListsToolStripMenuItem.Text = "Print Lists";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 1280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddToNotWatched);
            this.Controls.Add(this.btnAddToWatched);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericReleaseYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textGenre);
            this.Controls.Add(this.textActor);
            this.Controls.Add(this.textTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputForm";
            this.Text = "User Input";
            ((System.ComponentModel.ISupportInitialize)(this.numericReleaseYear)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericReleaseYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGenre;
        private System.Windows.Forms.TextBox textActor;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Button btnAddToWatched;
        private System.Windows.Forms.Button btnAddToNotWatched;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printListsToolStripMenuItem;
    }
}

