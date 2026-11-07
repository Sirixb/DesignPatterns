using System;
using UnityEngine;

namespace GameAudio
{
    [CreateAssetMenu(menuName = "Audio/Create AudioConfiguration", fileName = "AudioConfiguration", order = 0)]
    public class GameAudioConfiguration : ScriptableObject
    {
        [Serializable]
        public class Entry
        {
            [SerializeField] private AudioIds _id;
            [Tooltip("One clip is picked at random each time it plays (never the same one twice in a row).")]
            [SerializeField] private AudioClip[] _clips;
            [SerializeField, Range(0f, 1f)] private float _volume = 1f;
            [SerializeField, Range(0f, 0.5f)] private float _pitchVariation;

            public AudioIds Id => _id;
            public AudioClip[] Clips => _clips;
            public float Volume => _volume;
            public float PitchVariation => _pitchVariation;
        }

        [SerializeField] private Entry[] _entries;
        [SerializeField, Min(0)] private int _initialSfxPoolSize = 16;

        public Entry[] Entries => _entries;
        public int InitialSfxPoolSize => _initialSfxPoolSize;
    }
}
