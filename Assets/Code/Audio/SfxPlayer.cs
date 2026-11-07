using Patterns.Optimization.ObjectPooling;
using UnityEngine;

namespace GameAudio
{
    // One pooled voice: plays a clip and returns itself to the pool when the clip ends.
    [RequireComponent(typeof(AudioSource))]
    public class SfxPlayer : RecyclableObject
    {
        private AudioSource _source;
        private bool _isPlaying;
        private int _startFrame;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _source.playOnAwake = false;

            // The pool lives as long as the AudioService, so its voices must survive scene loads.
            if (transform.parent == null)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        internal override void Init()
        {
        }

        internal override void Release()
        {
            _isPlaying = false;
            _source.Stop();
        }

        public void Play(AudioClip clip, float volume, float pitch)
        {
            _source.clip = clip;
            _source.volume = volume;
            _source.pitch = pitch;
            _source.Play();
            _isPlaying = true;
            _startFrame = Time.frameCount;
        }

        private void Update()
        {
            // Checking isPlaying (instead of Invoke) keeps working while Time.timeScale is 0.
            if (_isPlaying && Time.frameCount > _startFrame && !_source.isPlaying)
            {
                Recycle();
            }
        }
    }
}
