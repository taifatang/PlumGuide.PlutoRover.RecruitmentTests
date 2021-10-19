using System;

namespace PlutoRover
{
    public class PlutoRover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Orientation { get; private set; }
        public PlutoRover(int x, int y, string orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void Execute(string s)
        {
            if (s == "F")
            {
                X += 1;
            }

            if (s == "B")
            {
                X -= 1;
            }
        }
    }
}
