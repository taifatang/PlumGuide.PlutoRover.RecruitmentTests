using PlutoRover.Commands;
using PlutoRover.Components;
using PlutoRover.Model;

namespace PlutoRover
{
    /*
    * Overall, I find the exercise challenging but fun and likely to have spent considerably longer than others. These are the assumptions made
    * LF will always be a 90, -90 degree turn,
    * FB will always be a 1, -1 step at a time
    * Obstacles  will not be placed out of bound
    * Most models are made immutable to avoid mutation by callers
    *
    * I have avoided using interfaces and keep unit tests in a single file to demonstrate my TDD approach
    * There are a few areas this exercise could be improved
    *  - Further refactoring to improve OOP
    *  - Improve readability and clarity on some of the namings
    *  - Optimise some of the  Maths and avoid repeating calculations
    *  - A better responsibility boundary between some of the classes
    *  - I do prefer to have lesser state manipulation by returning some data in some of the methods
    */
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
