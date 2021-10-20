using System.Collections.Generic;

namespace PlutoRover.Model
{
    public class Grid
    {
        private readonly List<Obstacle> _obstacles;

        public Coordinate Coordinate { get; }
        public IEnumerable<Obstacle> Obstacles => _obstacles;
        //Coordinate start at zero
        public int Width => Coordinate.Y + 1; 
        public int Depth => Coordinate.X + 1;

        public Grid(Coordinate coordinate)
        {
            _obstacles = new List<Obstacle>();
            Coordinate = coordinate;
        }

        public void Add(Obstacle obstacle)
        {
            _obstacles.Add(obstacle);
        }
    }
}
