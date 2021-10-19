using FluentAssertions;
using NUnit.Framework;

namespace PlutoRover.UnitTests
{
    [TestFixture]
    public class PlutoRoverShould
    {
        private int North = 0;

        [Test]
        public void Move_forward()
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute("F");

            rover.X.Should().Be(1);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be(0);
        }

        [Test]
        public void Move_backward()
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute("B");

            rover.X.Should().Be(-1);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be(0);
        }

        [TestCase("L", 270)]
        [TestCase("LL", 180)]
        [TestCase("LLL", 90)]
        [TestCase("LLLL", 0)]
        [TestCase("LLLLL", 270)]
        public void Turn_left(string command, int expectedOrientation)
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute(command);

            rover.X.Should().Be(0);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("R", 90)]
        [TestCase("RR", 180)]
        [TestCase("RRR", 270)]
        [TestCase("RRRR", 0)]
        [TestCase("RRRRR", 90)]
        public void Turn_right(string command, int expectedOrientation)
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute(command);

            rover.X.Should().Be(0);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("FLFF", 1, -2, 270)]
        [TestCase("FLFLFLFL", 0, 0, 0)]
        [TestCase("RLRLRLRL", 0, 0, 0)]
        [TestCase("FFBBFFLRLRLRFB", 2, 0, 0)]
        [TestCase("FFLFFRFFLFF", 4, -4, 270)]
        public void Complex_movement(string command, int expectedXCoordinate, int expectedYCoordinate, int expectedOrientation)
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute(command);

            rover.X.Should().Be(expectedXCoordinate);
            rover.Y.Should().Be(expectedYCoordinate);
            rover.Orientation.Should().Be(expectedOrientation);
        }
    }
}
