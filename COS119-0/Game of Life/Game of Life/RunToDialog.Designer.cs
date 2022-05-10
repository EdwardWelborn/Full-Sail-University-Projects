namespace Game_of_Life
{
    partial class RunToDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.runToNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.runToLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.runToNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(101, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // runToNumericUpDown
            // 
            this.runToNumericUpDown.Location = new System.Drawing.Point(98, 5);
            this.runToNumericUpDown.Name = "runToNumericUpDown";
            this.runToNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.runToNumericUpDown.TabIndex = 0;
            // 
            // runToLabel
            // 
            this.runToLabel.AutoSize = true;
            this.runToLabel.Location = new System.Drawing.Point(11, 8);
            this.runToLabel.Name = "runToLabel";
            this.runToLabel.Size = new System.Drawing.Size(43, 13);
            this.runToLabel.TabIndex = 3;
            this.runToLabel.Text = "Run To";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(11, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // RunToDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(186, 67);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.runToNumericUpDown);
            this.Controls.Add(this.runToLabel);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunToDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Run To";
            ((System.ComponentModel.ISupportInitialize)(this.runToNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown runToNumericUpDown;
        private System.Windows.Forms.Label runToLabel;
        private System.Windows.Forms.Button okButton;
    }
}