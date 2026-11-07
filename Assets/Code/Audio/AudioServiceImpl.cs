using System.Collections.Generic;
using Patterns.Optimization.ObjectPooling;
using UnityEngine;

namespace GameAudio
{
    public class AudioServiceImpl : MonoBehaviour, AudioService
    {
        private Dictionary<AudioIds, GameAudioConfiguration.Entry> _entries;
        private AudioSource _musicSource;
        private ObjectPool _sfxPool;
        private AudioIds? _currentMusic;
        private readonly Dictionary<AudioIds, int> _lastPlayedIndex = new Dictionary<AudioIds, int>();

        public void Configure(GameAudioConfiguration configuration)
        {
            _entries = new Dictionary<AudioIds, GameAudioConfiguration.Entry>();
            foreach (var entry in configuration.Entries)
            {
                _entries[entry.Id] = entry;
            }

            _musicSource = gameObject.AddComponent<AudioSource>();
            _musicSource.playOnAwake = false;
            _musicSource.loop = true;

            _sfxPool = new ObjectPool(CreateSfxPlayerTemplate());
            _sfxPool.Init(configuration.InitialSfxPoolSize);
        }

        private SfxPlayer CreateSfxPlayerTemplate()
        {
            var template = new GameObject("SfxPlayerTemplate");
            template.transform.SetParent(transform);
            return template.AddComponent<SfxPlayer>();
        }

        public void PlaySfx(AudioIds id)
        {
            if (!TryPickClip(id, out var entry, out var clip))
            {
                return;
            }

            var player = _sfxPool.Spawn<SfxPlayer>(Vector3.zero, Quaternion.identity);
            var pitch = 1f + Random.Range(-entry.PitchVariation, entry.PitchVariation);
            player.Play(clip, entry.Volume, pitch);
        }

        public void PlayMusic(AudioIds id)
        {
            if (_currentMusic == id && _musicSource.isPlaying)
            {
                return;
            }

            if (!TryPickClip(id, out var entry, out var clip))
            {
                return;
            }

            _currentMusic = id;
            _musicSource.clip = clip;
            _musicSource.volume = entry.Volume;
            _musicSource.Play();
        }

        public void StopMusic()
        {
            _musicSource.Stop();
            _currentMusic = null;
        }

        private bool TryPickClip(AudioIds id, out GameAudioConfiguration.Entry entry, out AudioClip clip)
        {
            clip = null;
            if (!_entries.TryGetValue(id, out entry) || entry.Clips == null || entry.Clips.Length == 0)
            {
                Debug.LogWarning($"Audio {id} has no clips assigned in the GameAudioConfiguration");
                return false;
            }

            var clips = entry.Clips;
            var index = Random.Range(0, clips.Length);
            if (clips.Length > 1 && _lastPlayedIndex.TryGetValue(id, out var lastIndex) && index == lastIndex)
            {
                index = (index + 1) % clips.Length;
            }

            _lastPlayedIndex[id] = index;
            clip = clips[index];
            if (clip != null)
            {
                return true;
            }

            Debug.LogWarning($"Audio {id} has an empty slot in its clips list");
            return false;
        }
    }
}
