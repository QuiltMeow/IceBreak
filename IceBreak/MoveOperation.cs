using System.Windows.Forms;

namespace IceBreak
{
    public class MoveOperation
    {
        public static readonly MoveOperation UP;
        public static readonly MoveOperation RIGHT;
        public static readonly MoveOperation DOWN;
        public static readonly MoveOperation LEFT;

        public static readonly MoveOperation ICE_UP;
        public static readonly MoveOperation ICE_RIGHT;
        public static readonly MoveOperation ICE_DOWN;
        public static readonly MoveOperation ICE_LEFT;

        public static readonly MoveOperation[] allOperation;

        public int index
        {
            get;
            private set;
        }

        public char symbol
        {
            get;
            private set;
        }

        public Keys key
        {
            get;
            private set;
        }

        public static MoveOperation getByKey(Keys key)
        {
            foreach (MoveOperation operation in allOperation)
            {
                if (operation.key == key)
                {
                    return operation;
                }
            }
            return null;
        }

        public static MoveOperation getBySymbol(char symbol)
        {
            foreach (MoveOperation operation in allOperation)
            {
                if (operation.symbol == symbol)
                {
                    return operation;
                }
            }
            return null;
        }

        static MoveOperation()
        {
            int index = 0;
            UP = new MoveOperation(index++, 'N', Keys.Up);
            RIGHT = new MoveOperation(index++, 'E', Keys.Right);
            DOWN = new MoveOperation(index++, 'S', Keys.Down);
            LEFT = new MoveOperation(index++, 'W', Keys.Left);

            ICE_UP = new MoveOperation(index++, '8', Keys.W);
            ICE_RIGHT = new MoveOperation(index++, '6', Keys.D);
            ICE_DOWN = new MoveOperation(index++, '2', Keys.S);
            ICE_LEFT = new MoveOperation(index, '4', Keys.A);

            allOperation = new MoveOperation[]
            {
                UP, RIGHT, DOWN, LEFT,
                ICE_UP, ICE_RIGHT, ICE_DOWN, ICE_LEFT
            };
        }

        private MoveOperation(int index, char symbol, Keys key)
        {
            this.index = index;
            this.symbol = symbol;
            this.key = key;
        }
    }
}