using Ships;
using UnityEngine;

namespace Input
{
    public class AIInputAdapter : Input
    {
        private readonly ShipMediator _ship;
        private float _currentDirectionX;

        public AIInputAdapter(ShipMediator ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
        }

        public Vector2 GetDirection()
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
            if (viewportPoint.x < 0.05f)
            {
                _currentDirectionX = _ship.transform.right.x;
            }
            else if (viewportPoint.x > 0.95f)
            {
                _currentDirectionX = -_ship.transform.right.x;
            }

            return new Vector2(_currentDirectionX, +1);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}
