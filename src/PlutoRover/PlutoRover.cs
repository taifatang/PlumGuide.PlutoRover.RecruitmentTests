using PlutoRover.Constants;
using PlutoRover.Model;

namespace PlutoRover
{
    public class PlutoRover
    {
        private readonly Grid _grid;
        public Coordinate Coordinate { get; }

        public PlutoRover(Coordinate coordinate, Grid grid)
        {
            _grid = grid;
            Coordinate = coordinate;
        }

        public void Execute(string s)
        {
            foreach (char command in s)
            {
                if (command == Command.Forward)
                {
                    Coordinate.Walk(1, _grid);
                }
                else if (command == Command.Backward)
                {
                    Coordinate.Walk(-1, _grid);
                }
                else if (command == Command.Left)
                {
                    Coordinate.Turn(270);
                }
                else if (command == Command.Right)
                {
                    Coordinate.Turn(90);
                }
            }
        }
    }
}
