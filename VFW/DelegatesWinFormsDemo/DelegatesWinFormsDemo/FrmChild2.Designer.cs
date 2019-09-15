namespace DelegatesWinFormsDemo
{
    partial class FrmChild2
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
            this.txtParam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(91, 18);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(111, 20);
            this.txtParam.TabIndex = 4;
            // 
            // FrmChild2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 56);
            this.Controls.Add(this.txtParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChild2";
            this.Text = "Child Form 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParam;
    }
}