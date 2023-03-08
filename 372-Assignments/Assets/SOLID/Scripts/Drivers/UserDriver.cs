using InputManagement;
using UnityEngine;
namespace SOLID.Drivers
{
    [RequireComponent(typeof(Motor))]
    public class UserDriver : Driver
    {
        [SerializeField] private BidirectionalFloat movementInput;

        private void FixedUpdate()
        {
            float xIn = movementInput.X;
            float yIn = movementInput.Y;
            Rotation(xIn, yIn);
            Movement(yIn);
        }
    }
}
