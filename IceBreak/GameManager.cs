using System;

namespace IceBreak
{
    public class GameManager : GameHandler
    {
        private const int REMAINING_RE_ICE_ADD_SCORE = 50;
        private const int FINISH_ADD_SCORE = 500;

        public FieldHandler field
        {
            get;
            private set;
        }

        public GameStatus status
        {
            get;
            private set;
        }

        public int time
        {
            get;
            private set;
        }

        public int stage
        {
            get;
            private set;
        }

        public int score
        {
            get;
            private set;
        }

        public bool finish
        {
            get;
            private set;
        }

        public GameForm form
        {
            get;
            set;
        }

        public void timerCount()
        {
            ++time;
        }

        public void addScore(int add)
        {
            score += add;
        }

        public GameManager()
        {
            cleanUp();
        }

        private void cleanUp()
        {
            status = GameStatus.GAME_OVER;
            time = score = 0;
            finish = false;
        }

        public void togglePause()
        {
            if (status == GameStatus.GAME_OVER)
            {
                return;
            }
            status = status == GameStatus.PLAYING ? GameStatus.PAUSE : GameStatus.PLAYING;
        }

        public void newGame(int stage)
        {
            cleanUp();
            this.stage = stage;
            field = new FieldHandler(this);
            status = GameStatus.PLAYING;
        }

        public void playAgain()
        {
            newGame(stage);
        }

        public bool nextLevel()
        {
            try
            {
                int next = FieldHandler.getNextStage(stage);
                newGame(next);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void gameOver(bool finish)
        {
            status = GameStatus.GAME_OVER;
            this.finish = finish;
            if (finish)
            {
                score += field.reIceRemaining * REMAINING_RE_ICE_ADD_SCORE + FINISH_ADD_SCORE;
            }
            form.timerGameOver.Start();
        }

        public static int maxScore
        {
            get
            {
                return (int)Math.Pow(FieldHandler.MAP_SIZE, 2) - 1 + REMAINING_RE_ICE_ADD_SCORE * FieldHandler.RE_ICE_CHANCE + FINISH_ADD_SCORE;
            }
        }
    }
}