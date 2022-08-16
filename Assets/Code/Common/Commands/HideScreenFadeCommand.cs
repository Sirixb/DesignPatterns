using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UI;

namespace Common.Commands
{
    public class HideScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Hide();
            await Task.Delay(200);
        }
    }
}