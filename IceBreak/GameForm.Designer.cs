namespace IceBreak
{
    partial class GameForm
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
            this.btnNextStage = new System.Windows.Forms.Button();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.labelPlayingTime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelGameStatus = new System.Windows.Forms.Label();
            this.gbCurrentTime = new System.Windows.Forms.GroupBox();
            this.gbPlayingTime = new System.Windows.Forms.GroupBox();
            this.gbScore = new System.Windows.Forms.GroupBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.pbIce = new System.Windows.Forms.PictureBox();
            this.labelReIce = new System.Windows.Forms.Label();
            this.gbReIce = new System.Windows.Forms.GroupBox();
            this.labelReIceTip = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).BeginInit();
            this.gbCurrentTime.SuspendLayout();
            this.gbPlayingTime.SuspendLayout();
            this.gbScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIce)).BeginInit();
            this.gbReIce.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCount
            // 
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // btnNextStage
            // 
            this.btnNextStage.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNextStage.Location = new System.Drawing.Point(350, 460);
            this.btnNextStage.Name = "btnNextStage";
            this.btnNextStage.Size = new System.Drawing.Size(215, 70);
            this.btnNextStage.TabIndex = 9;
            this.btnNextStage.Text = "下一個關卡";
            this.btnNextStage.UseVisualStyleBackColor = true;
            this.btnNextStage.Visible = false;
            this.btnNextStage.Click += new System.EventHandler(this.btnNextStage_Click);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPlayAgain.Location = new System.Drawing.Point(350, 350);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(215, 70);
            this.btnPlayAgain.TabIndex = 8;
            this.btnPlayAgain.Text = "重新開始";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentTime.Location = new System.Drawing.Point(3, 18);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(174, 49);
            this.labelCurrentTime.TabIndex = 0;
            this.labelCurrentTime.Text = "00 : 00 : 00";
            this.labelCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayingTime
            // 
            this.labelPlayingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPlayingTime.Location = new System.Drawing.Point(3, 18);
            this.labelPlayingTime.Name = "labelPlayingTime";
            this.labelPlayingTime.Size = new System.Drawing.Size(174, 49);
            this.labelPlayingTime.TabIndex = 0;
            this.labelPlayingTime.Text = "00 : 00 : 00";
            this.labelPlayingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1040, 915);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelGameStatus
            // 
            this.labelGameStatus.AutoSize = true;
            this.labelGameStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelGameStatus.Location = new System.Drawing.Point(12, 918);
            this.labelGameStatus.Name = "labelGameStatus";
            this.labelGameStatus.Size = new System.Drawing.Size(55, 15);
            this.labelGameStatus.TabIndex = 5;
            this.labelGameStatus.Text = "遊戲狀態";
            // 
            // gbCurrentTime
            // 
            this.gbCurrentTime.Controls.Add(this.labelCurrentTime);
            this.gbCurrentTime.Location = new System.Drawing.Point(935, 30);
            this.gbCurrentTime.Name = "gbCurrentTime";
            this.gbCurrentTime.Size = new System.Drawing.Size(180, 70);
            this.gbCurrentTime.TabIndex = 0;
            this.gbCurrentTime.TabStop = false;
            this.gbCurrentTime.Text = "目前時間";
            // 
            // gbPlayingTime
            // 
            this.gbPlayingTime.Controls.Add(this.labelPlayingTime);
            this.gbPlayingTime.Location = new System.Drawing.Point(935, 695);
            this.gbPlayingTime.Name = "gbPlayingTime";
            this.gbPlayingTime.Size = new System.Drawing.Size(180, 70);
            this.gbPlayingTime.TabIndex = 3;
            this.gbPlayingTime.TabStop = false;
            this.gbPlayingTime.Text = "經過時間";
            // 
            // gbScore
            // 
            this.gbScore.Controls.Add(this.labelScore);
            this.gbScore.Location = new System.Drawing.Point(935, 800);
            this.gbScore.Name = "gbScore";
            this.gbScore.Size = new System.Drawing.Size(180, 70);
            this.gbScore.TabIndex = 4;
            this.gbScore.TabStop = false;
            this.gbScore.Text = "分數";
            // 
            // labelScore
            // 
            this.labelScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelScore.Location = new System.Drawing.Point(3, 18);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(174, 49);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbIce
            // 
            this.pbIce.BackColor = System.Drawing.Color.Transparent;
            this.pbIce.Image = global::IceBreak.Properties.Resources.ReIce;
            this.pbIce.Location = new System.Drawing.Point(30, 18);
            this.pbIce.Name = "pbIce";
            this.pbIce.Size = new System.Drawing.Size(44, 48);
            this.pbIce.TabIndex = 10;
            this.pbIce.TabStop = false;
            // 
            // labelReIce
            // 
            this.labelReIce.AutoSize = true;
            this.labelReIce.Location = new System.Drawing.Point(110, 30);
            this.labelReIce.Name = "labelReIce";
            this.labelReIce.Size = new System.Drawing.Size(11, 12);
            this.labelReIce.TabIndex = 0;
            this.labelReIce.Text = "3";
            // 
            // gbReIce
            // 
            this.gbReIce.Controls.Add(this.pbIce);
            this.gbReIce.Controls.Add(this.labelReIce);
            this.gbReIce.Location = new System.Drawing.Point(935, 150);
            this.gbReIce.Name = "gbReIce";
            this.gbReIce.Size = new System.Drawing.Size(180, 75);
            this.gbReIce.TabIndex = 1;
            this.gbReIce.TabStop = false;
            this.gbReIce.Text = "重新結冰";
            // 
            // labelReIceTip
            // 
            this.labelReIceTip.AutoSize = true;
            this.labelReIceTip.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelReIceTip.Location = new System.Drawing.Point(932, 235);
            this.labelReIceTip.Name = "labelReIceTip";
            this.labelReIceTip.Size = new System.Drawing.Size(115, 17);
            this.labelReIceTip.TabIndex = 2;
            this.labelReIceTip.Text = "W、A、S、D 觸發";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Enabled = false;
            this.btnPlayPause.Location = new System.Drawing.Point(935, 915);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(75, 23);
            this.btnPlayPause.TabIndex = 6;
            this.btnPlayPause.TabStop = false;
            this.btnPlayPause.Text = "暫停";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // timerGameOver
            // 
            this.timerGameOver.Interval = 300;
            this.timerGameOver.Tick += new System.EventHandler(this.timerGameOver_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 941);
            this.Controls.Add(this.btnNextStage);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.labelReIceTip);
            this.Controls.Add(this.gbReIce);
            this.Controls.Add(this.gbScore);
            this.Controls.Add(this.gbPlayingTime);
            this.Controls.Add(this.gbCurrentTime);
            this.Controls.Add(this.labelGameStatus);
            this.Controls.Add(this.btnExit);
            this.Name = "GameForm";
            this.Text = "Break Ice 遊戲";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.labelGameStatus, 0);
            this.Controls.SetChildIndex(this.gbCurrentTime, 0);
            this.Controls.SetChildIndex(this.gbPlayingTime, 0);
            this.Controls.SetChildIndex(this.gbScore, 0);
            this.Controls.SetChildIndex(this.gbReIce, 0);
            this.Controls.SetChildIndex(this.labelReIceTip, 0);
            this.Controls.SetChildIndex(this.btnPlayPause, 0);
            this.Controls.SetChildIndex(this.pbGameField, 0);
            this.Controls.SetChildIndex(this.btnPlayAgain, 0);
            this.Controls.SetChildIndex(this.btnNextStage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameField)).EndInit();
            this.gbCurrentTime.ResumeLayout(false);
            this.gbPlayingTime.ResumeLayout(false);
            this.gbScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIce)).EndInit();
            this.gbReIce.ResumeLayout(false);
            this.gbReIce.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNextStage;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Label labelPlayingTime;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelGameStatus;
        private System.Windows.Forms.GroupBox gbCurrentTime;
        private System.Windows.Forms.GroupBox gbPlayingTime;
        private System.Windows.Forms.GroupBox gbScore;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox pbIce;
        private System.Windows.Forms.Label labelReIce;
        private System.Windows.Forms.GroupBox gbReIce;
        private System.Windows.Forms.Label labelReIceTip;
        private System.Windows.Forms.Button btnPlayPause;
        public System.Windows.Forms.Timer timerGameOver;
    }
}