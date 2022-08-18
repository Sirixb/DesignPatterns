using System;
using UnityEngine;

namespace Patterns.Structural.Composite
{
    public class Consumer : MonoBehaviour
    {
        private void Awake()
        {
            var directory1 = new Directory("Directory 1");
            directory1.Add(new FileImpl("File 1"));
            directory1.Add(new FileImpl("File 2"));
            var directory2 = new Directory("Directory 2");
            directory1.Add(directory2);
            directory2.Add(new FileImpl("File 3"));
            
            var directory3 = new Directory("Directory 3");
            directory1.Add(directory3);
            directory3.Add(new FileImpl("File 4"));
            
            var directory4 = new Directory("Directory 4");
            directory3.Add(directory4);
            directory4.Add(new FileImpl("File 5"));
            
            Print(directory1);
        }

        private static void Print(File root)
        {
            Debug.Log(root.Print(0));
        }
    }
}
