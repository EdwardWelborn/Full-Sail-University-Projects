namespace CasimirJustin_Assignment1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxHave = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBoxNeed = new System.Windows.Forms.ListBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNeedToHave = new System.Windows.Forms.Button();
            this.buttonHaveToNeed = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 787);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxHave
            // 
            this.listBoxHave.FormattingEnabled = true;
            this.listBoxHave.Location = new System.Drawing.Point(31, 263);
            this.listBoxHave.Name = "listBoxHave";
            this.listBoxHave.Size = new System.Drawing.Size(106, 264);
            this.listBoxHave.TabIndex = 21;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(143, 460);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 23;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listBoxNeed
            // 
            this.listBoxNeed.FormattingEnabled = true;
            this.listBoxNeed.Location = new System.Drawing.Point(223, 263);
            this.listBoxNeed.Name = "listBoxNeed";
            this.listBoxNeed.Size = new System.Drawing.Size(111, 264);
            this.listBoxNeed.TabIndex = 24;
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(139, 150);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(75, 32);
            this.buttonInput.TabIndex = 26;
            this.buttonInput.Text = "User input";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Have";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Need";
            // 
            // buttonNeedToHave
            // 
            this.buttonNeedToHave.Location = new System.Drawing.Point(157, 385);
            this.buttonNeedToHave.Name = "buttonNeedToHave";
            this.buttonNeedToHave.Size = new System.Drawing.Size(47, 32);
            this.buttonNeedToHave.TabIndex = 30;
            this.buttonNeedToHave.Text = "<-";
            this.buttonNeedToHave.UseVisualStyleBackColor = true;
            this.buttonNeedToHave.Click += new System.EventHandler(this.buttonNeedToHave_Click);
            // 
            // buttonHaveToNeed
            // 
            this.buttonHaveToNeed.Location = new System.Drawing.Point(157, 313);
            this.buttonHaveToNeed.Name = "buttonHaveToNeed";
            this.buttonHaveToNeed.Size = new System.Drawing.Size(47, 32);
            this.buttonHaveToNeed.TabIndex = 29;
            this.buttonHaveToNeed.Text = "->";
            this.buttonHaveToNeed.UseVisualStyleBackColor = true;
            this.buttonHaveToNeed.Click += new System.EventHandler(this.buttonHaveToNeed_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(143, 579);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 58);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 784);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonNeedToHave);
            this.Controls.Add(this.buttonHaveToNeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.listBoxNeed);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxHave);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxHave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListBox listBoxNeed;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNeedToHave;
        private System.Windows.Forms.Button buttonHaveToNeed;
        private System.Windows.Forms.Button buttonSave;
    }
}

