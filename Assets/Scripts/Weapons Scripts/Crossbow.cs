using Unit_Scripts;
using UnityEngine;

namespace Weapons_Scripts
{
    public class Crossbow : Bow
    {
        protected override Vector3 CalculateArrowVelocity(Health target)
        {
            if (target != null)
            {
                return 2 * (target.transform.position - transform.position + _targetPositionFallacy) / _arrowFlyTime;
            }

            return Vector3.zero;
        }
    
    }
}
