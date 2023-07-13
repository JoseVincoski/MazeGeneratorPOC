using MazeGeneratorClass.Enums;
using MazeGeneratorClass.MazeClass;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace MazeGeneratorLib.MazeClass
{
    public class TilesAroundInfo
    {
        public TileType NTile;
        public TileType ETile;
        public TileType STile;
        public TileType WTile;

        public bool IsAnyOutsideMaze()
        {
            return (NTile == TileType.OutsideMaze || ETile == TileType.OutsideMaze || STile == TileType.OutsideMaze || WTile == TileType.OutsideMaze);
        }
    }
}
