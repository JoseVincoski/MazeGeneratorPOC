using MazeGeneratorClass.Enums;
using MazeGeneratorClass.HelperClasses;
using MazeGeneratorClass.MazeClass;
using MazeGeneratorLib;
using static MazeGeneratorClass.HelperClasses.NumberHelper;

namespace MazeGeneratorClass
{
    public class MazeGenerator
    {
        private readonly int mazeHeight;
        private readonly int mazeWidth;

        private int[,] _maze;

        public MazeGenerator(int _mazeHeight, int _mazeWidth)
        {
            mazeHeight = _mazeHeight * 3;
            mazeWidth = _mazeWidth * 3;

            _maze = new int[mazeHeight, mazeWidth];

            GenerateBase();
        }

        public Maze GetMaze()
        {
            var startPosition = new MazePosition(1,1);
            var targetPosition = startPosition;

            while (targetPosition.X == startPosition.X && targetPosition.Y == startPosition.Y)
            {
                targetPosition = randomOddPosition(mazeHeight, mazeWidth);
            }

            GenerateMaze();

            return new Maze(_maze, startPosition, targetPosition);
        }

        private void GenerateMaze()
        {
            for (int row = 1; row < mazeHeight - 1; row += 1)
            {
                bool rowIsEven = IsEven(row);
                for (int column = 1; column < mazeWidth - 1; column += 1)
                {
                    bool columnIsEven = IsEven(column);

                    //Both odd -> always wall
                    //Both even -> always path
                    if (rowIsEven == columnIsEven) { continue; }

                    //Row even | Column odd -> Vertical Path
                    //Row odd | Column even -> Horizontal Path
                    _maze[row, column] = NumberHelper.randomNumber;
                }
            }
        }

        private void GenerateBase()
        {
            for (int row = 0; row < mazeHeight; row++)
            {
                for (int column = 0; column < mazeWidth; column++)
                {
                    //Generate Frame
                    if (row == 0 || column == 0) _maze[row, column] = GlobalVariables.WallTrue;
                    else if (row == mazeHeight - 1 || column == mazeWidth - 1) _maze[row, column] = GlobalVariables.WallTrue;

                    //Generate inside base walls
                    if (column % 2 == 0 || row % 2 == 0) _maze[row, column] = GlobalVariables.WallTrue;
                }
            }
        }
    }
}