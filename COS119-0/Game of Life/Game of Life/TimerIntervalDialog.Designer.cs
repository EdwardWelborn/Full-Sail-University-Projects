namespace Game_of_Life
{
    partial class TimerIntervalDailog
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
            this.intervalLabelll = new System.Windows.Forms.Label();
            this.timerIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 41);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // intervalLabelll
            // 
            this.intervalLabelll.AutoSize = true;
            this.intervalLabelll.Location = new System.Drawing.Point(12, 11);
            this.intervalLabelll.Name = "intervalLabelll";
            this.intervalLabelll.Size = new System.Drawing.Size(71, 13);
            this.intervalLabelll.TabIndex = 1;
            this.intervalLabelll.Text = "Timer Interval";
            // 
            // timerIntervalNumericUpDown
            // 
            this.timerIntervalNumericUpDown.Location = new System.Drawing.Point(99, 8);
            this.timerIntervalNumericUpDown.Name = "timerIntervalNumericUpDown";
            this.timerIntervalNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.timerIntervalNumericUpDown.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(102, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // TimerIntervalDailog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(186, 67);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.timerIntervalNumericUpDown);
            this.Controls.Add(this.intervalLabelll);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerIntervalDailog";
            this.Text = "Timer Interval";
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label intervalLabelll;
        private System.Windows.Forms.NumericUpDown timerIntervalNumericUpDown;
        private System.Windows.Forms.Button cancelButton;
    }
}