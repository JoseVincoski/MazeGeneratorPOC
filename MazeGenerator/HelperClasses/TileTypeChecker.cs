using MazeGeneratorLib.MazeClasses;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.HelperClasses
{
    public static class TileTypeChecker
    {
        public static bool IsAnyOutsideMaze(TilesAround<TileType> tiles)
        {
            return tiles.NTile == TileType.MazeFrame || tiles.ETile == TileType.MazeFrame || tiles.STile == TileType.MazeFrame || tiles.WTile == TileType.MazeFrame;
        }

        public static bool IsFrameOrWall(TileType type)
        {
            return (type == TileType.MazeFrame || type == TileType.Wall);
        }
    }
}
