using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.Structural.Composite.Command
{
    public class CompositeCommand : Behaviour.Command.Command
    {
        private readonly List<Behaviour.Command.Command> _commands;

        public CompositeCommand()
        {
            _commands = new List<Behaviour.Command.Command>();
        }

        public void AddCommand(Behaviour.Command.Command command)
        {
            _commands.Add(command);
        }
        
        public async Task Execute()
        {
            //El await y quitar la lista de task fue mi solucion para poder usar este composite en el ejercicio propuesto aunque luego el profe decidio no usarlo. Ver LoadGameSceneCommand.cs
            var tasks = new List<Task>(_commands.Count);
            foreach (var command in _commands)
            {
                var task = /*await*/ command.Execute();
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
