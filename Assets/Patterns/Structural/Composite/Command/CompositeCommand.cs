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
            var tasks = new List<Task>(_commands.Count);
            foreach (var command in _commands)
            {
                var task = command.Execute();
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
