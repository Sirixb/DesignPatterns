using UnityEngine;

namespace Ships
{
    public class DoNotCheckDestroyLimitsStrategy : CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            return true;
        }
    }
}
