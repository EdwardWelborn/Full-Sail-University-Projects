namespace CE09Lecture
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
            this.title_Label = new System.Windows.Forms.Label();
            this.releaseDate_Label = new System.Windows.Forms.Label();
            this.title_textbox = new System.Windows.Forms.TextBox();
            this.releaseDate_textbox = new System.Windows.Forms.TextBox();
            this.numberOfRows_Label = new System.Windows.Forms.Label();
            this.rows_Label = new System.Windows.Forms.Label();
            this.next_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title_Label
            // 
            this.title_Label.AutoSize = true;
            this.title_Label.Location = new System.Drawing.Point(44, 42);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(27, 13);
            this.title_Label.TabIndex = 0;
            this.title_Label.Text = "Title";
            // 
            // releaseDate_Label
            // 
            this.releaseDate_Label.AutoSize = true;
            this.releaseDate_Label.Location = new System.Drawing.Point(47, 80);
            this.releaseDate_Label.Name = "releaseDate_Label";
            this.releaseDate_Label.Size = new System.Drawing.Size(72, 13);
            this.releaseDate_Label.TabIndex = 1;
            this.releaseDate_Label.Text = "Release Date";
            // 
            // title_textbox
            // 
            this.title_textbox.Location = new System.Drawing.Point(129, 42);
            this.title_textbox.Name = "title_textbox";
            this.title_textbox.Size = new System.Drawing.Size(243, 20);
            this.title_textbox.TabIndex = 2;
            // 
            // releaseDate_textbox
            // 
            this.releaseDate_textbox.Location = new System.Drawing.Point(129, 80);
            this.releaseDate_textbox.Name = "releaseDate_textbox";
            this.releaseDate_textbox.Size = new System.Drawing.Size(243, 20);
            this.releaseDate_textbox.TabIndex = 3;
            // 
            // numberOfRows_Label
            // 
            this.numberOfRows_Label.AutoSize = true;
            this.numberOfRows_Label.Location = new System.Drawing.Point(47, 125);
            this.numberOfRows_Label.Name = "numberOfRows_Label";
            this.numberOfRows_Label.Size = new System.Drawing.Size(78, 13);
            this.numberOfRows_Label.TabIndex = 4;
            this.numberOfRows_Label.Text = "Nuber of Rows";
            // 
            // rows_Label
            // 
            this.rows_Label.AutoSize = true;
            this.rows_Label.Location = new System.Drawing.Point(144, 124);
            this.rows_Label.Name = "rows_Label";
            this.rows_Label.Size = new System.Drawing.Size(13, 13);
            this.rows_Label.TabIndex = 5;
            this.rows_Label.Text = "0";
            // 
            // next_button
            // 
            this.next_button.Location = new System.Drawing.Point(286, 167);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(75, 23);
            this.next_button.TabIndex = 6;
            this.next_button.Text = "Next >";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 374);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.rows_Label);
            this.Controls.Add(this.numberOfRows_Label);
            this.Controls.Add(this.releaseDate_textbox);
            this.Controls.Add(this.title_textbox);
            this.Controls.Add(this.releaseDate_Label);
            this.Controls.Add(this.title_Label);
            this.Name = "MainForm";
            this.Text = "CE09Lecture Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.Label releaseDate_Label;
        private System.Windows.Forms.TextBox title_textbox;
        private System.Windows.Forms.TextBox releaseDate_textbox;
        private System.Windows.Forms.Label numberOfRows_Label;
        private System.Windows.Forms.Label rows_Label;
        private System.Windows.Forms.Button next_button;
    }
}

