using Battle;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class GameFacadeInstaller : Installer
    {
        [SerializeField] private GameFacade _gameFacade;

        public override void Install(ServiceLocator serviceLocator)
        {
            serviceLocator.RegisterService(_gameFacade);
        }
    }
}
