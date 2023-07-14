using MazeGeneratorLib.HelperClasses;
using MazeGeneratorLib.MazeClasses;

namespace MazeGeneratorLib.Generators
{
    //Completely random
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
                    if (rowIsEven == columnIsEven) { continue; }

                    //Row even | Column odd -> Vertical Path
                    //Row odd | Column even -> Horizontal Path
                    maze.MazeTiles[row, column] = NumberHelper.randomNumber;
                }
            }
        }
    }
}
