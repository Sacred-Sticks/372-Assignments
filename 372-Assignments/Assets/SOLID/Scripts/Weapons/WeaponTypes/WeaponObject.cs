using UnityEngine;

namespace SOLID.Weapons.WeaponTypes
{
    public abstract class WeaponObject : ScriptableObject
    {
        public float Cooldown
        {
            get
            {
                return cooldown;
            }
        }
        [SerializeField] protected float cooldown;

        public abstract void Fire(Transform transform);
    }
}
