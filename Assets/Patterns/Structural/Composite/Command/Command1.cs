using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Structural.Composite.Command
{
    public class Command1 : Behaviour.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(200);
            Debug.Log("1");
        }
    }
}