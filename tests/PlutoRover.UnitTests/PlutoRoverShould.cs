using FluentAssertions;
using NUnit.Framework;
using PlutoRover.Model;

namespace PlutoRover.UnitTests
{
    [TestFixture]
    public class PlutoRoverShould
    {
        [Test]
        public void Move_forward()
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(100, 100));

            rover.Execute("F");

            rover.Coordinate.X.Should().Be(1);
            rover.Coordinate.Y.Should().Be(0);
            rover.Coordinate.Orientation.Should().Be(0);
        }

        [Test]
        public void Move_backward()
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(100, 100));

            rover.Execute("B");

            rover.Coordinate.X.Should().Be(-1);
            rover.Coordinate.Y.Should().Be(0);
            rover.Coordinate.Orientation.Should().Be(0);
        }

        [TestCase("L", 270)]
        [TestCase("LL", 180)]
        [TestCase("LLL", 90)]
        [TestCase("LLLL", 0)]
        [TestCase("LLLLL", 270)]
        public void Turn_left(string command, int expectedOrientation)
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(100, 100));

            rover.Execute(command);

            rover.Coordinate.X.Should().Be(0);
            rover.Coordinate.Y.Should().Be(0);
            rover.Coordinate.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("R", 90)]
        [TestCase("RR", 180)]
        [TestCase("RRR", 270)]
        [TestCase("RRRR", 0)]
        [TestCase("RRRRR", 90)]
        public void Turn_right(string command, int expectedOrientation)
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(100, 100));

            rover.Execute(command);

            rover.Coordinate.X.Should().Be(0);
            rover.Coordinate.Y.Should().Be(0);
            rover.Coordinate.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("FLFF", 1, -2, 270)]
        [TestCase("FLFLFLF", 0, 0, 90)]
        [TestCase("RLRLRLR", 0, 0, 90)]
        [TestCase("FFBBFFLRLRLRFB", 2, 0, 0)]
        [TestCase("FFLFFRFFLFF", 4, -4, 270)]
        [TestCase("BBLBBLBBLBB", 0, 0, 90)]
        public void Complex_movement(string command, int expectedXCoordinate, int expectedYCoordinate, int expectedOrientation)
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(100, 100));

            rover.Execute(command);

            rover.Coordinate.X.Should().Be(expectedXCoordinate);
            rover.Coordinate.Y.Should().Be(expectedYCoordinate);
            rover.Coordinate.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("FFFFF", 0, 0, 0)]
        [TestCase("BBBBB", 0, 0, 0)]
        [TestCase("LBBBBB", 0, 0, 270)]
        [TestCase("RBBBBB", 0, 0, 90)]
        [TestCase("LLBBBBB", 0, 0, 180)]
        public void Coordinate_is_wrapped_if_out_of_bound(string command, int expectedXCoordinate, int expectedYCoordinate, int expectedOrientation)
        {
            var rover = new PlutoRover(Coordinate.Begin, new Grid(4, 4));

            rover.Execute(command);

            rover.Coordinate.X.Should().Be(expectedXCoordinate);
            rover.Coordinate.Y.Should().Be(expectedYCoordinate);
            rover.Coordinate.Orientation.Should().Be(expectedOrientation);
        }
    }
}
