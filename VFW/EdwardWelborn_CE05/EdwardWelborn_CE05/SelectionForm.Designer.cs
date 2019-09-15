namespace EdwardWelborn_CE05
{
    partial class SelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
            this.gbSelectClass = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbtnWarrior = new System.Windows.Forms.RadioButton();
            this.rbtnDruid = new System.Windows.Forms.RadioButton();
            this.rbtnMage = new System.Windows.Forms.RadioButton();
            this.rbtnHunter = new System.Windows.Forms.RadioButton();
            this.rbtnWarlock = new System.Windows.Forms.RadioButton();
            this.rbtnShaman = new System.Windows.Forms.RadioButton();
            this.rbtnRogue = new System.Windows.Forms.RadioButton();
            this.rbtnPriest = new System.Windows.Forms.RadioButton();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gbSelectClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectClass
            // 
            this.gbSelectClass.Controls.Add(this.lblName);
            this.gbSelectClass.Controls.Add(this.tbName);
            this.gbSelectClass.Controls.Add(this.rbtnWarlock);
            this.gbSelectClass.Controls.Add(this.rbtnShaman);
            this.gbSelectClass.Controls.Add(this.rbtnRogue);
            this.gbSelectClass.Controls.Add(this.rbtnPriest);
            this.gbSelectClass.Controls.Add(this.rbtnMage);
            this.gbSelectClass.Controls.Add(this.rbtnHunter);
            this.gbSelectClass.Controls.Add(this.rbtnDruid);
            this.gbSelectClass.Controls.Add(this.rbtnWarrior);
            this.gbSelectClass.Location = new System.Drawing.Point(3, 12);
            this.gbSelectClass.Name = "gbSelectClass";
            this.gbSelectClass.Size = new System.Drawing.Size(231, 280);
            this.gbSelectClass.TabIndex = 0;
            this.gbSelectClass.TabStop = false;
            this.gbSelectClass.Text = "Select A Class";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "01-Warrior.png");
            this.imageList1.Images.SetKeyName(1, "Druid.png");
            this.imageList1.Images.SetKeyName(2, "Hunter.png");
            this.imageList1.Images.SetKeyName(3, "mage.png");
            this.imageList1.Images.SetKeyName(4, "priest.png");
            this.imageList1.Images.SetKeyName(5, "rogue.png");
            this.imageList1.Images.SetKeyName(6, "Shaman.png");
            this.imageList1.Images.SetKeyName(7, "Warlock.png");
            // 
            // rbtnWarrior
            // 
            this.rbtnWarrior.ImageKey = "01-Warrior.png";
            this.rbtnWarrior.ImageList = this.imageList1;
            this.rbtnWarrior.Location = new System.Drawing.Point(11, 19);
            this.rbtnWarrior.Name = "rbtnWarrior";
            this.rbtnWarrior.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnWarrior.Size = new System.Drawing.Size(105, 40);
            this.rbtnWarrior.TabIndex = 0;
            this.rbtnWarrior.TabStop = true;
            this.rbtnWarrior.Text = "Warrior";
            this.rbtnWarrior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnWarrior.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnWarrior.UseVisualStyleBackColor = true;
            // 
            // rbtnDruid
            // 
            this.rbtnDruid.ImageKey = "Druid.png";
            this.rbtnDruid.ImageList = this.imageList1;
            this.rbtnDruid.Location = new System.Drawing.Point(11, 62);
            this.rbtnDruid.Name = "rbtnDruid";
            this.rbtnDruid.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnDruid.Size = new System.Drawing.Size(105, 40);
            this.rbtnDruid.TabIndex = 1;
            this.rbtnDruid.TabStop = true;
            this.rbtnDruid.Text = "Druid";
            this.rbtnDruid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnDruid.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnDruid.UseVisualStyleBackColor = true;
            // 
            // rbtnMage
            // 
            this.rbtnMage.ImageKey = "mage.png";
            this.rbtnMage.ImageList = this.imageList1;
            this.rbtnMage.Location = new System.Drawing.Point(11, 145);
            this.rbtnMage.Name = "rbtnMage";
            this.rbtnMage.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnMage.Size = new System.Drawing.Size(105, 40);
            this.rbtnMage.TabIndex = 3;
            this.rbtnMage.TabStop = true;
            this.rbtnMage.Text = "Mage";
            this.rbtnMage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnMage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnMage.UseVisualStyleBackColor = true;
            // 
            // rbtnHunter
            // 
            this.rbtnHunter.ImageKey = "Hunter.png";
            this.rbtnHunter.ImageList = this.imageList1;
            this.rbtnHunter.Location = new System.Drawing.Point(11, 103);
            this.rbtnHunter.Name = "rbtnHunter";
            this.rbtnHunter.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnHunter.Size = new System.Drawing.Size(105, 40);
            this.rbtnHunter.TabIndex = 2;
            this.rbtnHunter.TabStop = true;
            this.rbtnHunter.Text = "Hunter";
            this.rbtnHunter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnHunter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnHunter.UseVisualStyleBackColor = true;
            // 
            // rbtnWarlock
            // 
            this.rbtnWarlock.ImageKey = "Warlock.png";
            this.rbtnWarlock.ImageList = this.imageList1;
            this.rbtnWarlock.Location = new System.Drawing.Point(127, 145);
            this.rbtnWarlock.Name = "rbtnWarlock";
            this.rbtnWarlock.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnWarlock.Size = new System.Drawing.Size(105, 40);
            this.rbtnWarlock.TabIndex = 7;
            this.rbtnWarlock.TabStop = true;
            this.rbtnWarlock.Text = "Warlock";
            this.rbtnWarlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnWarlock.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnWarlock.UseVisualStyleBackColor = true;
            // 
            // rbtnShaman
            // 
            this.rbtnShaman.ImageKey = "Shaman.png";
            this.rbtnShaman.ImageList = this.imageList1;
            this.rbtnShaman.Location = new System.Drawing.Point(127, 104);
            this.rbtnShaman.Name = "rbtnShaman";
            this.rbtnShaman.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnShaman.Size = new System.Drawing.Size(105, 40);
            this.rbtnShaman.TabIndex = 6;
            this.rbtnShaman.TabStop = true;
            this.rbtnShaman.Text = "Shaman";
            this.rbtnShaman.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnShaman.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnShaman.UseVisualStyleBackColor = true;
            // 
            // rbtnRogue
            // 
            this.rbtnRogue.ImageKey = "rogue.png";
            this.rbtnRogue.ImageList = this.imageList1;
            this.rbtnRogue.Location = new System.Drawing.Point(129, 62);
            this.rbtnRogue.Name = "rbtnRogue";
            this.rbtnRogue.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnRogue.Size = new System.Drawing.Size(105, 40);
            this.rbtnRogue.TabIndex = 5;
            this.rbtnRogue.TabStop = true;
            this.rbtnRogue.Text = "Rogue";
            this.rbtnRogue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnRogue.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnRogue.UseVisualStyleBackColor = true;
            // 
            // rbtnPriest
            // 
            this.rbtnPriest.ImageKey = "priest.png";
            this.rbtnPriest.ImageList = this.imageList1;
            this.rbtnPriest.Location = new System.Drawing.Point(128, 19);
            this.rbtnPriest.Name = "rbtnPriest";
            this.rbtnPriest.Padding = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.rbtnPriest.Size = new System.Drawing.Size(105, 40);
            this.rbtnPriest.TabIndex = 4;
            this.rbtnPriest.TabStop = true;
            this.rbtnPriest.Text = "Priest";
            this.rbtnPriest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnPriest.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.rbtnPriest.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(55, 194);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(163, 20);
            this.tbName.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 197);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name:";
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 338);
            this.Controls.Add(this.gbSelectClass);
            this.Name = "SelectionForm";
            this.Text = "CE05 SelectionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectionForm_FormClosing);
            this.gbSelectClass.ResumeLayout(false);
            this.gbSelectClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectClass;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton rbtnWarlock;
        private System.Windows.Forms.RadioButton rbtnShaman;
        private System.Windows.Forms.RadioButton rbtnRogue;
        private System.Windows.Forms.RadioButton rbtnPriest;
        private System.Windows.Forms.RadioButton rbtnMage;
        private System.Windows.Forms.RadioButton rbtnHunter;
        private System.Windows.Forms.RadioButton rbtnDruid;
        private System.Windows.Forms.RadioButton rbtnWarrior;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
    }
}