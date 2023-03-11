using UnityEngine;
using System;

namespace ReferenceVariables
{
    public class GenericVariable<TDataType> : GenericVariable
    {
        [SerializeField] private TDataType value;
        [SerializeField] private bool resetValue;
        [ConditionalHide("resetValue", true)]
        [SerializeField] private TDataType initialValue;

        public delegate void EventDelegate(object sender, EventArgs e);

        public event EventDelegate ValueChanged;
        
        public TDataType Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnEnable()
        {
            if (resetValue)
                value = initialValue;
        }

    }

    public class GenericVariable : ScriptableObject
    {

    }
}