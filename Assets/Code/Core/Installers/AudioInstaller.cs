using GameAudio;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class AudioInstaller : Installer
    {
        [SerializeField] private GameAudioConfiguration _configuration;

        public override void Install(ServiceLocator serviceLocator)
        {
            // Lives in the Init scene and survives every scene load, like the EventQueue.
            var audioObject = new GameObject("AudioService");
            DontDestroyOnLoad(audioObject);

            var audioService = audioObject.AddComponent<AudioServiceImpl>();
            audioService.Configure(Instantiate(_configuration));
            serviceLocator.RegisterService<AudioService>(audioService);

            audioObject.AddComponent<AudioEventObserver>().Configure(audioService);
        }
    }
}
