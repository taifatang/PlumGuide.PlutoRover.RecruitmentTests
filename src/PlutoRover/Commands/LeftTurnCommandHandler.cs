using PlutoRover.Components;
using PlutoRover.Constants;

namespace PlutoRover.Commands
{
    public class LeftTurnCommandHandler : ICommandHandler
    {
        private readonly IV12Engine _iv12Engine;
        private readonly Tracker _tracker;

        public LeftTurnCommandHandler(IV12Engine iv12Engine, Tracker tracker)
        {
            _iv12Engine = iv12Engine;
            _tracker = tracker;
        }

        public void Execute()
        {
            _iv12Engine.Left();
            _tracker.RecordOrientation(TurnDirection.Left);
        }
    }
}
