using System;

namespace PlutoRover.Model
{
    public class Coordinate
    {
        private readonly int _x;
        private readonly int _y;

        public int X => Math.Abs(_x);
        public int Y => Math.Abs(_y);

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
