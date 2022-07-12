using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageScript : MonoBehaviour
    {
        public float damageCount = 5;

        public FirstPersonDog firstPerson;

        private void Awake()
        {
            if (firstPerson == null)
            {
                firstPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                firstPerson.putDamage(damageCount);
            }
        }
    }
}