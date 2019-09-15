namespace DelegatesWinFormsDemo
{
    partial class FrmMain
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
            this.btnOpenFrm1 = new System.Windows.Forms.Button();
            this.btnOpenFrm2 = new System.Windows.Forms.Button();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.lstBx = new System.Windows.Forms.ListBox();
            this.btnScenario2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFrm1
            // 
            this.btnOpenFrm1.Location = new System.Drawing.Point(75, 5);
            this.btnOpenFrm1.Name = "btnOpenFrm1";
            this.btnOpenFrm1.Size = new System.Drawing.Size(111, 23);
            this.btnOpenFrm1.TabIndex = 0;
            this.btnOpenFrm1.Text = "Open Child Form 1";
            this.btnOpenFrm1.UseVisualStyleBackColor = true;
            this.btnOpenFrm1.Click += new System.EventHandler(this.btnOpenFrm1_Click);
            // 
            // btnOpenFrm2
            // 
            this.btnOpenFrm2.Location = new System.Drawing.Point(75, 34);
            this.btnOpenFrm2.Name = "btnOpenFrm2";
            this.btnOpenFrm2.Size = new System.Drawing.Size(111, 23);
            this.btnOpenFrm2.TabIndex = 1;
            this.btnOpenFrm2.Text = "Open Child Form 2";
            this.btnOpenFrm2.UseVisualStyleBackColor = true;
            this.btnOpenFrm2.Click += new System.EventHandler(this.btnOpenFrm2_Click);
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(75, 73);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(111, 20);
            this.txtParam.TabIndex = 2;
            this.txtParam.TextChanged += new System.EventHandler(this.txtParam_TextChanged);
            // 
            // lstBx
            // 
            this.lstBx.FormattingEnabled = true;
            this.lstBx.Location = new System.Drawing.Point(75, 115);
            this.lstBx.Name = "lstBx";
            this.lstBx.Size = new System.Drawing.Size(111, 134);
            this.lstBx.TabIndex = 3;
            // 
            // btnScenario2
            // 
            this.btnScenario2.Location = new System.Drawing.Point(75, 256);
            this.btnScenario2.Name = "btnScenario2";
            this.btnScenario2.Size = new System.Drawing.Size(111, 23);
            this.btnScenario2.TabIndex = 4;
            this.btnScenario2.Text = "Second Scenario";
            this.btnScenario2.UseVisualStyleBackColor = true;
            this.btnScenario2.Click += new System.EventHandler(this.btnScenario2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 291);
            this.Controls.Add(this.btnScenario2);
            this.Controls.Add(this.lstBx);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.btnOpenFrm2);
            this.Controls.Add(this.btnOpenFrm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFrm1;
        private System.Windows.Forms.Button btnOpenFrm2;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.ListBox lstBx;
        private System.Windows.Forms.Button btnScenario2;
    }
}

