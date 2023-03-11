using System.Collections;
using ReferenceVariables;
using UnityEngine;

namespace SOLID.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private FloatReference damageReference;
        [SerializeField] private LayerMask attackableLayers;

        private float damage;
        private bool active = false;
        
        private void Awake()
        {
            damage = damageReference.Value;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            active = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (attackableLayers == (attackableLayers | (1 << collision.gameObject.layer)))
            {
                collision.transform.gameObject.TryGetComponent<HealthManager>(out var healthManager);
                if (healthManager == null)
                    return;
                healthManager.ChangeHealth(-damage);
            }
            if (active)
                Destroy(gameObject);
        }
    }
}
