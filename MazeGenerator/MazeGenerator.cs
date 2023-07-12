using MazeGeneratorClass.Enums;
using MazeGeneratorClass.HelperClasses;
using MazeGeneratorClass.MazeClass;
using MazeGeneratorLib;
using static MazeGeneratorClass.HelperClasses.RandomNumberGenerator;

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
            var startPosition = new MazePosition(1, 1);
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
            for (int row = 2; row < mazeHeight; row = row + 2)
            {
                for (int column = 2; column < mazeWidth; column = column + 2)
                {
                    _maze[row, column] = RandomNumberGenerator.randomNumber;
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