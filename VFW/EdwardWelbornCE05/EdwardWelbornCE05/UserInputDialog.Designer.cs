namespace EdwardWelbornCE05
{
    partial class UserInputDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInputDialog));
            this.gbShips = new System.Windows.Forms.GroupBox();
            this.rdoFreighter = new System.Windows.Forms.RadioButton();
            this.rdoDestroyer = new System.Windows.Forms.RadioButton();
            this.rdoCruiser = new System.Windows.Forms.RadioButton();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.lblShipName = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.numCrewSize = new System.Windows.Forms.NumericUpDown();
            this.lblCrewSize = new System.Windows.Forms.Label();
            this.chkActiveDuty = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbShips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrewSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbShips
            // 
            this.gbShips.Controls.Add(this.chkActiveDuty);
            this.gbShips.Controls.Add(this.lblCrewSize);
            this.gbShips.Controls.Add(this.numCrewSize);
            this.gbShips.Controls.Add(this.lblShipName);
            this.gbShips.Controls.Add(this.txtShipName);
            this.gbShips.Controls.Add(this.rdoCruiser);
            this.gbShips.Controls.Add(this.rdoDestroyer);
            this.gbShips.Controls.Add(this.rdoFreighter);
            this.gbShips.Location = new System.Drawing.Point(1, 4);
            this.gbShips.Name = "gbShips";
            this.gbShips.Size = new System.Drawing.Size(413, 197);
            this.gbShips.TabIndex = 0;
            this.gbShips.TabStop = false;
            this.gbShips.Text = "Ship Information";
            // 
            // rdoFreighter
            // 
            this.rdoFreighter.AutoSize = true;
            this.rdoFreighter.Location = new System.Drawing.Point(27, 88);
            this.rdoFreighter.Name = "rdoFreighter";
            this.rdoFreighter.Size = new System.Drawing.Size(66, 17);
            this.rdoFreighter.TabIndex = 0;
            this.rdoFreighter.TabStop = true;
            this.rdoFreighter.Text = "Freighter";
            this.rdoFreighter.UseVisualStyleBackColor = true;
            // 
            // rdoDestroyer
            // 
            this.rdoDestroyer.AutoSize = true;
            this.rdoDestroyer.Location = new System.Drawing.Point(27, 122);
            this.rdoDestroyer.Name = "rdoDestroyer";
            this.rdoDestroyer.Size = new System.Drawing.Size(70, 17);
            this.rdoDestroyer.TabIndex = 1;
            this.rdoDestroyer.TabStop = true;
            this.rdoDestroyer.Text = "Destroyer";
            this.rdoDestroyer.UseVisualStyleBackColor = true;
            // 
            // rdoCruiser
            // 
            this.rdoCruiser.AutoSize = true;
            this.rdoCruiser.Location = new System.Drawing.Point(27, 158);
            this.rdoCruiser.Name = "rdoCruiser";
            this.rdoCruiser.Size = new System.Drawing.Size(57, 17);
            this.rdoCruiser.TabIndex = 2;
            this.rdoCruiser.TabStop = true;
            this.rdoCruiser.Text = "Cruiser";
            this.rdoCruiser.UseVisualStyleBackColor = true;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(103, 53);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(218, 20);
            this.txtShipName.TabIndex = 3;
            // 
            // lblShipName
            // 
            this.lblShipName.AutoSize = true;
            this.lblShipName.Location = new System.Drawing.Point(27, 56);
            this.lblShipName.Name = "lblShipName";
            this.lblShipName.Size = new System.Drawing.Size(59, 13);
            this.lblShipName.TabIndex = 4;
            this.lblShipName.Text = "Ship Name";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 257);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(412, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "freighter.png");
            this.imageList1.Images.SetKeyName(1, "destroyer.png");
            this.imageList1.Images.SetKeyName(2, "cruiser.png");
            // 
            // numCrewSize
            // 
            this.numCrewSize.Location = new System.Drawing.Point(201, 88);
            this.numCrewSize.Name = "numCrewSize";
            this.numCrewSize.Size = new System.Drawing.Size(120, 20);
            this.numCrewSize.TabIndex = 5;
            // 
            // lblCrewSize
            // 
            this.lblCrewSize.AutoSize = true;
            this.lblCrewSize.Location = new System.Drawing.Point(134, 94);
            this.lblCrewSize.Name = "lblCrewSize";
            this.lblCrewSize.Size = new System.Drawing.Size(54, 13);
            this.lblCrewSize.TabIndex = 6;
            this.lblCrewSize.Text = "Crew Size";
            // 
            // chkActiveDuty
            // 
            this.chkActiveDuty.AutoSize = true;
            this.chkActiveDuty.Location = new System.Drawing.Point(137, 122);
            this.chkActiveDuty.Name = "chkActiveDuty";
            this.chkActiveDuty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkActiveDuty.Size = new System.Drawing.Size(87, 17);
            this.chkActiveDuty.TabIndex = 7;
            this.chkActiveDuty.Text = "?Active Duty";
            this.chkActiveDuty.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(41, 222);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(167, 222);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 279);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbShips);
            this.Name = "UserInputDialog";
            this.Text = "CE05 UserInputDialog";
            this.gbShips.ResumeLayout(false);
            this.gbShips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrewSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbShips;
        private System.Windows.Forms.CheckBox chkActiveDuty;
        private System.Windows.Forms.Label lblCrewSize;
        private System.Windows.Forms.NumericUpDown numCrewSize;
        private System.Windows.Forms.Label lblShipName;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.RadioButton rdoCruiser;
        private System.Windows.Forms.RadioButton rdoDestroyer;
        private System.Windows.Forms.RadioButton rdoFreighter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}