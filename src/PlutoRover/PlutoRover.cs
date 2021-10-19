using System;

namespace PlutoRover
{

    public class PlutoRover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Orientation { get; private set; }

        public PlutoRover(int x, int y, int orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        private void Turn(char direction)
        {
            if (direction == 'L')
            {
                Orientation -= 90;
            }
            else
            {
                Orientation += 90;
            }

        }
        public void Execute(string s)
        {
            foreach (char command in s)
            {
                if (command == 'F')
                {
                    X += 1;
                }

                if (command == 'B')
                {
                    X -= 1;
                }

                if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }
            }
        }
    }
}
