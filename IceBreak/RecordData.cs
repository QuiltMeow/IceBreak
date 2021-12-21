using System;

namespace IceBreak
{
    public class RecordData : IComparable<RecordData>
    {
        public string name
        {
            get;
            private set;
        }

        public int score
        {
            get;
            private set;
        }

        public int time
        {
            get;
            private set;
        }

        public string record
        {
            get;
            private set;
        }

        public RecordData(string name, int score, int time, string record)
        {
            this.name = name;
            this.score = score;
            this.time = time;
            this.record = record;
        }

        public static bool isRecordLegal(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
            {
                return false;
            }
            foreach (char log in record)
            {
                if (MoveOperation.getBySymbol(log) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public int CompareTo(RecordData another)
        {
            int ret = another.score.CompareTo(score);
            if (ret != 0)
            {
                return ret;
            }

            ret = time.CompareTo(another.time);
            if (ret != 0)
            {
                return ret;
            }

            ret = record.Length.CompareTo(another.record.Length);
            if (ret != 0)
            {
                return ret;
            }
            return name.CompareTo(another.name);
        }
    }
}