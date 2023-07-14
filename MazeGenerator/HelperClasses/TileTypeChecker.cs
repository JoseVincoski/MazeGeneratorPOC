using MazeGeneratorLib.MazeClasses;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.HelperClasses
{
    public static class TileTypeChecker
    {
        public static bool IsAnyOutsideMaze(TilesAround<TileType> tiles)
        {
            return tiles.NTile == TileType.OutsideMaze || tiles.ETile == TileType.OutsideMaze || tiles.STile == TileType.OutsideMaze || tiles.WTile == TileType.OutsideMaze;
        }
    }
}
