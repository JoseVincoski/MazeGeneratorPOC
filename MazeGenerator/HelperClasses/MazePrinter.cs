using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorClass.Enums;
using MazeGeneratorClass.MazeClass;
using MazeGeneratorLib;

namespace MazeGeneratorClass.HelperClasses
{
    public class MazePrinter
    {
        private readonly Maze _maze;
        public MazePrinter(Maze maze)
        {
            _maze = maze;
        }

        public void PrintMaze()
        {
            for (int row = 0; row < _maze.MazeHeight; row++)
            {
                for (int column = 0; column < _maze.MazeWidth; column++)
                {
                    Console.Write(GetTileType(row, column));
                }
                Console.WriteLine();
            }
        }

        private string GetTileType(int y, int x)
        {
            var currentTile = _maze.GetPosition(x, y);
            if (currentTile == TileType.Path) return CharactersPrinter.GetTile(MazeTiles.Path);
            if (currentTile == TileType.Start) return CharactersPrinter.GetTile(MazeTiles.Start);
            if (currentTile == TileType.Target) return CharactersPrinter.GetTile(MazeTiles.Target);

            var edge = EdgeCases(y, x);
            if (edge != null) return edge;

            var NTile = _maze.GetPosition(x, y - 1);
            var ETile = _maze.GetPosition(x + 1, y);
            var STile = _maze.GetPosition(x, y + 1);
            var WTile = _maze.GetPosition(x - 1, y);

            if (NTile == TileType.Wall && ETile == TileType.Wall && STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            if (ETile == TileType.Wall && STile == TileType.Wall && WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            if (STile == TileType.Wall && WTile == TileType.Wall && NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            if (WTile == TileType.Wall && NTile == TileType.Wall && ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            if (NTile == TileType.Wall && ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NE);
            if (ETile == TileType.Wall && STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SE);
            if (STile == TileType.Wall && WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SW);
            if (WTile == TileType.Wall && NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NW);

            if (WTile == TileType.Wall && ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            if (NTile == TileType.Wall && STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return CharactersPrinter.GetTile(MazeTiles.Path);
        }

        private string? EdgeCases(int y, int x)
        {
            if ((x - 1) < 0 && (y - 1) < 0) return CharactersPrinter.GetTile(MazeTiles.SE);
            if ((x - 1) < 0 && (y + 1) >= _maze.MazeHeight) return CharactersPrinter.GetTile(MazeTiles.NE);
            if ((x + 1) >= _maze.MazeWidth && (y - 1) < 0) return CharactersPrinter.GetTile(MazeTiles.SW);
            if ((x + 1) >= _maze.MazeWidth && (y + 1) >= _maze.MazeHeight) return CharactersPrinter.GetTile(MazeTiles.NW);

            return null;
        }
    }
}
