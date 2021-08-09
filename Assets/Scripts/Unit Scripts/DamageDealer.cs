using UnityEngine;

namespace Unit_Scripts
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private Health _target;

        public void DealDamage() => _target.TakeDamage(_damage);
    }
}
