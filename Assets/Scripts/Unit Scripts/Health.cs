using System;
using Unit_Scripts.Unit_State_Machine;
using UnityEngine;
using Zenject;

namespace Unit_Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        [Inject] private UnitsLists _unitsLists;
        private ParticleSystem _bloodVFX;

        private void Awake()
        {
            _bloodVFX = GetComponentInChildren<ParticleSystem>();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            _bloodVFX.Play();
            if (_health <= 0)
            {
                _unitsLists.PlayerUnits.Remove(gameObject);
                _unitsLists.EnemyUnits.Remove(gameObject);
                GetComponent<IUnitsStateSwitcher>().SwitchState<DyingState>();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
