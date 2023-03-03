using ReferenceVariables;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.PlayerLoop;
namespace InputManagement
{
    [CreateAssetMenu(fileName = "Bidirectional Float", menuName = "Variable Groups/Bidirectional Float")]
    public class BidirectionalFloat : ScriptableObject
    {

        [SerializeField] private FloatReference up;
        [SerializeField] private FloatReference down;
        [SerializeField] private FloatReference left;
        [SerializeField] private FloatReference right;

        public FloatReference Up
        {
            get
            {
                return up;
            }
        }
        public FloatReference Down
        {
            get
            {
                return down;
            }
        }
        public FloatReference Left
        {
            get
            {
                return left;
            }
        }
        public FloatReference Right
        {
            get
            {
                return right;
            }
        }
        public float Magnitude
        {
            get
            {
                Vector2 vector = new(Right.Value - Left.Value, Up.Value - Down.Value);
                return vector.magnitude;
            }
        }
        public float Y
        {
            get
            {
                return Up.Value - Down.Value;
            }
        }
        public float X
        {
            get
            {
                return Right.Value - Left.Value;
            }
        }
    }
}
