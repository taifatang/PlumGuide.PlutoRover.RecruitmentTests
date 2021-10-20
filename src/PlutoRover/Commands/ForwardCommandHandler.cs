using PlutoRover.Components;
using PlutoRover.Constants;

namespace PlutoRover.Commands
{
    public class ForwardCommandHandler : ICommandHandler
    {
        private readonly IV12Engine _iv12Engine;
        private readonly Tracker _tracker;
        private readonly ObstacleDetector _detector;

        public ForwardCommandHandler(IV12Engine iv12Engine, Tracker tracker, ObstacleDetector detector)
        {
            _iv12Engine = iv12Engine;
            _tracker = tracker;
            _detector = detector;
        }

        public void Execute()
        {
            if (_detector.Find(TravelDistance.Forward))
            {
                return;
            }

            _iv12Engine.Forward();
            _tracker.RecordDistance(TravelDistance.Forward);
        }
    }
}
