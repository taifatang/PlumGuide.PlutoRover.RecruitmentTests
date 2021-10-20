using System.Linq;

namespace PlutoRover.Components
{
    public class ObstacleDetector
    {
        private readonly IGeoScanner _geoScanner;
        private readonly Tracker _tracker;

        public ObstacleDetector(IGeoScanner geoScanner, Tracker tracker)
        {
            _geoScanner = geoScanner;
            _tracker = tracker;
        }

        public bool Find(int distance)
        {
            var detectedObstacles = _geoScanner.Scan().Obstacles;

            var nextCoordinate = _tracker.GetNextCoordinate(distance);

            return detectedObstacles.Any(o =>
                o.Coordinate.X == nextCoordinate.X
                && o.Coordinate.Y == nextCoordinate.Y);
        }
    }
}
