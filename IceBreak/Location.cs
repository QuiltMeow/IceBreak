namespace IceBreak
{
    public class Location
    {
        public int row
        {
            get;
            private set;
        }

        public int column
        {
            get;
            private set;
        }

        public Location(Location origin)
        {
            row = origin.row;
            column = origin.column;
        }

        public Location(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}