using System.Threading.Tasks;
using Battle;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;

namespace Common.Commands
{
    public class StartBattleCommand : Command
    {
        public async Task Execute()
        {
            await new ShowScreenFadeCommand().Execute();

            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<GameStateController>().Reset();
            serviceLocator.GetService<ScoreView>().Reset();
            serviceLocator.GetService<EnemySpawner>().StartSpawn();
            serviceLocator.GetService<ShipInstaller>().SpawnUserShip();

            await new HideScreenFadeCommand().Execute();
        }
    }
}
