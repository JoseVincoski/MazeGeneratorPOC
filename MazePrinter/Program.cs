using MazeGeneratorLib.Generators;
using MazeGeneratorLib.Generators.V2;
using MazeGeneratorLib.MazePrinter;

namespace MazePrinterLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                GenerateAndPrintMaze();

                watch.Stop();

                Console.WriteLine(watch.ElapsedMilliseconds);
                Console.ReadLine();
            }
        }

        public static void GenerateAndPrintMaze()
        {
            var generator = new MazeGenV2();

            MazeGenerator mazeGenerator = new MazeGenerator(generator, 15, 51);

            var mazePrinterBefore = new MazePrinter(mazeGenerator.Maze);
            mazePrinterBefore.PrintMazeAsInts();

            var maze = mazeGenerator.GetMaze();

            var mazePrinter = new MazePrinter(maze);


            mazePrinter.PrintMazeAsInts();
            mazePrinter.PrintMazeTiles();
        }
    }
}