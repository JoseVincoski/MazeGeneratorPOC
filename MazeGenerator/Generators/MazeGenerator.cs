﻿using MazeGeneratorLib.MazeClasses;

namespace MazeGeneratorLib.Generators
{
    public class MazeGenerator
    {
        private Maze Maze;
        private IGenerator Generator;

        public MazeGenerator(IGenerator _generator, int _mazeHeight, int _mazeWidth)
        {
            Maze = new Maze(_mazeHeight, _mazeWidth);
            Generator = _generator;
        }

        public Maze GetMaze()
        {
            Generator.GeneratePoints(ref Maze);
            Generator.GenerateBase(ref Maze);
            Generator.GenerateMaze(ref Maze);

            return Maze;
        }
    }
}