using System;
using DG.Tweening;
using Unit_Scripts.Target_Finders;
using UnityEngine;
using Weapons_Scripts;

namespace Unit_Scripts
{
    [RequireComponent(typeof(TargetFindSystem))]
    public class WeaponUser : MonoBehaviour
    {
        private IWeapon _weapon;
        
        private ITargetFinder _targetFinder;

        private void Start()
        {
            _targetFinder = GetComponent<TargetFindSystem>().GetTargetFinder();
            _weapon = GetComponentInChildren<IWeapon>();
        }

        public void UseWeapon()
        {
            if (_targetFinder.GetTarget())
            {
                _weapon.Use(_targetFinder.GetTarget().GetComponent<Health>());
                LookAtTarget();
            }
        }

        private void LookAtTarget()
        {
            if(_targetFinder.GetTarget())transform.DORotate(
                Quaternion.LookRotation(_targetFinder.GetTarget().position - transform.position).eulerAngles, 1);
           
        }
    }
}
