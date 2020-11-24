namespace CasimirJustin_Assignment2
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
            this.pictureBoxPhone = new System.Windows.Forms.PictureBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.numericUpDownPhoneNumber = new System.Windows.Forms.NumericUpDown();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxRelation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhoneNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPhone
            // 
            this.pictureBoxPhone.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPhone.Image")));
            this.pictureBoxPhone.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxPhone.Name = "pictureBoxPhone";
            this.pictureBoxPhone.Size = new System.Drawing.Size(425, 787);
            this.pictureBoxPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPhone.TabIndex = 0;
            this.pictureBoxPhone.TabStop = false;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(148, 215);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(170, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(148, 278);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(170, 20);
            this.textBoxLastName.TabIndex = 2;
            // 
            // numericUpDownPhoneNumber
            // 
            this.numericUpDownPhoneNumber.Location = new System.Drawing.Point(148, 344);
            this.numericUpDownPhoneNumber.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.numericUpDownPhoneNumber.Name = "numericUpDownPhoneNumber";
            this.numericUpDownPhoneNumber.Size = new System.Drawing.Size(170, 20);
            this.numericUpDownPhoneNumber.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(148, 397);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(170, 20);
            this.textBoxEmail.TabIndex = 4;
            // 
            // textBoxRelation
            // 
            this.textBoxRelation.Location = new System.Drawing.Point(148, 450);
            this.textBoxRelation.Name = "textBoxRelation";
            this.textBoxRelation.Size = new System.Drawing.Size(170, 20);
            this.textBoxRelation.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 453);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Relation:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelName.Location = new System.Drawing.Point(143, 140);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(138, 25);
            this.labelName.TabIndex = 11;
            this.labelName.Text = "Contact List";
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(317, 529);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(61, 42);
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(222, 529);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(69, 42);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(148, 529);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(68, 42);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(46, 529);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(64, 42);
            this.btnFirst.TabIndex = 12;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(97, 597);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(69, 42);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 597);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 597);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 42);
            this.button2.TabIndex = 18;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(427, 784);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRelation);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.numericUpDownPhoneNumber);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.pictureBoxPhone);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPhoneNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxPhone;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.NumericUpDown numericUpDownPhoneNumber;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxRelation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

