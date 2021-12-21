using System;
using System.Windows.Forms;

namespace IceBreak
{
    public partial class ReplayForm : GameField
    {
        public ReplayGame replay
        {
            get;
            private set;
        }

        public ReplayForm(int stage, string record)
        {
            InitializeComponent();
            replay = new ReplayGame(this, stage, record);
            drawField();
        }

        private void timerCount_Tick(object sender, EventArgs e)
        {
            MoveOperation operation = replay.next();
            if (operation == null)
            {
                timerCount.Stop();
                if (!replay.field.isGameOver())
                {
                    MessageBox.Show("非預期重播錯誤，請檢查紀錄檔案完整性", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            replay.field.playerOperation(operation);
            drawField();
        }

        public override void drawField()
        {
            Util.drawGameField(pbGameField, replay);
        }

        private void timerIdle_Tick(object sender, EventArgs e)
        {
            timerIdle.Stop();
            timerCount.Start();
        }
    }
}