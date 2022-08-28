using UnityEngine;

namespace Common.Utils
{
    public class DestroyIn : MonoBehaviour
    {
        [SerializeField] private float _delay = 2f;

        private void Awake()
        {
            Destroy(gameObject, _delay);
        }
    }
}
