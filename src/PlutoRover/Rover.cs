using PlutoRover.Commands;
using PlutoRover.Components;
using PlutoRover.Model;

namespace PlutoRover
{
    public class Rover
    {
        private readonly CommandParser _commandParser;
        private readonly Tracker _tracker;
        public Location Location => _tracker.GetCurrentLocation();

        public Rover(Tracker tracker, CommandParser commandParser)
        {
            _commandParser = commandParser;
            _tracker = tracker;
        }

        public void Execute(string s)
        {
            var handlers = _commandParser.Parse(s);

            foreach (var handler in handlers)
            {
                handler.Execute();
            }
        }
    }
}
