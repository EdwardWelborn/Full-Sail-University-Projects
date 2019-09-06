namespace EventsDemoProject
{
    partial class EditTextForm
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
            this.textGroupBox = new System.Windows.Forms.GroupBox();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.text3 = new System.Windows.Forms.TextBox();
            this.textThreeLabel = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.TextBox();
            this.textTwoLabel = new System.Windows.Forms.Label();
            this.text1 = new System.Windows.Forms.TextBox();
            this.textOneLabel = new System.Windows.Forms.Label();
            this.textGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textGroupBox
            // 
            this.textGroupBox.Controls.Add(this.saveAndCloseButton);
            this.textGroupBox.Controls.Add(this.text3);
            this.textGroupBox.Controls.Add(this.textThreeLabel);
            this.textGroupBox.Controls.Add(this.text2);
            this.textGroupBox.Controls.Add(this.textTwoLabel);
            this.textGroupBox.Controls.Add(this.text1);
            this.textGroupBox.Controls.Add(this.textOneLabel);
            this.textGroupBox.Location = new System.Drawing.Point(12, 12);
            this.textGroupBox.Name = "textGroupBox";
            this.textGroupBox.Size = new System.Drawing.Size(186, 174);
            this.textGroupBox.TabIndex = 2;
            this.textGroupBox.TabStop = false;
            this.textGroupBox.Text = "Text Displays";
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Location = new System.Drawing.Point(6, 145);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(174, 23);
            this.saveAndCloseButton.TabIndex = 6;
            this.saveAndCloseButton.Text = "Save and Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // text3
            // 
            this.text3.Location = new System.Drawing.Point(7, 116);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(173, 20);
            this.text3.TabIndex = 5;
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
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(7, 76);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(173, 20);
            this.text2.TabIndex = 3;
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
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(7, 37);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(173, 20);
            this.text1.TabIndex = 1;
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
            // EditTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 200);
            this.Controls.Add(this.textGroupBox);
            this.Name = "EditTextForm";
            this.Text = "EditTextForm";
            this.textGroupBox.ResumeLayout(false);
            this.textGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox textGroupBox;
        private System.Windows.Forms.Button saveAndCloseButton;
        private System.Windows.Forms.TextBox text3;
        private System.Windows.Forms.Label textThreeLabel;
        private System.Windows.Forms.TextBox text2;
        private System.Windows.Forms.Label textTwoLabel;
        private System.Windows.Forms.TextBox text1;
        private System.Windows.Forms.Label textOneLabel;
    }
}