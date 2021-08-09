using Unit_Scripts.Unit_State_Machine;
using UnityEngine;

namespace Unit_Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        private Animator _animator;
        private int _dieToHash;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _dieToHash = Animator.StringToHash("Die");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if(_health <= 0) GetComponent<IUnitsStateSwitcher>().SwitchState<DyingState>();
        }

        public void Die() => Destroy(gameObject);
    }
}
