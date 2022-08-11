using Common;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class EventQueueInstaller: Installer
    {
        [SerializeField] private EventQueue _EventQueue;

        public override void Install(ServiceLocator serviceLocator)
        {
            serviceLocator.RegisterService(_EventQueue);
        }
    }
}
