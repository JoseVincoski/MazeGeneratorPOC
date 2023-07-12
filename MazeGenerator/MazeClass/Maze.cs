using MazeGeneratorClass.Enums;
using MazeGeneratorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorClass.MazeClass
{
    public class Maze
    {
        public int[,] MazeTiles { get; set; }
        public MazePosition StartPosition { get; set; }
        public MazePosition TargetPosition { get; set; }
        public int MazeHeight { get; set; }
        public int MazeWidth { get; set; }

        public TileType GetPosition(int y, int x)
        {
            if (x < 0 || x >= MazeHeight || y < 0 || y >= MazeWidth) return TileType.Path;

            var mazePosition = new MazePosition(x, y);

            if (mazePosition.X == StartPosition.X && mazePosition.Y == StartPosition.Y) return TileType.Start;
            else if (mazePosition.X == TargetPosition.X && mazePosition.Y == TargetPosition.Y) return TileType.Target;
            else if (MazeTiles[x, y] == GlobalVariables.WallTrue) return TileType.Wall;
            else return TileType.Path;
        }

        public Maze(int[,] _mazeTiles, MazePosition _startPosition, MazePosition _targetPosition)
        {
            MazeTiles = _mazeTiles;
            MazeHeight = _mazeTiles.GetLength(0);
            MazeWidth = _mazeTiles.GetLength(1);

            StartPosition = _startPosition;
            TargetPosition = _targetPosition;
        }
    }
}
