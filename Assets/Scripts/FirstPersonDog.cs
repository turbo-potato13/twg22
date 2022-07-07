using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class FirstPersonDog : MonoBehaviour
    {
        public float currentHealth;
        public HealthBar healthBar;
        public float currentEnergy;
        public HealthBar energyBar;
        public Dictionary<String, Int32> items = new Dictionary<string, int>();
        public ItemCanvas itemCanvas;

        private void Start()
        {
            healthBar.SetMaxHealth(100f);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
            energyBar.SetMaxEnergy(100f);
            currentEnergy = 100;
            energyBar.SetEnergy(currentEnergy);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.I))
            {
                itemCanvas.setCount(items);
                itemCanvas.transform.gameObject.SetActive(true);
            }
            else
            {
                itemCanvas.transform.gameObject.SetActive(false);
            }
        }

        public void putDamage(float damage)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
        }

        public void putHealth(float health)
        {
            if (currentHealth < 100)
            {
                currentHealth += health;
                healthBar.SetHealth(currentHealth);
            }
        }

        public void putDischarge(float discharge)
        {
            if (currentEnergy > 0)
            {
                currentEnergy -= discharge;
                energyBar.SetEnergy(currentEnergy);
            }
            else
            {
                currentEnergy = 0;
            }
        }

        public void putCharge(float charge)
        {
            if (currentEnergy < 100)
            {
                currentEnergy += charge;
                energyBar.SetEnergy(currentEnergy);
            }
        }

        public void takeItem(String itemName)
        {
            int countItems;
            if (!items.TryGetValue(itemName, out countItems))
            {
                items.Add(itemName, 1);
            }
            else
            {
                countItems = items[itemName] + 1;
                items[itemName] = countItems;
            }
        }
    }
}