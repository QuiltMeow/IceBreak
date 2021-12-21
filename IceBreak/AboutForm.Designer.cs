namespace IceBreak
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.pbAuthor = new System.Windows.Forms.PictureBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.wbMedia = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAuthor
            // 
            this.pbAuthor.BackColor = System.Drawing.Color.Transparent;
            this.pbAuthor.Image = global::IceBreak.Properties.Resources.OriginIcon;
            this.pbAuthor.Location = new System.Drawing.Point(12, 12);
            this.pbAuthor.Name = "pbAuthor";
            this.pbAuthor.Size = new System.Drawing.Size(100, 100);
            this.pbAuthor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAuthor.TabIndex = 0;
            this.pbAuthor.TabStop = false;
            this.pbAuthor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbAuthor_MouseClick);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthor.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAuthor.ForeColor = System.Drawing.Color.Purple;
            this.labelAuthor.Location = new System.Drawing.Point(130, 25);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(127, 40);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Break Ice Game\r\n棉被正在看著你";
            // 
            // wbMedia
            // 
            this.wbMedia.IsWebBrowserContextMenuEnabled = false;
            this.wbMedia.Location = new System.Drawing.Point(-8, -8);
            this.wbMedia.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMedia.Name = "wbMedia";
            this.wbMedia.ScrollBarsEnabled = false;
            this.wbMedia.Size = new System.Drawing.Size(650, 375);
            this.wbMedia.TabIndex = 1;
            this.wbMedia.Url = new System.Uri("", System.UriKind.Relative);
            this.wbMedia.Visible = false;
            this.wbMedia.WebBrowserShortcutsEnabled = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IceBreak.Properties.Resources.BeastTamer;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(639, 356);
            this.Controls.Add(this.wbMedia);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.pbAuthor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "關於";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AboutForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.WebBrowser wbMedia;
    }
}