using System;
using DG.Tweening;
using UnityEngine;

namespace Unit_Scripts
{
    [RequireComponent(typeof(TargetFindSystem))]
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        
        private ITargetFinder _targetFinder;

        private void Start()
        {
            _targetFinder = GetComponent<TargetFindSystem>().GetTargetFinder();
        }

        public void DealDamage()
        {
            _targetFinder.GetTarget().GetComponent<Health>().TakeDamage(_damage);
            LookAtTarget();
        }

        private void LookAtTarget()
        {
            if(_targetFinder.GetTarget())transform.DORotate(
                Quaternion.LookRotation(_targetFinder.GetTarget().position - transform.position).eulerAngles, 1);
           
        }
    }
}
