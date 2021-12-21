namespace IceBreak
{
    partial class ScoreBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreBoard));
            this.cbStage = new System.Windows.Forms.ComboBox();
            this.lvRank = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbStage
            // 
            this.cbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStage.FormattingEnabled = true;
            this.cbStage.Location = new System.Drawing.Point(12, 12);
            this.cbStage.Name = "cbStage";
            this.cbStage.Size = new System.Drawing.Size(260, 20);
            this.cbStage.TabIndex = 0;
            this.cbStage.SelectedIndexChanged += new System.EventHandler(this.cbStage_SelectedIndexChanged);
            // 
            // lvRank
            // 
            this.lvRank.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chScore,
            this.chTime});
            this.lvRank.HideSelection = false;
            this.lvRank.Location = new System.Drawing.Point(12, 50);
            this.lvRank.MultiSelect = false;
            this.lvRank.Name = "lvRank";
            this.lvRank.Size = new System.Drawing.Size(260, 415);
            this.lvRank.TabIndex = 1;
            this.lvRank.UseCompatibleStateImageBehavior = false;
            this.lvRank.View = System.Windows.Forms.View.Details;
            this.lvRank.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRank_MouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "玩家";
            this.chName.Width = 90;
            // 
            // chScore
            // 
            this.chScore.Text = "分數";
            this.chScore.Width = 75;
            // 
            // chTime
            // 
            this.chTime.Text = "時間";
            this.chTime.Width = 90;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(100, 476);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IceBreak.Properties.Resources.ScoreBoardBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 511);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lvRank);
            this.Controls.Add(this.cbStage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "ScoreBoard";
            this.Text = "排行榜";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStage;
        private System.Windows.Forms.ListView lvRank;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chScore;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.Button btnExit;
    }
}