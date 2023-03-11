using System;
using System.Collections;
using UnityEngine;

namespace SOLID.Weapons
{
    public class SingleShotWeapon : Weapon
    {
        private void Awake()
        {
            input.ValueChanged += VariableOnValueChanged;
        }

        private void VariableOnValueChanged(object sender, EventArgs e)
        {
            UseWeapon();
        }
    }
}
