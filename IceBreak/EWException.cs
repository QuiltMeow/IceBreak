using System;
using System.Runtime.Serialization;

namespace IceBreak
{
    [Serializable]
    public class EWException : Exception, ISerializable
    {
        private const int EW = 6987;
        private readonly int type;

        public EWException() : base("發生例外狀況")
        {
        }

        public EWException(string message) : base(message)
        {
        }

        public EWException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EWException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EWException(string message, int type) : base(message)
        {
            this.type = type;
        }

        public EWException(string message, Exception inner, int type) : base(message, inner)
        {
            this.type = type;
        }

        public EWException(SerializationInfo info, StreamingContext context, int type) : base(info, context)
        {
            this.type = type;
        }

        public int getFirstRef()
        {
            return 80923; // SX
        }

        public double getSecondRef()
        {
            return 221; // RX (As Known As DDD)
        }

        public double defaultDouble()
        {
            return 0;
        }

        public int defaultInteger()
        {
            return 0;
        }

        public string defaultString()
        {
            return "";
        }

        public int errorInteger()
        {
            return -1;
        }

        public void forceExit()
        {
            Environment.Exit(EW);
        }

        public int getEW()
        {
            return EW;
        }

        public int getExceptionType()
        {
            return type;
        }

        public object getNull()
        {
            return null;
        }
    }
}