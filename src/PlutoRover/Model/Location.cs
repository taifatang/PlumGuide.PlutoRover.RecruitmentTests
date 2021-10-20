using System;
using PlutoRover.Constants;

namespace PlutoRover.Model
{
    public class Location
    {
        private int _orientation;

        public Coordinate Coordinate { get; private set; }
        public int Orientation
        {
            get => _orientation % 360;
            private set => _orientation = value;
        }
        public CardinalPoint GetCardinalPoint => (CardinalPoint)Math.Abs(Orientation / 90 % 4); //This wouldn't work with SW, NW etc.

        public Location(Coordinate coordinate, int orientation)
        {
            Coordinate = coordinate;
            Orientation = orientation;
        }

        public void UpdateCoordinate(int distance, CardinalPoint cardinalPoint, Grid grid)
        {
            Coordinate = GetNexCoordinate(distance, cardinalPoint, grid);
        }

        public void UpdateOrientation(int degree)
        {
            Orientation += degree;
        }

        public Coordinate GetNexCoordinate(int distance, CardinalPoint cardinalPoint, Grid grid)
        {
            var x = Coordinate.X + grid.Depth;
            var y = Coordinate.Y + grid.Width;

            switch (cardinalPoint) 
            {
                case CardinalPoint.N:
                    x += distance;
                    break;
                case CardinalPoint.E:
                    y += distance;
                    break;
                case CardinalPoint.S:
                    x -= distance;
                    break;
                case CardinalPoint.W:
                    y -= distance;
                    break;
            }

            return new Coordinate(
                x % grid.Depth,
                y % grid.Width
            );
        }
    }
}
