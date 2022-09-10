using Battle;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class GameFacadeInstaller : Installer
    {
        [SerializeField] private GameFacadeImpl _gameFacade;

        public override void Install(ServiceLocator serviceLocator)
        {
            serviceLocator.RegisterService<GameFacade>(_gameFacade);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<GameFacade>();
        }
    }
}
