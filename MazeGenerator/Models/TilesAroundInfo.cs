using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.MazeClasses
{
    public class TilesAroundInfo
    {
        public TileType NTile;
        public TileType ETile;
        public TileType STile;
        public TileType WTile;

        public bool IsAnyOutsideMaze()
        {
            return NTile == TileType.OutsideMaze || ETile == TileType.OutsideMaze || STile == TileType.OutsideMaze || WTile == TileType.OutsideMaze;
        }
    }
}
