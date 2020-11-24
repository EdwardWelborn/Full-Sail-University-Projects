namespace CasimirJustin_Assignment1
{
    partial class UserInput
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
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNEED = new System.Windows.Forms.Button();
            this.buttonHAVE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxItem
            // 
            this.textBoxItem.Location = new System.Drawing.Point(102, 37);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(100, 20);
            this.textBoxItem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item:";
            // 
            // buttonNEED
            // 
            this.buttonNEED.Location = new System.Drawing.Point(46, 67);
            this.buttonNEED.Name = "buttonNEED";
            this.buttonNEED.Size = new System.Drawing.Size(75, 23);
            this.buttonNEED.TabIndex = 2;
            this.buttonNEED.Text = "NEED";
            this.buttonNEED.UseVisualStyleBackColor = true;
            this.buttonNEED.Click += new System.EventHandler(this.buttonNEED_Click);
            // 
            // buttonHAVE
            // 
            this.buttonHAVE.Location = new System.Drawing.Point(181, 67);
            this.buttonHAVE.Name = "buttonHAVE";
            this.buttonHAVE.Size = new System.Drawing.Size(75, 23);
            this.buttonHAVE.TabIndex = 3;
            this.buttonHAVE.Text = "HAVE";
            this.buttonHAVE.UseVisualStyleBackColor = true;
            this.buttonHAVE.Click += new System.EventHandler(this.buttonHAVE_Click);
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 102);
            this.Controls.Add(this.buttonHAVE);
            this.Controls.Add(this.buttonNEED);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxItem);
            this.Name = "UserInput";
            this.Text = "UserInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNEED;
        private System.Windows.Forms.Button buttonHAVE;
        public System.Windows.Forms.TextBox textBoxItem;
    }
}