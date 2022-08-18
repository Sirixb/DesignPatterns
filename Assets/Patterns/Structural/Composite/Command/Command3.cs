using System.Threading.Tasks;
using UnityEngine;

namespace Patterns.Structural.Composite.Command
{
    public class Command3 : Behaviour.Command.Command
    {
        public async Task Execute()
        {
            await Task.Delay(100);
            Debug.Log("3");
        }
    }
}