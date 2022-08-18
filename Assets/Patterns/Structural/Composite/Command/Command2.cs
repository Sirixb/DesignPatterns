using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Structural.Composite.Command
{
    public class Command2 : Behaviour.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(300);
            Debug.Log("2");
        }
    }
}