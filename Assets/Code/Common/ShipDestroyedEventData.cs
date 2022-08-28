using Ships.Common;

namespace Common
{
    public class ShipDestroyedEventData : EventData
    {
        public readonly int ScoreToAdd;
        public readonly Teams Team;
        public readonly int InstanceId;

        public ShipDestroyedEventData(int scoreToAdd, Teams team,int instanceId) : base(EventIds.ShipDestroyed)
        {
            ScoreToAdd = scoreToAdd;
            Team = team;
            InstanceId = instanceId;
        }
    }
}
