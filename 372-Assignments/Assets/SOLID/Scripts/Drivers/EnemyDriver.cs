using System;
using SOLID.DataSending;
using SOLID.Events;
using SOLID.Motors;
using UnityEngine;

namespace SOLID.Drivers
{
    [RequireComponent(typeof(Motor))]
    public class EnemyDriver : Driver
    {
        [SerializeField] private EventLinker eventReceiver;

        private Transform target;

        private new void Awake()
        {
            base.Awake();
            eventReceiver.ChainedEvent += OnChainedEventCalled;
            target = transform;
        }

        private void OnChainedEventCalled(object sender, EventArgs e)
        {
            if (e is not TransformData transformData)
                return;
            target = transformData.TransformObj;
        }

        private void FixedUpdate()
        {
            var difference = target.position - transform.position;
            float right = Vector3.Dot(difference, transform.right) / 90; 
            float forward = Vector3.Dot(difference, transform.forward) / 90;
            Rotation(right, forward);
            Movement(forward);
        }
    }
}
