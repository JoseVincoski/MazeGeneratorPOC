using MazeGeneratorLib.HelperClasses;
using MazeGeneratorLib.MazeClasses;

namespace MazeGeneratorLib.Generators
{
    public interface IGenerator
    {
        public void GenerateMaze(ref Maze maze) { throw new NotImplementedException();  }

        public void GeneratePoints(ref Maze maze)
        {
            maze.StartPosition = new MazePosition(1, 1);
            maze.TargetPosition = maze.StartPosition;

            while (maze.TargetPosition == maze.StartPosition)
            {
                maze.TargetPosition = NumberHelper.randomOddPosition(maze.MazeHeight, maze.MazeWidth);
            }
        }

        public void GenerateBase(ref Maze maze)
        {
            for (int row = 0; row < maze.MazeHeight; row++)
            {
                for (int column = 0; column < maze.MazeWidth; column++)
                {
                    //Generate Frame
                    if (row == 0 || column == 0) maze.MazeTiles[row, column] = true;
                    else if (row == maze.MazeHeight - 1 || column == maze.MazeWidth - 1) maze.MazeTiles[row, column] = true;

                    //Generate inside base walls
                    if (column % 2 == 0 || row % 2 == 0) maze.MazeTiles[row, column] = true;
                }
            }
        }
    }
}
