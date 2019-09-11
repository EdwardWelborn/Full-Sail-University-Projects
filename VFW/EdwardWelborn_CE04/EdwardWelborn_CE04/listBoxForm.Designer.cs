namespace EdwardWelborn_CE04
{
    partial class listBoxForm
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
            this.lstParty = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstParty
            // 
            this.lstParty.FormattingEnabled = true;
            this.lstParty.Location = new System.Drawing.Point(8, 8);
            this.lstParty.Margin = new System.Windows.Forms.Padding(2);
            this.lstParty.Name = "lstParty";
            this.lstParty.Size = new System.Drawing.Size(463, 472);
            this.lstParty.TabIndex = 0;
            // 
            // listBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 482);
            this.Controls.Add(this.lstParty);
            this.Location = new System.Drawing.Point(800, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "listBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "listBoxForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.listBoxForm_FormClosed);
            this.Load += new System.EventHandler(this.listBoxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstParty;
    }
}