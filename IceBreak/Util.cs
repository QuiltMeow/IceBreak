using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IceBreak
{
    public class Util
    {
        public static T[][] clone2DArray<T>(T[][] array)
        {
            T[][] ret = new T[array.Length][];
            for (int i = 0; i < array.Length; ++i)
            {
                ret[i] = new T[array[i].Length];
                for (int j = 0; j < array[i].Length; ++j)
                {
                    ret[i][j] = array[i][j];
                }
            }
            return ret;
        }

        private static string padTime(int input)
        {
            string ret = input.ToString();
            if (input < 10)
            {
                ret = "0" + ret;
            }
            return ret;
        }

        public static string makeTimeReadable(int time)
        {
            int hour = time / 3600;
            if (hour > 99)
            {
                string maxTime = "99 : 59 : 59";
                return maxTime;
            }

            int minute = (time - hour * 3600) / 60;
            time = time - (hour * 3600 + minute * 60);
            return padTime(hour) + " : " + padTime(minute) + " : " + padTime(time);
        }

        public static string getGameOverMessage(bool finish)
        {
            return finish ? "恭喜過關" : "你掉進水裡了";
        }

        public static Bitmap transparentBitmap(PictureBox target)
        {
            Bitmap bmp = new Bitmap(target.Width, target.Height);
            bmp.MakeTransparent();
            return bmp;
        }

        public static void drawGameField(PictureBox target, GameHandler game)
        {
            Bitmap bmp = transparentBitmap(target);
            using (Graphics graphic = Graphics.FromImage(bmp))
            {
                game.field.drawField(graphic);
            }
            target.Image = bmp;
        }

        public static Bitmap resizeBitmap(Bitmap origin, int width, int height)
        {
            Bitmap ret = new Bitmap(width, height);
            ret.MakeTransparent();

            using (Graphics graphic = Graphics.FromImage(ret))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.DrawImage(origin, new Rectangle(0, 0, width, height), new Rectangle(0, 0, origin.Width, origin.Height), GraphicsUnit.Pixel);
            }
            return ret;
        }

        public static string getGameStatusName(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.PLAYING:
                    {
                        return "遊戲進行中";
                    }
                case GameStatus.PAUSE:
                    {
                        return "遊戲暫停";
                    }
                case GameStatus.GAME_OVER:
                    {
                        return "遊戲結束";
                    }
            }
            throw new EWException("無效的遊戲狀態");
        }
    }
}