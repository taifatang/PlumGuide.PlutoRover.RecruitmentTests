using FluentAssertions;
using Moq;
using NUnit.Framework;
using PlutoRover.Commands;
using PlutoRover.Components;
using PlutoRover.Model;

namespace PlutoRover.UnitTests
{
    [TestFixture]
    public class PlutoRoverShould
    {
        private Location _deploymentLocation;
        private Grid _standardGrid;

        private Mock<IV12Engine> _engineMock;
        private Mock<IGeoScanner> _geoScanner;
        private Rover _rover;

        [SetUp]
        public void SetUp()
        {
            _deploymentLocation = new Location(new Coordinate(0, 0), 0);
            _standardGrid = new Grid(new Coordinate(100, 100));

            _engineMock = new Mock<IV12Engine>();
            _geoScanner = new Mock<IGeoScanner>();

            _geoScanner.Setup(x => x.Scan()).Returns(_standardGrid);

            var tracker = new Tracker(_deploymentLocation, _geoScanner.Object);
            var detector = new ObstacleDetector(_geoScanner.Object, tracker);
            var commandParser = new CommandParser(tracker, _engineMock.Object, detector);

            _rover = new Rover(tracker, commandParser);
        }

        [Test]
        public void Move_forward()
        {
            _rover.Execute("F");

            _rover.Location.Coordinate.X.Should().Be(1);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(0);
        }

        [Test]
        public void Move_backward()
        {
            _rover.Execute("B");

            _rover.Location.Coordinate.X.Should().Be(100);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(0);
        }

        [TestCase("L", 270)]
        [TestCase("LL", 180)]
        [TestCase("LLL", 90)]
        [TestCase("LLLL", 0)]
        [TestCase("LLLLL", 270)]
        public void Turn_left(string command, int expectedOrientation)
        {
            _rover.Execute(command);

            _rover.Location.Coordinate.X.Should().Be(0);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("R", 90)]
        [TestCase("RR", 180)]
        [TestCase("RRR", 270)]
        [TestCase("RRRR", 0)]
        [TestCase("RRRRR", 90)]
        public void Turn_right(string command, int expectedOrientation)
        {
            _rover.Execute(command);

            _rover.Location.Coordinate.X.Should().Be(0);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("FLFF", 1, 99, 270)]
        [TestCase("FLFLFLF", 0, 0, 90)]
        [TestCase("RLRLRLR", 0, 0, 90)]
        [TestCase("FFBBFFLRLRLRFB", 2, 0, 0)]
        [TestCase("FFLFFRFFLFF", 4, 97, 270)]
        [TestCase("BBLBBLBBLBB", 0, 0, 90)]
        public void Complex_movement(string command, int expectedXCoordinate, int expectedYCoordinate, int expectedOrientation)
        {
            _rover.Execute(command);

            _rover.Location.Coordinate.X.Should().Be(expectedXCoordinate);
            _rover.Location.Coordinate.Y.Should().Be(expectedYCoordinate);
            _rover.Location.Orientation.Should().Be(expectedOrientation);
        }

        [TestCase("FFFFF", 1, 0, 0)]
        [TestCase("BBBBB", 3, 0, 0)]
        [TestCase("LBBBBB", 0, 0, 270)]
        [TestCase("RBBBBB", 0, 0, 90)]
        [TestCase("LLBBBBB", 1, 0, 180)]
        public void Coordinate_is_wrapped_for_out_of_bound(string command, int expectedXCoordinate, int expectedYCoordinate, int expectedOrientation)
        {
            var grid = new Grid(new Coordinate(3, 4));
            _geoScanner.Setup(x => x.Scan()).Returns(grid);

            _rover.Execute(command);

            _rover.Location.Coordinate.X.Should().Be(expectedXCoordinate);
            _rover.Location.Coordinate.Y.Should().Be(expectedYCoordinate);
            _rover.Location.Orientation.Should().Be(expectedOrientation);
        }

        [Test]
        public void Stop_upon_detection_obstacle()
        {
            var grid = new Grid(new Coordinate(4, 4));
            grid.Add(new Obstacle(new Coordinate(2, 0)));
            _geoScanner.Setup(x => x.Scan()).Returns(grid);

            _rover.Execute("FFFFF");

            _rover.Location.Coordinate.X.Should().Be(1);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(0);
        }

        [Test]
        public void Stop_upon_detection_obstacle_in_reverse()
        {
            var grid = new Grid(new Coordinate(4, 4));
            grid.Add(new Obstacle(new Coordinate(2, 0)));
            _geoScanner.Setup(x => x.Scan()).Returns(grid);

            _rover.Execute("BBBBB");

            _rover.Location.Coordinate.X.Should().Be(3);
            _rover.Location.Coordinate.Y.Should().Be(0);
            _rover.Location.Orientation.Should().Be(0);
        }

        [Test]
        public void Carry_on_executing_remaining_command_when_obscured()
        {
            var grid = new Grid(new Coordinate(4, 4));
            grid.Add(new Obstacle(new Coordinate(2, 0)));
            _geoScanner.Setup(x => x.Scan()).Returns(grid);

            _rover.Execute("FFFLFRF");

            _rover.Location.Coordinate.X.Should().Be(2);
            _rover.Location.Coordinate.Y.Should().Be(4);
            _rover.Location.Orientation.Should().Be(0);
        }
    }
}
