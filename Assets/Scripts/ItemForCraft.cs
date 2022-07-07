using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemForCraft : MonoBehaviour
    {
        public FirstPersonDog firstPerson;
        public String itemName;

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, firstPerson.transform.position);

            if (Input.GetKeyDown(KeyCode.E) && distance < 2)
            {
                firstPerson.takeItem(itemName);
                Destroy(gameObject);
            }
        }
    }
}