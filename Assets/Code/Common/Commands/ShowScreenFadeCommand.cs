using Common.Utils;
using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UI;

namespace Common.Commands
{
    public class ShowScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Show();
            await TaskUtils.Delay(200);
        }
    }
}
