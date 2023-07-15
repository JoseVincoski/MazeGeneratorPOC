using MazeGeneratorLib.Models;

namespace MazeGeneratorLib.Generators
{
    public static class NumberHelper
    {
        private static Random RNG = new Random((int)DateTime.Now.Ticks);

        public static int RandomWallOrPath { get { return RNG.Next(2); } }

        public static MazePosition GetRandomPathPosition(int maxHeight, int maxWidth)
        {
            var oddHeightValue = RNG.Next(maxHeight / 2) * 2 + 1;
            var oddWidthValue = RNG.Next(maxWidth / 2) * 2 + 1;

            return new MazePosition(oddHeightValue, oddWidthValue);
        }

        public static bool IsEven(int value)
        {
            return value % 2 != 0;
        }
    }
}
