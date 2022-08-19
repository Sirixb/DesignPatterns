using System.Threading.Tasks;
using Patterns.Behaviour.Command;
using Patterns.Structural.Composite.Command;
using UnityEngine;

namespace Common.Commands
{
    public class LoadGameSceneCommand : Command
    {
        public async Task Execute()
        {
            await new LoadSceneCommand("Game").Execute();
            await new StartBattleCommand().Execute();

            //Mi solucion modificando el composite para que no haga las llamadas todas al tiempo
            //var compositeCommand = new CompositeCommand();
            //compositeCommand.AddCommand(new LoadSceneCommand("Game"));
            //compositeCommand.AddCommand(new StartBattleCommand());
            //await compositeCommand.Execute();
            //Debug.Log("Successful");
        }
    }
}
