using MazeGeneratorLib.Generators.V2.Helper;
using MazeGeneratorLib.Models;
using MazeGeneratorLib.Models.Enums;

namespace MazeGeneratorLib.Generators.V2.Models
{
    public class TilesAroundInfo
    {
        private MazePosition basePosition;
        private Maze maze;

        public List<TileInfo> TileInfos = new List<TileInfo>();

        public List<TileInfo> MovableWalls { get { UpdateTiles(); return GetTileType(TileType.MovableWall); } }

        public TilesAroundInfo(Maze maze, int Y, int X)
        {
            basePosition = new MazePosition(Y, X);
            this.maze = maze;

            UpdateTiles();
        }
        private List<TileInfo> GetTileType(TileType tileType)
        {
            return TileInfos.FindAll(x => x.TileType == tileType);
        }

        private void UpdateTiles()
        {
            List<int> rng = new List<int>() { 0, 1, 2, 3 };

            TileInfos.Clear();
            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y - 1, basePosition.X),
                NextPathPosition = new MazePosition(basePosition.Y - 2, basePosition.X),
                TileType = maze.GetTileTypeInPosition(basePosition.Y - 1, basePosition.X),
                Direction = TileDirection.N,
                Priority = RNGenerator.GetRandomDecreasingDirection(ref rng),
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y, basePosition.X + 1),
                NextPathPosition = new MazePosition(basePosition.Y, basePosition.X + 2),
                TileType = maze.GetTileTypeInPosition(basePosition.Y, basePosition.X + 1),
                Direction = TileDirection.E,
                Priority = RNGenerator.GetRandomDecreasingDirection(ref rng),
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y + 1, basePosition.X),
                NextPathPosition = new MazePosition(basePosition.Y + 2, basePosition.X),
                TileType = maze.GetTileTypeInPosition(basePosition.Y + 1, basePosition.X),
                Direction = TileDirection.S,
                Priority = RNGenerator.GetRandomDecreasingDirection(ref rng),
            });

            TileInfos.Add(new TileInfo()
            {
                Position = new MazePosition(basePosition.Y, basePosition.X - 1),
                NextPathPosition = new MazePosition(basePosition.Y, basePosition.X - 2),
                TileType = maze.GetTileTypeInPosition(basePosition.Y, basePosition.X - 1),
                Direction = TileDirection.W,
                Priority = RNGenerator.GetRandomDecreasingDirection(ref rng),
            });
        }
    }
}
