using MazeGeneratorClass.Enums;
using MazeGeneratorClass.HelperClasses;
using MazeGeneratorLib;
using MazeGeneratorLib.MazeClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MazeGeneratorClass.MazeClass
{
    public class Maze
    {
        public int[,] MazeTiles { get; set; }
        public MazePosition StartPosition { get; set; }
        public MazePosition TargetPosition { get; set; }
        public int MazeHeight { get; set; }
        public int MazeWidth { get; set; }

        public TileType GetTileTypeInPosition(int y, int x)
        {
            if (x < 0 || x >= MazeHeight || y < 0 || y >= MazeWidth) return TileType.OutsideMaze;

            var mazePosition = new MazePosition(y, x);

            if (mazePosition.X == StartPosition.X && mazePosition.Y == StartPosition.Y) return TileType.Start;
            else if (mazePosition.X == TargetPosition.X && mazePosition.Y == TargetPosition.Y) return TileType.Target;
            else if (GetValueInPosition(y, x) == GlobalVariables.WallTrue) return TileType.Wall;
            else return TileType.Path;
        }

        public int GetValueInPosition(int y, int x)
        {
            return MazeTiles[y, x];
        }

        public TilesAroundInfo GetTilesAroundInfo(int y, int x)
        {
            return new TilesAroundInfo()
            {
                NTile = GetTileTypeInPosition(y - 1, x),
                ETile = GetTileTypeInPosition(y, x + 1),
                STile = GetTileTypeInPosition(y + 1, x),
                WTile = GetTileTypeInPosition(y, x - 1),
            };
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
