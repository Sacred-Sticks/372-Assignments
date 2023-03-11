using System;
using System.Collections;
using ReferenceVariables;
using SOLID.Weapons.WeaponTypes;
using UnityEngine;

namespace SOLID.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected FloatVariable input;
        [SerializeField] protected WeaponObject weapon;
        
        protected bool canFire = true;

        protected const double TOLERANCE = 0.01;

        protected IEnumerator FireWeapon()
        {
            weapon.Fire(transform);
            canFire = false;
            yield return new WaitForSeconds(weapon.Cooldown);
            canFire = true;
        }

        protected void UseWeapon()
        {

            if (Math.Abs(input.Value - 1) > TOLERANCE)
                return;
            if (!canFire)
                return;
            StartCoroutine(FireWeapon());
        }
    }
}
