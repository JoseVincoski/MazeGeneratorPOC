using MazeGeneratorLib.Models;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.Generators
{
    public interface IGenerator
    {
        public void GenerateMaze(ref Maze maze) { throw new NotImplementedException();  }

        public void GeneratePoints(ref Maze maze)
        {
            maze.StartPosition = new MazePosition(1, 1);
            maze.TargetPosition = maze.StartPosition;

            while (maze.TargetPosition.IsEqual(maze.StartPosition))
            {
                maze.TargetPosition = NumberHelper.GetRandomPathPosition(maze.Height, maze.Width);
            }
        }

        public void GenerateBase(ref Maze maze)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                for (int column = 0; column < maze.Width; column++)
                {
                    //Generate Frame
                    if (row == 0 || column == 0) maze.Tiles[row, column] = (int)TileType.SolidWall;
                    else if (row == maze.Height - 1 || column == maze.Width - 1) maze.Tiles[row, column] = (int)TileType.SolidWall;
                    //Generate inside base walls
                    else if (column % 2 == 0 || row % 2 == 0) maze.Tiles[row, column] = (int)TileType.MovableWall;
                }
            }
        }
    }
}
