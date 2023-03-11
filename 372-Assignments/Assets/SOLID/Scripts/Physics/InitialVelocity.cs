using System;
using UnityEngine;

namespace SOLID.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class InitialVelocity : MonoBehaviour
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        private Rigidbody body;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            direction = direction.normalized;
            var velocity = (direction.x * transform.right +
                            direction.y * transform.up +
                            direction.z * transform.forward) * speed;
            body.velocity = velocity;
        }
    }
}
