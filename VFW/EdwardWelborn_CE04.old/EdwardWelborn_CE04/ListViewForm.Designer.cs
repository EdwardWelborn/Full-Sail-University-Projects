namespace EdwardWelborn_CE04
{
    partial class ListViewForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspbtnClearData = new System.Windows.Forms.ToolStripButton();
            this.lvwCharacters = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "01-Warrior.png");
            this.imageList.Images.SetKeyName(1, "rogue.png");
            this.imageList.Images.SetKeyName(2, "Druid.png");
            this.imageList.Images.SetKeyName(3, "mage.png");
            this.imageList.Images.SetKeyName(4, "priest.png");
            this.imageList.Images.SetKeyName(5, "Shaman.png");
            this.imageList.Images.SetKeyName(6, "Hunter.png");
            this.imageList.Images.SetKeyName(7, "Warlock.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbtnClearData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(245, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspbtnClearData
            // 
            this.tspbtnClearData.Image = ((System.Drawing.Image)(resources.GetObject("tspbtnClearData.Image")));
            this.tspbtnClearData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbtnClearData.Name = "tspbtnClearData";
            this.tspbtnClearData.Size = new System.Drawing.Size(81, 22);
            this.tspbtnClearData.Text = "Clear Data";
            this.tspbtnClearData.Click += new System.EventHandler(this.tspbtnClearData_Click);
            // 
            // lvwCharacters
            // 
            this.lvwCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCharacters.HideSelection = false;
            this.lvwCharacters.LargeImageList = this.imageList;
            this.lvwCharacters.Location = new System.Drawing.Point(0, 25);
            this.lvwCharacters.Name = "lvwCharacters";
            this.lvwCharacters.Size = new System.Drawing.Size(245, 383);
            this.lvwCharacters.TabIndex = 2;
            this.lvwCharacters.UseCompatibleStateImageBehavior = false;
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 408);
            this.Controls.Add(this.lvwCharacters);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(700, 100);
            this.Name = "ListViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE04 ListViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListViewForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspbtnClearData;
        private System.Windows.Forms.ListView lvwCharacters;
    }
}