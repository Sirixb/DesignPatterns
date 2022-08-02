using Ships.Common;

namespace Common
{
    public class ShipDestroyedEventData : EventData
    {
        public readonly int ScoreToAdd;
        public readonly Teams Team;

        public ShipDestroyedEventData(int scoreToAdd, Teams team) : base(EventIds.ShipDestroyed)
        {
            ScoreToAdd = scoreToAdd;
            Team = team;
        }
    }
}
