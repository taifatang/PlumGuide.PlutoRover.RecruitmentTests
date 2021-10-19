using FluentAssertions;
using NUnit.Framework;

namespace PlutoRover.UnitTests
{
    [TestFixture]
    public class PlutoRoverShould
    {
        [Test]
        public void Move_Forward()
        {
            var rover = new PlutoRover(0, 0, "N");

            rover.Execute("F");

            rover.X.Should().Be(1);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be("N");
        }

        [Test]
        public void Move_Backward()
        {
            var rover = new PlutoRover(0, 0, "N");

            rover.Execute("B");

            rover.X.Should().Be(-1);
            rover.Y.Should().Be(0);
            rover.Orientation.Should().Be("N");
        }
    }
}
