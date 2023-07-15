using MazeGeneratorLib.Generators.V2.Helper;
using MazeGeneratorLib.Models;
using MazeGeneratorLib.Models.Enums;
using TilesAroundInfo = MazeGeneratorLib.Generators.V2.Models.TilesAroundInfo;

namespace MazeGeneratorLib.Generators.V2
{
    public class MazeGenV2 : IGenerator
    {
        public void GenerateMaze(ref Maze maze)
        {
            for(int row = 1; row < maze.Height - 1; row += 2)
            {
                for (int column = 1; column < maze.Width - 1; column += 2)
                {
                    var tilesAroundInfo = new TilesAroundInfo(maze, row, column);

                    if (tilesAroundInfo.MovableWalls.Count > 1)
                    {
                        var numberOfWallsToCarve = RNGenerator.GetRandomIntLowerThan(tilesAroundInfo.MovableWalls.Count);

                        for (int i = 0; i < numberOfWallsToCarve; i++)
                        {
                            var wallToChange = tilesAroundInfo.MovableWalls.MaxBy(mw => mw.Priority)!.Position;
                            maze.Tiles[wallToChange.Y, wallToChange.X] = (int)TileType.Path;
                        }

                        //Set last wall as solid wall
                        if (tilesAroundInfo.MovableWalls.Count == 1)
                        {
                            var wallToChange = tilesAroundInfo.MovableWalls.First().Position;
                            maze.Tiles[wallToChange.Y, wallToChange.X] = (int)TileType.SolidWall;
                        }
                        //Set current path as verified path
                        maze.Tiles[row, column] = (int)TileType.VerifiedPath;
                    }
                }
            }
        }
    }
}
