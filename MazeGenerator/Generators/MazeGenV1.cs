using MazeGeneratorLib.HelperClasses;
using MazeGeneratorLib.MazeClasses;

namespace MazeGeneratorLib.Generators
{
    public class MazeGenV1 : IGenerator
    {
        public void GenerateMaze(ref Maze maze)
        {
            for (int row = 1; row < maze.MazeHeight - 1; row++)
            {
                bool rowIsEven = NumberHelper.IsEven(row);
                for (int column = 1; column < maze.MazeWidth - 1; column++)
                {
                    bool columnIsEven = NumberHelper.IsEven(column);

                    //Both odd -> always wall
                    //Both even -> always path
                    if (rowIsEven == columnIsEven) continue;

                    //Row even | Column odd -> Vertical Path
                    //Row odd | Column even -> Horizontal Path
                    maze.MazeTiles[row, column] = NumberHelper.RandomWallOrPath;
                }
            }
        }
    }

    //This generator is completelly random. It not necessarelly generates a path between the start and the target
}
