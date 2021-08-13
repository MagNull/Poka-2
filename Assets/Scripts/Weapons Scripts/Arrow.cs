using Unit_Scripts;
using UnityEngine;

namespace Weapons_Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Arrow : MonoBehaviour // TODO: Refactor to object pool of arrow
    {
        public int Damage = 1;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Health health)) health.TakeDamage(Damage);
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}