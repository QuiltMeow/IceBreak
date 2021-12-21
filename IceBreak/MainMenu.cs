using IceBreak.Properties;
using System;
using System.Windows.Forms;

namespace IceBreak
{
    public partial class MainMenu : Form
    {
        private static readonly RecordHandler record = Program.record;

        private bool titleSwitch;

        public MainMenu()
        {
            InitializeComponent();
            updateMenu();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            string name = cbPlayerName.Text.Trim();
            cbPlayerName.Text = name;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("請輸入您的名稱", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name.Length > RecordHandler.MAX_NAME_LENGTH)
            {
                MessageBox.Show("名稱長度不得超過 " + RecordHandler.MAX_NAME_LENGTH + " 字元", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stage = int.Parse(cbStage.SelectedItem.ToString());
            record.currentPlayerName = name;
            record.playerNameSet.Add(name);
            record.selectStage = stage;
            record.save();
            updateMenu();

            Program.game.newGame(stage);
            using (GameForm gameForm = new GameForm(name))
            {
                gameForm.ShowDialog();
            }
        }

        private void updateMenu()
        {
            cbPlayerName.Items.Clear();
            foreach (string name in record.playerNameSet)
            {
                cbPlayerName.Items.Add(name);
            }
            cbPlayerName.Text = record.currentPlayerName;

            cbStage.Items.Clear();
            foreach (MapData map in FieldHandler.MAP_CACHE)
            {
                cbStage.Items.Add(map.stage);
            }
            cbStage.SelectedItem = record.selectStage;
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            using (ScoreBoard rank = new ScoreBoard())
            {
                rank.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Program.about.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Program.loadMapData();
            bool success = Program.loadRecordData();
            updateMenu();
            if (success)
            {
                MessageBox.Show("已重新載入所有資料", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbTitle_Click(object sender, EventArgs e)
        {
            titleSwitch = !titleSwitch;
            pbTitle.Image = titleSwitch ? Resources.Title_2 : Resources.Title;
        }
    }
}