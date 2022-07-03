using UnityEngine;

namespace DefaultNamespace
{
    public class FirstPersonDog : MonoBehaviour
    {
        public float currentHealth;
        public HealthBar healthBar;
        public float currentEnergy;
        public HealthBar energyBar;

        private void Start()
        {
            healthBar.SetMaxHealth(100f);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
            energyBar.SetMaxEnergy(100f);
            currentEnergy = 100;
            energyBar.SetEnergy(currentEnergy);
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
                energyBar.SetEnergy(charge);
            }
        }
    }
}