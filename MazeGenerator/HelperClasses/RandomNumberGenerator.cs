using MazeGeneratorClass.MazeClass;

namespace MazeGeneratorClass.HelperClasses
{
    public static class RandomNumberGenerator
    {
        private static Random RNG = new Random();
        private static readonly int MaxTileTypeValue = 2;

        public static int randomNumber { get { return RNG.Next(2); } }

        public static MazePosition randomOddPosition(int maxHeight, int maxWidth)
        {
            var oddHeightValue = RNG.Next(maxHeight / 2) * 2 + 1;
            var oddWidthValue = RNG.Next(maxWidth / 2) * 2 + 1;

            return new MazePosition(oddHeightValue, oddWidthValue);
        }
    }
}
