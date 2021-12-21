using System;

namespace IceBreak
{
    public class MapData : IComparable<MapData>
    {
        public int stage
        {
            get;
            private set;
        }

        public MapObject[][] map
        {
            get;
            private set;
        }

        public Location playerLocation
        {
            get;
            private set;
        }

        public MapData(MapData origin)
        {
            stage = origin.stage;
            map = Util.clone2DArray(origin.map);
            playerLocation = new Location(origin.playerLocation);
        }

        public MapData(int stage, MapObject[][] map, Location playerLocation)
        {
            this.stage = stage;
            this.map = map;
            this.playerLocation = playerLocation;
        }

        public int CompareTo(MapData another)
        {
            return stage.CompareTo(another.stage);
        }
    }
}