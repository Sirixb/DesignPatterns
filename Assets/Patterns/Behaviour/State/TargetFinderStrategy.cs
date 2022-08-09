using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Behaviour.State
{
    public class TargetFinderStrategy : TargetFinder
    {
        public IEnumerable<Enemy> FindTargets()
        {
            return Object.FindObjectsOfType<Enemy>();
        }
    }
}
