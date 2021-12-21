using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceBreak
{
    public partial class GameForm : GameField
    {
        private const int SCORE_ADD = 1;

        private static readonly GameManager game = Program.game;
        private static readonly Pen linePen = new Pen(Color.Gray);
        private readonly Bitmap pauseImage;

        public bool noRender
        {
            get;
            private set;
        }

        public string name
        {
            get;
            private set;
        }

        public GameForm(string name)
        {
            InitializeComponent();
            applyFont();
            pauseImage = loadPauseImage();

            game.form = this;
            this.name = name;
            initGame();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keyData)
        {
            if (game.status == GameStatus.PLAYING && timerCount.Enabled)
            {
                MoveOperation operation = MoveOperation.getByKey(keyData);
                if (operation != null)
                {
                    bool valid = game.field.playerOperation(operation);
                    if (valid)
                    {
                        game.addScore(SCORE_ADD);
                        updateGame();
                    }
                }
            }
            base.ProcessCmdKey(ref message, keyData);
            return true;
        }

        private void gameOver()
        {
            btnPlayPause.Enabled = false;
            visibleGameOverControl(true);

            bool add = Program.record.addPlayer(game.stage, new RecordData(name, game.score, game.time, game.field.getRecord()));
            StringBuilder sb = new StringBuilder();
            sb.Append(Util.getGameOverMessage(game.finish));
            if (add)
            {
                sb.AppendLine().Append("本次得分已列入排行榜 !");
            }
            MessageBox.Show(sb.ToString(), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateGame()
        {
            drawField();
            labelCurrentTime.Text = getCurrentClock();
            labelReIce.Text = game.field.reIceRemaining.ToString();
            labelPlayingTime.Text = getSolveClock();
            labelScore.Text = game.score.ToString();
            labelGameStatus.Text = "玩家名稱 : " + name + "，目前關卡 : " + game.stage + "，" + Util.getGameStatusName(game.status);
        }

        public static string getCurrentClock()
        {
            return DateTime.Now.ToString("HH : mm : ss");
        }

        private static string getSolveClock()
        {
            return Util.makeTimeReadable(game.time);
        }

        private Bitmap loadPauseImage()
        {
            Font font = new Font("微軟正黑體 Light", 72);
            Point location = new Point(200, 350);

            Bitmap bmp = Util.transparentBitmap(pbGameField);
            using (Graphics graphic = Graphics.FromImage(bmp))
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    graphic.DrawString("遊戲暫停中", font, brush, location);
                }
            }
            return bmp;
        }

        public override void drawField()
        {
            if (noRender)
            {
                pbGameField.Image = Util.transparentBitmap(pbGameField);
                return;
            }
            switch (game.status)
            {
                case GameStatus.PAUSE:
                    {
                        pbGameField.Image = pauseImage;
                        break;
                    }
                default:
                    {
                        Util.drawGameField(pbGameField, game);
                        break;
                    }
            }
        }

        private void timerCount_Tick(object sender, EventArgs e)
        {
            if (game.status == GameStatus.PLAYING)
            {
                game.timerCount();
            }
            updateGame();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics graphic = e.Graphics)
            {
                int fieldWidth = pbGameField.Width;
                int fieldHeight = pbGameField.Height;
                graphic.DrawLine(linePen, fieldWidth, 0, fieldWidth, Height);
                graphic.DrawLine(linePen, 0, fieldHeight, Width, fieldHeight);
            }
        }

        private void btnNextStage_Click(object sender, EventArgs e)
        {
            if (!game.nextLevel())
            {
                if (MessageBox.Show("已經沒有下一關了" + Environment.NewLine + "請問是否從第一關開始 ?", "問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                game.newGame(FieldHandler.getFirstStage());
            }
            initGame();
        }

        private void initGame()
        {
            visibleGameOverControl(false);
            noRender = false;
            updateGame();
            timerCount.Start();
            btnPlayPause.Enabled = true;
        }

        private void applyFont()
        {
            labelCurrentTime.Font = labelReIce.Font = labelPlayingTime.Font = labelScore.Font = Program.font.sevenSegment;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            game.playAgain();
            initGame();
        }

        private void visibleGameOverControl(bool visible)
        {
            btnPlayAgain.Visible = btnNextStage.Visible = visible;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            game.togglePause();
            updateGame();
            btnPlayPause.Text = game.status == GameStatus.PLAYING ? "暫停" : "繼續";
        }

        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            timerGameOver.Stop();
            noRender = true;
            updateGame();
            gameOver();
        }
    }
}