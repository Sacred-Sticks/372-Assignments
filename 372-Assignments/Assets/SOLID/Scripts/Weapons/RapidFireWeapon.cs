using System;
using UnityEngine;

namespace SOLID.Weapons
{
    public class RapidFireWeapon : Weapon
    {
        private void Update()
        {
            if (Math.Abs(input.Value - 1) > TOLERANCE)
                return;
            if (!canFire)
                return;
            UseWeapon();
        }
    }
}
