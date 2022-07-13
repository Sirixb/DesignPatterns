using UnityEngine;

namespace Ships
{
    public class InitialPositionCheckLimits : CheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private float _maxDistance;

        public InitialPositionCheckLimits(Transform transform,float maxDistance)
        {
            _transform = transform;
            _initialPosition = _transform.position;
            _maxDistance = maxDistance;
        }
        
        public void ClampFinalPosition()
        {
            var currentPosition = _transform.position;
            var finalPositionX = currentPosition;
            var distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            
            if (distance <= _maxDistance)
            {
                return;
            }

            if (currentPosition.x > _initialPosition.x)
            {
                finalPositionX.x = _initialPosition.x + _maxDistance;
            }
            else
            {
                finalPositionX.x = _initialPosition.x - _maxDistance;
            }
            _transform.position = finalPositionX;
        }
    }

}
