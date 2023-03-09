using UnityEngine;

namespace SOLID.Motors
{
    [RequireComponent(typeof(Rigidbody))]
    public class Motor : MonoBehaviour
    {
        [SerializeField] private MotorType motorType;

        private Rigidbody body;

        private const float Tolerance = 0.1f;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        // Move the vehicle
        public void ControlledMove(Vector3 direction)
        {
            var currentVelocity = body.velocity;
            if (currentVelocity.sqrMagnitude < motorType.MovementSpeed * motorType.MovementSpeed)
            {
                float multiplier = body.angularVelocity.sqrMagnitude / Mathf.Pow(motorType.AngularSpeed, 2);
                multiplier = Mathf.Clamp(multiplier, motorType.Drift, 1);
                Accelerate(direction, motorType.MovementSpeed);
                return;
            }
            DeAccelerate();
        }

        public void DeAccelerate()
        {
            var velocity = -body.velocity;
            if (velocity.sqrMagnitude > Tolerance)
            {
                Accelerate(velocity, motorType.MovementBrakes);
                return;
            }
            body.velocity = Vector3.zero;
        }

        private void Accelerate(Vector3 direction, float magnitude)
        {
            body.AddForce(direction.normalized * magnitude);
        }

        // Rotate the vehicle
        public void ControlledTurn(Vector3 direction, float forward)
        {
            var currentAngularVelocity = body.angularVelocity;
            if (forward != 0 && currentAngularVelocity.sqrMagnitude < Mathf.Pow(motorType.AngularSpeed, 2))
            {
                float multiplier = body.velocity.sqrMagnitude / Mathf.Pow(motorType.MovementSpeed, 2);
                multiplier = Mathf.Clamp(multiplier, motorType.Traction, motorType.Drift);
                AccelerateRotation(direction, motorType.AngularSpeed * multiplier);
                return;
            }
            DeAccelerateRotation();
        }

        public void DeAccelerateRotation()
        {
            var angularVelocity = body.angularVelocity;
            if (angularVelocity.sqrMagnitude > Tolerance)
            {
                AccelerateRotation(angularVelocity, -motorType.AngularBrakes);
                return;
            }
            body.angularVelocity = Vector3.zero;
        }

        private void AccelerateRotation(Vector3 direction, float magnitude)
        {
            body.AddTorque(direction.normalized * magnitude);
        }
    }
}
