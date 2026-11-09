using Pickups;
using Ships.Common;
using UnityEngine;

namespace Common
{
    public class ShipDestroyedEventData : EventData
    {
        public readonly int ScoreToAdd;
        public readonly Teams Team;
        public readonly int InstanceId;
        public readonly Vector3 Position;
        public readonly PickupIds Drop;

        public ShipDestroyedEventData(int scoreToAdd, Teams team, int instanceId,
                                      Vector3 position = default, PickupIds drop = PickupIds.None) : base(EventIds.ShipDestroyed)
        {
            ScoreToAdd = scoreToAdd;
            Team = team;
            InstanceId = instanceId;
            Position = position;
            Drop = drop;
        }
    }
}
