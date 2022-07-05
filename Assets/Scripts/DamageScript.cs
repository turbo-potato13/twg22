using UnityEngine;

namespace DefaultNamespace
{
    public class DamageScript : MonoBehaviour
    {
        public float damageCount = 5;

        public FirstPersonDog firstPerson;

        private void OnTriggerEnter(Collider other)
        {
            firstPerson.putDamage(damageCount);
        }
    }
}