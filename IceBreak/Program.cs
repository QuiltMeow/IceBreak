using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IceBreak
{
    // 貓貓最可愛了唷
    public static class Program
    {
        private const int EXIT_FAILURE = 1;

        public static MainMenu menuForm
        {
            get;
            private set;
        }

        public static GameManager game
        {
            get;
            private set;
        }

        public static RecordHandler record
        {
            get;
            private set;
        }

        public static FontHandler font
        {
            get;
            private set;
        }

        public static AboutForm about
        {
            get
            {
                if (_about == null || _about.IsDisposed)
                {
                    _about = new AboutForm();
                }
                return _about;
            }
        }

        private static AboutForm _about;

        public static bool loadRecordData()
        {
            record = new RecordHandler();
            try
            {
                record.load();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取紀錄檔案時發生例外狀況 將套用空白資料 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void loadMapData()
        {
            try
            {
                FieldHandler.loadAllMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取地圖檔案時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(EXIT_FAILURE);
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Process currentProcess = Process.GetCurrentProcess();
            string processName = currentProcess.ProcessName;
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("已偵測到其他遊戲正在執行", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            loadMapData();
            loadRecordData();
            game = new GameManager();

            font = new FontHandler();
            menuForm = new MainMenu();
            Application.Run(menuForm);
        }
    }
}