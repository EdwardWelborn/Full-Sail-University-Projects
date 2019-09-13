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
            this.lbDataList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.gbDataList.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDataList
            // 
            this.gbDataList.Controls.Add(this.lbDataList);
            this.gbDataList.Location = new System.Drawing.Point(9, 33);
            this.gbDataList.Margin = new System.Windows.Forms.Padding(2);
            this.gbDataList.Name = "gbDataList";
            this.gbDataList.Padding = new System.Windows.Forms.Padding(2);
            this.gbDataList.Size = new System.Drawing.Size(400, 394);
            this.gbDataList.TabIndex = 0;
            this.gbDataList.TabStop = false;
            this.gbDataList.Text = "Data List";
            // 
            // lbDataList
            // 
            this.lbDataList.FormattingEnabled = true;
            this.lbDataList.Location = new System.Drawing.Point(5, 17);
            this.lbDataList.Margin = new System.Windows.Forms.Padding(2);
            this.lbDataList.Name = "lbDataList";
            this.lbDataList.Size = new System.Drawing.Size(393, 368);
            this.lbDataList.TabIndex = 1;
            this.lbDataList.SelectedIndexChanged += new System.EventHandler(this.personListBox_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(417, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip";
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(89, 28);
            this.tsbtnClear.Text = "Clear Data";
            this.tsbtnClear.ToolTipText = "Clear";
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // fmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 435);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbDataList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmList_FormClosed);
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
        private System.Windows.Forms.ListBox lbDataList;
    }
}