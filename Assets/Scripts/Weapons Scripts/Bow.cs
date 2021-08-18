using Unit_Scripts;
using UnityEngine;

namespace Weapons_Scripts
{
    public class Bow : MonoBehaviour, IWeapon
    {
        [SerializeField] protected Transform _shootPoint;
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] protected Vector3 _targetPositionFallacy;
        [SerializeField] protected float _arrowFlyTime = 2;
        
        public void Use(Health targetHealth)
        {
            Rigidbody arrow = Instantiate(_arrowPrefab, _shootPoint.position, _shootPoint.rotation)
                .GetComponent<Rigidbody>();
            arrow.velocity = CalculateArrowVelocity(targetHealth);
            _shootPoint.LookAt(targetHealth.transform.position + _targetPositionFallacy);
        }
        

        protected virtual Vector3 CalculateArrowVelocity(Health target)
        {
            if(target != null)
            {
                Vector3 velocity = (target.transform.position - _shootPoint.position + _targetPositionFallacy - 
                                    (Physics.gravity * _arrowFlyTime * _arrowFlyTime) / 2) / _arrowFlyTime;
                return velocity;
            }
            return Vector3.zero;
        
        }
    }
}