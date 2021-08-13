using Unit_Scripts;
using UnityEngine;

namespace Weapons_Scripts
{
    public class Bow : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private float _shootAngle = 10;
        [SerializeField] private Vector3 _targetPositionFallacy;
        [SerializeField] private float _arrowFlyTime = 2;
        
        public void Use(Health targetHealth)
        {
            _shootPoint.localRotation = Quaternion.Euler(Vector3.up * _shootAngle);
            
            Rigidbody arrow = Instantiate(_arrowPrefab, _shootPoint.position, _shootPoint.rotation)
                .GetComponent<Rigidbody>();
            arrow.velocity = CalculateArrowVelocity(targetHealth);
            _shootPoint.LookAt(targetHealth.transform.position + _targetPositionFallacy);
        }
        

        private Vector3 CalculateArrowVelocity(Health target)
        {
            if(target != null)
            {
                Vector3 velocity = (target.transform.position - _shootPoint.position + _targetPositionFallacy - 
                                    (Physics.gravity * _arrowFlyTime * _arrowFlyTime) / 2) / _arrowFlyTime;
                return velocity;
            }
            Debug.LogError($"Target of {gameObject.name} is null");
            return Vector3.zero;
        
        }
    }
}