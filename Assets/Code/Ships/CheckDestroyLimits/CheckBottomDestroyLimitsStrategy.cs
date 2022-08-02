using UnityEngine;

namespace Ships
{
    public class CheckBottomDestroyLimitsStrategy : CheckDestroyLimits
    {
        private readonly Camera _camera;

        public CheckBottomDestroyLimitsStrategy(Camera camera)
        {
            _camera = camera;
        }

        public bool IsInsideTheLimits(Vector3 position)
        {
            var viewportPoint = _camera.WorldToViewportPoint(position);
            return viewportPoint.y > 0;
        }
    }
}
