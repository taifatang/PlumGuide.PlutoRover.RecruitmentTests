using PlutoRover.Model;

namespace PlutoRover.Components
{
    public class Tracker
    {
        private readonly Location _location;
        private readonly IGeoScanner _geoScanner;

        public Tracker(Location location, IGeoScanner geoScanner)
        {
            _location = location;
            _geoScanner = geoScanner;
        }

        public void RecordDistance(int distance)
        {
            var cardinalPoint = _location.GetCardinalPoint;
            var grid = _geoScanner.Scan();

            _location.UpdateCoordinate(distance, cardinalPoint, grid);
        }

        public void RecordOrientation(int orientation)
        {
            _location.UpdateOrientation(orientation);
        }

        public Location GetCurrentLocation()
        {
            return _location;
        }

        public Coordinate GetNextCoordinate(int distance)
        {
            var cardinalPoint = _location.GetCardinalPoint;
            var grid = _geoScanner.Scan();

            return _location.GetNexCoordinate(distance, cardinalPoint, grid);
        }
    }
}
