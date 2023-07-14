﻿using MazeGeneratorLib.HelperClasses;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.MazeClasses
{
    public class Maze
    {
        public bool[,] MazeTiles { get; set; }
        public MazePosition StartPosition { get; set; }
        public MazePosition TargetPosition { get; set; }

        public int MazeHeight { get; set; }
        public int MazeWidth { get; set; }

        public TileType GetTileTypeInPosition(int y, int x)
        {
            if (x < 0 || x >= MazeWidth || y < 0 || y >= MazeHeight) return TileType.OutsideMaze;

            var mazePosition = new MazePosition(y, x);

            if (mazePosition.X == StartPosition.X && mazePosition.Y == StartPosition.Y) return TileType.Start;
            else if (mazePosition.X == TargetPosition.X && mazePosition.Y == TargetPosition.Y) return TileType.Target;
            else if (GetValueInPosition(y, x)) return TileType.Wall;
            else return TileType.Path;
        }

        public bool GetValueInPosition(int y, int x)
        {
            if (y >= MazeHeight || x >= MazeWidth) return true;

            return MazeTiles[y, x];
        }

        public TilesAround<TileType> GetTilesAroundType(int y, int x)
        {
            return new TilesAround<TileType>()
            {
                NTile = GetTileTypeInPosition(y - 1, x),
                ETile = GetTileTypeInPosition(y, x + 1),
                STile = GetTileTypeInPosition(y + 1, x),
                WTile = GetTileTypeInPosition(y, x - 1),
            };
        }

        public TilesAround<bool> GetTilesAround(int y, int x)
        {
            return new TilesAround<bool>()
            {
                NTile = GetValueInPosition(y - 1, x),
                ETile = GetValueInPosition(y, x + 1),
                STile = GetValueInPosition(y + 1, x),
                WTile = GetValueInPosition(y, x - 1),
            };
        }

        public Maze(int _mazeHeight, int _mazeWidth)
        {
            MazeHeight = _mazeHeight * 3;
            MazeWidth = _mazeWidth * 3;

            MazeTiles = new bool[MazeHeight, MazeWidth];


        }
    }
}
