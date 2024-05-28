namespace Bai3
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
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btndownloadfiles = new System.Windows.Forms.Button();
            this.btndownloadresources = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.SuspendLayout();
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Location = new System.Drawing.Point(4, 69);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(729, 277);
            this.webView2.TabIndex = 0;
            this.webView2.ZoomFactor = 1D;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(4, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btndownloadfiles
            // 
            this.btndownloadfiles.Location = new System.Drawing.Point(573, 41);
            this.btndownloadfiles.Name = "btndownloadfiles";
            this.btndownloadfiles.Size = new System.Drawing.Size(125, 23);
            this.btndownloadfiles.TabIndex = 2;
            this.btndownloadfiles.Text = "Download Files";
            this.btndownloadfiles.UseVisualStyleBackColor = true;
            this.btndownloadfiles.Click += new System.EventHandler(this.btndownloadfiles_Click);
            // 
            // btndownloadresources
            // 
            this.btndownloadresources.Location = new System.Drawing.Point(654, 11);
            this.btndownloadresources.Name = "btndownloadresources";
            this.btndownloadresources.Size = new System.Drawing.Size(79, 23);
            this.btndownloadresources.TabIndex = 3;
            this.btndownloadresources.Text = "Download Source";
            this.btndownloadresources.UseVisualStyleBackColor = true;
            this.btndownloadresources.Click += new System.EventHandler(this.btndownloadresources_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(126, 25);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(441, 20);
            this.txtUrl.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 353);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btndownloadresources);
            this.Controls.Add(this.btndownloadfiles);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.webView2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btndownloadfiles;
        private System.Windows.Forms.Button btndownloadresources;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button button1;
    }
}

