using PlutoRover.Components;
using PlutoRover.Constants;

namespace PlutoRover.Commands
{
    public class BackwardCommandHandler: ICommandHandler
    {
        private readonly IV12Engine _iv12Engine;
        private readonly Tracker _tracker;
        private readonly ObstacleDetector _detector;

        public BackwardCommandHandler(IV12Engine iv12Engine, Tracker tracker, ObstacleDetector detector)
        {
            _iv12Engine = iv12Engine;
            _tracker = tracker;
            _detector = detector;
        }

        public void Execute()
        {
            if (_detector.Find(TravelDistance.Backward))
            {
                return;
            }

            _iv12Engine.Backward();
            _tracker.RecordDistance(TravelDistance.Backward);
        }
    }
}
