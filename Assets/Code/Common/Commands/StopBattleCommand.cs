using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using Ships.Enemies;

namespace Common.Commands
{
    public class StopBattleCommand : Command
    {
        public Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopAndReset();
            return Task.CompletedTask;
        }
    }
}
