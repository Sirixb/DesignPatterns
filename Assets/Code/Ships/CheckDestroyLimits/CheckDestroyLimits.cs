using UnityEngine;

namespace Ships
{
    public interface CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position);
    }
}
