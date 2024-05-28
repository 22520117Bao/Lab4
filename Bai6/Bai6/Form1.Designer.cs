namespace Bai6
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txturl = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btconnect = new System.Windows.Forms.Button();
            this.btinfo = new System.Windows.Forms.Button();
            this.rtbtoken = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(104, 13);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(376, 20);
            this.txturl.TabIndex = 3;
            this.txturl.Text = "https://nt106.uitiot.vn/auth/token";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(104, 52);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(308, 20);
            this.txtusername.TabIndex = 4;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(104, 95);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(308, 20);
            this.txtpass.TabIndex = 5;
            // 
            // btconnect
            // 
            this.btconnect.Location = new System.Drawing.Point(486, 6);
            this.btconnect.Name = "btconnect";
            this.btconnect.Size = new System.Drawing.Size(75, 54);
            this.btconnect.TabIndex = 6;
            this.btconnect.Text = "Kết nối";
            this.btconnect.UseVisualStyleBackColor = true;
            this.btconnect.Click += new System.EventHandler(this.btconnect_Click);
            // 
            // btinfo
            // 
            this.btinfo.Location = new System.Drawing.Point(456, 66);
            this.btinfo.Name = "btinfo";
            this.btinfo.Size = new System.Drawing.Size(105, 49);
            this.btinfo.TabIndex = 7;
            this.btinfo.Text = "Thông tin";
            this.btinfo.UseVisualStyleBackColor = true;
            this.btinfo.Click += new System.EventHandler(this.btinfo_Click);
            // 
            // rtbtoken
            // 
            this.rtbtoken.Location = new System.Drawing.Point(15, 121);
            this.rtbtoken.Name = "rtbtoken";
            this.rtbtoken.Size = new System.Drawing.Size(546, 166);
            this.rtbtoken.TabIndex = 8;
            this.rtbtoken.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 291);
            this.Controls.Add(this.rtbtoken);
            this.Controls.Add(this.btinfo);
            this.Controls.Add(this.btconnect);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btconnect;
        private System.Windows.Forms.Button btinfo;
        private System.Windows.Forms.RichTextBox rtbtoken;
    }
}

