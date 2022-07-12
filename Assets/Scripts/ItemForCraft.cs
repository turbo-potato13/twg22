using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemForCraft : MonoBehaviour
    {
        public FirstPersonDog firstPerson;
        public Item.ItemType itemType;
        public int itemAmount = 1;

        private void Awake()
        {
            firstPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, firstPerson.transform.position);

            if (Input.GetKeyDown(KeyCode.E) && distance < 2)
            {
                Item item = new Item {itemType = itemType, amount = itemAmount};
                firstPerson.takeItem(item);
                Destroy(gameObject);
            }
        }
    }
}