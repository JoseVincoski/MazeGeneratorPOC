using MazeGeneratorLib.HelperClasses;
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

        public void PrintMazeAsInts()
        {
            for (int row = 0; row < _maze.Height; row++)
            {
                for (int column = 0; column < _maze.Width; column++)
                {
                    Console.Write(_maze.Tiles[row,column]);
                }
                Console.WriteLine();
            }
        }

        public void PrintMazeTiles()
        {
            for (int row = 0; row < _maze.Height; row++)
            {
                for (int column = 0; column < _maze.Width; column++)
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

            var tilesInfo = _maze.GetTilesAroundType(y, x);

            if (TileTypeChecker.IsAnyOutsideMaze(tilesInfo))
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

        private string? CheckIntersections(TilesAround<TileType> tiles)
        {
            if      (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntesectionAll);
            else if (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            else if (tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            else if (tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            else if (tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            return null;
        }

        private string? CheckCorners(TilesAround<TileType> tiles)
        {
            if      (tiles.NTile == TileType.Wall && tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (tiles.ETile == TileType.Wall && tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SE);
            else if (tiles.STile == TileType.Wall && tiles.WTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (tiles.WTile == TileType.Wall && tiles.NTile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.NW);

            return null;
        }

        private string? CheckStraightLines(TilesAround<TileType> tiles)
        {
            if      (tiles.WTile == TileType.Wall || tiles.ETile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (tiles.NTile == TileType.Wall || tiles.STile == TileType.Wall) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }

        private string? CheckOutsideFrame(TilesAround<TileType> tiles)
        {
            //Print frame vertices
            if      (tiles.NTile == TileType.MazeFrame && tiles.ETile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.NE);
            else if (tiles.ETile == TileType.MazeFrame && tiles.STile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.SE);
            else if (tiles.STile == TileType.MazeFrame && tiles.WTile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.SW);
            else if (tiles.WTile == TileType.MazeFrame && tiles.NTile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.NW);

            //Print frame intersections
            else if (TileTypeChecker.IsFrameOrWall(tiles.NTile) && TileTypeChecker.IsFrameOrWall(tiles.ETile) && TileTypeChecker.IsFrameOrWall(tiles.STile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionE);
            else if (TileTypeChecker.IsFrameOrWall(tiles.ETile) && TileTypeChecker.IsFrameOrWall(tiles.STile) && TileTypeChecker.IsFrameOrWall(tiles.WTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionS);
            else if (TileTypeChecker.IsFrameOrWall(tiles.STile) && TileTypeChecker.IsFrameOrWall(tiles.WTile) && TileTypeChecker.IsFrameOrWall(tiles.NTile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionW);
            else if (TileTypeChecker.IsFrameOrWall(tiles.WTile) && TileTypeChecker.IsFrameOrWall(tiles.NTile) && TileTypeChecker.IsFrameOrWall(tiles.ETile)) return CharactersPrinter.GetTile(MazeTiles.IntersectionN);

            //Print frame straight walls
            else if (tiles.WTile == TileType.MazeFrame || tiles.ETile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.Horizontal);
            else if (tiles.NTile == TileType.MazeFrame || tiles.STile == TileType.MazeFrame) return CharactersPrinter.GetTile(MazeTiles.Vertical);

            return null;
        }
    }
}
