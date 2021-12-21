using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IceBreak
{
    public class RecordHandler
    {
        private const string RECORD_FILE = "record.ew";
        public const int MAX_NAME_LENGTH = 10;

        public string currentPlayerName
        {
            get;
            set;
        }

        public int selectStage
        {
            get;
            set;
        }

        public ISet<string> playerNameSet
        {
            get;
            private set;
        }

        public List<StageRecord> scoreBoard
        {
            get;
            private set;
        }

        public RecordHandler()
        {
            currentPlayerName = string.Empty;
            selectStage = FieldHandler.getFirstStage();

            playerNameSet = new SortedSet<string>();
            scoreBoard = new List<StageRecord>();
        }

        public void sortAll()
        {
            scoreBoard.Sort();
            foreach (StageRecord record in scoreBoard)
            {
                record.rankPlayer();
            }
        }

        public static StageRecord getStageRecord(IList<StageRecord> recordList, int stage)
        {
            foreach (StageRecord record in recordList)
            {
                if (record.stage == stage)
                {
                    return record;
                }
            }
            return null;
        }

        public StageRecord getStageRecord(int stage)
        {
            return getStageRecord(scoreBoard, stage);
        }

        public bool addPlayer(int stage, RecordData data)
        {
            StageRecord record = getStageRecord(stage);
            if (record == null)
            {
                record = new StageRecord(stage);
                scoreBoard.Add(record);
            }
            if (!record.canAdd(data))
            {
                return false;
            }
            record.rank.Add(data);
            sortAll();
            save();
            return true;
        }

        public static string cleanPlayerName(string name)
        {
            name = name.Trim();
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_NAME_LENGTH)
            {
                return null;
            }
            return name;
        }

        public void load()
        {
            if (!File.Exists(RECORD_FILE))
            {
                return;
            }
            using (FileStream fs = new FileStream(RECORD_FILE, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // 讀取階段
                    string readCurrentName = cleanPlayerName(br.ReadString()); // usr/currentID
                    if (readCurrentName == null)
                    {
                        throw new EWException("玩家資訊錯誤 : 目前名稱");
                    }

                    int readSelectStage = br.ReadInt32(); // temp/tmpMapID
                    if (FieldHandler.getStage(readSelectStage) == null)
                    {
                        throw new EWException("關卡資訊錯誤");
                    }

                    ISet<string> readPlayerNameSet = new SortedSet<string>(); // ID
                    int readNameSize = br.ReadInt32();
                    if (readNameSize < 0)
                    {
                        throw new EWException("玩家資訊錯誤 : 項目數");
                    }
                    for (int i = 1; i <= readNameSize; ++i)
                    {
                        string readPlayerName = cleanPlayerName(br.ReadString());
                        if (readPlayerName == null || readPlayerNameSet.Contains(readPlayerName))
                        {
                            throw new EWException("玩家資訊錯誤 : 儲存名稱");
                        }
                        readPlayerNameSet.Add(readPlayerName);
                    }

                    List<StageRecord> readRecordList = new List<StageRecord>(); // rank/stage
                    while (fs.Position != fs.Length)
                    {
                        int readRecordStage = br.ReadInt32();
                        if (FieldHandler.getStage(readRecordStage) == null)
                        {
                            throw new EWException("記分板關卡錯誤");
                        }

                        if (getStageRecord(readRecordList, readRecordStage) != null)
                        {
                            throw new EWException("記分板資訊錯誤");
                        }
                        StageRecord stageRecord = new StageRecord(readRecordStage);

                        int readRecordCount = br.ReadInt32();
                        if (readRecordCount <= 0 || readRecordCount > StageRecord.MAX_RECORD_COUNT) // 不應存在無紀錄記分板
                        {
                            throw new EWException("記分板項目錯誤");
                        }
                        for (int i = 1; i <= readRecordCount; ++i)
                        {
                            string readRecordName = cleanPlayerName(br.ReadString());
                            if (readRecordName == null)
                            {
                                throw new EWException("記分板玩家名稱錯誤");
                            }

                            int readRecordScore = br.ReadInt32();
                            if (readRecordScore < 0 || readRecordScore > GameManager.maxScore)
                            {
                                throw new EWException("記分板分數錯誤");
                            }

                            int readRecordTime = br.ReadInt32();
                            if (readRecordTime < 0)
                            {
                                throw new EWException("記分板時間錯誤");
                            }

                            string readRecordLog = br.ReadString();
                            if (!RecordData.isRecordLegal(readRecordLog))
                            {
                                throw new EWException("記分板移動記錄錯誤");
                            }
                            RecordData data = new RecordData(readRecordName, readRecordScore, readRecordTime, readRecordLog);
                            stageRecord.rank.Add(data);
                        }
                        readRecordList.Add(stageRecord);
                    }

                    // 填入階段
                    currentPlayerName = readCurrentName;
                    playerNameSet = readPlayerNameSet;

                    selectStage = readSelectStage;
                    scoreBoard = readRecordList;
                    sortAll();
                }
            }
        }

        public void save()
        {
            try
            {
                using (FileStream fs = new FileStream(RECORD_FILE, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(currentPlayerName);
                        bw.Write(selectStage);

                        bw.Write(playerNameSet.Count);
                        foreach (string playerName in playerNameSet)
                        {
                            bw.Write(playerName);
                        }

                        foreach (StageRecord score in scoreBoard)
                        {
                            bw.Write(score.stage);
                            bw.Write(score.rank.Count);
                            foreach (RecordData record in score.rank)
                            {
                                bw.Write(record.name);
                                bw.Write(record.score);
                                bw.Write(record.time);
                                bw.Write(record.record);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("紀錄檔案儲存失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}