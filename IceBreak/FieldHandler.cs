using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace IceBreak
{
    public class FieldHandler
    {
        private const int IMAGE_SIZE = 40;
        private const string MAP_FOLDER = "map";

        public const int MAP_SIZE = 18; // 18 * 18
        public const int RE_ICE_CHANCE = 3;

        private static readonly IDictionary<MapObject, Bitmap> DRAW_IMAGE = new Dictionary<MapObject, Bitmap>()
        {
            { MapObject.WATER, resizeMapObjectBitmap(Properties.Resources.Water) },
            { MapObject.ICE, resizeMapObjectBitmap(Properties.Resources.Ice) },
            { MapObject.STONE, resizeMapObjectBitmap(Properties.Resources.Stone) },
            { MapObject.GOAL, resizeMapObjectBitmap(Properties.Resources.End) },
            { MapObject.PLAYER, resizeMapObjectBitmap(Properties.Resources.Player) }
        };

        public static readonly List<MapData> MAP_CACHE = new List<MapData>();

        private readonly StringBuilder record;

        public GameHandler game
        {
            get;
            private set;
        }

        public MapObject[][] mapStatus
        {
            get;
            private set;
        }

        public Location playerLocation
        {
            get;
            private set;
        }

        public int reIceRemaining
        {
            get;
            private set;
        }

        public string getRecord()
        {
            return record.ToString();
        }

        private delegate void ReIceHandler();

        private delegate Location MoveHandler();

        private readonly IDictionary<MoveOperation, ReIceHandler> reIceOperation;
        private readonly IDictionary<MoveOperation, MoveHandler> moveOperation;

        private void loadOperation()
        {
            reIceOperation.Add(MoveOperation.ICE_UP, () =>
            {
                ref MapObject target = ref mapStatus[playerLocation.row - 1][playerLocation.column];
                if (playerLocation.row <= 0 || target != MapObject.WATER)
                {
                    return;
                }
                target = MapObject.ICE;
            });

            reIceOperation.Add(MoveOperation.ICE_RIGHT, () =>
            {
                ref MapObject target = ref mapStatus[playerLocation.row][playerLocation.column + 1];
                if (playerLocation.column >= MAP_SIZE - 1 || target != MapObject.WATER)
                {
                    return;
                }
                target = MapObject.ICE;
            });

            reIceOperation.Add(MoveOperation.ICE_DOWN, () =>
            {
                ref MapObject target = ref mapStatus[playerLocation.row + 1][playerLocation.column];
                if (playerLocation.row >= MAP_SIZE - 1 || target != MapObject.WATER)
                {
                    return;
                }
                target = MapObject.ICE;
            });

            reIceOperation.Add(MoveOperation.ICE_LEFT, () =>
            {
                ref MapObject target = ref mapStatus[playerLocation.row][playerLocation.column - 1];
                if (playerLocation.column <= 0 || target != MapObject.WATER)
                {
                    return;
                }
                target = MapObject.ICE;
            });

            moveOperation.Add(MoveOperation.UP, () =>
            {
                if (playerLocation.row <= 0)
                {
                    return null;
                }
                return new Location(playerLocation.row - 1, playerLocation.column);
            });

            moveOperation.Add(MoveOperation.RIGHT, () =>
            {
                if (playerLocation.column >= MAP_SIZE - 1)
                {
                    return null;
                }
                return new Location(playerLocation.row, playerLocation.column + 1);
            });

            moveOperation.Add(MoveOperation.DOWN, () =>
            {
                if (playerLocation.row >= MAP_SIZE - 1)
                {
                    return null;
                }
                return new Location(playerLocation.row + 1, playerLocation.column);
            });

            moveOperation.Add(MoveOperation.LEFT, () =>
            {
                if (playerLocation.column <= 0)
                {
                    return null;
                }
                return new Location(playerLocation.row, playerLocation.column - 1);
            });
        }

        public bool reIce(MoveOperation direction)
        {
            if (reIceRemaining <= 0)
            {
                return false;
            }
            if (!reIceOperation.ContainsKey(direction))
            {
                throw new EWException("未知的方位");
            }
            reIceOperation[direction].Invoke();
            record.Append(direction.symbol);
            --reIceRemaining;
            return true;
        }

        private void updateMoveGameStatus(Location from, Location to)
        {
            mapStatus[from.row][from.column] = MapObject.WATER;
            MapObject target = mapStatus[to.row][to.column];
            switch (target)
            {
                case MapObject.WATER:
                    {
                        game.gameOver(false);
                        break;
                    }
                case MapObject.GOAL:
                    {
                        game.gameOver(true);
                        break;
                    }
            }
        }

        private bool canMove(Location location)
        {
            if (location == null)
            {
                return false;
            }
            return mapStatus[location.row][location.column] != MapObject.STONE;
        }

        public bool movePlayer(MoveOperation direction)
        {
            if (!moveOperation.ContainsKey(direction))
            {
                throw new EWException("未知的方位");
            }
            Location from = playerLocation;
            Location to = moveOperation[direction].Invoke();
            if (!canMove(to))
            {
                return false;
            }
            playerLocation = to;
            record.Append(direction.symbol);
            updateMoveGameStatus(from, playerLocation);
            return true;
        }

        public bool playerOperation(MoveOperation operation)
        {
            if (moveOperation.ContainsKey(operation))
            {
                return movePlayer(operation);
            }
            return reIce(operation);
        }

        private FieldHandler()
        {
            reIceOperation = new Dictionary<MoveOperation, ReIceHandler>();
            moveOperation = new Dictionary<MoveOperation, MoveHandler>();
            loadOperation();
        }

        public FieldHandler(GameHandler game) : this()
        {
            this.game = game;
            record = new StringBuilder();
            reIceRemaining = RE_ICE_CHANCE;

            MapData data = getStage(game.stage);
            mapStatus = data.map;
            playerLocation = data.playerLocation;
        }

        public static Bitmap resizeMapObjectBitmap(Bitmap origin)
        {
            return Util.resizeBitmap(origin, IMAGE_SIZE, IMAGE_SIZE);
        }

        public static int getFirstStage()
        {
            if (MAP_CACHE.Count <= 0)
            {
                throw new EWException("找不到任何地圖");
            }
            return MAP_CACHE[0].stage;
        }

        public static int getNextStage(int stage)
        {
            int index = indexOfStage(stage);
            int next = index + 1;
            if (index == -1 || next >= MAP_CACHE.Count)
            {
                throw new EWException("找不到下一關");
            }
            return MAP_CACHE[next].stage;
        }

        public static int indexOfStage(int stage)
        {
            for (int i = 0; i < MAP_CACHE.Count; ++i)
            {
                if (MAP_CACHE[i].stage == stage)
                {
                    return i;
                }
            }
            return -1;
        }

        public void drawField(Graphics graphic, int blank = 10)
        {
            int offset = IMAGE_SIZE + blank;
            int counterY = 10;
            for (int i = 0; i < MAP_SIZE; ++i)
            {
                int counterX = 10;
                for (int j = 0; j < MAP_SIZE; ++j)
                {
                    MapObject current = mapStatus[i][j];
                    Point point = new Point(counterX, counterY);
                    graphic.DrawImage(DRAW_IMAGE[current], point);
                    if (playerLocation.row == i && playerLocation.column == j)
                    {
                        graphic.DrawImage(DRAW_IMAGE[MapObject.PLAYER], point);
                    }
                    counterX += offset;
                }
                counterY += offset;
            }
        }

        public static int getStageFromPath(string path)
        {
            string[] split = path.Replace("\\", "/").Split('/');
            string fileName = split[split.Length - 1];
            return int.Parse(fileName.Split('.')[0].Substring(6));
        }

        public static void loadAllMap()
        {
            if (!Directory.Exists(MAP_FOLDER))
            {
                throw new EWException("地圖檔案資料夾不存在");
            }

            string[] mapDataPath = Directory.GetFiles(MAP_FOLDER, "stage_*.map");
            if (mapDataPath.Length <= 0)
            {
                throw new EWException("地圖檔案不存在");
            }

            MAP_CACHE.Clear();
            foreach (string path in mapDataPath)
            {
                MAP_CACHE.Add(loadMap(path));
            }
            MAP_CACHE.Sort();
        }

        public static MapData getStage(int stage)
        {
            foreach (MapData data in MAP_CACHE)
            {
                if (data.stage == stage)
                {
                    return new MapData(data);
                }
            }
            return null;
        }

        public bool isGameOver()
        {
            MapObject current = mapStatus[playerLocation.row][playerLocation.column];
            switch (current)
            {
                case MapObject.WATER:
                case MapObject.GOAL:
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public static MapData loadMap(string path)
        {
            int stage = getStageFromPath(path);
            MapObject[][] map = new MapObject[MAP_SIZE][];
            Location playerLocation = null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int current = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        map[current] = new MapObject[MAP_SIZE];
                        if (line.Length != MAP_SIZE)
                        {
                            throw new EWException("無效的地圖列數");
                        }

                        for (int i = 0; i < MAP_SIZE; ++i)
                        {
                            int read = line[i] - '0';
                            if (read < (int)MapObject.WATER || read > (int)MapObject.PLAYER)
                            {
                                throw new EWException("無效的地圖物件");
                            }

                            MapObject data = (MapObject)read;
                            if (data == MapObject.PLAYER)
                            {
                                if (playerLocation != null)
                                {
                                    throw new EWException("重複的玩家物件");
                                }
                                playerLocation = new Location(current, i);
                                data = MapObject.ICE;
                            }
                            map[current][i] = data;
                        }
                        ++current;
                    }
                    if (current != MAP_SIZE)
                    {
                        throw new EWException("無效的地圖行數");
                    }
                }
            }
            if (playerLocation == null)
            {
                throw new EWException("找不到玩家預設點");
            }
            return new MapData(stage, map, playerLocation);
        }
    }
}