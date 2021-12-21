using Installer.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Installer
{
    public static class Program
    {
        private const int EXIT_FAILURE = 1;
        private const string INSTALL_FOLDER = "IceBreak";
        private const string MAP_FOLDER = "map";

        private const string MAIN_PROGRAM = "IceBreak.exe";
        private const string MAIN_PROGRAM_CHECKSUM = "241577AEE2962F3F8D2B49428A19E0C504A55B9A";

        private static readonly string INSTALL_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), INSTALL_FOLDER);
        private static readonly string MAIN_PROGRAM_PATH = Path.Combine(INSTALL_PATH, MAIN_PROGRAM);

        private static readonly IDictionary<string, byte[]> EXTRACT_FILE = new Dictionary<string, byte[]>
        {
            { MAP_FOLDER + "/stage_1.map", stringToByteArray(Resources.stage_1) },
            { MAP_FOLDER + "/stage_2.map", stringToByteArray(Resources.stage_2) },
            { MAP_FOLDER + "/stage_3.map", stringToByteArray(Resources.stage_3) },
            { MAP_FOLDER + "/stage_4.map", stringToByteArray(Resources.stage_4) },
            { MAP_FOLDER + "/stage_5.map", stringToByteArray(Resources.stage_5) },
            { MAP_FOLDER + "/stage_6.map", stringToByteArray(Resources.stage_6) },
            { MAP_FOLDER + "/stage_7.map", stringToByteArray(Resources.stage_7) },
            { MAP_FOLDER + "/stage_8.map", stringToByteArray(Resources.stage_8) },
            { MAP_FOLDER + "/stage_9.map", stringToByteArray(Resources.stage_9) },
            { MAIN_PROGRAM, Resources.IceBreak }
        };

        private static void fail()
        {
            Environment.Exit(EXIT_FAILURE);
        }

        public static byte[] stringToByteArray(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static string fileSHA1Checksum(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (SHA1Managed sha1 = new SHA1Managed())
                    {
                        byte[] hash = sha1.ComputeHash(bs);
                        StringBuilder format = new StringBuilder(2 * hash.Length);
                        foreach (byte data in hash)
                        {
                            format.AppendFormat("{0:X2}", data);
                        }
                        return format.ToString();
                    }
                }
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                switch (args[0].ToLowerInvariant())
                {
                    case "install":
                    case "repair":
                        {
                            install();
                            break;
                        }
                    case "uninstall":
                        {
                            uninstall();
                            MessageBox.Show("解除安裝完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                }
            }
            launch();
        }

        private static void launch()
        {
            if (!Directory.Exists(INSTALL_PATH))
            {
                install();
            }
            else
            {
                try
                {
                    string checksum = fileSHA1Checksum(MAIN_PROGRAM_PATH);
                    if (checksum != MAIN_PROGRAM_CHECKSUM)
                    {
                        MessageBox.Show("主程式已遭到修改，將進行重新解包", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        install();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("檢查校驗和時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fail();
                }
            }
            start();
        }

        private static void start()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = MAIN_PROGRAM_PATH;
                startInfo.WorkingDirectory = INSTALL_PATH;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("啟動程式時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void extract()
        {
            createFolder();
            foreach (KeyValuePair<string, byte[]> file in EXTRACT_FILE)
            {
                string path = Path.Combine(INSTALL_PATH, file.Key);
                File.WriteAllBytes(path, file.Value);
            }
        }

        private static void createFolder()
        {
            Directory.CreateDirectory(INSTALL_PATH);
            Directory.CreateDirectory(Path.Combine(INSTALL_PATH, MAP_FOLDER));
        }

        private static void install()
        {
            uninstall();
            try
            {
                extract();
            }
            catch (Exception ex)
            {
                MessageBox.Show("安裝時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fail();
            }
        }

        private static void uninstall()
        {
            try
            {
                if (File.Exists(INSTALL_PATH))
                {
                    File.Delete(INSTALL_PATH);
                }
                else if (Directory.Exists(INSTALL_PATH))
                {
                    Directory.Delete(INSTALL_PATH, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除檔案時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fail();
            }
        }
    }
}