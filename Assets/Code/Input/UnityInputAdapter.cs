using UnityEngine;

namespace Input
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            var horizonalDir = UnityEngine.Input.GetAxis("Horizontal");
            var verticalDir = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizonalDir, verticalDir);
        }

        public bool IsFireActionPressed()
        {
            return UnityEngine.Input.GetButton("Fire1");
        }
    }
}