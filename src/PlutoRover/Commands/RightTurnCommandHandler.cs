using PlutoRover.Components;
using PlutoRover.Constants;

namespace PlutoRover.Commands
{
    public class RightTurnCommandHandler : ICommandHandler
    {
        private readonly IV12Engine _iv12Engine;
        private readonly Tracker _tracker;

        public RightTurnCommandHandler(IV12Engine iv12Engine, Tracker tracker)
        {
            _iv12Engine = iv12Engine;
            _tracker = tracker;
        }

        public void Execute()
        {
            _iv12Engine.Right();
            _tracker.RecordOrientation(TurnDirection.Right);
        }
    }
}
