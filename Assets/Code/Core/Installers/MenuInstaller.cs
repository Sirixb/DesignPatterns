using GameAudio;
using Patterns.Decoupling.ServiceLocator;

namespace Core.Installers
{
    public class MenuInstaller : GeneralInstaller
    {
        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<AudioService>().PlayMusic(AudioIds.MenuMusic);
        }

        protected override void DoInstallDependencies()
        {
        }
    }
}
