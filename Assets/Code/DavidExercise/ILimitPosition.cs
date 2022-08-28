using UnityEngine;
namespace pruebasDavid { 
public interface ILimitPosition
{
    Vector2 CheckLimit(Transform transform);
}
public class IALimitsAdapter : ILimitPosition

{
    //private int _currentDirectionX= 1;

    public Vector2 CheckLimit(Transform transform)
    {
        //var viewportPoint = Camera.main.WorldToViewportPoint(transform.position);
        //if (viewportPoint.x < 0.05f)
        //{
        //    _currentDirectionX = 1;
        //}
        //else if (viewportPoint.x > 0.95f)
        //{
        //    _currentDirectionX = -1;
        //}
        var viewPortPoint = Camera.main.WorldToViewportPoint(transform.position);
        viewPortPoint.x = Mathf.Clamp(viewPortPoint.x, 0.1f, 0.5f);
        viewPortPoint.y = Mathf.Clamp(viewPortPoint.y, 0.1f, 0.5f);


        return transform.position = Camera.main.ViewportToWorldPoint(viewPortPoint);
    }
}
public class UserLimitsAdapter :  ILimitPosition

{
    public Vector2 CheckLimit(Transform transform)
    {
        var viewPortPoint = Camera.main.WorldToViewportPoint(transform.position);
        viewPortPoint.x = Mathf.Clamp(viewPortPoint.x, 0.03f, 0.97f);
        viewPortPoint.y = Mathf.Clamp(viewPortPoint.y, 0.03f, 0.97f);
        return transform.position = Camera.main.ViewportToWorldPoint(viewPortPoint);
    }
}
}