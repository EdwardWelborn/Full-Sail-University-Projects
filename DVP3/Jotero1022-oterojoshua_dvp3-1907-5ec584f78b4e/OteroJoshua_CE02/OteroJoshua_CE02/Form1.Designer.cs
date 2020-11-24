namespace OteroJoshua_CE02
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblRelease = new System.Windows.Forms.Label();
            this.txtRelease = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.cmbIcon = new System.Windows.Forms.ComboBox();
            this.lvfData = new System.Windows.Forms.ListView();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pntDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(116, 216);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(152, 213);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(248, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblRelease
            // 
            this.lblRelease.AutoSize = true;
            this.lblRelease.Location = new System.Drawing.Point(71, 277);
            this.lblRelease.Name = "lblRelease";
            this.lblRelease.Size = new System.Drawing.Size(75, 13);
            this.lblRelease.TabIndex = 2;
            this.lblRelease.Text = "Release Date:";
            // 
            // txtRelease
            // 
            this.txtRelease.Location = new System.Drawing.Point(152, 274);
            this.txtRelease.Name = "txtRelease";
            this.txtRelease.Size = new System.Drawing.Size(108, 20);
            this.txtRelease.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtRelease, "Release Date will not be accepted by database. Try entering it in a format of \"yy" +
        "yy-MM-dd\" or similar formats");
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(152, 333);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(248, 20);
            this.txtPublisher.TabIndex = 5;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(93, 336);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(53, 13);
            this.lblPublisher.TabIndex = 4;
            this.lblPublisher.Text = "Publisher:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(152, 398);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(248, 20);
            this.txtAuthor.TabIndex = 7;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(105, 401);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 6;
            this.lblAuthor.Text = "Author:";
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(152, 458);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(248, 20);
            this.txtDirector.TabIndex = 9;
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(99, 461);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(47, 13);
            this.lblDirector.TabIndex = 8;
            this.lblDirector.Text = "Director:";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(152, 521);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(248, 20);
            this.txtGenre.TabIndex = 11;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(116, 524);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 10;
            this.lblGenre.Text = "Genre:";
            // 
            // cmbIcon
            // 
            this.cmbIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIcon.FormattingEnabled = true;
            this.cmbIcon.Items.AddRange(new object[] {
            "Movie",
            "Book"});
            this.cmbIcon.Location = new System.Drawing.Point(208, 575);
            this.cmbIcon.Name = "cmbIcon";
            this.cmbIcon.Size = new System.Drawing.Size(121, 21);
            this.cmbIcon.TabIndex = 12;
            // 
            // lvfData
            // 
            this.lvfData.LargeImageList = this.imgIcons;
            this.lvfData.Location = new System.Drawing.Point(96, 650);
            this.lvfData.Name = "lvfData";
            this.lvfData.Size = new System.Drawing.Size(476, 273);
            this.lvfData.TabIndex = 13;
            this.toolTip1.SetToolTip(this.lvfData, "Double Click an object to send data to the fields above.");
            this.lvfData.UseCompatibleStateImageBehavior = false;
            this.lvfData.DoubleClick += new System.EventHandler(this.lvfData_DoubleClick);
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "video-camera");
            this.imgIcons.Images.SetKeyName(1, "open-book");
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(497, 243);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 38);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.toolTip1.SetToolTip(this.btnPrint, "Print\'s out list");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(497, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 38);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.toolTip1.SetToolTip(this.btnUpdate, "Updates Item to List and Database. ONLY USE IF ITEM EXISTS");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(497, 461);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 38);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add New";
            this.toolTip1.SetToolTip(this.btnAdd, "Add new item to List View and Database");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pntDialog
            // 
            this.pntDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pntDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pntDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.pntDialog.Enabled = true;
            this.pntDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("pntDialog.Icon")));
            this.pntDialog.Name = "pntDialog";
            this.pntDialog.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::OteroJoshua_CE02.Properties.Resources.iPhone7Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(671, 1061);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lvfData);
            this.Controls.Add(this.cmbIcon);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtRelease);
            this.Controls.Add(this.lblRelease);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Entertainment Saver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblRelease;
        private System.Windows.Forms.TextBox txtRelease;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cmbIcon;
        private System.Windows.Forms.ListView lvfData;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PrintPreviewDialog pntDialog;
    }
}

