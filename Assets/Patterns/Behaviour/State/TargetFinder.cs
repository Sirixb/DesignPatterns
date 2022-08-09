using System.Collections.Generic;

namespace Patterns.Behaviour.State
{
    public interface TargetFinder
    {
        IEnumerable<Enemy> FindTargets();
    }
}
