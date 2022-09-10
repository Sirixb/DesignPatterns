using Patterns.Decoupling.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(ServiceLocator serviceLocator);
    }
}
