using System;

namespace PlutoRover
{

    public class PlutoRover
    {
        private int _orientation;
        public int X { get; private set; }
        public int Y { get; private set; }

        public int Orientation
        {
            get => _orientation % 360;
        }

        public PlutoRover(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            _orientation = orientation;
        }

        private void Turn(char direction)
        {
            if (direction == 'L')
            {
                _orientation += 270;
            }
            else
            {
                _orientation += 90;
            }

        }

        private Direction GetCurrentDirection()
        {
            return (Direction)Math.Abs(Orientation / 90 % 4);
        }

        public void Execute(string s)
        {
            foreach (char command in s)
            {
                if (command == 'F')
                {
                    var facing = GetCurrentDirection();

                    switch (facing)
                    {
                        case Direction.N:
                            X += 1;
                            break;
                        case Direction.E:
                            Y += 1;
                            break;
                        case Direction.S:
                            X -= 1;
                            break;
                        case Direction.W:
                            Y -= 1;
                            break;
                    }
                }

                else if (command == 'B')
                {
                    X -= 1;
                }

                else if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }
            }
        }
    }
}
