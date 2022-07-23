using UnityEngine;

namespace Ships.CheckLimits
{
    public class ViewportCheckLimits :CheckLimits
    {      
        private readonly Transform _Transform;
        private readonly Camera _camera;

        public ViewportCheckLimits(Transform transform, Camera camera)
        {
            _Transform = transform;
            _camera = camera;
        }
        void CheckLimits.ClampFinalPosition()
        {
            var viewPortPoint = _camera.WorldToViewportPoint(_Transform.position);
            viewPortPoint.x = Mathf.Clamp(viewPortPoint.x, 0.03f, 0.97f);
            viewPortPoint.y = Mathf.Clamp(viewPortPoint.y, 0.03f, 0.97f);
            _Transform.position = _camera.ViewportToWorldPoint(viewPortPoint);
        }
    }

}
