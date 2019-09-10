namespace WelbornEdward_CE03
{
    partial class fmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmList));
            this.gbDataList = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.lbDataList = new System.Windows.Forms.ListBox();
            this.gbDataList.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDataList
            // 
            this.gbDataList.Controls.Add(this.lbDataList);
            this.gbDataList.Location = new System.Drawing.Point(13, 51);
            this.gbDataList.Name = "gbDataList";
            this.gbDataList.Size = new System.Drawing.Size(600, 606);
            this.gbDataList.TabIndex = 0;
            this.gbDataList.TabStop = false;
            this.gbDataList.Text = "Data List";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(626, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip";
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(121, 29);
            this.tsbtnClear.Text = "Clear Data";
            this.tsbtnClear.ToolTipText = "Clear";
            // 
            // lbDataList
            // 
            this.lbDataList.FormattingEnabled = true;
            this.lbDataList.ItemHeight = 20;
            this.lbDataList.Location = new System.Drawing.Point(7, 26);
            this.lbDataList.Name = "lbDataList";
            this.lbDataList.Size = new System.Drawing.Size(587, 564);
            this.lbDataList.TabIndex = 0;
            this.lbDataList.DoubleClick += new System.EventHandler(this.lbDataList_DoubleClick);
            // 
            // fmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 670);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbDataList);
            this.Name = "fmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmList";
            this.gbDataList.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDataList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        public System.Windows.Forms.ListBox lbDataList;
    }
}