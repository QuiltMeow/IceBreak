using System;
using System.Collections.Generic;

namespace IceBreak
{
    public class StageRecord : IComparable<StageRecord>
    {
        public const int MAX_RECORD_COUNT = 10;

        public int stage
        {
            get;
            private set;
        }

        public List<RecordData> rank
        {
            get;
            private set;
        }

        public StageRecord(int stage)
        {
            this.stage = stage;
            rank = new List<RecordData>();
        }

        public bool canAdd(RecordData data)
        {
            if (rank.Count < MAX_RECORD_COUNT)
            {
                return true;
            }

            RecordData last = rank[rank.Count - 1];
            if (data.score > last.score)
            {
                return true;
            }
            else if (data.score == last.score)
            {
                if (data.time < last.time)
                {
                    return true;
                }
                else if (data.time == last.time)
                {
                    return data.record.Length < last.record.Length;
                }
            }
            return false;
        }

        public void rankPlayer()
        {
            rank.Sort();
            if (rank.Count > MAX_RECORD_COUNT)
            {
                rank.RemoveRange(MAX_RECORD_COUNT, rank.Count - MAX_RECORD_COUNT);
            }
        }

        public int CompareTo(StageRecord another)
        {
            return stage.CompareTo(another.stage);
        }
    }
}