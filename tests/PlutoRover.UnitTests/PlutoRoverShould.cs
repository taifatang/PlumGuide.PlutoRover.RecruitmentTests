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

        [TestCase("L", -90)]
        [TestCase("LL", -180)]
        [TestCase("LLL", -270)]
        [TestCase("LLLL", -360)]
        [TestCase("LLLLL", -450)]
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
        [TestCase("RRRR", 360)]
        [TestCase("RRRRR", 450)]

        public void Turn_right(string command, int expectedOrientation)
        {
            var rover = new PlutoRover(0, 0, North);

            rover.Execute(command);

            rover.X.Should().Be(0);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be(expectedOrientation);
        }

    }
}
