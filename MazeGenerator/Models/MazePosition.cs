using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorLib.MazeClasses
{
    public class MazePosition
    {
        public int Y;
        public int X;

        public MazePosition(int _y, int _x)
        {
            Y = _y;
            X = _x;
        }

        public bool IsEqual(MazePosition otherMazePosition)
        {
            return (Y == otherMazePosition.Y && X == otherMazePosition.X);
        }
    }
}
