using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider energySlider;

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetEnergy(float energy)
    {
        energySlider.value = energy;
    }

    public void SetMaxEnergy(float energy)
    {
        energySlider.maxValue = energy;
        energySlider.value = energy;
    }
}