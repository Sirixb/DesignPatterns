using System.Threading.Tasks;
using UnityEngine;

namespace Common.Utils
{
    public static class TaskUtils
    {
        // En PC usa Task.Delay (comportamiento original). En WebGL no hay hilos ni timers,
        // asi que Task.Delay nunca se completa: se espera frame a frame con Task.Yield.
        public static async Task Delay(int milliseconds)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            var endTime = Time.realtimeSinceStartup + milliseconds / 1000f;
            while (Time.realtimeSinceStartup < endTime)
            {
                await Task.Yield();
            }
#else
            await Task.Delay(milliseconds);
#endif
        }
    }
}
