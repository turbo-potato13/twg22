using UnityEngine;

namespace DefaultNamespace
{
    public class FirstPersonDog : MonoBehaviour
    {
        public float currentHealth;
        public HealthBar healthBar;

        private void Start()
        {
            healthBar.SetMaxHealth(100f);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }

        public void putDamage(float damage)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
        }

        public void putHealth(float damage)
        {
            if (currentHealth < 100)
            {
                currentHealth += damage;
                healthBar.SetHealth(currentHealth);
            }
        }
    }
}