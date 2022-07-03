using DefaultNamespace;
using UnityEngine;

public class ToxicMars : MonoBehaviour
{
    public FirstPersonDog firstDog;

    //При заходе в триггер будет прекращать вызываться функция хила, и через 0.5 сек начнет вызываться функция takeDamage каждую секунду
    //Для здоровья аналогично
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

    //Время нахождения на Марсе можно высчитывать по формуле t * d = 100, где t время которое за которое разряжается, d - дамаг который нужен для этого
    //0.833f - дамаг для нахождения 3мин, 1.66f - 2мин
    private void takeDamage()
    {
        firstDog.putDischarge(0.833f);
        if (firstDog.currentEnergy < 1)
        {
            firstDog.putDamage(1.66f);
        }
    }

    private void takeHealth()
    {
        firstDog.putHealth(1f);
        firstDog.putCharge(2f);
    }
}