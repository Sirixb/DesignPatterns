using System;
using System.Collections.Generic;
using Patterns.Optimization.ObjectPooling;
using UnityEngine;

namespace Pickups
{
    public class PickupFactory
    {
        private readonly Dictionary<PickupIds, PickupsConfiguration.Entry> _entries;
        private readonly ObjectPool _pool;
        private readonly HashSet<Pickup> _activePickups = new HashSet<Pickup>();
        private readonly Action<Pickup> _onPickupReleased;

        public PickupFactory(PickupsConfiguration configuration)
        {
            _entries = new Dictionary<PickupIds, PickupsConfiguration.Entry>();
            foreach (var entry in configuration.Entries)
            {
                _entries[entry.Id] = entry;
            }

            _onPickupReleased = pickup => _activePickups.Remove(pickup);

            _pool = new ObjectPool(configuration.Prefab);
            _pool.Init(configuration.InitialPoolSize);
        }

        public Pickup Create(PickupIds id, Vector3 position)
        {
            if (!_entries.TryGetValue(id, out var entry))
            {
                Debug.LogWarning($"Pickup {id} is not defined in the PickupsConfiguration");
                return null;
            }

            var pickup = _pool.Spawn<Pickup>(position, Quaternion.identity);
            pickup.Setup(CreateEffect(id, entry), entry, _onPickupReleased);
            _activePickups.Add(pickup);
            return pickup;
        }

        public void RecycleAll()
        {
            var pickups = new List<Pickup>(_activePickups);
            foreach (var pickup in pickups)
            {
                pickup.Recycle();
            }
        }

        private static PickupEffect CreateEffect(PickupIds id, PickupsConfiguration.Entry entry)
        {
            switch (id)
            {
                case PickupIds.FireRateUpgrade:
                    return new FireRateUpgradeEffect(entry.Value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
        }
    }
}
