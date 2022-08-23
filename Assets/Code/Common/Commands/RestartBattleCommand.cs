using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;

namespace Common.Commands
{
    public class RestartBattleCommand : Command
    {
        public async Task Execute()
        {
            ServiceLocator.Instance.GetService<EventQueue>()
                          .EnqueueEvent(new EventData(EventIds.Restart));
            await new StopBattleCommand().Execute();
            await new StartBattleCommand().Execute();
        }
    }
}
