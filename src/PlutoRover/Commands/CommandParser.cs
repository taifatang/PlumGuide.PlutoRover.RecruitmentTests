using System.Collections.Generic;
using PlutoRover.Components;
using PlutoRover.Constants;

namespace PlutoRover.Commands
{
    public class CommandParser
    {
        private readonly Dictionary<char, ICommandHandler> _commandHandler;

        public CommandParser(Tracker tracker, IV12Engine iv12Engine, ObstacleDetector detector)
        {
            //Could use Ioc for this
            _commandHandler = new Dictionary<char, ICommandHandler>()
            {
                {Command.Forward, new ForwardCommandHandler(iv12Engine, tracker, detector)},
                {Command.Backward, new BackwardCommandHandler(iv12Engine, tracker, detector)},
                {Command.Left, new LeftTurnCommandHandler(iv12Engine, tracker)},
                {Command.Right, new RightTurnCommandHandler(iv12Engine, tracker)},
            };
        }

        public IEnumerable<ICommandHandler> Parse(string commands)
        {
            var handlers = new Queue<ICommandHandler>();

            foreach (var command in commands)
            {
                handlers.Enqueue(_commandHandler[command]);
            }

            return handlers;
        }
    }
}
