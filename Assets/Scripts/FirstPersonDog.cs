using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace DefaultNamespace
{
    public class FirstPersonDog : MonoBehaviour
    {
        public float currentHealth;
        public HealthBar healthBar;
        public float currentEnergy;
        public HealthBar energyBar;
        public Dictionary<Item.ItemType, Int32> inventory;
        public TMP_Text helpText;
        public GameObject Gun;
        public GameObject Muzzle;
        public TMP_Text TaskText;

        private void Start()
        {
            inventory = new Dictionary<Item.ItemType, int>();
            helpText.text = "";
            healthBar.SetMaxHealth(100f);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
            energyBar.SetMaxEnergy(100f);
            currentEnergy = 100;
            energyBar.SetEnergy(currentEnergy);
        }

        private void Update()
        {
            if (currentHealth < 1 || transform.position.y < -170)
            {
                gameObject.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");
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

        public void takeItem(Item item)
        {
            int countItems;
            if (!inventory.TryGetValue(item.itemType, out countItems))
            {
                inventory.Add(item.itemType, 1);
            }
            else
            {
                countItems = inventory[item.itemType] + 1;
                inventory[item.itemType] = countItems;
            }

            checkSuccessGame();
        }

        public bool tryGetItem(Item item)
        {
            int countItems;
            return inventory.TryGetValue(item.itemType, out countItems);
        }

        public void removeItem(Item item)
        {
            int countItems;
            if (!inventory.TryGetValue(item.itemType, out countItems))
            {
                inventory.Add(item.itemType, 0);
            }
            else
            {
                countItems = inventory[item.itemType] - 1;
                inventory[item.itemType] = countItems;
            }
        }

        public void activateGun()
        {
            Gun.SetActive(true);
            Muzzle.SetActive(true);
        }

        public void checkSuccessGame()
        {
            int countGun;
            int countFilter;
            int countSunPanel;
            int countGarden;
            inventory.TryGetValue(Item.ItemType.Gun, out countGun);
            inventory.TryGetValue(Item.ItemType.Filter, out countFilter);
            inventory.TryGetValue(Item.ItemType.SunPanel, out countSunPanel);
            inventory.TryGetValue(Item.ItemType.Garden, out countGarden);
            bool gun = countGun >= 1;
            bool filter = countFilter >= 5;
            bool sunPanel = countSunPanel >= 4;
            bool Garden = countGarden >= 1;
            if (gun && filter && sunPanel && Garden)
            {
                SceneManager.LoadScene("GameOk");
            }
        }
    }
}