using MazeGeneratorLib.MazeClasses;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.MazePrinter
{
    public class MazePrinter
    {
        private readonly Maze _maze;
        public MazePrinter(Maze maze)
        {
            _maze = maze;
        }

        public void PrintMazePrimitiveValues()
        {
            for (int row = 0; row < _maze.MazeHeight; row++)
            {
                if (row == 44 || row == 45) { var a = 1; }

                for (int column = 0; column < _maze.MazeWidth; column++)
                {
                    Console.Write(_maze.GetValueInPosition(row, column));
                }
                Console.WriteLine();
            }
        }

        public void PrintMazeTiles()
        {
            for (int row = 0; row < _maze.MazeHeight; row++)
            {
                if (row == 44 || row == 45) { var a = 1; }

                for (int column = 0; column < _maze.MazeWidth; column++)
                {
                    Console.Write(GetTileType(row, column));
                }
                Console.WriteLine();
            }
        }

        private string GetTileType(int y, int x)
        {
            var currentTile = _maze.GetTileTypeInPosition(y, x);
            if (currentTile == TileType.Path) return CharactersPrinter.GetTile(MazeTiles.Path);
            else if (currentTile == TileType.Start) return CharactersPrinter.GetTile(MazeTiles.Start);
            else if (currentTile == TileType.Target) return CharactersPrinter.GetTile(MazeTiles.Target);

            var tilesInfo = _maze.GetTilesAroundInfo(y, x);

            if (tilesInfo.IsAnyOutsideMaze())
            {
                var frame = CheckOutsideFrame(tilesInfo);
                if (frame != null) return frame;
            }

            var intersection = CheckIntersections(tilesInfo);
            if (intersection != null) return intersection;

            var corners = CheckCorners(tilesInfo);
            if (corners != null) return corners;

            var straightLines = CheckStraightLines(tilesInfo);
            if (straightLines != null) return straightLines;

            return CharactersPrinter.GetTile(MazeTiles.Path);
        }

        private string? CheckIntersections(TilesAroundInfo tiles)
        {
            if (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntesectionAll);
            else if (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            else if (tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            else if (tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            else if (tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            return null;
        }

        private string? CheckCorners(TilesAroundInfo tiles)
        {
            if (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SE);
            else if (tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NW);

            return null;
        }

        private string? CheckStraightLines(TilesAroundInfo tiles)
        {
            if (tiles.WTile == TileType.Wall || tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (tiles.NTile == TileType.Wall || tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }

        private string? CheckOutsideFrame(TilesAroundInfo tiles)
        {
            if (tiles.NTile == TileType.OutsideMaze && tiles.ETile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (tiles.ETile == TileType.OutsideMaze && tiles.STile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.NW);
            else if (tiles.STile == TileType.OutsideMaze && tiles.WTile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (tiles.WTile == TileType.OutsideMaze && tiles.NTile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.SE);

            else if (tiles.NTile == TileType.OutsideMaze || tiles.STile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (tiles.ETile == TileType.OutsideMaze || tiles.WTile == TileType.OutsideMaze) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }
    }
}
