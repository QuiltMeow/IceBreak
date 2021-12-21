namespace IceBreak
{
    public interface GameHandler
    {
        int stage
        {
            get;
        }

        FieldHandler field
        {
            get;
        }

        void gameOver(bool finish);
    }
}