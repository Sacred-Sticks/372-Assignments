using ReferenceVariables;
using UnityEngine;

namespace SOLID
{
    public class HealthManager : MonoBehaviour
    {
        public float Health
        {
            get
            {
                return health.Value;
            }
            private set
            {
                health.Value = value;
                if (health.Value <= 0)
                    Destroy(gameObject);
            }
        }
        [SerializeField] private FloatReference health;

        public void ChangeHealth(float modification)
        {
            Health += modification;
        }
    }
}
