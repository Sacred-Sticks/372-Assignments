using System;
using UnityEngine;
namespace SOLID.Drivers
{
    [RequireComponent(typeof(Motor))]
    public abstract class Driver : MonoBehaviour
    {
        private Motor motor;
        
        protected void Awake()
        {
            motor = GetComponent<Motor>();
        }

        protected void Movement(float forwardMoveDirection)
        {
            if (forwardMoveDirection != 0)
            {
                var direction = forwardMoveDirection * transform.forward;
                motor.ControlledMove(direction);
                return;
            }
            motor.DeAccelerate();
            //motor.Move(direction, movementSpeed);
        }
        
        protected void Rotation(float rotationPercentage, float forwardMoveDirection)
        {
            if (rotationPercentage != 0)
            {
                var direction = rotationPercentage * transform.up;
                motor.ControlledTurn(direction, forwardMoveDirection);
                return;
            }
            motor.DeAccelerateRotation();
        }
    }
}
