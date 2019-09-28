namespace CheckLinkValid
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.listBoxLinkNotValid = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.ckAdminPage = new System.Windows.Forms.CheckBox();
            this.btnProcessRapidgator = new System.Windows.Forms.Button();
            this.pChrome = new System.Windows.Forms.Panel();
            this.btnInitChrome = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(776, 20);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check Link";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(52, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(535, 20);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Text = "http://blogpp.xyz/videohive-31-unique-titles-pack-free-download-4/";
            // 
            // listBoxLinkNotValid
            // 
            this.listBoxLinkNotValid.FormattingEnabled = true;
            this.listBoxLinkNotValid.Location = new System.Drawing.Point(633, 87);
            this.listBoxLinkNotValid.Name = "listBoxLinkNotValid";
            this.listBoxLinkNotValid.Size = new System.Drawing.Size(339, 394);
            this.listBoxLinkNotValid.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Link not valid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 525);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End Time";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(109, 496);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(0, 13);
            this.lblStartTime.TabIndex = 8;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(109, 525);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(0, 13);
            this.lblEndTime.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số bản ghi lỗi / Tổng số bản ghi:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(612, 496);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 11;
            // 
            // ckAdminPage
            // 
            this.ckAdminPage.AutoSize = true;
            this.ckAdminPage.Location = new System.Drawing.Point(593, 24);
            this.ckAdminPage.Name = "ckAdminPage";
            this.ckAdminPage.Size = new System.Drawing.Size(83, 17);
            this.ckAdminPage.TabIndex = 12;
            this.ckAdminPage.Text = "Admin Page";
            this.ckAdminPage.UseVisualStyleBackColor = true;
            // 
            // btnProcessRapidgator
            // 
            this.btnProcessRapidgator.Location = new System.Drawing.Point(857, 21);
            this.btnProcessRapidgator.Name = "btnProcessRapidgator";
            this.btnProcessRapidgator.Size = new System.Drawing.Size(115, 23);
            this.btnProcessRapidgator.TabIndex = 13;
            this.btnProcessRapidgator.Text = "Process Rapidgator";
            this.btnProcessRapidgator.UseVisualStyleBackColor = true;
            this.btnProcessRapidgator.Click += new System.EventHandler(this.btnProcessRapidgator_Click);
            // 
            // pChrome
            // 
            this.pChrome.Location = new System.Drawing.Point(16, 87);
            this.pChrome.Name = "pChrome";
            this.pChrome.Size = new System.Drawing.Size(611, 394);
            this.pChrome.TabIndex = 14;
            // 
            // btnInitChrome
            // 
            this.btnInitChrome.Location = new System.Drawing.Point(682, 19);
            this.btnInitChrome.Name = "btnInitChrome";
            this.btnInitChrome.Size = new System.Drawing.Size(88, 23);
            this.btnInitChrome.TabIndex = 15;
            this.btnInitChrome.Text = "Load Chrome";
            this.btnInitChrome.UseVisualStyleBackColor = true;
            this.btnInitChrome.Click += new System.EventHandler(this.btnInitChrome_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Chrome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnInitChrome);
            this.Controls.Add(this.pChrome);
            this.Controls.Add(this.btnProcessRapidgator);
            this.Controls.Add(this.ckAdminPage);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxLinkNotValid);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Check Link Valid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ListBox listBoxLinkNotValid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox ckAdminPage;
        private System.Windows.Forms.Button btnProcessRapidgator;
        private System.Windows.Forms.Panel pChrome;
        private System.Windows.Forms.Button btnInitChrome;
        private System.Windows.Forms.Label label6;
    }
}

