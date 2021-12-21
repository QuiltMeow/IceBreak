namespace IceBreak
{
    partial class MainMenu
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.cbPlayerName = new System.Windows.Forms.ComboBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelStage = new System.Windows.Forms.Label();
            this.cbStage = new System.Windows.Forms.ComboBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitle
            // 
            this.pbTitle.BackColor = System.Drawing.Color.Transparent;
            this.pbTitle.Image = global::IceBreak.Properties.Resources.Title;
            this.pbTitle.Location = new System.Drawing.Point(170, 65);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(400, 75);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitle.TabIndex = 0;
            this.pbTitle.TabStop = false;
            this.pbTitle.Click += new System.EventHandler(this.pbTitle_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerName.Location = new System.Drawing.Point(330, 200);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(53, 12);
            this.labelPlayerName.TabIndex = 0;
            this.labelPlayerName.Text = "玩家暱稱";
            // 
            // cbPlayerName
            // 
            this.cbPlayerName.FormattingEnabled = true;
            this.cbPlayerName.Location = new System.Drawing.Point(260, 225);
            this.cbPlayerName.Name = "cbPlayerName";
            this.cbPlayerName.Size = new System.Drawing.Size(200, 20);
            this.cbPlayerName.TabIndex = 1;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStartGame.Location = new System.Drawing.Point(260, 345);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(200, 35);
            this.btnStartGame.TabIndex = 4;
            this.btnStartGame.Text = "開始遊戲";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnRank
            // 
            this.btnRank.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRank.Location = new System.Drawing.Point(260, 400);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(200, 35);
            this.btnRank.TabIndex = 5;
            this.btnRank.Text = "排行榜";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExit.Location = new System.Drawing.Point(260, 455);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 35);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelStage
            // 
            this.labelStage.AutoSize = true;
            this.labelStage.BackColor = System.Drawing.Color.Transparent;
            this.labelStage.Location = new System.Drawing.Point(330, 265);
            this.labelStage.Name = "labelStage";
            this.labelStage.Size = new System.Drawing.Size(53, 12);
            this.labelStage.TabIndex = 2;
            this.labelStage.Text = "遊戲關卡";
            // 
            // cbStage
            // 
            this.cbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStage.FormattingEnabled = true;
            this.cbStage.Location = new System.Drawing.Point(260, 290);
            this.cbStage.Name = "cbStage";
            this.cbStage.Size = new System.Drawing.Size(200, 20);
            this.cbStage.TabIndex = 3;
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAbout.Location = new System.Drawing.Point(732, 460);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(40, 40);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "?";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::IceBreak.Properties.Resources.Refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(732, 509);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 40);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IceBreak.Properties.Resources.MainBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.cbStage);
            this.Controls.Add(this.labelStage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.cbPlayerName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.pbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "主選單";
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.ComboBox cbPlayerName;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelStage;
        private System.Windows.Forms.ComboBox cbStage;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnRefresh;
    }
}

