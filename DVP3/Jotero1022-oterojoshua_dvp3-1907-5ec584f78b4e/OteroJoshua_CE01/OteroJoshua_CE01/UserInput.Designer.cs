namespace OteroJoshua_CE01
{
    partial class UserInput
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
            this.grpBoxUser = new System.Windows.Forms.GroupBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpBoxUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxUser
            // 
            this.grpBoxUser.Controls.Add(this.btnAdd);
            this.grpBoxUser.Controls.Add(this.chkCompleted);
            this.grpBoxUser.Controls.Add(this.lblClassName);
            this.grpBoxUser.Controls.Add(this.txtClassName);
            this.grpBoxUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpBoxUser.Location = new System.Drawing.Point(7, 12);
            this.grpBoxUser.Name = "grpBoxUser";
            this.grpBoxUser.Size = new System.Drawing.Size(298, 137);
            this.grpBoxUser.TabIndex = 0;
            this.grpBoxUser.TabStop = false;
            this.grpBoxUser.Text = "Class Information";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(90, 30);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(164, 20);
            this.txtClassName.TabIndex = 0;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(18, 33);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(66, 13);
            this.lblClassName.TabIndex = 1;
            this.lblClassName.Text = "Class Name:";
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Location = new System.Drawing.Point(90, 67);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(104, 17);
            this.chkCompleted.TabIndex = 2;
            this.chkCompleted.Text = "Class Completed";
            this.chkCompleted.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(78, 104);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 161);
            this.Controls.Add(this.grpBoxUser);
            this.Name = "UserInput";
            this.Text = "User Input Window";
            this.grpBoxUser.ResumeLayout(false);
            this.grpBoxUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxUser;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Button btnAdd;
    }
}