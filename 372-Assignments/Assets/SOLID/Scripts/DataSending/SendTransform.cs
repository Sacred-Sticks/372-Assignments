using System;
using UnityEngine;

namespace SOLID.DataSending
{
    public class SendTransform : Sender
    {
        private void Start()
        {
            var args = new TransformData(transform);
            eventTarget.CallChainedEvent(this, args);
        }
    }
    public class TransformData : EventArgs
    {
        public Transform TransformObj
        {
            get;
            private set;
        }

        public TransformData(Transform transformObj)
        {
            TransformObj = transformObj;
        }
    }
}
