using Common.Commands;
using Common.Score;
using Core.DataStorage;
using Core.Serializares;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using ScoreSystem = Common.Score.ScoreSystem;

namespace Core.Installers
{
    public class GlobalInstaller : GeneralInstaller
    {
        protected override void DoStart()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(new LoadSceneCommand("Menu"));
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator.Instance.RegisterService(CommandQueue.Instance);
            
            var serializer = new JsonSerializerAdapater() ;
            var dataStore = new PlayerPrefsDataStoreAdapter(serializer);
            var scoreSystmeImpl = new ScoreSystemImpl(dataStore);
            ServiceLocator.Instance.RegisterService<ScoreSystem>(scoreSystmeImpl);
        }
    }
}
