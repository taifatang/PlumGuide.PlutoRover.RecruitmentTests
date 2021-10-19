using System;
using PlutoRover.Constants;

namespace PlutoRover.Model
{
    public class Coordinate
    {
        private int _orientation;

        public static Coordinate Begin => new Coordinate(0, 0, 0);

        public int Orientation
        {
            get => _orientation % 360;
            set => _orientation = value;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            _orientation = orientation;
        }

        public void Walk(int step, Grid grid)
        {
            var facing = GetDirection();

            var boundX = grid.X + 1;
            var boundY = grid.Y + 1;

            switch (facing)
            {
                case Direction.N:
                    X += step;
                    break;
                case Direction.E:
                    Y += step;
                    break;
                case Direction.S:
                    X -= step;
                    break;
                case Direction.W:
                    Y -= step;
                    break;
            }

            X %= boundX;
            Y %= boundY;
        }

        public void Turn(int degreeToTurn)
        {
            Orientation += degreeToTurn;
        }

        private Direction GetDirection()
        {
            return (Direction)Math.Abs(Orientation / 90 % 4);
        }
    }
}
