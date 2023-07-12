using MazeGeneratorClass;
using MazeGeneratorClass.HelperClasses;

namespace MazePrinterLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MazeGenerator mazeGenerator = new MazeGenerator(5, 5);
            var maze = mazeGenerator.GetMaze();

            var mazePrinter = new MazePrinter(maze);

            mazePrinter.PrintMaze();
        }
    }
}