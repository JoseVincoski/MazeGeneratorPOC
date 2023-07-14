using MazeGeneratorLib.Generators;
using MazeGeneratorLib.MazePrinter;

namespace MazePrinterLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var generator = new RandomGen();

                MazeGenerator mazeGenerator = new MazeGenerator(generator, 15, 51);
                var maze = mazeGenerator.GetMaze();

                var mazePrinter = new MazePrinter(maze);

                mazePrinter.PrintMazeTiles();

                Console.ReadLine();
            }
        }
    }
}