using MazeGeneratorLib.MazeClasses;

namespace MazeGeneratorLib.HelperClasses
{
    public static class NumberHelper
    {
        private static Random RNG = new Random((int)DateTime.Now.Ticks);
        private static readonly int MaxTileTypeValue = 2;

        public static int randomNumber { get { return RNG.Next(MaxTileTypeValue); } }

        public static MazePosition randomOddPosition(int maxHeight, int maxWidth)
        {
            var oddHeightValue = RNG.Next(maxHeight / 2) * 2 + 1;
            var oddWidthValue = RNG.Next(maxWidth / 2) * 2 + 1;

            return new MazePosition(oddHeightValue, oddWidthValue);
        }

        public static bool IsOdd(int value)
        {
            return value % 2 == 0;
        }

        public static bool IsEven(int value)
        {
            return value % 2 != 0;
        }
    }
}
