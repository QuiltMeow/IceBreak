using System.Text;
using System.Windows.Forms;

namespace IceBreak
{
    public class ReplayGame : GameHandler
    {
        public int stage
        {
            get;
            private set;
        }

        public string record
        {
            get;
            private set;
        }

        public int current
        {
            get;
            private set;
        }

        public FieldHandler field
        {
            get;
            private set;
        }

        public ReplayForm form
        {
            get;
            private set;
        }

        public MoveOperation next()
        {
            if (current >= record.Length)
            {
                return null;
            }
            return MoveOperation.getBySymbol(record[current++]);
        }

        public ReplayGame(ReplayForm form, int stage, string record)
        {
            this.form = form;
            this.stage = stage;
            field = new FieldHandler(this);

            this.record = record;
            current = 0;
        }

        public void gameOver(bool finish)
        {
            form.drawField();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("播放結束 !").Append(Util.getGameOverMessage(finish));
            MessageBox.Show(sb.ToString(), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}