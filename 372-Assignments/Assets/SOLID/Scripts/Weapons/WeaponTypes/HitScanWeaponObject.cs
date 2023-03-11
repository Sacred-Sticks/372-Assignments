using System;
using ReferenceVariables;
using UnityEngine;
using UnityEngine.Serialization;

namespace SOLID.Weapons.WeaponTypes
{
    [CreateAssetMenu(fileName = "Hit Scan Weapon", menuName = "Weapons/Hit Scan Weapon")]
    public class HitScanWeaponObject : WeaponObject
    {
        [SerializeField] private FloatReference damageValue;
        [SerializeField] private float range;
        [SerializeField] private LayerMask attackableLayers;

        private float damage;

        private void Awake()
        {
            damage = damageValue.Value;
        }

        public override void Fire(Transform transform)
        {
            if (!UnityEngine.Physics.Raycast(origin: transform.position, direction: transform.forward, maxDistance: range, layerMask: attackableLayers, hitInfo: out var hitInfo))
                return;
            hitInfo.transform.gameObject.TryGetComponent<HealthManager>(out var healthManager);
            healthManager.ChangeHealth(-damage);
        }
    }
}
