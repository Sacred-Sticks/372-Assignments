using System.Runtime.CompilerServices;
using UnityEngine;
using ReferenceVariables;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Motor", menuName = "Motor")]
public class MotorType : ScriptableObject
    {
        [SerializeField] private FloatReference movementSpeed;
        [SerializeField] private FloatReference movementBrakes;
        [SerializeField] private FloatReference angularSpeed;
        [SerializeField] private FloatReference angularBrakes;
        [Range(0, 1)] 
        [SerializeField] private float driftStrength;
        [Range(0, 1)]
        [SerializeField] private float traction;

        public float MovementSpeed
        {
            get
            {
                return movementSpeed.Value;
            }
        }
        public float MovementBrakes
        {
            get
            {
                return movementBrakes.Value;
            }
        }
        public float AngularSpeed
        {
            get
            {
                return angularSpeed.Value;
            }
        }
        public float AngularBrakes
        {
            get
            {
                return angularBrakes.Value;
            }
        }
        public float Drift
        {
            get
            {
                return driftStrength;
            }
        }
        public float Traction
        {
            get
            {
                return traction;
            }
        }
    }