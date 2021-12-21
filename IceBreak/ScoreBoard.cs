using System;
using System.Windows.Forms;

namespace IceBreak
{
    public partial class ScoreBoard : Form
    {
        private const string PREFIX = "關卡 ";

        public int currentStage
        {
            get;
            private set;
        }

        public StageRecord currentRecord
        {
            get;
            private set;
        }

        public ScoreBoard()
        {
            InitializeComponent();
            loadStageList();
        }

        private void loadStageList()
        {
            foreach (MapData data in FieldHandler.MAP_CACHE)
            {
                cbStage.Items.Add(PREFIX + data.stage);
            }
            cbStage.SelectedIndex = 0;
            currentStage = FieldHandler.getFirstStage();
            loadRecord();
        }

        private void loadRecord()
        {
            lvRank.Items.Clear();
            currentRecord = Program.record.getStageRecord(currentStage);
            if (currentRecord == null)
            {
                lvRank.Items.Add(new ListViewItem(new string[] {
                    "無紀錄"
                }));
                return;
            }
            foreach (RecordData record in currentRecord.rank)
            {
                lvRank.Items.Add(new ListViewItem(new string[] {
                    record.name, record.score.ToString(), Util.makeTimeReadable(record.time)
                }));
            }
        }

        private void cbStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStage = int.Parse(cbStage.SelectedItem.ToString().Substring(PREFIX.Length));
            loadRecord();
        }

        private void lvRank_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentRecord == null)
            {
                return;
            }
            if (lvRank.SelectedIndices.Count > 0)
            {
                int select = lvRank.SelectedIndices[0];
                RecordData record = currentRecord.rank[select];
                using (ReplayForm replay = new ReplayForm(currentStage, record.record))
                {
                    replay.ShowDialog();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}