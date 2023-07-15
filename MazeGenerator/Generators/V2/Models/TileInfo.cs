using MazeGeneratorLib.Models;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.Generators.V2.Models
{
    public class TileInfo
    {
        public TileType TileType { get; set; }
        public TileDirection Direction { get; set; }
        public MazePosition Position { get; set; }
        public MazePosition NextPathPosition { get; set; }
        public int Priority { get; set; }
    }
}
