using Unit_Scripts;
using UnityEngine;

namespace Weapons_Scripts
{
    public class Sword : MonoBehaviour, IWeapon
    {
        public int Damage = 1;

        public void Use(Health targetHealth)
        {
            targetHealth.TakeDamage(Damage);
        }
    }
}
