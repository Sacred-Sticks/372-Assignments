using UnityEngine;

namespace SOLID.Weapons.WeaponTypes
{
    [CreateAssetMenu(fileName = "Projectile Weapon", menuName = "Weapons/Projectile Weapon")]
    public class ProjectileWeaponObject : WeaponObject
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Vector3 firePositionOffset;
        
        public override void Fire(Transform transform)
        {
            var offset = firePositionOffset.x * transform.right + 
                         firePositionOffset.y * transform.up + 
                         firePositionOffset.z * transform.forward;
            var position = transform.position + offset;
            Instantiate(original: projectilePrefab, position: position, rotation: transform.rotation);
        }
    }
}
