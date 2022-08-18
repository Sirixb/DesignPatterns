using UnityEngine;

namespace Patterns.Structural.Composite
{
    public interface File
    {
        bool IsDirectory { get; }
        void Add(File file);
        void Remove(File file);
        string Print(int level);
    }
}
