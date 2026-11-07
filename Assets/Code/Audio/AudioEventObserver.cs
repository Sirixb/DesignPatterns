using Common;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace GameAudio
{
    // Plays the sounds that react to the game state, so nothing else needs to know about audio for them.
    public class AudioEventObserver : MonoBehaviour, EventObserver
    {
        private AudioService _audioService;

        public void Configure(AudioService audioService)
        {
            _audioService = audioService;
        }

        // Start (not Awake): the EventQueue is initialized by then, whatever the Awake order is.
        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.Restart, this);
        }

        private void OnDestroy()
        {
            if (!ServiceLocator.Instance.Contains<EventQueue>())
            {
                return;
            }

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.Restart, this);
        }

        public void Process(EventData eventData)
        {
            switch (eventData.EventId)
            {
                case EventIds.GameOver:
                    _audioService.StopMusic();
                    _audioService.PlaySfx(AudioIds.GameOver);
                    break;
                case EventIds.Victory:
                    _audioService.StopMusic();
                    _audioService.PlaySfx(AudioIds.Victory);
                    break;
                case EventIds.Restart:
                    _audioService.PlayMusic(AudioIds.GameplayMusic);
                    break;
            }
        }
    }
}
