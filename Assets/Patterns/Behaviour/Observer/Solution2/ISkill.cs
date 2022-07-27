using System;

namespace Patterns.Behaviour.Observer.Solution2
{
    public interface ISkill
    {
        event Action<int> OnChargesUpdated;
        event Action<bool> OnIsReadyUpdated;

        void Use();
    }
}
