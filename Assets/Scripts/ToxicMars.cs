using DefaultNamespace;
using UnityEngine;

public class ToxicMars : MonoBehaviour
{
    public FirstPersonDog firstDog;

    private void OnTriggerEnter(Collider other)
    {
        CancelInvoke("takeHealth");
        InvokeRepeating("takeDamage", .5f, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("takeDamage");
        InvokeRepeating("takeHealth", .5f, 0.3f);
    }

    private void takeDamage()
    {
        firstDog.putDamage(0.833f);
    }

    private void takeHealth()
    {
        firstDog.putHealth(1f);
    }
}