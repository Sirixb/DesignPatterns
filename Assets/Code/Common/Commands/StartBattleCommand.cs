using System.Threading.Tasks;
using Battle;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using ScoreSystem = Common.Score.ScoreSystem;

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
            serviceLocator.GetService<ScoreSystem>().Reset();

            await new HideScreenFadeCommand().Execute();
        }
    }
}
