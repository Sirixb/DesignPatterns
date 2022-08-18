using UnityEngine;

namespace Patterns.Structural.Composite.Command
{
    public class Consumer : MonoBehaviour
    {
        private async void Awake()
        {
            Debug.Log("Start");
            var compositeCommand = new CompositeCommand();
            compositeCommand.AddCommand(new Command1());
            compositeCommand.AddCommand(new Command2());
            compositeCommand.AddCommand(new Command3());
            await compositeCommand.Execute();
            Debug.Log("End");
        }
    }
}
