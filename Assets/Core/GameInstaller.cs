using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class GameInstaller : MonoBehaviour
    {

        [SerializeField] private Installer[] _installers;

        private void Awake()
        {
            InstallDependencies();
        }

        //private async void Start()
        //{
        //    InstallDependencies();
        //}

        private void InstallDependencies()
        {
            foreach (var installer in _installers)
            {
                installer.Install(ServiceLocator.Instance);
            }
        }

    }
}
