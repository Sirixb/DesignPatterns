using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Weapons/Create ProjectileId", fileName = "ProjectileId", order = 0)]             
    public class ProjectileId: ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}
