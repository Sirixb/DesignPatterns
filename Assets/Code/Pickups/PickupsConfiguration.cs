using System;
using GameAudio;
using UnityEngine;

namespace Pickups
{
    [CreateAssetMenu(menuName = "Pickups/Create PickupsConfiguration", fileName = "PickupsConfiguration", order = 0)]
    public class PickupsConfiguration : ScriptableObject
    {
        [Serializable]
        public class Entry
        {
            [SerializeField] private PickupIds _id;
            [Tooltip("Optional. If empty, the sprite of the prefab is used.")]
            [SerializeField] private Sprite _sprite;
            [SerializeField] private Color _color = new Color(1f, 0.85f, 0.2f, 1f);
            [Tooltip("Strength of the effect. FireRateUpgrade: the fire rate is multiplied by this (0.5 = twice as fast, half the delay between shots).")]
            [SerializeField] private float _value = 0.5f;
            [SerializeField] private float _fallSpeed = 1.5f;
            [SerializeField] private AudioIds _pickUpSound = AudioIds.Pickup;

            public PickupIds Id => _id;
            public Sprite Sprite => _sprite;
            public Color Color => _color;
            public float Value => _value;
            public float FallSpeed => _fallSpeed;
            public AudioIds PickUpSound => _pickUpSound;
        }

        [SerializeField] private Pickup _prefab;
        [SerializeField] private Entry[] _entries;
        [SerializeField, Min(0)] private int _initialPoolSize = 3;

        public Pickup Prefab => _prefab;
        public Entry[] Entries => _entries;
        public int InitialPoolSize => _initialPoolSize;
    }
}
