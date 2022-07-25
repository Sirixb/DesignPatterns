using UnityEngine;

namespace Ships.CheckLimits
{
    public interface CheckLimits
    {
        Vector2 ClampFinalPosition(Vector2 currentPosition);
    }
}

