using InputManagement;
using UnityEngine;

namespace SOLID
{
    [RequireComponent(typeof(Motor))]
    public class UserDriver : Driver
    {
        [SerializeField] private BidirectionalFloat movementInput;

        private Motor motor;

        private void Awake()
        {
            motor = GetComponent<Motor>();
        }

        private void FixedUpdate()
        {
            Rotation();
            Movement();
        }

        private void Movement()
        {
            if (movementInput.Y != 0)
            {
                var direction = movementInput.Y * transform.forward;
                motor.ControlledMove(direction);
                return;
            }
            motor.DeAccelerate();
            //motor.Move(direction, movementSpeed);
        }

        private void Rotation()
        {
            if (movementInput.X != 0)
            {
                var direction = movementInput.X * transform.up;
                motor.ControlledTurn(direction, movementInput.Y);
                return;
            }
            motor.DeAccelerateRotation();
            //motor.Turn(direction, rotationSpeed);
        }
    }
}
