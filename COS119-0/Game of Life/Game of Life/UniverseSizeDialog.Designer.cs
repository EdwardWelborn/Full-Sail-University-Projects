namespace Game_of_Life
{
    partial class universeSizeDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.ySizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ySizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(154, 64);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(9, 11);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(82, 13);
            this.xLabel.TabIndex = 2;
            this.xLabel.Text = "Universe X Size";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(12, 40);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(82, 13);
            this.yLabel.TabIndex = 3;
            this.yLabel.Text = "Universe Y Size";
            // 
            // ySizeNumericUpDown
            // 
            this.ySizeNumericUpDown.Location = new System.Drawing.Point(109, 37);
            this.ySizeNumericUpDown.Name = "ySizeNumericUpDown";
            this.ySizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.ySizeNumericUpDown.TabIndex = 4;
            // 
            // xSizeNumericUpDown
            // 
            this.xSizeNumericUpDown.Location = new System.Drawing.Point(109, 7);
            this.xSizeNumericUpDown.Name = "xSizeNumericUpDown";
            this.xSizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.xSizeNumericUpDown.TabIndex = 5;
            // 
            // universeSizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 97);
            this.Controls.Add(this.xSizeNumericUpDown);
            this.Controls.Add(this.ySizeNumericUpDown);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "universeSizeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Universe Size";
            ((System.ComponentModel.ISupportInitialize)(this.ySizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.NumericUpDown ySizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown xSizeNumericUpDown;
    }
}