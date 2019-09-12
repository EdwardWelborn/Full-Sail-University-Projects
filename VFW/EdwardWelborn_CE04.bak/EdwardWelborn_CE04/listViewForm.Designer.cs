namespace EdwardWelborn_CE04
{
    partial class listViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listViewForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwCharacters = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwCharacters);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(401, 413);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List View";
            // 
            // lvwCharacters
            // 
            this.lvwCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCharacters.HideSelection = false;
            this.lvwCharacters.LargeImageList = this.imageList;
            this.lvwCharacters.Location = new System.Drawing.Point(2, 15);
            this.lvwCharacters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvwCharacters.Name = "lvwCharacters";
            this.lvwCharacters.Size = new System.Drawing.Size(397, 396);
            this.lvwCharacters.TabIndex = 0;
            this.lvwCharacters.UseCompatibleStateImageBehavior = false;
            this.lvwCharacters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Warrior.png");
            this.imageList.Images.SetKeyName(1, "Rogue.png");
            this.imageList.Images.SetKeyName(2, "Druid.png");
            this.imageList.Images.SetKeyName(3, "Mage.png");
            this.imageList.Images.SetKeyName(4, "Priest.png");
            // 
            // listViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 429);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(325, 0);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "listViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CE 04 List View Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.listViewForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwCharacters;
        private System.Windows.Forms.ImageList imageList;
    }
}