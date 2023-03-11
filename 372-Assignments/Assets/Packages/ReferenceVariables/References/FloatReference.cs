using System;
using UnityEngine;
using UnityEngine.Serialization;
namespace ReferenceVariables
{
    [Serializable]
    public class FloatReference
    {
        [SerializeField] private bool useConstant = true;
        [SerializeField] private float constantValue;
        [SerializeField] private FloatVariable variable;

        public FloatVariable Variable
        {
            get
            {
                return variable;
            }
        }
        public float Value
        {
            get
            {
                return useConstant ? constantValue : Variable.Value;
            }
            set
            {
                if (useConstant)
                {
                    constantValue = value;
                    return;
                }
                Variable.Value = value;
            }
        }

    }
}
