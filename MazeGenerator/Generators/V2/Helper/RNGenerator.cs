namespace MazeGeneratorLib.Generators.V2.Helper
{
    public static class RNGenerator
    {
        private static Random RNG = new Random((int)DateTime.Now.Ticks);

        public static int GetRandomIntLowerThan(int value)
        {
            return RNG.Next(1, value);
        }

        public static int GetRandomDecreasingDirection(ref List<int> exclude)
        {
            int index = RNG.Next(0, exclude.Count);

            var numberToReturn = exclude.ElementAt(index);
            exclude.RemoveAt(index);

            return numberToReturn;
        }
    }
}
