using Common;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class EventQueueInstaller: Installer
    {
        [SerializeField] private EventQueueImpl _EventQueue;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_EventQueue.gameObject);
            serviceLocator.RegisterService<EventQueue>(_EventQueue);
        }
    }
}
